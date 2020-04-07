using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Soccer.Common.Models;
using Soccer.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TravelBills.Common.Helpers;
using TravelBills.Common.Models;
using TravelBills.Prism.Helpers;
using Xamarin.Forms;

namespace TravelBills.Prism.ViewModels
{
    public class TripDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly IFilesHelper _filesHelper;
        private bool _isRunning;
        private bool _isEnabled;
        private TripExpenseTypeResponse _tripexpensetype;
        private ObservableCollection<TripExpenseTypeResponse> _tripexpensetypes;
        private TripDetailRequest _tripDetail;
        private TripResponse _trip;
        private ImageSource _image;
        private MediaFile _file;
        private DelegateCommand _changeImageCommand;
        private DelegateCommand _saveCommand;

        public TripDetailPageViewModel(INavigationService navigationService, IApiService apiService, IFilesHelper filesHelper) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _filesHelper = filesHelper;
            Image = App.Current.Resources["UrlNoImage"].ToString();
            IsEnabled = true;
            TripDetail = new TripDetailRequest();
            todayDate = DateTime.Now;
            Time = DateTime.Now.TimeOfDay;
            LoadTripExpenseTypeAsync();
        }
        public TimeSpan Time { get; set; }

        public DateTime Date { get; set; }

        public DateTime todayDate { get; set; }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAsync));

        public DelegateCommand ChangeImageCommand => _changeImageCommand ?? (_changeImageCommand = new DelegateCommand(ChangeImageAsync));
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public TripDetailRequest TripDetail
        {
            get => _tripDetail;
            set => SetProperty(ref _tripDetail, value);
        }
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }
        public TripExpenseTypeResponse TripExpenseType
        {
            get => _tripexpensetype;
            set => SetProperty(ref _tripexpensetype, value);
        }


        public ObservableCollection<TripExpenseTypeResponse> TripExpenseTypes
        {
            get => _tripexpensetypes;
            set => SetProperty(ref _tripexpensetypes, value);
        }
        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
        public override void OnNavigatedTo(INavigationParameters parameters) {
             base.OnNavigatedTo(parameters);
            _trip = parameters.GetValue<TripResponse>("trip"); Title = _trip.TripType.Type; 
        }
        private async void SaveAsync()
        {
            var isValid = await ValidateDataAsync();
            if (!isValid)
            {
                return;
            }

            IsRunning = true;
            IsEnabled = false;
            string url = App.Current.Resources["UrlAPI"].ToString();

            byte[] imageArray = null;

            if (_file != null)
            {
                imageArray = _filesHelper.ReadFully(_file.GetStream());
            }

            TripDetail.StartDate = Date + Time;
            TripDetail.PictureArray = imageArray;
            TripDetail.TripId = _trip.Id;
            TripDetail.TripExpenseTypeId = TripExpenseType.Id;
            TripDetail.CultureInfo = Languages.Culture;

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            Response response = await _apiService.NewTripDetailAsync(url, "/api", "/TripDetail", TripDetail, "bearer", token.Token);
            IsRunning = false;
            IsEnabled = true;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            await App.Current.MainPage.DisplayAlert(Languages.OK, response.Message, Languages.Accept);
            await _navigationService.GoBackAsync();
        }
            private async Task<bool> ValidateDataAsync()
        {
            if (Image.ToString().Contains("/images/noimage.png"))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Please upload an image of the expense type!", Languages.Accept);
                return false;
            }
            if (string.IsNullOrEmpty(TripDetail.BillValue.ToString()) || TripDetail.BillValue == 0)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Please enter the bill value", Languages.Accept);
                return false;
            }else if (TripDetail.BillValue <= 0)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Please enter a valid the bill value", Languages.Accept);
                return false;
            }

            if (TripExpenseType == null)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "Please select the trip expense type", Languages.Accept);
                return false;
            }

            return true;
        }
        private async void ChangeImageAsync()
        {
            await CrossMedia.Current.Initialize();

            string source = await Application.Current.MainPage.DisplayActionSheet(
               Languages.PictureSource,
                Languages.Cancel,
                null,
                Languages.FromGallery,
                Languages.FromCamera);

            if (source == Languages.Cancel)
            {
                _file = null;
                return;
            }

            try
            {
                if (source == Languages.FromCamera)
                {
                    _file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );
                }
                else
                {
                    _file = await CrossMedia.Current.PickPhotoAsync();
                }
            }
            catch (System.Exception)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, "You need to give the application permissions to select the image, try again!", Languages.Accept);
                return;
            }


            if (_file != null)
            {
                Image = ImageSource.FromStream(() =>
                {
                    System.IO.Stream stream = _file.GetStream();
                    return stream;
                });
            }
        }
        private async void LoadTripExpenseTypeAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
           

            IsRunning = true;
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            Response response = await _apiService.GetListAsync<TripExpenseTypeResponse>(url, "/api", "/TripExpenseTypes", "bearer", token.Token);

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            List<TripExpenseTypeResponse> list = (List<TripExpenseTypeResponse>)response.Result;
            TripExpenseTypes = new ObservableCollection<TripExpenseTypeResponse>(list.OrderBy(t => t.Type));
            IsRunning = false;
        }
    }
}

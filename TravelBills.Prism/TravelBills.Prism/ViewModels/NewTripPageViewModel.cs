using Newtonsoft.Json;
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

namespace TravelBills.Prism.ViewModels
{
    public class NewTripPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private TripTypeResponse _triptype;
        private ObservableCollection<TripTypeResponse> _tripstypes;
        private UserResponse _user;
        private TripRequest _trip;
        private bool _isRunning;
        private bool _isEnabled;
        private DelegateCommand _saveCommand;
        public NewTripPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            Title = Languages.NewTripPage;
            IsEnabled = true;
            Trip = new TripRequest();
            LoadCitiesAsync();
            LoadUser();
            todayDate = DateTime.Now;
        }

        public DelegateCommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveAsync));

        public DateTime todayDate { get; set; }
        public TripTypeResponse TripType
        {
            get => _triptype;
            set => SetProperty(ref _triptype, value);
        }
        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        public ObservableCollection<TripTypeResponse> TripTypes
        {
            get => _tripstypes;
            set => SetProperty(ref _tripstypes, value);
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }
        public TripRequest Trip
        {
            get => _trip;
            set => SetProperty(ref _trip, value);
        }
        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                User = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            }
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

            Trip.User = Guid.Parse(User.Id);
            Trip.TripType = TripType.Id;
            Trip.CultureInfo = Languages.Culture;

            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            Response response = await _apiService.NewTripAsync(url, "/api", "/Trips", Trip, "bearer", token.Token);

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

            if (string.IsNullOrEmpty(Trip.VisitedCity))
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PleaseEnterACity, Languages.Accept);
                return false;
            }
            if (Trip.StartDate>Trip.EndDate)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.TheStartDateMustBeLess, Languages.Accept);
                return false;
            }
            if (TripType == null)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, Languages.PleaseSelectATripType, Languages.Accept);
                return false;
            }

            return true;
        }
        private async void LoadCitiesAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();

            IsRunning = true;
            TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            Response response = await _apiService.GetListAsync<TripTypeResponse>(url, "/api", "/TripTypes", "bearer", token.Token);

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            List<TripTypeResponse> list = (List<TripTypeResponse>)response.Result;
            TripTypes = new ObservableCollection<TripTypeResponse>(list.OrderBy(t => t.Type));
            IsRunning = false;
        }

    }
}

using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Soccer.Common.Models;
using Soccer.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelBills.Common.Helpers;
using TravelBills.Common.Models;
using TravelBills.Prism.Helpers;
using TravelBills.Prism.Views;

namespace TravelBills.Prism.ViewModels
{
    public class TripsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private DelegateCommand _newTrip;
        private static TripsPageViewModel _instance;
        private List<TripResponse> _trips;
        private List<TripResponse> _trips1;
        private UserResponse _user;
        private bool _isRunning;
        public TripsPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            _instance = this;
            Title = Languages.TripsPage;
            _navigationService = navigationService;
            _apiService = apiService;
            LoadUser();
            LoadTripsAsync();
        }
        public DelegateCommand NewTrip => _newTrip ?? (_newTrip = new DelegateCommand(NewTripAsync));
        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        public static TripsPageViewModel GetInstance()
        {
            return _instance;
        }
        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                User = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            }
        }
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public List<TripResponse> Trips
        {
            get => _trips;
            set => SetProperty(ref _trips, value);
        }

        public List<TripResponse> Trips1
        {
            get => _trips1;
            set => SetProperty(ref _trips1, value);
        }

        private async void NewTripAsync()
        {
            await _navigationService.NavigateAsync(nameof(NewTripPage));
        }

        public async void LoadTripsAsync()
        {
            IsRunning = true;
            string url = App.Current.Resources["UrlAPI"].ToString();
           
                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
                Response response = await _apiService.GetListAsync<TripResponse>(url, "/api", "/Trips", "bearer", token.Token);

                IsRunning = false;

                if (!response.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                }


                Trips = (List<TripResponse>)response.Result;
                var list = new List<TripResponse>();
                foreach (var item in Trips)
                {
                    if (item.User.Id == User.Id)
                    {

                        list.Add(new TripResponse
                        {
                            User = item.User,
                            EndDate = item.EndDate,
                            StartDate = item.StartDate,
                            TripType = item.TripType,
                            VisitedCity = item.VisitedCity

                        });
                    }

                }

                Trips1 = list;
        }
    }
}

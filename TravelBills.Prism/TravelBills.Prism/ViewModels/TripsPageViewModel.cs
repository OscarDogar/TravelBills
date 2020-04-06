using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelBills.Prism.Helpers;
using TravelBills.Prism.Views;

namespace TravelBills.Prism.ViewModels
{
    public class TripsPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _newTrip;
        public TripsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = Languages.TripsPage;
            _navigationService = navigationService;
        }
        public DelegateCommand NewTrip => _newTrip ?? (_newTrip = new DelegateCommand(NewTripAsync));

        private async void NewTripAsync()
        {
            await _navigationService.NavigateAsync(nameof(NewTripPage));
        }
    }
}

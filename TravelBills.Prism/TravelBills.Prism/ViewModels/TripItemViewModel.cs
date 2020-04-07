using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TravelBills.Common.Models;
using TravelBills.Prism.Views;

namespace TravelBills.Prism.ViewModels
{
    public class TripItemViewModel : TripResponse
    {
        private readonly INavigationService _navigationService;

        private DelegateCommand _selectTripCommand;
        public TripItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public DelegateCommand SelectTripCommand => _selectTripCommand ?? (_selectTripCommand = new DelegateCommand(SelectAsync));

        private async void SelectAsync()
        {
            NavigationParameters parameters = new NavigationParameters { { "trip", this } };
            await _navigationService.NavigateAsync(nameof(TripDetailPage), parameters);
        }
    }
}

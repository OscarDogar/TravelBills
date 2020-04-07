using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using TravelBills.Common.Models;

namespace TravelBills.Prism.ViewModels
{
    public class TripDetailPageViewModel : ViewModelBase
    {
        private TripResponse _trip;
        public TripDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
        public override void OnNavigatedTo(INavigationParameters parameters) {
             base.OnNavigatedTo(parameters);
            _trip = parameters.GetValue<TripResponse>("trip"); Title = _trip.TripType.Type; 
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelBills.Prism.Helpers;

namespace TravelBills.Prism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.MainPage;
        }
    }
}

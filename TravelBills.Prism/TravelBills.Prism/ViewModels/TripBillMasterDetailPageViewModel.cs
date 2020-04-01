using Newtonsoft.Json;
using Prism.Navigation;
using Soccer.Common.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TravelBills.Common.Helpers;
using TravelBills.Common.Models;
using TravelBills.Prism.Helpers;
using TravelBills.Prism.ViewModels;

namespace Soccer.Prism.ViewModels
{
    public class TripBillMasterDetailPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private UserResponse _user;

        public TripBillMasterDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadUser();
            LoadMenus();
        }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public UserResponse User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }

        private void LoadUser()
        {
            if (Settings.IsLogin)
            {
                User = JsonConvert.DeserializeObject<UserResponse>(Settings.User);
            }
        }

        private void LoadMenus()
        {
            List<Menu> menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "home",
                    PageName = "MainPage",
                    Title =  Languages.Home
                },
                new Menu
                {
                    Icon = "user",
                    PageName = "ModifyUserPage",
                    Title = Languages.Modifyuser
                },
                new Menu
                {
                    Icon = "login",
                    PageName = "LoginPage",
                    Title = Settings.IsLogin ? Languages.Logout : Languages.Login
                }
            };

            Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel(_navigationService)
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }
    }
}

using TravelBills.Prism.Interfaces;
using System.Globalization;
using TravelBills.Prism.Resources;
using Xamarin.Forms;

namespace TravelBills.Prism.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            Culture = ci.Name;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }
        public static string Culture { get; set; }

        public static string Loading => Resource.Loading;

        public static string Email => Resource.Email;

        public static string Hello => Resource.Hello;

        public static string EmailPlaceHolder => Resource.EmailPlaceHolder;

        public static string Logout => Resource.Logout;

        public static string EmailError => Resource.EmailError;

        public static string LoginError => Resource.LoginError;

        public static string Password => Resource.Password;

        public static string PasswordError => Resource.PasswordError;

        public static string PasswordPlaceHolder => Resource.PasswordPlaceHolder;

        public static string Register => Resource.Register;

        public static string Home => Resource.Home;

        public static string MainPage => Resource.Main_Page;

        public static string Modifyuser => Resource.Modify_user;

        public static string Login => Resource.Login;

        public static string Accept => Resource.Accept;

        public static string Welcome => Resource.Welcome;

        public static string Error => Resource.Error;
    }
}

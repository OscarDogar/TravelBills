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
            Culture = ci.ToString();
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }
        public static string Culture { get; set; }

        public static string ForgotPassword => Resource.ForgotPassword;

        public static string PasswordRecover => Resource.PasswordRecover;

        public static string DocumentError => Resource.DocumentError;

        public static string FirstNameError => Resource.FirstNameError;

        public static string LastNameError => Resource.LastNameError;

        public static string OK => Resource.OK;

        public static string Address => Resource.Address;

        public static string AddressError => Resource.AddressError;

        public static string AddressPlaceHolder => Resource.AddressPlaceHolder;

        public static string Phone => Resource.Phone;

        public static string PhoneError => Resource.PhoneError;

        public static string PhonePlaceHolder => Resource.PhonePlaceHolder;

        public static string PasswordConfirm => Resource.PasswordConfirm;

        public static string PasswordConfirmError1 => Resource.PasswordConfirmError1;

        public static string PasswordConfirmError2 => Resource.PasswordConfirmError2;

        public static string PasswordConfirmPlaceHolder => Resource.PasswordConfirmPlaceHolder;

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

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

        public static string City => Resource.City;

        public static string TapTheImage => Resource.TapTheImage;

        public static string TapTheTrip => Resource.TapTheTrip;

        public static string TripExpenseType => Resource.TripExpenseType;

        public static string BillValue => Resource.BillValue;

        public static string CityPlaceHolder => Resource.CityPlaceHolder;

        public static string StartDate => Resource.StartDate;

        public static string TripType => Resource.TripType;

        public static string TripTypes => Resource.TripTypes;

        public static string SelectTheTripType => Resource.SelectTheTripType;

        public static string Date => Resource.Date;

        public static string Time => Resource.Time;

        public static string SelectTheTripExpenseType => Resource.SelectTheTripExpenseType;

        public static string Add => Resource.Add;

        public static string EndDate => Resource.EndDate;

        public static string PleaseEnterTheBillValue => Resource.PleaseEnterTheBillValue;

        public static string PleaseUploadAPictureOfTheBill => Resource.PleaseUploadAPictureOfTheBill;

        public static string PleaseSelectTheTripExpenseType => Resource.PleaseSelectTheTripExpenseType;

        public static string PleaseGrantTheRequiredRermissions => Resource.PleaseGrantTheRequiredRermissions;

        public static string PictureSource => Resource.PictureSource;

        public static string Cancel => Resource.Cancel;

        public static string FromCamera => Resource.FromCamera;

        public static string FromGallery => Resource.FromGallery;

        public static string Save => Resource.Save;

        public static string PleaseEnterACity => Resource.PleaseEnterACity;

        public static string TheStartDateMustBeLess => Resource.TheStartDateMustBeLess;

        public static string PleaseSelectATripType => Resource.PleaseSelectATripType;

        public static string TripsPage => Resource.TripsPage;

        public static string NewTripPage => Resource.NewTripPage;

        public static string ChangePassword => Resource.ChangePassword;

        public static string ConfirmNewPassword => Resource.ConfirmNewPassword;

        public static string PasswordLength => Resource.PasswordLength;

        public static string ConfirmNewPasswordError => Resource.ConfirmNewPasswordError;

        public static string ConfirmNewPasswordError2 => Resource.ConfirmNewPasswordError2;

        public static string ConfirmNewPasswordPlaceHolder => Resource.ConfirmNewPasswordPlaceHolder;

        public static string CurrentPassword => Resource.CurrentPassword;

        public static string CurrentPasswordError => Resource.CurrentPasswordError;

        public static string CurrentPasswordPlaceHolder => Resource.CurrentPasswordPlaceHolder;

        public static string NewPassword => Resource.NewPassword;

        public static string NewPasswordError => Resource.NewPasswordError;

        public static string NewPasswordPlaceHolder => Resource.NewPasswordPlaceHolder;

        public static string UserUpdated => Resource.UserUpdated;

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

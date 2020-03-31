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
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Home => Resource.Home;

        public static string MainPage => Resource.Main_Page;

        public static string Modifyuser => Resource.Modify_user;

        public static string Login => Resource.Login;

        public static string Accept => Resource.Accept;

        public static string Welcome => Resource.Welcome;

        public static string Error => Resource.Error;
    }
}


using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Test.Helpers;
using Test.Models;
using Test.Pages;
using Xamarin.Forms;

namespace Test
{
    public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }

		public App ()
		{
            if (!IsUserLoggedIn) {
                MainPage = new NavigationPage(new LoginPage());
            } else {
                MainPage = new NavigationPage(new MainPage());
            }
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            AppCenter.Start("android=0b76f381-381f-42ad-9a13-fe64ca21fe41;ios=9ba7c884-fb25-468b-9c17-a7a288d5decb;", 
                typeof(Analytics), typeof(Crashes));

            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY)) {
                Models.User userlogged = Application.Current.Properties[Constants.USER_KEY] as Models.User;
                Analytics.TrackEvent("OnStart ::" + userlogged.UserID);
            }
            else
                Analytics.TrackEvent("OnStart");
        }

		protected override void OnSleep ()
		{
            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY))
            {
                Models.User userlogged = Application.Current.Properties[Constants.USER_KEY] as Models.User;
                Analytics.TrackEvent("OnSleep ::" + userlogged.UserID);
            }
            else
                Analytics.TrackEvent("OnSleep");
        }

		protected override void OnResume ()
		{
            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY))
            {
                Models.User userlogged = Application.Current.Properties[Constants.USER_KEY] as Models.User;
                Analytics.TrackEvent("OnResume ::" + userlogged.UserID);
            }
            else
                Analytics.TrackEvent("OnResume");
        }
	}
}

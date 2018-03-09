
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
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
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

using Test.Helpers;
using Test.Pages;
using Xamarin.Forms;

namespace Test
{
    public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }

		public App ()
		{
            AnalyticsHelper.start();
            setMainPage();
        }

		protected override void OnStart ()
		{
            AnalyticsHelper.send("App", "Start application");
        }

		protected override void OnSleep ()
		{
            AnalyticsHelper.send("App", "OnSleep application");
        }

		protected override void OnResume ()
		{
            AnalyticsHelper.send("App", "OnResume application");
        }

        private void setMainPage()
        {
            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }
	}
}

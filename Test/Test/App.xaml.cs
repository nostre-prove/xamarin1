using Test.Helpers;
using Test.Pages;
using Xamarin.Forms;

namespace Test
{
    public partial class App : Application
	{
		public App ()
		{
            AnalyticsHelper.Start();
            SetMainPage();
        }

		protected override void OnStart ()
		{
            AnalyticsHelper.Send("App", "Start application");
        }

		protected override void OnSleep ()
		{
            AnalyticsHelper.Send("App", "OnSleep application");
        }

		protected override void OnResume ()
		{
            AnalyticsHelper.Send("App", "OnResume application");
        }

        private void SetMainPage()
        {
            if(Application.Current.Properties.ContainsKey(Constants.USER_NAME))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
	}
}

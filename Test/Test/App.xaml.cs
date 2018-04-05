using Test.Helpers;
using Test.Interfaces;
using Test.Pages;
using Test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Test
{
    public partial class App : Application
	{
        static ItemDatabase database;

		public App ()
		{
            AnalyticsHelper.Start();
            SetMainPage();
        }

		protected override void OnStart ()
		{
            IEnvironment myEnv = EnvironmentFactory.getInstance();
            AnalyticsHelper.Send(Constants.APP_NAME, "OnStart");
        }

		protected override void OnSleep ()
		{
            AnalyticsHelper.Send(Constants.APP_NAME, "OnSleep");
        }

		protected override void OnResume ()
		{
            AnalyticsHelper.Send(Constants.APP_NAME, "OnResume");
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

        public static ItemDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new ItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }
       
	}
}

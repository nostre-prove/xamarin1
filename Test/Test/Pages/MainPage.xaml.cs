using System;
using Test.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
	{
        public MainPage ()
		{
			InitializeComponent ();            
            IsPresented = false;
            MasterBehavior = MasterBehavior.Popover;
            Detail = new NavigationPage(new CalendarPage());
        }

        private void OnClicked_Calendar(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CalendarPage());
            IsPresented = false;
        }

        private void OnClicked_Post(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PostPage());
            IsPresented = false;
        }

        private void OnClicked_About(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutPage());
            IsPresented = false;
        }

        async void OnClicked_Logout(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Application.Current.Properties.Remove(Constants.USER_KEY);
            AnalyticsHelper.Send("Logout", "Return to Login");
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
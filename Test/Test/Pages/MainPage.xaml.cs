using System;
using Test.Helpers;
using Test.Services;
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
            Detail = new NavigationPage(new SiteInspectionPage());
        }

        protected override void OnAppearing()
        {
            var username = Application.Current.Properties.ContainsKey(Constants.USER_NAME) ? Application.Current.Properties[Constants.USER_NAME] : "ospite";
            LabelMenuText.Text = String.Format("Benvenuto, {0}", username);
        }

        private void OnClicked_SiteInspection(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SiteInspectionPage());
            IsPresented = false;
        }

        private void OnClicked_Survey(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SurveyPage());
            IsPresented = false;
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
            AnalyticsHelper.Send("Logout", "Return to Login");
            LoginService.RemoveUserInfo();
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
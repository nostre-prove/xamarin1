using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
	public partial class MainPage : MasterDetailPage
	{
        public MainPage ()
		{
			InitializeComponent ();            
            IsPresented = false;
            MasterBehavior = MasterBehavior.Popover;
            Detail = new NavigationPage(new CalendarPage());
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        private void OnClicked_Calendar(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CalendarPage());
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
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
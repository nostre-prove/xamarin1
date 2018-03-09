using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
            DependencyService.Get<IMyTest>().Speak("Hi");
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EngagementPage : ContentPage
	{
		public EngagementPage()
		{
			InitializeComponent ();
		}

        async void OnClicked_Logout(object sender, EventArgs e)
        {
            // AnalyticsHelper.Send("Logout", "Return to Login");
            LoginService.RemoveUserInfo();
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

    }
}
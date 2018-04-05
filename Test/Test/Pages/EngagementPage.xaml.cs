using System;
using Test.Helpers;
using Test.Interfaces;
using Test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EngagementPage : ContentPage
	{
        IEnvironment client = EnvironmentFactory.GetInstance();

        public EngagementPage()
		{
			InitializeComponent ();
            labelClient.Text = client != null ? client.GetEnvName() : "Guest";                        
            Console.WriteLine(String.Format("client: {0}", client?.ToString()));
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
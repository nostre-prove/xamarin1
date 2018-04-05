using AuditPlus.Helpers;
using AuditPlus.Interfaces;
using AuditPlus.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditPlus.Pages
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
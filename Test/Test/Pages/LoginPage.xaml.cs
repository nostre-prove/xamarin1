using System;
using Test.Helpers;
using Test.ViewModels;
using Xamarin.Forms;

namespace Test.Pages
{
    public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
            InitializeComponent();
            BindingContext = new LoginViewModel();
            DependencyService.Get<ILogging>().Info("Login", "mymessage");
            DependencyService.Get<ILogging>().Warn("Login", "mymessage");
            DependencyService.Get<ILogging>().Debug("Login", "mymessage");
            DependencyService.Get<ILogging>().Error("Login", "mymessage");
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Login.AreCredentialsCorrect(usernameEntry.Text, passwordEntry.Text);

            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY))
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            } else
            {
                messageLabel.Text = "Dati non corretti";
                passwordEntry.Text = string.Empty;
            }
        }
    }
}
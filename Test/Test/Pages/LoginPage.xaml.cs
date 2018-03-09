using System;
using Test.Helpers;
using Test.Models;
using Xamarin.Forms;

namespace Test.Pages
{
    public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var isValid = AreCredentialsCorrect(user);
            if (isValid)
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

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == Constants.Username && user.Password == Constants.Password;
        }
    }
}
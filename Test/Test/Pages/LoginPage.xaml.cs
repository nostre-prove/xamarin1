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
            //User user = new User
            //{
            //    Username = usernameEntry.Text,
            //    Password = passwordEntry.Text
            //};

            AreCredentialsCorrect(usernameEntry.Text, passwordEntry.Text);

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
        //da mettere in un'aaltra parte
        void AreCredentialsCorrect(string username, string password)
        {
            Application.Current.Properties.Remove(Constants.USER_KEY);
            if (username == "abc" && password == "123")
            {
                User loginUser = new User();
                loginUser.Password = password;
                loginUser.Username = username;
                loginUser.UserID = "1234";
                Application.Current.Properties.Add(Constants.USER_KEY, loginUser);
            }
        }
    }
}
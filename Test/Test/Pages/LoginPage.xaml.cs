﻿using System;
using Test.Helpers;
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
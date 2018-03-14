using System;
using System.Collections.Generic;
using System.Text;
using Test.Models;
using Xamarin.Forms;

namespace Test.Helpers
{
    static class Login
    {
        // da mettere in un'altra parte
        public static void AreCredentialsCorrect(string username, string password)
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

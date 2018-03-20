using System;
using System.Collections.Generic;
using System.Text;
using Test.Helpers;
using Test.Models;
using Xamarin.Forms;

namespace Test.Services
{
    static class LoginService
    {
        public static void SaveUserInfo(OauthAccess oauthAccess)
        {
            Application.Current.Properties.Add(Constants.ACCESS_TOKEN, oauthAccess.access_token);
            Application.Current.Properties.Add(Constants.REFRESH_TOKEN, oauthAccess.refresh_token);
            Application.Current.Properties.Add(Constants.USER_NAME, oauthAccess.user_info);
        }

        public static void RemoveUserInfo()
        {
            Application.Current.Properties.Remove(Constants.ACCESS_TOKEN);
            Application.Current.Properties.Remove(Constants.REFRESH_TOKEN);
            Application.Current.Properties.Remove(Constants.USER_NAME);
        }
    }
}

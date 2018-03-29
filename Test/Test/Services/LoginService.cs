using System.Collections.Generic;
using Test.Helpers;
using Xamarin.Forms;

namespace Test.Services
{
    static class LoginService
    {
        public static void SaveUserInfo(List<string> userData)
        {
            Application.Current.Properties.Add(Constants.ACCESS_TOKEN, userData[0]);
            Application.Current.Properties.Add(Constants.USER_NAME, string.Format("{0} {1}", userData[2], userData[3]));
        }

        public static void RemoveUserInfo()
        {
            Application.Current.Properties.Remove(Constants.ACCESS_TOKEN);
            Application.Current.Properties.Remove(Constants.USER_NAME);
        }
    }
}

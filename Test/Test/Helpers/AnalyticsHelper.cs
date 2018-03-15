using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;

namespace Test.Helpers
{
    static class AnalyticsHelper
    {
        public static void start()
        {
            AppCenter.Start(String.Format("android={0};ios={1};", Constants.ANALYTICS_KEY_ANDROID, Constants.ANALYTICS_KEY_IOS),
                typeof(Analytics), typeof(Crashes));
        }

        public static void send(string sender, string message)
        {
            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY) && 1==0)
            {                
                Models.User userlogged = Application.Current.Properties[Constants.USER_KEY] as Models.User;
                Analytics.TrackEvent(String.Format("User ID: {0} - {1} - {2}", userlogged.UserID, sender, message));
            }
            else
            {
                Analytics.TrackEvent(String.Format("{0} - {1}", sender, message));
            }
        }
    }
}

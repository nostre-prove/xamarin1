using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using Xamarin.Forms;

namespace Test.Helpers
{
    static class AnalyticsHelper
    {
        public static void Start()
        {
            AppCenter.Start(String.Format("android={0};ios={1};", Constants.ANALYTICS_KEY_ANDROID, Constants.ANALYTICS_KEY_IOS),
                typeof(Analytics), typeof(Crashes));
        }

        public static void Send(string sender, string message)
        {
            // TODO: change output
            if (Application.Current.Properties.ContainsKey(Constants.USER_NAME) && 1==0)
            {                
                var username = Application.Current.Properties[Constants.USER_NAME];
                Analytics.TrackEvent(String.Format("Username: {0} - {1} - {2}", username, sender, message));
            }
            else
            {
                Analytics.TrackEvent(String.Format("{0} - {1}", sender, message));
            }
        }
    }
}

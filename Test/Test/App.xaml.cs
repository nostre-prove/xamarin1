
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.IO;
using Test.Helpers;
using Test.Models;
using Test.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Test
{
    public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }

		public App ()
		{
            if (!IsUserLoggedIn) {
                MainPage = new NavigationPage(new LoginPage());
            } else {
                MainPage = new NavigationPage(new MainPage());
            }
        }

		protected override void OnStart ()
		{
            AppCenter.Start("android=b3c120a0-5a9b-4f2f-863b-3546e0ba8e17;ios=77ed2365-e5d9-4b98-a110-105176cbf376;", 
                typeof(Analytics), typeof(Crashes));

            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY)) {
                Models.User userlogged = Application.Current.Properties[Constants.USER_KEY] as Models.User;
                Analytics.TrackEvent("OnStart ::" + userlogged.UserID);
            }
            else
            {
                Analytics.TrackEvent("OnStart");
            }
        }

		protected override void OnSleep ()
		{
            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY))
            {
                Models.User userlogged = Application.Current.Properties[Constants.USER_KEY] as Models.User;
                Analytics.TrackEvent("OnSleep ::" + userlogged.UserID);
            }
            else
            {
                Analytics.TrackEvent("OnSleep");
            }
        }

		protected override void OnResume ()
		{
            if (Application.Current.Properties.ContainsKey(Constants.USER_KEY))
            {
                Models.User userlogged = Application.Current.Properties[Constants.USER_KEY] as Models.User;
                Analytics.TrackEvent("OnResume ::" + userlogged.UserID);
            }
            else
            {
                Analytics.TrackEvent("OnResume");
            }
        }
	}
}

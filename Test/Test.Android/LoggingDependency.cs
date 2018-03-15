using Android.Util;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Test.Droid.LoggingDependency))]
namespace Test.Droid
{
    public class LoggingDependency : ILogging
    {
        public LoggingDependency() { }

        public void Debug(string sender, string message)
        {
            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
            Log.Debug("xamarin_debug", String.Format("{0} - {1} - {2}", now, sender, message));
        }

        public void Info(string sender, string message)
        {
            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");           
            Log.Info("xamarin_info", String.Format("{0} - {1} - {2}", now, sender, message));
        }

        public void Warn(string sender, string message)
        {
            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
            Log.Warn("xamarin_warn", String.Format("{0} - {1} - {2}", now, sender, message));
        }

        public void Error(string sender, string message)
        {
            var now = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");
            Log.Error("xamarin_error", String.Format("{0} - {1} - {2}", now, sender, message));
        }
    }
}
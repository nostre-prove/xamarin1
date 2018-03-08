using Android.Util;
using Xamarin.Forms;

[assembly: Dependency(typeof(Test.Droid.TestDependency))]
namespace Test.Droid
{
    public class TestDependency : IMyTest
    {
        public TestDependency() { }

        public void Speak(string text)
        {
            Log.Info("dba", "Dependency Injection Android OK");
        }
    }
}
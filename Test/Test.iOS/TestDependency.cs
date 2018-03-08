using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Test.Droid.TestDependency))]
namespace Test.Droid
{
    public class TestDependency : IMyTest
    {
        public TestDependency() { }

        public void Speak(string text)
        {
            Console.WriteLine("Dependency Injection iOS OK");
        }
    }
}
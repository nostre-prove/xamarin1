using Test.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
	{
		public TestPage ()
		{
			InitializeComponent ();
            AnalyticsHelper.Send("Test", "Enter in Test section");
        }
	}
}
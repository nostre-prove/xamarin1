using Test.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();
            AnalyticsHelper.Send("About", "Enter in About section");
        }
	}
}
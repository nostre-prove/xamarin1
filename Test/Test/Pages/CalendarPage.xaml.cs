using Test.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarPage : ContentPage
	{
		public CalendarPage()
		{
			InitializeComponent ();
            AnalyticsHelper.Send("Calendar", "Enter in Calendar section");
        }
    }
}
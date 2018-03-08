using Xamarin.Forms;

namespace Test
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();
            DependencyService.Get<IMyTest>().Speak("Hi");
        }
	}
}

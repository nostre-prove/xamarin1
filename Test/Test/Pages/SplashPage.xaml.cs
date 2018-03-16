
using Xamarin.Forms;

namespace Test.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
	{
        Image SplashImage;
        public static bool IsUserLoggedIn { get; set; }

        public SplashPage ()
		{
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            SplashImage = new Image {
                Source = "dbalab.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(SplashImage,
                AbsoluteLayoutFlags.PositionProportional);

            sub.Children.Add(SplashImage);

            this.BackgroundColor = Color.FromHex("#aabbcc");
            this.Content = sub;
			// InitializeComponent ();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await SplashImage.ScaleTo(1, 1000);
            // await SplashImage.ScaleTo(0.9, 1500, Easing.Linear);
            // await SplashImage.ScaleTo(150, 1200, Easing.Linear);

            if (!IsUserLoggedIn)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
            }            
        }
	}
}
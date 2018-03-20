using System;
using System.Collections.Generic;
using Test.Services;
using Test.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
            DependencyService.Get<ILogging>().Info("Login", "mymessage");
        }

        protected override void OnAppearing()
        {
            /*
            if (Application.Current.Properties.ContainsKey(Constants.USER_NAME))
            {
                messageLabel.Text = Application.Current.Properties[Constants.USER_NAME].ToString();
            } else
            {
                messageLabel.Text = "Nessun username presente";
            }
            */

            var Environments = new List<String>()
            {
                "Sviluppo",
                "Produzione"
            };
            myPicker.ItemsSource = Environments;
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                messageEnvironment.Text = String.Format("Ambiente selezionato: {0}", (string)picker.ItemsSource[selectedIndex]);
            }
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var content = await RestService.DoLogin(usernameEntry.Text, passwordEntry.Text);
            if (content != null)
            {
                messageLabel.Text = content.user_info;
                LoginService.SaveUserInfo(content);
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                messageLabel.Text = "Errore autenticazione";
                passwordEntry.Text = string.Empty;
            }
        }

        async void OnQuickAccessButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
    }
}
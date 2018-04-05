using System;
using System.Collections.Generic;
using System.ComponentModel;
using AuditPlus.Helpers;
using AuditPlus.Services;
using AuditPlus.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuditPlus.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage, INotifyPropertyChanged
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
            DependencyService.Get<ILogging>().Info("Login", "mymessage");            
        }
        
        protected override void OnAppearing()
        {
            var Environments = new List<String>()
            {
                "OpenFiberProdEnv",
                "OpenFiberTestEnv"
            };
            PickerEnvironment.ItemsSource = Environments;
        }
        
        void OnPickerEnvironmentChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                if(Application.Current.Properties.ContainsKey(Constants.SITE_ID))
                {
                    Application.Current.Properties[Constants.SITE_ID] = picker.ItemsSource[selectedIndex];
                } else
                {
                    Application.Current.Properties.Add(Constants.SITE_ID, picker.ItemsSource[selectedIndex]);
                }
            }
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            messageLabel.Text = "";
            if (usernameEntry.Text == "" || passwordEntry.Text == "")
            {
                messageLabel.Text = "Username e password obbligatori";
                return;
            }

            buttonLogin.IsEnabled = false;
            indicatorLoader.IsRunning = true;

            var content = await RestService.DoLogin(usernameEntry.Text, passwordEntry.Text);

            indicatorLoader.IsRunning = false;
            buttonLogin.IsEnabled = true;

            if (content != null)
            {
                if (content.success)
                {
                    if (content.message != null)
                    {
                        messageLabel.Text = content.message;
                    }

                    if(content.data != null && content.data.Count >= 4)
                    {
                        LoginService.SaveUserInfo(content.data);
                        passwordEntry.Text = string.Empty;
                        Navigation.InsertPageBefore(new MainPage(), this);
                        await Navigation.PopAsync();
                    }
                } else
                {
                    messageLabel.Text = content.message;
                }
            }
        }

        async void OnQuickAccessButtonClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
    }
}
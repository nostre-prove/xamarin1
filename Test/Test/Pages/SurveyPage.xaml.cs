
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Test.Models;
using Test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SurveyPage : ContentPage
	{
        ObservableCollection<SurveyGroup> SurveyGroupTest { get; set; }

        public SurveyPage()
		{
			InitializeComponent ();

            SurveyGroupTest = new ObservableCollection<SurveyGroup>
            {
                new SurveyGroup
                {
                    Title = "Gruppo 1",
                    IsVisible = false,
                    Surveys = new List<Survey>
                    {
                        new Survey { SiteId=1, Id = 1, Title = "Indirizzo", TypeId=1, TypeDescriptionText="Descrizione di Test", IsVisible = true },
                        new Survey { SiteId=1, Id = 2, Title = "Appaltatore", TypeId=2, TypeOptions=new List<string> { "aaa" }, IsVisible = true },
                        new Survey { SiteId=1, Id = 3, Title = "Subappaltatore", IsVisible = true },
                        new Survey { SiteId=1, Id = 4, Title = "Per direzione lavori", IsVisible = true }
                    }
                },
                new SurveyGroup{
                    Title = "Gruppo 2",
                    IsVisible = false,
                    Surveys = new List<Survey>
                    {
                        new Survey { SiteId=1, Id = 5, Title = "Indirizzo2", IsVisible = true },
                        new Survey { SiteId=1, Id = 6, Title = "Appaltatore2", IsVisible = true },
                        new Survey { SiteId=1, Id = 7, Title = "Subappaltatore2", IsVisible = true },
                        new Survey { SiteId=1, Id = 8, Title = "Per direzione lavori2", IsVisible = true }
                    }
                },
                new SurveyGroup{
                    Title = "Gruppo 3",
                    IsVisible = false,
                },
                new SurveyGroup{
                    Title = "Gruppo 4",
                    IsVisible = false,
                },
            };


            SurveyGroups.ItemsSource = SurveyGroupTest;
        }

        public void SaveSurvey(object sender, EventArgs e)
        {
        }

        public void OnQuestionSelected(object sender, ItemTappedEventArgs e)
        {
            var SelectedSurveyGroup = e.Item as SurveyGroup;
            SelectedSurveyGroup.IsVisible = !SelectedSurveyGroup.IsVisible;
            UpdateSurveyList(SelectedSurveyGroup);
        }

        private void UpdateSurveyList(SurveyGroup SelectedSurveyGroup)
        {
            var index = SurveyGroupTest.IndexOf(SelectedSurveyGroup);
            SurveyGroupTest.Remove(SelectedSurveyGroup);
            SurveyGroupTest.Insert(index, SelectedSurveyGroup);
        }

        async void OnClicked_Logout(object sender, EventArgs e)
        {
            LoginService.RemoveUserInfo();
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
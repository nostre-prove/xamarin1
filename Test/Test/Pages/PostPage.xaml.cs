using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Test.Helpers;
using Test.Models;
using Test.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostPage : ContentPage
	{
        private const string url = "http://jsonplaceholder.typicode.com/posts";
        private ObservableCollection<Post> postsObservable;

        public PostPage ()
		{
            InitializeComponent();
            // AnalyticsHelper.Send("Calendar", "Enter in Calendar section")
            countPost.Text = "SQLite";
        }
        
        public async void LoadDataFromService(Object sender, EventArgs e)
        {
            try
            {
                var content = await RestService.GetRequest(url);
                var posts = JsonConvert.DeserializeObject<List<Post>>(content);

                long timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                foreach(Post post in posts)
                {
                    post.Timestamp = timestamp;
                    Console.WriteLine(JsonConvert.SerializeObject(post));
                    await App.Database.SaveItemAsync(post);
                }
            } catch (Exception ex)
            {
                DependencyService.Get<ILogging>().Info("Test.PostPage", ex.ToString());
            }
        }

        public async void LoadDataInternal(Object sender, EventArgs e)
        {
            try
            {
                var posts = await App.Database.GetItemsAsync();
                countPost.Text = "SQLite - Totale post salvati: " + posts.Count.ToString();
                Console.WriteLine("Count: " + posts.Count);
                postsObservable = new ObservableCollection<Post>(posts);
                Posts.ItemsSource = postsObservable;                
            }
            catch (Exception ex)
            {
                DependencyService.Get<ILogging>().Info("Test.PostPage", ex.ToString());
            }
        }

        public async void DeleteAllPosts(Object sender, EventArgs e)
        {
            try
            {
                var posts = await App.Database.GetItemsAsync();
                foreach(Post post in posts)
                {
                    await App.Database.DeleteItemAsync(post);
                }
            }
            catch (Exception ex)
            {
                DependencyService.Get<ILogging>().Info("Test.PostPage", ex.ToString());
            }
        }

        async void OnClicked_Logout(object sender, EventArgs e)
        {
            LoginService.RemoveUserInfo();
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }
    }
}
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Test.Helpers;
using Test.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PostPage : ContentPage
	{
        private const string url = "http://jsonplaceholder.typicode.com/posts";
        private HttpClient httpClient = new HttpClient();
        private ObservableCollection<Post> postsObservable;

        public PostPage ()
		{
            InitializeComponent();
            AnalyticsHelper.Send("Calendar", "Enter in Calendar section");
        }
        
        public async void LoadData(Object sender, EventArgs e)
        {
            try
            {
                var content = await httpClient.GetStringAsync(url);
                var posts = JsonConvert.DeserializeObject<List<Post>>(content);
                postsObservable = new ObservableCollection<Post>(posts);
                Posts.ItemsSource = postsObservable;                
            } catch (Exception ex)
            {
                DependencyService.Get<ILogging>().Info("Test.PostPage", ex.ToString());
            }
        }
        
    }
}
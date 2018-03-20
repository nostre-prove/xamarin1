using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Test.Models;
using Xamarin.Forms;

namespace Test.Services
{
    static class RestService
    {
        static HttpClient httpClient = new HttpClient();

        public static async Task<String> GetRequest(string url)
        {
            DependencyService.Get<ILogging>().Info("GET request", url);
            var content = await httpClient.GetStringAsync(url);
            return content;
        }

        public static async Task<OauthAccess> DoLogin(string username, string password)
        {
            OauthAccess oauthAccess = null;
            string url = "https://ismael.dbalab.it/gateway/auu/v1/oauth/token";

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "aXNtYWVsOg==");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpContent = new HttpRequestMessage(HttpMethod.Post, url);
            DependencyService.Get<ILogging>().Info("POST request", url);

            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("grant_type", "password"));
            values.Add(new KeyValuePair<string, string>("username", username)); 
            values.Add(new KeyValuePair<string, string>("password", password));
            httpContent.Content = new FormUrlEncodedContent(values);

            var response = await httpClient.SendAsync(httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBodyAsText = response.Content.ReadAsStringAsync().Result;
                oauthAccess = JsonConvert.DeserializeObject<OauthAccess>(responseBodyAsText);
            }
            else
            {
                DependencyService.Get<ILogging>().Info("Test.PostPage", "Errore");
            }

            return oauthAccess;
        }
    }
}

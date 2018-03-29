using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public static async Task<OauthAccess> DoLoginIsmael(string username, string password)
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

        public static async Task<LoginResponse> DoLogin(string username, string password)
        {
            LoginResponse loginResponse = null;
            string url = "http://ws-mobile-connector-dba.appspot.com/userLoginServlet?servletAction=login";

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpContent = new HttpRequestMessage(HttpMethod.Post, url);
            DependencyService.Get<ILogging>().Info("POST request", url);

            JObject oJsonObject = new JObject();
            oJsonObject.Add("username", username);
            oJsonObject.Add("password", password);

            httpContent.Content = new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(httpContent);

            if (response.IsSuccessStatusCode)
            {
                var responseBodyAsText = response.Content.ReadAsStringAsync().Result;
                loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseBodyAsText);               
            }
            else
            {
                DependencyService.Get<ILogging>().Info("Test.PostPage", "Errore");
            }

            return loginResponse;
        }
    }
}

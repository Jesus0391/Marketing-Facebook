using Facebook.Models.Interfaces;
using Facebook.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Client
{
    public class FacebookClient : IClient
    {
        private readonly HttpClient _httpClient;
        public string Version { get; set; }
        public string AccessToken { get; set; }
        /// <summary>
        /// Make Client with specific version
        /// </summary>
        /// <param name="version"></param>
        public FacebookClient(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new Exception("Required version for access to Facebook Api");
            }
            //Set Version
            Version = version;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://graph.facebook.com/v{Version}/")
            };
            _httpClient.DefaultRequestHeaders.Accept
                   .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        /// <summary>
        /// Make Client with specific version and access token for all requests
        /// </summary>
        /// <param name="version"></param>
        public FacebookClient(string version, string accessToken)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new Exception("Required version for access to Facebook Api");
            }
            //Set Version
            Version = version;
            AccessToken = accessToken;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://graph.facebook.com/v{Version}/")
            };
            _httpClient.DefaultRequestHeaders.Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Request Access token
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <param name="grantType"></param>
        /// <returns></returns>
        public string GetAccessToken(string clientId, string secret, string grantType)
        {
            //act_10155310538728783/ads?fields=name,adset,creative,campaign
            var response = _httpClient.GetAsync($"oauth/access_token?client_id={clientId}&client_secret={secret}&grant_type={grantType}").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new Exception(content));
            }
            var token = JsonConvert.DeserializeObject<Token>(content);
            return token.access_token;
        }

        private string GetQueryString(object model)
        {
            var queryString = 
                string.Join("&", model.GetType().GetProperties().Select(p => p.Name + "=" + p.GetValue(model, null)));

            return queryString;
        }
        private StringContent GetPayload(object parameters)
        {
            var json = JsonConvert.SerializeObject(parameters);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        public object Get(string endpoint, object parameters)
        {
            var queryStringParameters = GetQueryString(parameters);
            var response = _httpClient.GetAsync($"{endpoint}?acess_token={AccessToken}&{queryStringParameters}").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new Exception(content));
            }

            return content;
        }

        public async Task<object> GetAsync(string endpoint, object parameters)
        {
            var queryStringParameters = GetQueryString(parameters);
            var response = await _httpClient.GetAsync($"{endpoint}?acess_token={AccessToken}&{queryStringParameters}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new Exception(content));
            }

            return content;
        }

        public object Post(string endpoint, object parameters)
        {
            var body = GetPayload(parameters);
            var response =  _httpClient.PostAsync($"{endpoint}?acess_token={AccessToken}", body).Result;
            var content =  response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new Exception(content));
            }

            return content;
        }

        public async Task<object> PostAsync(string endpoint, object parameters)
        {
            var body = GetPayload(parameters);
            var response = await _httpClient.PostAsync($"{endpoint}?acess_token={AccessToken}", body);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new Exception(content));
            }

            return content;
        }
    }
}

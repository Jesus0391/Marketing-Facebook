using Facebook.Interfaces;
using Facebook.Models.Response;
using Facebook.SDK;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Facebook.Client
{
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;
        public string Version { get; set; }
        public string AccessToken { get; set; }
        public FacebookClient()
        {
        
        }
        /// <summary>
        /// Make Client with specific version
        /// </summary>
        /// <param name="version">The version of api to access example: 2.8, 2.9, etc..</param>
        private FacebookClient(string version)
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
        /// <param name="version">The version of api to access example: 2.8, 2.9, etc..</param>
        /// <param name="accessToken">The access token provider for facebook </param>
        public FacebookClient(string version, string accessToken)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new Exception("Required version for access to Facebook Api");
            }
            else
            {
                //Set Version
                Version = version;
            }
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Required access token for access to Facebook Api");
            }
            else
            {

                AccessToken = accessToken;
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://graph.facebook.com/v{Version}/")
            };
            _httpClient.DefaultRequestHeaders.Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Create Facebook client with generated Access Token
        /// </summary>
        /// <param name="version"></param>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <param name="grantType"></param>
        public FacebookClient(string version, string clientId,
                                    string secret, string grantType)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new Exception("Required version for access to Facebook Api");
            }
            else
            {
                //Set Version
                Version = version;
            }

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri($"https://graph.facebook.com/v{Version}/")
            };
            _httpClient.DefaultRequestHeaders.Accept
                     .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(grantType))
            {
                throw new Exception("Required the clientId, secret and grantType is provider for access to Facebook Api");
            }
            else
            {

                AccessToken = GetAccessToken(clientId, secret, grantType);
            }
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
                throw new Exception("Error making request for get access token, more details inner exception", new FacebookException(content));
            }
            var token = JsonConvert.DeserializeObject<Token>(content);
            return token.access_token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string GetQueryString(object model)
        {
            if (model == null)
            {
                return "";
            }
            else
            {
                var queryString =
                    string.Join("&", model.GetType().GetProperties().Select(p => GetFieldName(p) + "=" + GetFieldValue(p, model)));

                return queryString;
            }
        }
        /// <summary>
        /// Serialize Model in Json Values
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private StringContent GetPayload(object parameters)
        {
            var json = JsonConvert.SerializeObject(parameters);
            JObject jsonObject = JObject.FromObject(parameters);
            jsonObject.Add("acess_token", AccessToken);

            return new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");
        }
        public object Get(string endpoint, object parameters)
        {
            var queryStringParameters = GetQueryString(parameters);
            var response = _httpClient.GetAsync($"{endpoint}?access_token={AccessToken}{queryStringParameters}").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new FacebookException(content));
            }

            return content;
        }

        public async Task<object> GetAsync(string endpoint, object parameters)
        {
            var queryStringParameters = GetQueryString(parameters);
            var response = await _httpClient.GetAsync($"{endpoint}?access_token={AccessToken}&{queryStringParameters}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new FacebookException(content));
            }

            return content;
        }


        public object Post(string endpoint, object parameters)
        {
            var body = GetPayload(parameters);
            var response =  _httpClient.PostAsync($"{endpoint}?access_token={AccessToken}", body).Result;
            var content =  response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
               
                throw new Exception("Error making request, more detail inner exception", new FacebookException(content));
            }

            return content;
        }

        public async Task<object> PostAsync(string endpoint, object parameters)
        {
            var body = GetPayload(parameters);
            var response = await _httpClient.PostAsync($"{endpoint}?access_token={AccessToken}", body);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error making request, more detail inner exception", new FacebookException(content));
            }

            return content;
        }
        
        /// <summary>
        /// Get FieldName of Object and Retrive the propertyName in JsonPropertyAttribute
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private string GetFieldName(PropertyInfo property)
        {
           
            var attrType = typeof(JsonPropertyAttribute);
            var customAttribute = property.GetCustomAttributes(attrType, false).FirstOrDefault();
            if (customAttribute != null)
            {
                return ((JsonPropertyAttribute)customAttribute).PropertyName;
            }


            return property.Name;//Regex.Replace(name, "([A-Z])", "_$1").ToLower();
        }
        /// <summary>
        /// Get FieldValue from model
        /// </summary>
        /// <param name="property"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private string GetFieldValue(PropertyInfo property, object model)
        {
            var attrType = typeof(JsonConverterAttribute);
            var customAttribute = property.GetCustomAttributes(attrType, false).FirstOrDefault();
            if (customAttribute != null)
            {
                var typeofConvert = ((JsonConverterAttribute)customAttribute).ConverterType;
                //p.GetValue(model, null)
                return Enum.GetName(typeofConvert, property.GetValue(model, null));
            }


            return property.GetValue(model, null).ToString();//Regex.Replace(name, "([A-Z])", "_$1").ToLower();


        }
    }
}

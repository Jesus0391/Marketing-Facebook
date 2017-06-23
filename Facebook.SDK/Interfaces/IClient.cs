using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Interfaces
{
    public interface IClient
    {
        object Get(string endpoint, object parameters);
        Task<object> GetAsync(string endpoint, object parameters);

        //Post Methods
        object Post(string endpoint, object parameters);
        Task<object> PostAsync(string endpoint, object parameters);
    }

    public interface IFacebookClient : IClient
    {
        string GetAccessToken(string clientId, string secret, string grantType);
        string AccessToken { get; set; }
        string Version { get; set; }
    }
}

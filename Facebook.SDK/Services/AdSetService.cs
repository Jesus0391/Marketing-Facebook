using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Facebook.Models;
using JAM.Facebook.Models;
using Facebook.Interfaces;
using Facebook.SDK.Response;

namespace Facebook.SDK.Services
{
    public class AdSetService : BaseService, IAdSetService
    {
        private const string ENDPOINT = "adsets";
        public AdSetService(string version, string clientId,
                                    string secret, string grantType) : 
                                        base(version, clientId, secret, grantType)
        {

        }
        public AdSetService(IFacebookClient client) : base(client)
        {

        }
      
        public List<AdSet> List(string accountId)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new Exception("The account id is empty");
            }
            accountId = GetAccount(accountId);
            var adsets = _client.Get($"{accountId}/{ENDPOINT}", new  {
                fields = "id,name"
            }).ToString().JsonToObject<List<AdSet>>();
          
            return adsets;
        }

        public string Create(string accountId, AdSet model)
        {
            if (string.IsNullOrEmpty(accountId))
            {
                throw new Exception("The account id is empty");
            }
            accountId = GetAccount(accountId);
            var adset = _client.Get($"{accountId}/{ENDPOINT}", new
            {
                fields = "id,name"
            }).ToString().JsonToObject<ResponseShared>();

            return adset.Id;
        }
    }
}

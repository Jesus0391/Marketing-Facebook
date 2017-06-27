using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Facebook.Models;
using JAM.Facebook.Models;
using Facebook.Interfaces;

namespace Facebook.SDK.Services
{
    public class AdSetService : BaseService, IAdSetService
    {
        private const string ENDPOINT = "adcampaigns";
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
            var list = new List<AdSet>();
            if (string.IsNullOrEmpty(accountId))
            {
                throw new Exception("The account id is empty");
            }
            accountId = GetAccount(accountId);
            dynamic adsets = _client.Get($"{accountId}/{ENDPOINT}", new  {
                fields = new AdSet()
            });
            foreach (var adset in adsets.data)
            {
                list.Add(new AdSet()
                {

                });
            }
            return null;
        }

        public string Create(string accountId, AdSet model)
        {
            throw new NotImplementedException();
        }
    }
}

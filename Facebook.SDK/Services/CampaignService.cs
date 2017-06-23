using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using JAM.Facebook.Models;
using Facebook.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Facebook.SDK.Services
{
    public class CampaignService : BaseService, ICampaignService
    {
        private const string ENDPOINT = "campaigns";
        public CampaignService(string version, string clientId,
                                    string secret, string grantType) : 
                                        base(version, clientId, secret, grantType)
        {

        }
        public CampaignService(IFacebookClient client) : base(client)
        {

        }

        public string Create(string accountId, Campaign campaign)
        {
         
            _results = new List<ValidationResult>();
            _validationContext = new ValidationContext(campaign);
            var isValid = Validator.TryValidateObject(campaign, _validationContext, _results);
            string id = "";
            if (!isValid)
            {
                throw new Exception("The Campaign is invalid model, more inner exception", new Exception(GetErrorsMesages()));
            }
            //accountId = GetAccount(accountId);
            //Valid Rules for Create Campaigns based in Facebook Api. 
            if (campaign != null && !string.IsNullOrEmpty(accountId))
            {
                dynamic response = _client.Post($"act_{accountId}/{ENDPOINT}", campaign);
                id = (string)response.id;
                if (string.IsNullOrEmpty(id))
                {
                    throw new Exception("Error to trying saved campaign in Facebook");
                }
            }
            return id;

        }

        public List<Campaign> List(string accountId)
        {
            if (string.IsNullOrEmpty(accountId)) {
                throw new Exception("The account id is empty");
            }
            dynamic campaigns = _client.Get($"{accountId}/{ENDPOINT}", null);
            return null;
        }
    }
}

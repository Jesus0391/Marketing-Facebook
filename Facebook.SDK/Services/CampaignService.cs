using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using JAM.Facebook.Models;
using Facebook.Interfaces;
using System.ComponentModel.DataAnnotations;
using Facebook.SDK.Response;
using Facebook.Models;
using Facebook.Models.Enums;

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
        /// <summary>
        /// Create Campaign 
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="campaign"></param>
        /// <returns></returns>
        public string Create(string accountId, Campaign campaign)
        {
         
            _results = new List<ValidationResult>();
            _validationContext = new ValidationContext(campaign);
            var isValid = Validator.TryValidateObject(campaign, _validationContext, _results);
            ResponseShared response = null;
            if (!isValid)
            {
                throw new Exception("The Campaign is invalid model, more inner exception", new Exception(GetErrorsMesages()));
            }
            accountId = GetAccount(accountId);
            //Valid Rules for Create Campaigns based in Facebook Api. 
            if (campaign != null && !string.IsNullOrEmpty(accountId))
            {
                 response = ((string)_client.Post($"{accountId}/{ENDPOINT}", campaign)).JsonToObject<ResponseShared>(ResponseType.Other);
               
                if (response == null || string.IsNullOrEmpty(response.Id))
                {
                    throw new Exception("Error to trying saved campaign in Facebook");
                }
            }
            return response.Id;

        }

        /// <summary>
        /// Get Campaigns 
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<Campaign> List(string accountId)
        {
            if (string.IsNullOrEmpty(accountId)) {
                throw new Exception("The account id is empty");
            }
            List<Campaign> campaigns = ((string)_client.Get($"{accountId}/{ENDPOINT}", null)).JsonToObject<List<Campaign>>();
           
            return campaigns;
        }

        public List<AdSet> GetAdSets(string campaignId)
        {
            throw new NotImplementedException();
        }

        public bool Update(string accountID, Campaign model)
        {
            throw new NotImplementedException();
        }
    }
}

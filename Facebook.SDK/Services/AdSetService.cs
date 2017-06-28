using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Facebook.Models;
using JAM.Facebook.Models;
using Facebook.Interfaces;
using Facebook.SDK.Response;
using Facebook.Models.Enums;
using System.ComponentModel.DataAnnotations;

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

        public string Create(string accountId, AdSet adset)
        {
            _results = new List<ValidationResult>();
            _validationContext = new ValidationContext(adset);
            var isValid = Validator.TryValidateObject(adset, _validationContext, _results);
            ResponseShared response = null;
            if (!isValid)
            {
                throw new Exception("The Campaign is invalid model, more inner exception", new Exception(GetErrorsMesages()));
            }
            accountId = GetAccount(accountId);
            //Valid Rules for Create Campaigns based in Facebook Api. 
            if (adset != null && !string.IsNullOrEmpty(accountId))
            {
                try
                {
                    response = ((string)_client.Post($"{accountId}/{ENDPOINT}", adset)).JsonToObject<ResponseShared>(ResponseType.Other);

                    if (response == null || string.IsNullOrEmpty(response.Id))
                    {
                        throw new Exception("Error to trying saved adset in Facebook");
                    }
                }catch(Exception e)
                {
                    throw e;
                }
            }
            return response.Id;
        }
    }
}

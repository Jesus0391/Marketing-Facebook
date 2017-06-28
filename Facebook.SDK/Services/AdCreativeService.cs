using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Facebook.Models;
using Facebook.Interfaces;
using System.ComponentModel.DataAnnotations;
using Facebook.SDK.Response;
using Facebook.Models.Enums;

namespace Facebook.SDK.Services
{
    public class AdCreativeService : BaseService, IAdCreativeService
    {
        private const string ENDPOINT = "adcreatives";
        public AdCreativeService(string version, string accessToken) : base(version, accessToken)
        {
           
        }
        /// <summary>
        /// Get Service with Facebook Client and acess token
        /// </summary>
        /// <param name="version"></param>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <param name="grantType"></param>
        public AdCreativeService(string version, string clientId,
                                    string secret, string grantType) : base(version, clientId, secret, grantType)
        {
           
        }

        public AdCreativeService(IFacebookClient client) : base(client)
        {
          
        }
        public string Create(string accountId, AdCreative model)
        {
            _results = new List<ValidationResult>();
            _validationContext = new ValidationContext(model);
            var isValid = Validator.TryValidateObject(model, _validationContext, _results);
            ResponseShared response = null;
            if (!isValid)
            {
                throw new Exception("The Campaign is invalid model, more inner exception", new Exception(GetErrorsMesages()));
            }
            accountId = GetAccount(accountId);
            //Valid Rules for Create Campaigns based in Facebook Api. 
            if (model != null && !string.IsNullOrEmpty(accountId))
            {
                try
                {
                    response = ((string)_client.Post($"{accountId}/{ENDPOINT}", model)).JsonToObject<ResponseShared>(ResponseType.Other);

                    if (response == null || string.IsNullOrEmpty(response.Id))
                    {
                        throw new Exception("Error to trying saved adset in Facebook");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return response.Id;
        }

        public List<AdCreative> List(string accountId)
        {
            throw new NotImplementedException();
        }

        public bool Update(string id, AdCreative model)
        {
            throw new NotImplementedException();
        }
    }
}

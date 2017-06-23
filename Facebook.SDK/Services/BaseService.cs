using Facebook.Client;
using Facebook.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Facebook.SDK.Services
{
    public abstract class BaseService
    {
        protected IFacebookClient _client;
        protected List<ValidationResult> _results;
        protected ValidationContext _validationContext;

        //Constructs 
        private BaseService(string version)
        {
           // _client = new FacebookClient(version);
        }
        public BaseService(string version, string accessToken)
        {
            _client = new FacebookClient(version, accessToken);
        }
        /// <summary>
        /// Get Service with Facebook Client and acess token
        /// </summary>
        /// <param name="version"></param>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <param name="grantType"></param>
        public BaseService(string version, string clientId,
                                    string secret, string grantType)
        { 
            _client = new FacebookClient(version, clientId, secret, grantType);
        }

        public BaseService(IFacebookClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Get Errors Messages for Validations
        /// </summary>
        /// <returns></returns>
        protected string GetErrorsMesages()
        {
            var messages = "";
            if (_results != null)
            {
             
                foreach(var result in _results)
                {
                    messages += result.ErrorMessage + "\n";
                }
            }
            return messages;
        }

        public string GetAccount(string customerId)
        {
            if (customerId != "")
            {
                dynamic account;
                try
                {
                    account = _client.Get($"/{customerId}/", new
                    {
                        fields = "account_id"
                    });
                }
                catch (Exception ex)
                {
                    account = _client.Get($"/act_{customerId}/", new { fields = "account_id" });
                }
                return "act_" + (string)account.account_id;
            }
            else
            {
                throw new Exception("The customerId can't be empty");
            }

        }



    }
}

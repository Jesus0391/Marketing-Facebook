using Facebook.Client;
using Facebook.Models.Interfaces;
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

        public BaseService(string version)
        {
            _client = new FacebookClient(version);
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




    }
}

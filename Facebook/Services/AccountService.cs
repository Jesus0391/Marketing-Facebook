using Facebook.Interfaces;
using Facebook.Models.Page;
using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public const string ENDPOINT = "accounts";

        public AccountService(IFacebookClient client) : base(client) { }
        public AccountService(string version, string clientId,
                                    string secret, string grantType) : base(version, clientId, secret, grantType)
        {
        }

        
        public List<BusinessPageAccount> GetAccounts(int limit = 100000)
        {
            //if (string.IsNullOrEmpty(accountId))
            //{
            //    throw new Exception("The account id is empty");
            //}
            var accounts = ((string)_client.Get($"me/{ENDPOINT}", new { fields = "business, name, perms", limit = limit })).JsonToObject<List<BusinessPageAccount>>();

            return accounts;
        }
  
    }
}

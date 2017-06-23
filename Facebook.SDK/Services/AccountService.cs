using Facebook.Interfaces;
using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IFacebookClient client) : base(client) { }
        public AccountService(string version, string clientId,
                                    string secret, string grantType) : base(version, clientId, secret, grantType)
        {
        }

  
    }
}

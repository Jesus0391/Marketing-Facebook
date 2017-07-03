using Facebook.Models.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Interfaces
{
    public interface IAccountService
    {
        string GetAccount(string customerId);
        /// <summary>
        /// Get All Accounts about current
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        List<BusinessPageAccount> GetAccounts(int limit = 100000);
    }
}

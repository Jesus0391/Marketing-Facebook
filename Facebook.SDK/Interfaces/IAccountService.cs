using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Interfaces
{
    public interface IAccountService
    {
        string GetAccount(string customerId);
    }
}

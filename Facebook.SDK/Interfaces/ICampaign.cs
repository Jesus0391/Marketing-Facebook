using JAM.Facebook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Interfaces
{
    public interface ICampaign
    {
        string Create(string accountId, Campaign campaign);
        //List<Campaign> 
    }
}

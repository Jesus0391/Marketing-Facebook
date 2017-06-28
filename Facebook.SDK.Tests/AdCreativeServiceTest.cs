using Facebook.Client;
using Facebook.Interfaces;
using Facebook.Models;
using Facebook.SDK.Interfaces;
using Facebook.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Tests
{
    [TestClass]
    public class AdCreativeServiceTest
    {

        [TestMethod]
        public void CreateAdCreative()
        {
            //Act
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");
            //Services

            IAdCreativeService adsetService = new AdCreativeService(client);
            AdCreative creative = new AdCreative();
            //adset.CampaignId = "23842604565950113";
            creative.Title = "Create Posts";
        }
    }
}

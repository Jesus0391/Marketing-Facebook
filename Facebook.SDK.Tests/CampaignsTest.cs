using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facebook.Models.Interfaces;
using Facebook.Client;
using Facebook.SDK.Interfaces;
using Facebook.SDK.Services;
using JAM.Facebook.Models;

namespace Facebook.SDK.Tests
{
    [TestClass]
    public class CampaignsTest
    {
        [TestMethod]
        public void CreateCampaign()
        {
            //Act
            IFacebookClient client = new FacebookClient("2.9");

            //Services
            ICampaign campaignService = new CampaignService(client);

            //The Campaign Test
            Campaign model = new Campaign();
            model.Name = "Test from new APi";
            model.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            model.Objective = JAM.Facebook.Models.Enums.Objective.LINK_CLICKS;

            campaignService.Create("32323", model);

        }
    }
}

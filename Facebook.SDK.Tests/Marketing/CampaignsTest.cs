using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facebook.Interfaces;
using Facebook.Client;
using Facebook.SDK.Interfaces;
using Facebook.SDK.Services;
using JAM.Facebook.Models;
using Facebook.Models;

namespace Facebook.SDK.Tests
{
    [TestClass]
    public class CampaignsTest
    {
       
        [TestMethod]
        public void CreateCampaign()
        {
            //Act
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAHr5S7bGsX8G6fht6BE8NEm2tOAcI8k6tWTIA1GzwSlOh1U9ZAghSIivmmMtZBYlkaIQGV3FXAaK6e6R3WH1rxmGgo2UPLcts2v5TLH3ccUtEZAN1UDZBABLmd85x1EmcG1sJaywpxA0VZCa76j8ZD");
            //Services
            ICampaignService campaignService = new CampaignService(client);

            //The Campaign Test
            Campaign model = new Campaign();
            model.Name = "Test from new API Engagement";
            model.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            model.Objective = JAM.Facebook.Models.Enums.Objective.POST_ENGAGEMENT;
            model.SpendCap = 10000;
            var response = campaignService.Create("10155310538728783", model);

            Assert.AreNotSame("", response);

        }

        
        public void GetCampaignsByAccount()
        {
            //Act 
            IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            //IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAHr5S7bGsX8G6fht6BE8NEm2tOAcI8k6tWTIA1GzwSlOh1U9ZAghSIivmmMtZBYlkaIQGV3FXAaK6e6R3WH1rxmGgo2UPLcts2v5TLH3ccUtEZAN1UDZBABLmd85x1EmcG1sJaywpxA0VZCa76j8ZD");
            //Services
            ICampaignService campaignService = new CampaignService(client);

            //The List Campaign Test

            var response = campaignService.List("10155310538728783");
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0, "Return a list of Campaigns");
        }

    }
}

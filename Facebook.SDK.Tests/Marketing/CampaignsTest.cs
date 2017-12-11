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
            IFacebookClient client = new FacebookClient("2.10", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services
            ICampaignService campaignService = new CampaignService(client);

            //The Campaign Test
            Campaign model = new Campaign();
            model.Name = "Test from new API Engagement";
            model.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            model.Objective = JAM.Facebook.Models.Enums.Objective.POST_ENGAGEMENT;
            model.SpendCap = 10000;
            var response = campaignService.Create("10155310538728783", model); //INSA

            Assert.AreNotSame("", response);

        }

        [TestMethod]
        public void CreateCampaignReach()
        {
            //Act
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services
            ICampaignService campaignService = new CampaignService(client);

            //The Campaign Test
            Campaign model = new Campaign();
            model.Name = "Test from new API Engagement";
            model.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            model.Objective = JAM.Facebook.Models.Enums.Objective.REACH;
            model.BuyingType = JAM.Facebook.Models.Enums.BuyingType.AUCTION;
            model.SpendCap = 10000;
            var response = campaignService.Create("10155310538728783", model);

            Assert.AreNotSame("", response);

        }
        [TestMethod]
        public void GetCampaignsByAccount()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services
            ICampaignService campaignService = new CampaignService(client);

            //The List Campaign Test

            var response = campaignService.List("act_10155310538728783");
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0, "Return a list of Campaigns");
        }

    }
}

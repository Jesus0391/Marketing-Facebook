using Facebook.Client;
using Facebook.Interfaces;
using Facebook.Models;
using Facebook.Models.Enums;
using Facebook.SDK.Interfaces;
using Facebook.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Tests
{
    [TestClass]
    public class AdSetServiceTest
    {
        [TestMethod]
        public void VerifyAdSetResponse()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");

            //Service 
            IAdSetService adsetService = new AdSetService(client);

            var response = adsetService.List("10155310538728783");

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void CreateAdSetDefaultSettings()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.10", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services

            IAdSetService adsetService = new AdSetService(client);
            AdSet adset = new AdSet();
            adset.CampaignId = "23842707904700113";
          

            adset.DailyBudget = 500; //5.00 Dollarss
            adset.StartTime = DateTime.Now;
            adset.EndTime = DateTime.Now.AddDays(3);
            adset.Name = "Auto AdSet Configuration";
            adset.BillingEvent = BillingEvent.POST_ENGAGEMENT;
            adset.OptimizationGoal = OptimizationGoal.POST_ENGAGEMENT;
            adset.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            adset.IsAutoBid = true; //Automatic Delivery
            adset.Targeting = new
            {
                geo_locations = new
                {
                    countries = new[] { "DO" }
                },
                publisher_platforms = new string[] { "facebook" },
                age_min = 18,
                age_max = 65
            };
            //{

            //};
            var response = adsetService.Create("10155310538728783", adset);

            Assert.AreNotSame("", response);
        }
        [TestMethod]
        public void CreateAdSetManualSettings()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services
          
            IAdSetService adsetService = new AdSetService(client);
            AdSet adset = new AdSet();
            adset.CampaignId = "23842604565950113";
            adset.BidAmount = 1;//100 = 1.00 Dollars for Clicks

            adset.DailyBudget = 500; //5.00 Dollarss
            adset.StartTime = DateTime.Now;
            //adset.CampaignId = "";
            adset.EndTime = DateTime.Now.AddDays(3);
            adset.Name = "Auto AdSet Configuration";
            adset.BillingEvent = BillingEvent.LINK_CLICKS;
            adset.OptimizationGoal = OptimizationGoal.LINK_CLICKS;
            adset.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            adset.IsAutoBid = false; //Automatic Delivery
            adset.Targeting = new
            {
                geo_locations = new
                {
                    countries = new[] { "US" }
                },
                publisher_platforms = new string[] { "facebook" },
                age_min = 18,
                age_max = 65
            };
            //{

            //};
            var response = adsetService.Create("10155310538728783", adset);

            Assert.AreNotSame("", response);
        }

        [TestMethod]
        public void CreateAdSetReachSettings()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services

            IAdSetService adsetService = new AdSetService(client);
            AdSet adset = new AdSet();
            adset.CampaignId = "23842605921670113";


            adset.DailyBudget = 500; //5.00 Dollarss
            adset.StartTime = DateTime.Now;
            adset.EndTime = DateTime.Now.AddDays(3);
            adset.Name = "Auto AdSet Configuration";
            adset.BillingEvent = BillingEvent.POST_ENGAGEMENT;
            adset.OptimizationGoal = OptimizationGoal.REACH;
            adset.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            adset.IsAutoBid = true; //Automatic Delivery
            adset.Targeting = new
            {
                geo_locations = new
                {
                    countries = new[] { "DO" }
                },
                publisher_platforms = new string[] { "facebook" },
                age_min = 18,
                age_max = 65
            };
            //{

            //};
            var response = adsetService.Create("10155310538728783", adset);

            Assert.AreNotSame("", response);
        }

        [TestMethod]
        public void UpdateNormalAdSet()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services

            IAdSetService adsetService = new AdSetService(client);
            AdSet adset = new AdSet();
            //Update important parameters
            adset.AccountId = "23842605478110113"; //Customer Account
            adset.CampaignId = "23842604565950113"; //Campaign ID

            adset.BidAmount = 100;//100 = 1.00 Dollars for Clicks
            adset.DailyBudget = 500; //5.00 Dollarss
          
            adset.Name = "Auto AdSet Configuration";
            adset.BillingEvent = BillingEvent.POST_ENGAGEMENT;
            adset.OptimizationGoal = OptimizationGoal.POST_ENGAGEMENT;
            adset.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            adset.IsAutoBid = false; //Automatic Delivery
            adset.Targeting = new
            {
                geo_locations = new
                {
                    countries = new[] { "DO" }
                },
                publisher_platforms = new string[] { "facebook",  "audience_network" }, //Limita ejemplo: Facebook, Instagram, Sponsons, etc.. (Ver API)
                age_min = 18,
                age_max = 65
            };
            //{

            //};
            var response = adsetService.Update("23842605478170113", adset);

            Assert.IsTrue(response);
        }

        [TestMethod]
        public void UpdateAutoBidAdSet()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services

            IAdSetService adsetService = new AdSetService(client);
            AdSet adset = new AdSet();
            //Update important parameters
            adset.AccountId = "10155310538728783"; //Customer Account
            adset.CampaignId = "23842604565950113"; //Campaign ID

            //adset.BidAmount = 100;//100 = 1.00 Dollars for Clicks
            adset.OptimizationGoal = OptimizationGoal.LINK_CLICKS;
            adset.BillingEvent = BillingEvent.LINK_CLICKS;
            adset.IsAutoBid = true; //Automatic Delivery
        
            var response = adsetService.Update("23842604628310113", adset);

            Assert.IsTrue(response);
        }


    }
}

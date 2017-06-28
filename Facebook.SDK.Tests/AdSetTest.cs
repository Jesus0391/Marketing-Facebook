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
    public class AdSetTest
    {
        [TestMethod]
        public void VerifyAdSetResponse()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");

            //Service 
            IAdSetService adsetService = new AdSetService(client);

            var response = adsetService.List("10155310538728783");

            Assert.IsNotNull(response);
        }
        [TestMethod]
        public void CreateAdSet()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");
            //Services
            /*
              var account = GetFacebookAccount(id);
            countries = new[] { "US"};
            var parameters = new
            {
                name = adset.Name,
                bid_amount = 100,
                daily_budget = 300, 
                campaign_id = 23842599207010113,
                billing_event = Enum.GetName(typeof(BillingEvent), BillingEvent.IMPRESSIONS)
                ,
                targeting = new
                {
                    geo_locations = new
                    {
                        countries = countries
                    },
                    publisher_platforms = new string[] { "facebook" },
                    age_min = 18,
                    age_max = 40

                },
                is_autobid = false,
            }
             */
            IAdSetService adsetService = new AdSetService(client);
            AdSet adset = new AdSet();
            adset.CampaignId = "23842604565950113";
            adset.BidAmount = 30;
            adset.StartTime = DateTime.Now;
            adset.CampaignId = "";
            adset.EndTime = DateTime.Now.AddDays(3);
            adset.Name = "Auto AdSet Configuration";
            adset.BillingEvent = BillingEvent.LINK_CLICKS;
            adset.OptimizationGoal = OptimizationGoal.LINK_CLICKS;
            adset.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            adset.IsAutoBid = false;
            adset.Targeting = new
            {
                geo_locations = new
                {
                    countries = new[] { "US" }
                },
                publisher_platforms = new string[] { "facebook" },
                age_min = 18,
                age_max = 40
            };
            //{

            //};
            var response = adsetService.Create("10155310538728783", adset);

            Assert.AreNotSame("", response);
        }


    }
}

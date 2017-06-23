using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facebook.Interfaces;
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
        public void ListCampaigns()
        {
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");
            //Services
            ICampaignService campaignService = new CampaignService(client);

            //The Campaign Test
            Campaign model = new Campaign();
            model.Name = "Test from new APi";
            model.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            model.Objective = JAM.Facebook.Models.Enums.Objective.LINK_CLICKS;

            var campaigns = campaignService.List("act_10155310538728783");

            Assert.IsNotNull(campaigns);
            Assert.IsTrue(campaigns.Count > 0);
        }
        [TestMethod]
        public void CreateCampaign()
        {
            //Act
            //          <add key="FACEBOOK_CLIENT_ID" value="1057652130914324" />
            //<add key="FACEBOOK_CLIENT_SECRET" value="9ffc28c2a12d447cb5132995656ac92c" />
            //<add key="FACEBOOK_GRANT_TYPE" value="client_credentials" />
            //<add key="FACEBOOKTOKEN" value="EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD" />
            IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            //IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");
            //Services
            ICampaignService campaignService = new CampaignService(client);

            //The Campaign Test
            Campaign model = new Campaign();
            model.Name = "Test from new APi";
            model.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            model.Objective = JAM.Facebook.Models.Enums.Objective.LINK_CLICKS;

            var response = campaignService.Create("10155310538728783", model);

            Assert.AreNotSame("", response);

        }

    }
}

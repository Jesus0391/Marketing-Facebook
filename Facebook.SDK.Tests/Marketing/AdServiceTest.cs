using Facebook.Client;
using Facebook.Interfaces;
using Facebook.Models;
using Facebook.SDK.Interfaces;
using Facebook.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Tests.Marketing
{
    [TestClass]
    public class AdServiceTest
    {
        [TestMethod]
        public void CreateAdPostEngdment()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");

            //Service 
            IAdService service = new AdService(client);

            //Create
            Ad ad = new Ad();
            ad.Name = "Test AD";
            ad.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            ad.AdSetId = 23842605921750113; //Post Engag
            
            ad.Creative = new AdCreative()
            {
                CreativeId = "23842605023090113" //Este creative ya existia y se habia creado anteriormente
                // CreativeId = "23842605023090113" //Se creo este creative pero hay que averiguar que clase de post aplica para LINK_CLICK 
            };
            var response = service.Create("10155310538728783", ad);

            Assert.IsNotNull(response); //Ads Create for APi: 23842605030960113
        }

        [TestMethod]
        public void CreateAdReach()
        {
            //Act 
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");

            //Service 
            IAdService service = new AdService(client);

            //Create
            Ad ad = new Ad();
            ad.Name = "Test AD";
            ad.Status = JAM.Facebook.Models.Enums.Status.PAUSED;
            ad.AdSetId = 23842605921750113; //Post Engag

            ad.Creative = new AdCreative()
            {
                CreativeId = "23842605023090113" //Este creative ya existia y se habia creado anteriormente
                // CreativeId = "23842605023090113" //Se creo este creative pero hay que averiguar que clase de post aplica para LINK_CLICK 
            };
            var response = service.Create("10155310538728783", ad);

            Assert.IsNotNull(response); //Ads Create for APi: 23842605030960113
        }
        public void GetAds()
        {

        }
    }
}

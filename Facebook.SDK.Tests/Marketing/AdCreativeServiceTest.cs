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
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services

            IAdCreativeService adsetService = new AdCreativeService(client);
            AdCreative creative = new AdCreative();
            creative.Name = "Test API POst"; //Este nombre puede ser dado posteriormente
            creative.ObjectStoryId = "732881306823664_1203458439765946"; //Post que se quiere crear debe ser el mismo que esta en el unpublish

            var response =  adsetService.Create("10155310538728783", creative);

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void GetCreativesByAccount()
        {
            //https://graph.facebook.com/v2.9/act_<AD_ACCOUNT_ID>/adcreatives

            //Act
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");
            //Services

            IAdCreativeService adsetService = new AdCreativeService(client);

            var response =  adsetService.List("10155310538728783");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0, "The request should be return almost 1 ad creative");
        }
    }
}

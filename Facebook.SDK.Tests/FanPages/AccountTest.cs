using Facebook.Client;
using Facebook.Interfaces;
using Facebook.SDK.Interfaces;
using Facebook.SDK.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Tests.FanPages
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void GetAllAccounts()
        {
            //Act
            //IFacebookClient client = new FacebookClient("2.9", "1057652130914324", "9ffc28c2a12d447cb5132995656ac92c", "client_credentials");
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");

            //Service
            IAccountService service = new AccountService(client);

            //Assert
            var response = service.GetAccounts();

            Assert.IsNotNull(response, "Error to trying accounts");
        }
    }
}

using Facebook.Client;
using Facebook.Interfaces;
using Facebook.Models.Interfaces;
using Facebook.Services.Page;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Tests.FanPages
{
    [TestClass]
    public class FeedtServiceTest
    {

        [TestMethod]
        public void GetAllSchedulePosts()
        {
            //Act
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAMcBC4tDSqpbb1AWfYZAj3BZCoifcMgm3yOADpVWmonpa8drpMyiP6JPf3UAdYbpM4j6NmBIhzIBlF2NyAid1ecKvWWTNXvM8cNWCZBleZCZA2EONXXczk4nFdKtz99NB52POJARZAc2ArQtYEIi8ZD");

            //Service
            IPageFeedService service = new PageFeedService(client);

            //Assert
            var response = service.GetPromotablePosts("732881306823664");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0, "The page should be return almost 1 post");
            
        }
    }
}

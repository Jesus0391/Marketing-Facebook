using Facebook.Client;
using Facebook.Interfaces;
using Facebook.Models;
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
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");

            //Service
            IPageFeedService service = new PageFeedService(client);

            //Assert
            var response = service.GetPromotablePosts("732881306823664");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0, "The page should be return almost 1 post");
            
        }

        [TestMethod]
        public void GetAllPosts()
        {
            //Act
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");

            //Service
            IPageFeedService service = new PageFeedService(client);

            //Assert
            var response = service.List("732881306823664");

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0, "The page should be return almost 1 post");

        }

        [TestMethod]
        public void CreatePhotoPost()
        {
            //1476161685781570?fields=access_token&access_token
            IFacebookClient client = new FacebookClient("2.9", "EAANOERzv1jEBAAbnPmk9tZAY6lCUCk0Lyvu22ZBhOc8vVqDYvPScisavZCYJwepHxEvKmYENSBMnKORaXZA0mOj42SmLhUyR7WxWEP7GgiP4gfFk4WooCZARKrrudKg47vUaAm0NYBoAPVkfJ3CiFgu4b0lf39Iw1ZCiZBknTfsQQZDZD");

            //Service
            IPageFeedService service = new PageFeedService(client);

            //Assert
            var photo = new Photo();
            photo.Message = "¡Visita nuestra página web y conoce más sobre nuestros proyectos! Link http://bit.ly/2vMxRkk #CEMADOJA #Educación #Médica #SantoDomingo #RD";
            photo.Published = false;
            photo.Url = "https://assets.materialup.com/uploads/771196a5-dd77-4d29-98e2-117082907da1/preview.png";

            photo.SchedulePublishTime = DateTimeOffset.Now.AddDays(3).ToUnixTimeSeconds();
            var response = service.CreatePhotoPost("1476161685781570", photo);

            Assert.IsNotNull(response, "The method shoul be return Post Id");
        }

    }
}

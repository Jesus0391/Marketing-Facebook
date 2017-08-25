using Facebook.Models.Interfaces;
using Facebook.SDK.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Facebook.Models;
using Facebook.Interfaces;

namespace Facebook.Services.Page
{
    /// <summary>
    /// https://developers.facebook.com/docs/graph-api/reference/page/feed
    /// </summary>
    public class PageFeedService : BaseService, IPageFeedService
    {
        private const string ENDPOINT = ""; //Missing definitions for Feed in 
        public PageFeedService(string version, string accessToken) : base(version, accessToken)
        {
           
        }
        /// <summary>
        /// Get Service with Facebook Client and acess token
        /// </summary>
        /// <param name="version"></param>
        /// <param name="clientId"></param>
        /// <param name="secret"></param>
        /// <param name="grantType"></param>
        public PageFeedService(string version, string clientId,
                                    string secret, string grantType) : base(version, clientId, secret,grantType)
        {
           
        }

        public PageFeedService(IFacebookClient client) : base(client)
        {
          
        }
        public string Create(string accountId, Post model)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetPromotablePosts(string pageAccountId)
        {

            //pageAccountId = GetAccount(accountId);
            //Valid Rules for Create Campaigns based in Facebook Api. 
            List<Post> response = null;
            if (pageAccountId != null && !string.IsNullOrEmpty(pageAccountId))
            {
                try
                {
                    response = ((string)_client.Get($"{pageAccountId}/promotable_posts", new
                    {
                        fields = "id,object_id,scheduled_publish_time,message,picture,permalink_url,is_published,created_time",
                        is_published = false
                    })).JsonToObject<List<Post>>();

                    if (response == null)
                    {
                        throw new Exception("Error to trying get promotable Posts at Fan Page Facebook");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return response;
            }
            else
            {
                throw new Exception("Error to trying get promotable Posts at Fan Page Facebook, the page Account is empty!");
            }
        }
        public List<Post> List(string pageAccountId)
        {
            List<Post> response = null;
            if (pageAccountId != null && !string.IsNullOrEmpty(pageAccountId))
            {
                try
                {
                    response = ((string)_client.Get($"{pageAccountId}/posts", new
                    {
                        fields = "id,object_id,scheduled_publish_time,message,picture,permalink_url,is_published,created_time",
                        limit="100"
                    })).JsonToObject<List<Post>>();

                    if (response == null)
                    {
                        throw new Exception("Error to trying get promotable Posts at Fan Page Facebook");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return response;
            }
            else
            {
                throw new Exception("Error to trying get promotable Posts at Fan Page Facebook, the page Account is empty!");
            }
        }

        public bool Update(string id, Post model)
        {
            throw new NotImplementedException();
        }
    }
}

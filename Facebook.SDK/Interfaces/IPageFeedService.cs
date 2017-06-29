using Facebook.SDK.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models.Interfaces
{
    public interface IPageFeedService : IService<Post>
    {
        /// <summary>
        /// shows only the posts that can be boosted (includes unpublished and scheduled posts).
        /// </summary>
        /// <param name="pageAccountId"></param>
        /// <returns></returns>
        List<Post> GetPromotablePosts(string pageAccountId);
        
    }
}

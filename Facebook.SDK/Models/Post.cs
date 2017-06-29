using Facebook.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models
{
    /// <summary>
    /// An individual entry in a profile's feed. The profile could be a user, page, app, or group.
    /// </summary>
    public class Post : IEntity
    {
        /// <summary>
        /// The post ID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Information about the app this post was published by.
        /// </summary>
        [JsonProperty("application")]
        public string Application { get; set; }

        /// <summary>
        /// ink caption in post that appears below name. 
        /// The caption must be an actual URLs and should accurately reflect the URL and associated advertiser or business someone visits when they click on it.
        /// </summary>
        [JsonProperty("caption")]
        public string Caption { get; set; }

        /// <summary>
        /// The time the post was initially published. For a post about a life event, this will be the date and time of the life event
        /// </summary>
        [JsonProperty("created_time")]
        public DateTime CreateTime { get; set; }

        ///// <summary> Feed Targeting ************************
        ///// Maximum age
        ///// </summary>
        //[JsonProperty("age_max")]
        //public int AgeMax { get; set; }

        ///// <summary>
        ///// Must be 13 or higher. Default is 0
        ///// </summary>
        //[JsonProperty("age_min")]
        //public int AgeMin { get; set; }

        ///// <summary>
        ///// Values of targeting cities. Use type of adcity to find Targeting Options and use the returned key to specify.
        ///// </summary>
        //[JsonProperty("cities")]
        //public int[] Cities { get; set; }

        ///// <summary>
        ///// Array of integers for graduation year from college.
        ///// </summary>
        //[JsonProperty("college_years")]
        //public int[] CollegeYears { get; set; }

        ///// <summary>
        ///// Values of targeting countries. You can specify up to 25 countries. Use ISO 3166 format codes.
        ///// </summary>
        //[JsonProperty("countries")]
        //public string[] Countries { get; set; }

        /// <summary>
        /// Information about the profile that posted the message.
        /// </summary>
        [JsonProperty("from")] //Profile type
        public object From { get; set; }

        /// <summary>
        /// A link to an icon representing the type of this post.
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Whether the post can be promoted on Instagram.
        /// It returns the enum "eligible" if it can be promoted. Otherwise it returns an enum for why it cannot be promoted
        /// </summary>
        [JsonProperty("instagram_eligibility")]
        public string InstagramEligibility { get; set; }

        /// <summary>
        /// If this post is marked as hidden (Applies to Pages only).
        /// </summary>
        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        /// <summary>
        /// Whether this post can be promoted in Instagram
        /// </summary>
        [JsonProperty("is_instagram_eligible")]
        public string IsInstagramEligible { get; set; }

        /// <summary>
        /// Indicates whether a scheduled post was published (applies to scheduled Page Post only, for users post and instantly published posts this value is always true).
        /// Note that this value is always false for page posts created as part of the Ad Creation process.
        /// </summary>
        [JsonProperty("is_published")]
        public bool IsPublished { get; set; }

        /// <summary>
        /// The link attached to this post.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }

        /// <summary>
        /// The status message in the post.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The name of the link.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of any uploaded photo or video attached to the post.
        /// </summary>
        [JsonProperty("object_id")]
        public string ObjectId { get; set; }
        
        /// <summary>
        /// The ID of a parent post for this post, if it exists. 
        /// For example, if this story is a 'Your Page was mentioned in a post' story, the parent_id will be the original post where the mention happened
        /// </summary>
        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        /// <summary>
        /// URL to the permalink page of the post.
        /// </summary>
        [JsonProperty("permalink_url")]
        public string PermanentLink { get; set; }

        /// <summary>
        /// The picture scraped from any link included with the post.
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Any location information attached to the post.
        /// </summary>
        [JsonProperty("place")]
        public String Place { get; set; }

        /// <summary>
        /// The shares count of this post. The share count may include deleted posts and posts you cannot see for privacy reasons.
        /// </summary>
        [JsonProperty("shares")]
        public object Shares { get; set; }

        /// <summary>
        /// A URL to any Flash movie or video file attached to the post.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// Description of the type of a status update.
        /// </summary>
        [JsonProperty("status_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PostStatusType StatusType { get; set; }

        /// <summary>
        /// Text from stories not intentionally generated by users, such as those generated when two people become friends, or when someone else posts on the person's wall.
        /// </summary>
        [JsonProperty("story")]
        public string Story { get; set; }

        /// <summary>
        /// A string indicating the object type of this post.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PostType PostType { get; set; }

        /// <summary>
        /// he time when the post was created, last edited or the time of the last comment that was left on the post.
        /// For a post about a life event, this will be the date and time of the life event
        /// </summary>
        [JsonProperty("updated_time")]
        public DateTime UpdatedTime { get; set; }

        /// <summary>
        /// Profiles tagged as being 'with' the publisher of the post.
        /// </summary>
        [JsonProperty("with_tags")]
        public object Tags { get; set; }

        [JsonProperty("scheduled_publish_time")]
        public Int64 SchedulePublishTime { get; set; }

        [JsonIgnore]
        public DateTime SchedulePublish
        {
            get
            {
                DateTime time = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                if (SchedulePublishTime != 0)
                {
                    time = time.AddSeconds(SchedulePublishTime).ToLocalTime();
                   
                }
                return time;
            }
        }
    }
}

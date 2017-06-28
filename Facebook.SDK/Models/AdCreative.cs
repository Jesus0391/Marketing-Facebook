using Facebook.Enums;
using Facebook.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models
{
    /// <summary>
    /// Format which provides layout and contains content for the ad
    /// </summary>
    public class AdCreative : IEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The Facebook object ID that is the actor for a link ad (not connected to a Page)
        /// </summary>
        [JsonProperty("actor_id")]
        public Int64? ActorId { get; set; }

        /// <summary>
        /// Deep link fallback behavior for dynamic product ads if the app is not installed.
        /// </summary>
        [JsonProperty("applink_treatment")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LinkTreatment LinkTreatment { get; set; }

        /// <summary>
        /// The body ad of the ad
        /// </summary>
        [JsonProperty("body")]
        public string Body { get; set; }

        //[JsonProperty("call_to_action")]
        //public CallToAction CallToAction { get=> throw NotImplementedException; set=> throw NotImplementedException; }

        /// <summary>
        /// DynamicAdVoice
        /// </summary>
        [JsonProperty("dynamic_ad_voice")]
        public DynamicAdVoice DynamicAdVoice { get; set; }

        //public dictionary<enum> ImageCrops {get;set;}

        /// <summary>
        /// Reference to a local image file to upload for use in a creative. Not to exceed 8MB in size.
        /// One of these three fields should be specified: image_file, image_hash, and image_url.
        /// </summary>
        [JsonProperty("image_file")]
        public string ImageFile { get; set; }

        /// <summary>
        /// Image hash for an image you have uploaded and can be used in a creative. One of these three fields should be specified: image_file, image_hash, or image_url.
        /// </summary>
        [JsonProperty("image_hash")]
        public string ImageHash { get; set; }

        /// <summary>
        /// A URL for the image for this creative. 
        /// You should not use image URLs returned from the FB CDN but instead have the image hosted on your own servers. 
        /// The image specified at the URL will be saved into the ad account's image library and cannot exceed 8 MB in size. 
        /// One of these three fields should be specified: image_file, image_hash, or image_url.
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Instagram account ID
        /// </summary>
        [JsonProperty("instagram_actor_id")]
        public string InstagramActorId { get; set; }

        /// <summary>
        /// Instagram post URL
        /// </summary>
        [JsonProperty("instagram_permalink_url")]
        public Int64? InstagramPermanentLink { get; set; }

        /// <summary>
        /// Instagram story ID
        /// </summary>
        [JsonProperty("instagram_story_id")]
        public string InstagramStoryId { get; set; }

        /// <summary>
        /// The Open Graph (OG) ID for the link in this creative if the landing page has OG tags
        /// </summary>
        [JsonProperty("link_og_id")]
        public string LinkOgId { get; set; }

        /// <summary>
        /// Used to identify a specific landing tab on the Page (e.g. a Page tab app) by the Page tab's URL.
        /// See connection objects for retrieving Page tabs' URLs. app_data parameters may be added to the url to pass data to a tab app.
        /// </summary>
        [JsonProperty("link_url")]
        public string LinkUrl { get; set; }

        /// <summary>
        /// The name of the creative in the creative library. Must be unique
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        //Object_story_spec
        /// <summary>
        /// The type of object that is being advertised. Allowed values are:
        ///     PAGE
        ///     DOMAIN
        ///     EVENT
        ///     STORE_ITEM: refers to an iTunes or Google Play store destination
        ///     OFFER
        ///     SHARE: from a page
        ///     PHOTO
        ///     STATUS: of a page
        ///     VIDEO
        ///     APPLICATION: app on Facebook
        /// </summary>
        [JsonProperty("object_type")]
        public string ObjectType { get; set; }

        /// <summary>
        /// URL
        /// Destination URL for a link ad(not connected to a page)
        /// </summary>
        [JsonProperty("object_url")]
        public string ObjectUrl { get; set; }


        /// <summary>
        /// The Dynamic Product Ad's product set ID
        /// </summary>
        [JsonProperty("product_set_id")]
        public string ProductSetId { get; set; }

        /// <summary>
        /// The product link url, which overrides the one set in Dynamic Product Ad's product feeds.
        /// </summary>
        [JsonProperty("template_url")]
        public string TemplateUrl { get; set; }

        /// <summary>
        /// The URL to a thumbnail for this creative.
        /// You can optionally request dimensions of this thumbnail by providing the thumbnail_width and thumbnail_height parameters. 
        /// </summary>
        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Title for a link ad (not connected to a page)
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// A set of query string parameters which will replace or be appended to urls clicked from page post ads, message of the post, and canvas app install creatives only.
        /// </summary>
        [JsonProperty("url_tags")]
        public string UrlTags { get; set; }

        /// <summary>
        /// If this is true, we will show the page actor for mobile app ads
        /// </summary>
        [JsonProperty("use_page_actor_override")]
        public bool UsePageActorOverride { get; set; }
    }
}

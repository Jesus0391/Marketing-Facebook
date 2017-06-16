using Facebook.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Models
{
    /// <summary>
    /// The object this ad set is promoting across all its ads. Required with certain campaign objectives.
    /// CONVERSIONS
    ///  pixel_id(Conversion pixel ID)
    ///  pixel_id(Facebook pixel ID) and custom_event_type
    ///  pixel_id(Facebook pixel ID) and pixel_rule and custom_event_type
    ///  event_id(Facebook event ID) and custom_event_type
    ///  application_id, object_store_url, and custom_event_type for mobile app events
    ///  PAGE_LIKES
    ///  page_id
    ///  OFFER_CLAIMS
    ///  page_id
    ///  LINK_CLICKS
    ///  application_id and object_store_url for mobile app or Canvas app engagement link clicks
    ///  APP_INSTALLS
    ///  application_id and object_store_url
    ///  or application_id, object_store_url, and custom_event_type if the optimization_goal is OFFSITE_CONVERSIONS
    ///  PRODUCT_CATALOG_SALES
    ///  product_set_id, 
    ///  or product_set_id and custom_event_type
    /// </summary>
    public class PromotedObject
    {
        /// <summary>
        /// The ID of a Facebook Application. Usually related to mobile or canvas games being promoted on Facebook for installs or engagement
        /// </summary>
        public int ApplicationId { get; set; }
        /// <summary>
        /// The ID of a Facebook conversion pixel. Used with offsite conversion campaigns.
        /// </summary>
        public int PixelId { get; set; }
        /// <summary>
        /// The event from an App Event of a mobile app, or tag of an conversion pixel.
        /// </summary>
        public CustomEventType CustomEventType { get; set; }
        /// <summary>
        /// The uri of the mobile / digital store where an application can be bought / downloaded. This is platform specific.
        /// When combined with the "application_id" this uniquely specifies an object which can be the subject of a Facebook advertising campaign.
        /// </summary>
        public string ObjectStoreUrl { get; set; }
        /// <summary>
        /// The ID of an Offer from a Facebook Page.
        /// </summary>
        public int OfferId { get; set; }
        /// <summary>
        /// The ID of a Facebook Page
        /// </summary>
        public string PageId { get; set; }
        /// <summary>
        /// The ID of a Product Catalog. Used with Dynamic Product Ads.
        /// </summary>
        public int ProductCatalogId { get; set; }
        /// <summary>
        /// The ID of a Product Set within a Campaign Group level Product Catalog. Used with Dynamic Product Ads.
        /// </summary>
        public int ProductSetId { get; set; }
        /// <summary>
        /// The ID of a Facebook Event
        /// </summary>
        public int EventId { get; set; }
        /// <summary>
        /// The ID of the offline dataset.
        /// </summary>
        public int OfflineCOnversionDataSetId { get; set; }
    }
}

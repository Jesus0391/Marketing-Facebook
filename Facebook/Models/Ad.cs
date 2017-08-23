using Facebook.Models.Enums;
using JAM.Facebook.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models
{
    public class Ad : IEntity
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the ad set, required on creation.
        /// </summary>
        [JsonProperty("adset_id")]
        public Int64 AdSetId { get; set; }

        /// <summary>
        /// Bid amount for this ad which will be used in auction instead of the ad set bid_amount,
        /// if specified. Any updates to the ad set bid_amount will overwrite this value with the new ad set value.
        /// </summary>
        [JsonProperty("bid_amount")]
        public int? BidAmount { get; set; }

        /// <summary>
        /// This field is required for create. 
        /// The ID of the ad creative to be used by this ad. You can read more about creatives here. You should supply the ID within an object as follows:
        ///{creative_id: <CREATIVE_ID>}
        /// </summary>
        [JsonProperty("creative")]
        public AdCreative Creative { get; set; }

        /// <summary>
        /// Name of the ad.
        /// </summary>
        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Only ACTIVE and PAUSED are valid during creation. Other statuses can be used for update. When an ad is created, it will first go through ad review, and will have the ad status PENDING_REVIEW before it finishes review and reverts back to your selected status of ACTIVE or PAUSED.
        /// During testing, it is recommended to set ads to a PAUSED status so as to not incur accidental spend.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        /// <summary>
        /// The format of the date.
        /// </summary>
        [JsonProperty("date_format")]
        public string DateFormat { get; set; }
    }
}

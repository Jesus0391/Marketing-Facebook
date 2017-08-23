
using Facebook.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models
{
    /// <summary>
    /// A call to action button required when passing instagram_story_id.
    /// </summary>
    public class CallToAction
    {
        /// <summary>
        /// The type of the action. Not all types can be used for all ads. Check Ads Product Guide to see which type can be used for based on the objective of your campaign.
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CallActionType type { get; set; }

        //public object 

    }
}

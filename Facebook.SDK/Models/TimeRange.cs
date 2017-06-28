using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models
{
    /// <summary>
    /// Time range used to aggregate insights metrics
    /// </summary>
    public class TimeRange
    {
        /// <summary>
        /// A date in the format of "YYYY-MM-DD", which means from the beginning midnight of that day.
        /// </summary>
        [JsonProperty("since")]
        public DateTime Since { get; set; }
        /// <summary>
        /// A date in the format of "YYYY-MM-DD", which means to the beginning midnight of the following day.
        /// </summary>
        [JsonProperty("until")]
        public DateTime Time { get; set; }
    }
}

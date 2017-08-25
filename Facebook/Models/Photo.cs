using Facebook.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models
{
    public class Photo : Post
    {
        /// <summary>
        /// Url Image 
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

      
        [JsonProperty("published")]
        public bool Published { get; set; }
    }
}

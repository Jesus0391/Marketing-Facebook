using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models.Page
{
    public class BusinessPageAccount
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

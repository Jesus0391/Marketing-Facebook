using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Models
{
    public class BusinessAccount
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("account_id")]
        public string AccountId { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

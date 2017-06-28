using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Response
{
    public class ResponseShared
    {
        //Normalize Case
        [JsonProperty("id")]
        public string Id { get; set; }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK.Response
{
    public class ResponseShared
    {
        private bool _success;

        //Normalize Case
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("success")]
        public bool IsSuccess { get
            {
                if (string.IsNullOrEmpty(Id) && _success == false)
                {
                    return false;
                }
                else
                {
                    return _success;
                }
            }
            set
            {
                _success = value;
            }
        }
    }
}

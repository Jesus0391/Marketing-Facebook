using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static Facebook.SDK.FacebookErrorMessage;

namespace Facebook.SDK
{
    public class FacebookException : Exception
    {
        protected string _message;
        public ErrorMessage FacebookError { get; set; }
        public FacebookException(string content)
        {
            FacebookError = JsonConvert.DeserializeObject<FacebookErrorMessage>(content).Error;
        }

        public override string Message => $"Facebook error: {FacebookError.message}";

    }

    public class FacebookErrorMessage {
        public class ErrorMessage
        {
            public string message { get; set; }
            public string type { get; set; }
            public string code { get; set; }
            public string fbtrace_id { get; set; }
        }

        public ErrorMessage Error { get; set; }
    }


}
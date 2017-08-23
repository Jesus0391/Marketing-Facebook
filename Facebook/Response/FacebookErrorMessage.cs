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
            _message = !string.IsNullOrEmpty(FacebookError.error_user_title) ?
                            FacebookError.error_user_title : FacebookError.message;
        }

        public override string Message => $"Facebook error: {_message}";

    }

    public class FacebookErrorMessage
    {
        public class ErrorMessage
        {
            //
            public string message { get; set; }
            public string type { get; set; }
            public string code { get; set; }
            public string error_subcode { get; set; }
            public bool is_transient { get; set; }
            public string fbtrace_id { get; set; }
            public IEnumerable<string> blame_field_specs { get; set; }

            //User Message
            public string error_user_title { get; set; }
            public string error_user_msg { get; set; }
        }

        public ErrorMessage Error { get; set; }

    }
}
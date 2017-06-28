using Facebook.Models.Enums;
using Facebook.Response;
using Facebook.SDK.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.SDK
{
    public static class Extensions
    {
        public static string JsonToQuery(this string jsonQuery)
        {
            string str = "?";
            str += jsonQuery.Replace(":", "=").Replace("{", "").
                        Replace("}", "").Replace(",", "&").
                            Replace("\"", "");
            return str;
        }

        public static T  JsonToObject<T>(this string content, ResponseType type = ResponseType.List) where T : class
        {
            switch (type)
            {
                case ResponseType.List:
                    var list = JsonConvert.DeserializeObject<ResponseList<T>>(content);
                    return list.Query;
                default:
                    return JsonConvert.DeserializeObject<T>(content);
            }
         
        }
    }
}

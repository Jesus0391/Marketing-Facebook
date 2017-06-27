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
    }
}

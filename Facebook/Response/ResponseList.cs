using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Response
{
    public class ResponseList<T>
    {
        [JsonProperty("data")]
        public T Query { get; set; }
        [JsonProperty("paging")]
        public Paging Paging { get; set; }
    }
    public class Paging
    {
        [JsonProperty("cursors")]
        public Cursors Cursors { get; set; }
    }
    public class Cursors
    {
        [JsonProperty("before")]
        public string Before { get; set; }
        [JsonProperty("after")]
        public string After { get; set; }
    }
}

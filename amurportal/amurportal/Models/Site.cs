using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace amurportal.Models
{
    [JsonObject]
    public class Site
    {
        [JsonProperty("TypeId")]
        public uint TypeId { get; set; }
        [JsonProperty("TypeName")]
        public string TypeName { get; set; }
        [JsonProperty("TypeNameShort")]
        public string TypeNameShort { get; set; }
    }
}
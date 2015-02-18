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
        public int TypeId { get; set; }
        [JsonProperty("TypeName")]
        public string TypeName { get; set; }
        [JsonProperty("TypeNameShort")]
        public string TypeNameShort { get; set; }
        [JsonProperty("Border")]
        public string Border { get; set; }
        [JsonProperty("Comment")]
        public string Comment { get; set; }
        [JsonProperty("Height")]
        public float Height { get; set; }
        [JsonProperty("Id")]
        public string Id { get; set; }
        [JsonProperty("Lat")]
        public decimal Lat { get; set; }
        [JsonProperty("LocalX")]
        public float LocalX { get; set; }
        [JsonProperty("LocalY")]
        public float LocalY { get; set; }
        [JsonProperty("Lon")]
        public decimal Lon { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("ParentSiteId")]
        public int ParentSiteId { get; set; }
        [JsonProperty("PosAccuracy_m")]
        public float PosAccuracy_m { get; set; }
        [JsonProperty("Ref")]
        public string Ref { get; set; }
        [JsonProperty("RegionId")]
        public int RegionId { get; set; }
        [JsonProperty("SiteCode")]
        public string SiteCode { get; set; }
        [JsonProperty("SiteId")]
        public int SiteId { get; set; }
        [JsonProperty("UtcOffset")]
        public float UtcOffset { get; set; }
    }
}
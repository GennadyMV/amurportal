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
        [JsonProperty("LatLongDatumID")]
        public int LatLongDatumID { get; set; }
        [JsonProperty("Elevation_m")]
        public float Elevation_m { get; set; }
        [JsonProperty("LocalProjectionID")]
        public int LocalProjectionID { get; set; }
        [JsonProperty("isComplex")]
        public bool isComplex { get; set; }



        public Site(Hydro.Site site)
        {
            this.TypeId = site.Type.Id;
            this.TypeName = site.Type.Name;
            this.TypeNameShort = site.Type.ShortName;
            this.Border = site.Border;
            this.Comment = site.Comment;
            this.Id = site.Id;

            if (site.Lat != null)
            {
                this.Lat = (decimal)site.Lat;
            }
            else
            {
                this.Lat = -1;
            }
            if (site.Lon != null)
            {
                this.Lon = (decimal)site.Lon;
            }
            else
            {
                this.Lon = -1;
            }

            if (site.LatLonDatumId != null)
            {
                this.LatLongDatumID = (int)site.LatLonDatumId;
            }
            else
            {
                this.LatLongDatumID = -1;
            }

            if (site.Height != null)
            {
                this.Height = (float)site.Height;
                this.Elevation_m = (float)site.Height;
            }
            else
            {
                this.Height = -1;
                this.Elevation_m = -1;
            }

            if (site.LocalProjectionId != null)
            {
                this.LocalProjectionID = (int)site.LocalProjectionId;
            }
            else
            {
                this.LocalProjectionID = -1;
            }

            if (site.RegionId != null)
            {
                this.RegionId = (int)site.RegionId;
            }
            else
            {
                this.RegionId = -1;
            }

            this.isComplex = site.IsComplex;
            this.Name = site.Name;
            this.SiteCode = site.SiteCode;
            this.SiteId = site.SiteId;
            this.UtcOffset = site.UtcOffset;
            this.Id = site.Id;
        }
    }
}
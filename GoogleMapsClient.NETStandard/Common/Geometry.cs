
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Common
{
    public partial class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("viewport")]
        public Viewport Viewport { get; set; }
    }
}

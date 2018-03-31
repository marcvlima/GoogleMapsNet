
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Common
{
    public partial class Location
    {
        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }
}

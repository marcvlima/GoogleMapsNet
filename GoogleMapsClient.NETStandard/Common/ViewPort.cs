using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Common
{
    public partial class Viewport
    {
        [JsonProperty("northeast")]
        public Location Northeast { get; set; }

        [JsonProperty("southwest")]
        public Location Southwest { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Common
{
    public partial class AddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public IEnumerable<string> Types { get; set; }
    }
}

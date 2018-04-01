using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Common
{
    [Serializable]
    public partial class Result
    {
        [JsonProperty("address_components")]
        public IEnumerable<AddressComponent> AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("types")]
        public IEnumerable<string> Types { get; set; }

        public IEnumerable<AddressComponent> GetSublocalities()
        {
            var query = from a in AddressComponents
                        where a.Types.Contains("sublocality") 
                            || a.Types.Contains("sublocality_level_1")
                            || a.Types.Contains("sublocality_level_2")
                            || a.Types.Contains("sublocality_level_3")
                            || a.Types.Contains("sublocality_level_4")
                            || a.Types.Contains("sublocality_level_5")
                        orderby a.Types descending
                        select a;
            return query.ToList();
        }
    }
}

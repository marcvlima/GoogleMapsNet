using GoogleMapsServicesClient.NETStandard.Common;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Geocode
{
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
        private IEnumerable<string> _Types { get; set; }


        private List<AddressTypes> addressTypes;
        public List<AddressTypes> AddressTypes
        {
            get
            {
                if(this.addressTypes == null)
                {
                    this.addressTypes = new List<AddressTypes>();
                    foreach(String addressTypeName in _Types)
                    {
                        this.addressTypes.Add(AddressTypesListing.AddressTypesDict[addressTypeName]);
                    }
                }

                return this.addressTypes;
            }
        }

        /// <summary>
        /// Checks if the returned location is more specific than an address type.
        /// </summary>
        /// <param name="addressTypeToCompare">The Address Type as a parameter for the comparison</param>
        /// <returns></returns>
        public bool IsMoreSpecificThan(AddressTypes addressTypeToCompare)
        {
            var query = from at in this.AddressTypes
                        where at.GetInfo().SpecificityLevel >= addressTypeToCompare.GetInfo().SpecificityLevel
                        select at;

            // If the is one  item less of with equal specificity returns false;
            return !query.Any();
        }


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

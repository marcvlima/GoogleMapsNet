using GoogleMapsServicesClient.NETStandard.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Geocode
{
    [Serializable]
    public class GeocodeResult
    {
        [JsonProperty("results")]
        public IEnumerable<Result> Results { get; set; }

        [JsonProperty("status")]
        public string _Status { get; set; }

        private StatusTypes? status = null;
        public StatusTypes Status
        {
            get
            {
                if (status == null)
                {
                    status = statusTypes[this._Status];
                }
                return status.Value;
            }
        }

        public enum StatusTypes
        {
            /// <summary>
            /// Indicates no error has ocurred.
            /// </summary>
            OK,
            ZERO_RESULTS,
            OVER_QUERY_LIMIT,
            REQUEST_DENIED,
            INVALID_REQUEST,
            UNKNOWN_ERROR
        }

        private Dictionary<String, StatusTypes> statusTypes = new Dictionary<String, StatusTypes>() {
            { "OK", StatusTypes.OK },
            { "ZERO_RESULTS", StatusTypes.ZERO_RESULTS },
            { "OVER_QUERY_LIMIT", StatusTypes.OVER_QUERY_LIMIT },
            { "REQUEST_DENIED", StatusTypes.REQUEST_DENIED },
            { "INVALID_REQUEST", StatusTypes.INVALID_REQUEST },
            { "UNKNOWN_ERROR", StatusTypes.UNKNOWN_ERROR }
         };
    }
}

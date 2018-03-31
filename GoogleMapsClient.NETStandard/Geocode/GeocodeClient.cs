using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapsServicesClient.NETStandard.Geocode
{
    public class GeocodeClient : MapsClient
    {

        protected Uri BaseGeocodeUri { get; set; }

        protected String CountryCode { get; set; }

        public GeocodeClient(Uri mapsUri, String mapsApiKey, String countryCode)
            :base(mapsUri, mapsApiKey)
        {
            this.BaseGeocodeUri = new Uri(this.BaseMapsUri, "geocode/json?");
            this.CountryCode = countryCode;
        }

        public GeocodeClient(String mapsUriPath, String mapsApiKey, String countryCode)
            : this(new Uri(mapsUriPath), mapsApiKey, null)
        {
        }

        public GeoCodeResult GetLocationByAddress(String addressInfo)
        {
            UriBuilder uriBuilder = new UriBuilder(this.BaseGeocodeUri);
            string query = "key=" + this.MapsKey + "&address=" + addressInfo.Replace(" ", "+");
            if (!String.IsNullOrEmpty(this.CountryCode))
                query += "&components=country:" + this.CountryCode;
            uriBuilder.Query = query;


            WebRequest request = WebRequest.Create(uriBuilder.Uri);
            WebResponse response = request.GetResponse();
            string responseContent = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GeoCodeResult>(responseContent);
        }

        public GeoCodeResult GetLocationByAddress(GeocodeRequestInfo addressInfo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.Append(addressInfo.PlaceNumber.ToString() + " " + addressInfo.PublicPlaceName);
            if (!String.IsNullOrEmpty(addressInfo.CityName))
                stringBuilder.Append(", " + addressInfo.CityName);
            return this.GetLocationByAddress(stringBuilder.ToString());
        }
    }
}

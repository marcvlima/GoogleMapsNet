using System;
using System.IO;
using System.Net;
using System.Text;

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

        public GeocodeClient(Uri mapsUri, String mapsApiKey)
            : this(mapsUri, mapsApiKey, null)
        {
            this.BaseGeocodeUri = new Uri(this.BaseMapsUri, "geocode/json?");
        }

        public GeocodeClient(String mapsUriPath, String mapsApiKey)
            : this(new Uri(mapsUriPath), mapsApiKey, null)
        {
        }

        public GeocodeClient(String mapsUriPath, String mapsApiKey, String countryCode)
            : this(new Uri(mapsUriPath), mapsApiKey, countryCode)
        {
            this.CountryCode = countryCode;
        }

        public GeocodeResult GetLocationByAddress(String addressInfo)
        {
            UriBuilder uriBuilder = new UriBuilder(this.BaseGeocodeUri);
            string query = "key=" + this.MapsKey + "&address=" + addressInfo.Replace(" ", "+");
            if (!String.IsNullOrEmpty(this.CountryCode))
                query += "&components=country:" + this.CountryCode;
            uriBuilder.Query = query;


            WebRequest request = WebRequest.Create(uriBuilder.Uri);
            WebResponse response = request.GetResponse();
            string responseContent = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<GeocodeResult>(responseContent);
        }

        public GeocodeResult GetLocationByAddress(GeocodeRequestInfo addressInfo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.Append(" " + addressInfo.PublicPlaceName);
            if (addressInfo.PlaceNumber != null)
                stringBuilder.Append(", " + addressInfo.PlaceNumber.ToString());
            if (!String.IsNullOrEmpty(addressInfo.CityName))
                stringBuilder.Append(", " + addressInfo.CityName);
            return this.GetLocationByAddress(stringBuilder.ToString());
        }
    }
}

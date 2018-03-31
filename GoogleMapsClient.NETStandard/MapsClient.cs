using System;
using System.Net.Http;

namespace GoogleMapsServicesClient.NETStandard
{
    public class MapsClient
    {
        internal Uri BaseMapsUri { get; private set; }
        internal String MapsKey { get; private set; }
        protected HttpClient RequestClient { get { return MapsClient.HttpClient; } }

        protected static readonly HttpClient HttpClient = new HttpClient();

        public MapsClient(Uri mapsUri, String mapsApiKey)
        {
            this.BaseMapsUri = mapsUri;
            this.MapsKey = mapsApiKey;
        }

        public MapsClient(String mapsUriPath, String mapsApiKey)
            :this(new Uri(mapsUriPath), mapsApiKey)
        {
        }
    }
}

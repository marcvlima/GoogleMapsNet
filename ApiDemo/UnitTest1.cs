using System;
using System.Threading.Tasks;
using GoogleMapsServicesClient.NETStandard;
using GoogleMapsServicesClient.NETStandard.Geocode;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using GoogleMapsServicesClient.NETStandard.Common;

namespace ApiDemo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodRuaNumeroCidade()
        {
            GeocodeClient geoClient = new GeocodeClient("https://maps.googleapis.com/maps/api/", "AIzaSyBepGH1lMmdhpQ9CIpq6ip6dep3ACzdFMs", "BR");
            var response = geoClient.GetLocationByAddress(new GeocodeRequestInfo()
            {
                CityName = "Belo Horizonte",
                PlaceNumber = 411,
                PublicPlaceName = "Sao João Evangelista"
            });
            try
            {
                if (response.Status == GeoCodeResult.StatusTypes.OK)
                    foreach(var sublocality in response.Results.FirstOrDefault().GetSublocalities())
                        Console.WriteLine(sublocality.LongName);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [TestMethod]
        public void TestMethodRuaCidade()
        {
            GeocodeClient geoClient = new GeocodeClient("https://maps.googleapis.com/maps/api/", "AIzaSyBepGH1lMmdhpQ9CIpq6ip6dep3ACzdFMs", "BR");
            var response = geoClient.GetLocationByAddress(new GeocodeRequestInfo()
            {
                CityName = "Belo Horizonte",
                PublicPlaceName = "Rua João Antônio Cardoso"
            });
            try
            {
                if (response.Status == GeoCodeResult.StatusTypes.OK) { 
                    foreach (var sublocality in response.Results.FirstOrDefault().GetSublocalities())
                        Console.WriteLine(sublocality.LongName);

                    Assert.IsTrue(response.Results.FirstOrDefault().IsMoreSpecificThan(AddressTypes.locality));
                }

            }
            catch (Exception e)
            {
            }

        }


        [TestMethod]
        public void TestMethodRuaLocalNaoProeminente()
        {
            GeocodeClient geoClient = new GeocodeClient("https://maps.googleapis.com/maps/api/", "AIzaSyBepGH1lMmdhpQ9CIpq6ip6dep3ACzdFMs", "BR");
            var response = geoClient.GetLocationByAddress(new GeocodeRequestInfo()
            {
                CityName = "Rua Maria Natividade de Lima",
                PlaceNumber = 112,
                PublicPlaceName = "Ibirite"
            });
            try
            {
                if (response.Status == GeoCodeResult.StatusTypes.OK)
                    foreach (var sublocality in response.Results.FirstOrDefault().GetSublocalities())
                        Console.WriteLine(sublocality.LongName);
            }
            catch (Exception e)
            {
            }

        }

        [TestMethod]
        public void TestMethodApenasCidade()
        {
            GeocodeClient geoClient = new GeocodeClient("https://maps.googleapis.com/maps/api/", "AIzaSyBepGH1lMmdhpQ9CIpq6ip6dep3ACzdFMs", "BR");
            var response = geoClient.GetLocationByAddress(new GeocodeRequestInfo()
            {
                CityName = "",
                PublicPlaceName = "Ibirite"
            });
            try
            {
                if (response.Status == GeoCodeResult.StatusTypes.OK)
                {
                    foreach (var sublocality in response.Results.FirstOrDefault().GetSublocalities())
                        Console.WriteLine(sublocality.LongName);
                    Assert.IsFalse(response.Results.FirstOrDefault().IsMoreSpecificThan(AddressTypes.locality));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}

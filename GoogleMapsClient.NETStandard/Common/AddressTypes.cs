using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace GoogleMapsServicesClient.NETStandard.Common
{
    public enum AddressTypes
    {
        [AddressTypeInfo(0)]
        establishment,
        [AddressTypeInfo(0)]
        colloquial_area,
        [AddressTypeInfo(0)]
        political,
        [AddressTypeInfo(0)]
        natural_feature,
        [AddressTypeInfo(0)]
        post_box,
        [AddressTypeInfo(1)]
        room,
        [AddressTypeInfo(2)]
        floor,
        [AddressTypeInfo(3)]
        street_number,
        [AddressTypeInfo(4)]
        street_address,
        [AddressTypeInfo(5)]
        parking,
        [AddressTypeInfo(5)]
        premise,
        [AddressTypeInfo(5)]
        point_of_interest,
        [AddressTypeInfo(5)]
        bus_station,
        [AddressTypeInfo(5)]
        train_station,
        [AddressTypeInfo(5)]
        transit_station,
        [AddressTypeInfo(6)]
        airport,
        [AddressTypeInfo(6)]
        park,
        [AddressTypeInfo(6)]
        route,
        [AddressTypeInfo(7)]
        postal_code,
        [AddressTypeInfo(8)]
        intersection,
        [AddressTypeInfo(9)]
        neighborhood,
        [AddressTypeInfo(10)]
        sublocality,
        [AddressTypeInfo(11)]
        sublocality_level_5,
        [AddressTypeInfo(12)]
        sublocality_level_4,
        [AddressTypeInfo(13)]
        sublocality_level_3,
        [AddressTypeInfo(14)]
        sublocality_level_2,
        [AddressTypeInfo(15)]
        sublocality_level_1,
        [AddressTypeInfo(16)]
        locality,
        [AddressTypeInfo(17)]
        postal_town,
        [AddressTypeInfo(18)]
        administrative_area_level_5,
        [AddressTypeInfo(19)]
        administrative_area_level_4,
        [AddressTypeInfo(20)]
        administrative_area_level_3,
        [AddressTypeInfo(21)]
        administrative_area_level_2,
        [AddressTypeInfo(22)]
        administrative_area_level_1,
        [AddressTypeInfo(23)]
        country,
    }

    public static class AddressTypesListing
    {
        public static Dictionary<String, AddressTypes> AddressTypesDict = new Dictionary<string, AddressTypes>()
        {
            { "establishment" , AddressTypes.establishment },
            { "colloquial_area" , AddressTypes.colloquial_area },
            { "political" , AddressTypes.political },
            { "natural_feature" , AddressTypes.natural_feature },
            { "post_box" , AddressTypes.post_box },
            { "room" , AddressTypes.room },
            { "floor" , AddressTypes.floor },
            { "street_number" , AddressTypes.street_number },
            { "street_address" , AddressTypes.street_address },
            { "parking" , AddressTypes.parking },
            { "premise" , AddressTypes.premise },
            { "point_of_interest" , AddressTypes.point_of_interest },
            { "bus_station" , AddressTypes.bus_station },
            { "train_station" , AddressTypes.train_station },
            { "transit_station" , AddressTypes.transit_station },
            { "airport" , AddressTypes.airport },
            { "park" , AddressTypes.park },
            { "route" , AddressTypes.route },
            { "postal_code" , AddressTypes.postal_code },
            { "intersection" , AddressTypes.intersection },
            { "neighborhood" , AddressTypes.neighborhood },
            { "sublocality" , AddressTypes.sublocality },
            { "sublocality_level_5" , AddressTypes.sublocality_level_5 },
            { "sublocality_level_4" , AddressTypes.sublocality_level_4 },
            { "sublocality_level_3" , AddressTypes.sublocality_level_3 },
            { "sublocality_level_2" , AddressTypes.sublocality_level_2 },
            { "sublocality_level_1" , AddressTypes.sublocality_level_1 },
            { "locality" , AddressTypes.locality },
            { "postal_town" , AddressTypes.postal_town },
            { "administrative_area_level_5" , AddressTypes.administrative_area_level_5 },
            { "administrative_area_level_4" , AddressTypes.administrative_area_level_4 },
            { "administrative_area_level_3" , AddressTypes.administrative_area_level_3 },
            { "administrative_area_level_2" , AddressTypes.administrative_area_level_2 },
            { "administrative_area_level_1" , AddressTypes.administrative_area_level_1 },
            { "country" , AddressTypes.country }
        };
    }

    public class AddressTypeInfo
    {
        public AddressTypeInfo(int specificityLevel)
        {
            this.SpecificityLevel = specificityLevel;
        }

        /// <summary>
        /// Indicates how specific a Address Type is.
        /// </summary>
        public int SpecificityLevel;
    }

    public static class AddressTypesExtensions
    {
        public static AddressTypeInfo GetInfo(this AddressTypes value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            AddressTypeInfoAttribute[] attributes =
                (AddressTypeInfoAttribute[])fi.GetCustomAttributes(typeof(AddressTypeInfoAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].AddressTypeInfo;
            else
                throw new InvalidEnumArgumentException();
        }
    }

    /// <summary>
    /// Contains insightfull information about the Address Types
    /// </summary>
    public class AddressTypeInfoAttribute : Attribute
    {
        public AddressTypeInfo AddressTypeInfo;

        public AddressTypeInfoAttribute(int specificityLevel) {
            AddressTypeInfo = new AddressTypeInfo(specificityLevel);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biz2Credit_Test
{
    public class Customer
    {
        /// <summary>
        /// Unique Identifier User Id
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        /// Customer Name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Customer Latitude
        /// </summary>
        public double latitude { get; set; }

        /// <summary>
        /// Customer Longitude
        /// </summary>
        public double longitude { get; set; }

        /// <summary>
        /// Customer calculated Distnce in Km with Reference to Durbin
        /// </summary>
        public double distance_in_kms_from_dublin
        {
            get
            {
                var R = Constants.EarthRadius;
                var dLat = DegreeToRad(latitude - Constants.Dublin.LAT);
                var dLon = DegreeToRad(longitude - Constants.Dublin.LONG);
                var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                  Math.Cos(DegreeToRad(Constants.Dublin.LAT)) * Math.Cos(DegreeToRad(latitude)) *
                  Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
                var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                var d = R * c; // Distance in km
                return d;
            }
        }

        private double DegreeToRad(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}

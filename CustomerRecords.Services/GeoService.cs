using CustomerRecords.Models.ValueObjects;
using CustomerRecords.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.Services
{
    /// <summary>
    /// Service provides geo utils
    /// </summary>
    public class GeoService : IGeoService
    {
        private const int EARTH_RADIUS_KM = 6371;

        /// <summary>
        /// get distance between points in km
        /// </summary>
        /// <param name="point1">Coordinates of point 1</param>
        /// <param name="point2">Coordinates of point 2</param>
        /// <returns>Distnace in km</returns>
        public double GetDistance(GeoCoordinate point1, GeoCoordinate point2)
        {
            if (point1 == null)
                throw new ArgumentNullException("point1 is null");

            if (point2 == null)
                throw new ArgumentNullException("point2 is null");

            var dLat = ToRadians(point2.Latitude - point1.Latitude);
            var dLon = ToRadians(point2.Longitude - point1.Longitude);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(ToRadians(point1.Latitude)) * Math.Cos(ToRadians(point2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            return EARTH_RADIUS_KM * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }

        private double ToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}

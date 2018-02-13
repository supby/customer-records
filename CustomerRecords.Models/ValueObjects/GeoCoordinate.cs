using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.Models.ValueObjects
{
    /// <summary>
    /// Geo Coordinate.
    /// </summary>
    public class GeoCoordinate : IEquatable<GeoCoordinate>
    {
        private readonly double latitude;
        private readonly double longitude;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="latitude">Latitude of point</param>
        /// <param name="longitude">Longitude of point</param>
        public GeoCoordinate(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /// <summary>
        /// return Latitude
        /// </summary>
        public double Latitude => latitude;

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude => longitude;


        public override string ToString()
        {
            return string.Format("{0},{1}", Latitude, Longitude);
        }

        public bool Equals(GeoCoordinate other)
        {
            return other != null
                   && Latitude == other.Latitude 
                   && Longitude == other.Longitude;
        }

        public override int GetHashCode()
        {
            return Latitude.GetHashCode() ^ Longitude.GetHashCode();
        }

        public override bool Equals(object other)
        {
            return other is GeoCoordinate && Equals((GeoCoordinate)other);
        }
    }
}

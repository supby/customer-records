using CustomerRecords.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.Services.Interfaces
{
    /// <summary>
    /// Service provides geo utils
    /// </summary>
    public interface IGeoService
    {
        /// <summary>
        /// get distance between points in km
        /// </summary>
        /// <param name="point1">Coordinates of point 1</param>
        /// <param name="point2">Coordinates of point 2</param>
        /// <returns>Distnace in km</returns>
        double GetDistance(GeoCoordinate point1, GeoCoordinate point2);
    }
}

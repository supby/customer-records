using CustomerRecords.Models.ValueObjects;
using CustomerRecords.Services;
using System;
using Xunit;

namespace CustomerRecords.Tests
{
    public class GeoServiceTests
    {
        /// <summary>
        /// Check if distance calculation is correct
        /// </summary>
        [Fact]
        public void GetDistanceTest()
        {
            var target = new GeoService();
            double res = target.GetDistance(new GeoCoordinate(35.6544, 139.74477), new GeoCoordinate(21.4225, 39.8261));

            Assert.Equal(9480.660007, Math.Round(res, 6));
        }
    }
}

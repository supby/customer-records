using CustomerRecords.DataAccess.Interfaces;
using CustomerRecords.Models.Entity;
using CustomerRecords.Models.ValueObjects;
using CustomerRecords.Services;
using CustomerRecords.Services.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CustomerRecords.Tests
{
    public class CustomerServiceTests
    {
        private readonly List<Customer> customerData;
        private readonly Mock<IRepository<Customer>> customerRepositoryMock;
        private readonly Mock<IGeoService> geoServiceMock;

        public CustomerServiceTests()
        {
            customerData = new List<Customer>()
            {
                new Customer() { Id = 12, Name = "Christina McArdle", Coordinate = new GeoCoordinate(52.986375, -6.043701) },
                new Customer() { Id = 1, Name = "Alice Cahill", Coordinate = new GeoCoordinate(51.92893, -10.27699) },
                new Customer() { Id = 2, Name = "Ian McArdle", Coordinate = new GeoCoordinate(51.885616, -10.4240951) },
            };

            customerRepositoryMock = new Mock<IRepository<Customer>>();
            customerRepositoryMock.Setup(x => x.Get()).Returns(customerData);

            geoServiceMock = new Mock<IGeoService>();
            geoServiceMock
                .Setup(x => x.GetDistance(It.IsAny<GeoCoordinate>(), It.IsAny<GeoCoordinate>()))
                .Returns<GeoCoordinate, GeoCoordinate>((c1, c2) => c2.Latitude == 52.986375 ? 120 : 90);
        }

        /// <summary>
        /// Check invocation of repository and geo service method
        /// </summary>
        [Fact]
        public void GetCustomersInvocationTest()
        {
            var target = new CustomerService(customerRepositoryMock.Object, geoServiceMock.Object);
            var res = target.Get(new GeoCoordinate(53.339428, -6.257664), 100).ToList();

            customerRepositoryMock.Verify(x => x.Get(), Times.Once);
            geoServiceMock.Verify(x => x.GetDistance(It.IsAny<GeoCoordinate>(), It.IsAny<GeoCoordinate>()), Times.Exactly(3));
        }

        /// <summary>
        /// Check filtering logic: point inside raduisKm
        /// </summary>
        [Fact]
        public void GetCustomersilteringTest()
        {
            var target = new CustomerService(customerRepositoryMock.Object, geoServiceMock.Object);
            var res = target.Get(new GeoCoordinate(53.339428, -6.257664), 100).ToList();

            Assert.Equal(2, res.Count());
        }
    }
}

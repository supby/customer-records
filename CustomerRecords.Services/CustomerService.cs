using CustomerRecords.DataAccess.Interfaces;
using CustomerRecords.Models.Entity;
using CustomerRecords.Models.ValueObjects;
using CustomerRecords.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerRecords.Services
{
    /// <summary>
    /// Customer Service implementation
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IGeoService geoService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="customerRepository">Instance od customer repository</param>
        public CustomerService(IRepository<Customer> customerRepository, IGeoService geoService)
        {
            this.customerRepository = customerRepository;
            this.geoService = geoService;
        }

        /// <summary>
        /// Get list of customers within raduis
        /// </summary>
        /// <param name="centerPoint">Center point</param>
        /// <param name="radiusKm">Radius in killometers</param>
        /// <returns>List of Customers</returns>
        public IEnumerable<Customer> Get(GeoCoordinate centerPoint, double radiusKm)
        {
            return customerRepository.Get()
                        .Where(x => geoService.GetDistance(centerPoint, x.Coordinate) < radiusKm);
        }
    }
}

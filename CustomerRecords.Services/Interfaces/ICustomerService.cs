using CustomerRecords.Models.Entity;
using CustomerRecords.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.Services.Interfaces
{
    /// <summary>
    /// Customer Service
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Get list of customers within raduis
        /// </summary>
        /// <param name="centerPoint">Center point</param>
        /// <param name="radiusKm">Radius in killometers</param>
        /// <returns>List of Customers</returns>
        IEnumerable<Customer> Get(GeoCoordinate centerPoint, double radiusKm);
    }
}

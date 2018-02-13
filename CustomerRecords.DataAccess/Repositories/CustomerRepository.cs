using CustomerRecords.DataAccess.Interfaces;
using CustomerRecords.Models.Entity;
using CustomerRecords.Models.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CustomerRecords.DataAccess.Repositories
{
    /// <summary>
    /// Repository pattern for working with data
    /// </summary>
    /// <typeparam name="TEntity">Type of repository entity</typeparam>
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly string filename;

        public CustomerRepository(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Get customers as list from store
        /// </summary>
        /// <returns>List of Customers</returns>
        public IEnumerable<Customer> Get()
        {
            // TODO: in real projects i would use AutoMapper for mapping CustomerRecord to Customer
            return File.ReadAllLines(filename)
                        .Select(x => JsonConvert.DeserializeObject<CustomerRecord>(x))
                        .Select(x => new Customer
                        {
                            Id = x.UserId,
                            Name = x.Name,
                            Coordinate = new GeoCoordinate(x.Latitude, x.Longitude)
                        });
        }
    }
}

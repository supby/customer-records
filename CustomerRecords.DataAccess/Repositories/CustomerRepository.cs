using CustomerRecords.DataAccess.Interfaces;
using CustomerRecords.Models.Entity;
using CustomerRecords.Models.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerRecords.DataAccess.Repositories
{
    /// <summary>
    /// Repository pattern for working with data
    /// </summary>
    /// <typeparam name="TEntity">Type of repository entity</typeparam>
    public class CustomerRepository : IRepository<Customer>
    {   
        private readonly IDataSource source;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Source od raw data</param>
        public CustomerRepository(IDataSource source)
        {
            this.source = source ?? throw new ArgumentNullException("IDataSource is null");
        }

        /// <summary>
        /// Get customers as list from store
        /// </summary>
        /// <returns>List of Customers</returns>
        public IEnumerable<Customer> Get()
        {   
            // TODO: in real projects i would use AutoMapper for mapping CustomerRecord to Customer
            return source.ReadAll()
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

using CustomerRecords.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.Models.Entity
{
    /// <summary>
    /// Stands for customer information
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Id of customer
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// Name of customer
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// Geo coordinate of customer
        /// </summary>        
        public GeoCoordinate Coordinate { get; set; }
    }
}

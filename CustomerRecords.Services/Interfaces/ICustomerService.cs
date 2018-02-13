using CustomerRecords.Models.Entity;
using CustomerRecords.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> Get(GeoCoordinate centerPoint, double radiusKilometers);
    }
}

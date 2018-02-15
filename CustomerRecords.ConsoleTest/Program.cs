using CustomerRecords.DataAccess.DataSources;
using CustomerRecords.DataAccess.Repositories;
using CustomerRecords.Models.ValueObjects;
using CustomerRecords.Services;
using System;
using System.IO;
using System.Reflection;

namespace CustomerRecords.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // create source of jsoned customers and repository to load them
            var source = new FileDataSource(Path.Combine(Environment.CurrentDirectory, "data", "customers.json"));
            var customerRepository = new CustomerRepository(source);

            // create geo service for distance calculating
            var geoService = new GeoService();

            // create customer service as entry point and domain service
            var customerService = new CustomerService(customerRepository, geoService);

            // our office ccordinate
            var centerPoint = new GeoCoordinate(53.339428, -6.257664);
            // radius in km
            double radiusKm = 100;

            var customers = customerService.Get(centerPoint, radiusKm);

            Console.WriteLine(string.Format("We found folowwing customers within {0} km around of point ({1}, {2})",
                                            radiusKm, centerPoint.Latitude, centerPoint.Longitude));
            foreach(var customer in customers)
            {
                Console.WriteLine(string.Format("Name: {0}, Coordianes: ({1}, {2})", 
                    customer.Name, customer.Coordinate.Latitude, customer.Coordinate.Longitude));
            }

            Console.ReadLine();
        }
    }
}

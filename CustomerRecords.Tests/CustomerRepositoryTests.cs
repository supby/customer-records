using CustomerRecords.DataAccess.Interfaces;
using CustomerRecords.DataAccess.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CustomerRecords.Tests
{
    public class CustomerRepositoryTests
    {
        private readonly List<string> customerData;
        private readonly Mock<IDataSource> dataSourceMock;

        public CustomerRepositoryTests()
        {
            customerData = new List<string>()
            {
                "{\"latitude\": \"52.986375\", \"user_id\": 12, \"name\": \"Christina McArdle\", \"longitude\": \"-6.043701\"}",
                "{\"latitude\": \"51.92893\", \"user_id\": 1, \"name\": \"Alice Cahill\", \"longitude\": \"-10.27699\"}",
                "{\"latitude\": \"51.8856167\", \"user_id\": 2, \"name\": \"Ian McArdle\", \"longitude\": \"-10.4240951\"}"
            };

            dataSourceMock = new Mock<IDataSource>();
        }

        [Fact]
        public void GetAllCustomersTest()
        {   
            dataSourceMock
                .Setup(x => x.ReadAll())
                .Returns(customerData);

            var target = new CustomerRepository(dataSourceMock.Object);
            var res = target.Get();

            Assert.Equal(3, res.Count());
            Assert.Equal(12, res.ElementAt(0).Id);
            Assert.Equal(1, res.ElementAt(1).Id);
            Assert.Equal(2, res.ElementAt(2).Id);
        }

        [Fact]
        public void GetZerCustomersTest()
        {   
            dataSourceMock
                .Setup(x => x.ReadAll())
                .Returns(new string[] { });

            var target = new CustomerRepository(dataSourceMock.Object);
            var res = target.Get();

            Assert.Empty(res);
        }
    }
}

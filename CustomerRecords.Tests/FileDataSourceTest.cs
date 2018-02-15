using CustomerRecords.DataAccess.DataSources;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomerRecords.Tests
{
    public class FileDataSourceTest
    {
        [Fact]
        public void CreateNullExceptionTest()
        {
            Assert.Throws<ArgumentNullException>(() => new FileDataSource(null));
            Assert.Throws<ArgumentNullException>(() => new FileDataSource(string.Empty));
        }
    }
}

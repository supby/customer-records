using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.DataAccess.Interfaces
{
    /// <summary>
    /// Source of raw data fro repository
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Read all data from source
        /// </summary>
        /// <returns>List of string</returns>
        IEnumerable<string> ReadAll();
    }
}

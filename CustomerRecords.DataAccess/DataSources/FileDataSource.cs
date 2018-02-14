using CustomerRecords.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CustomerRecords.DataAccess.DataSources
{
    /// <summary>
    /// transparent File reader
    /// </summary>
    public class FileDataSource : IDataSource
    {
        private readonly string filename;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">Name of file where is data stored</param>
        public FileDataSource(string filename)
        {
            this.filename = filename;
        }

        /// <summary>
        /// Read all lines from file
        /// </summary>
        /// <returns>List of string</returns>
        public IEnumerable<string> ReadAll()
        {
            return File.ReadAllLines(filename);
        }
    }
}

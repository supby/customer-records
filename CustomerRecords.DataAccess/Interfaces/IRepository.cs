using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.DataAccess.Interfaces
{
    /// <summary>
    /// Repository pattern for working with data
    /// </summary>
    /// <typeparam name="TEntity">Type of repository entity</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get customers as list from store
        /// </summary>
        /// <returns>List of TEntity</returns>
        IEnumerable<TEntity> Get();
    }
}

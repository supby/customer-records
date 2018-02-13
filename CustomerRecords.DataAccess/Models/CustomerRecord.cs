using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRecords.Models.Entity
{
    /// <summary>
    /// Stands for flat customer information from store
    /// </summary>
    public class CustomerRecord
    {
        /// <summary>
        /// Id of customer
        /// </summary>  
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        /// <summary>
        /// Name of customer
        /// </summary>    
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// return Latitude
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    /// <summary>
    /// Class Send data to RabbitMQ
    /// </summary>
    public class cmlRcvDataUpload
    {
        /// <summary>
        /// Json data
        /// </summary>
        public string ptData { get; set; }

        /// <summary>
        /// Connection string
        /// </summary>
        public string ptConnStr { get; set; }
    }
}
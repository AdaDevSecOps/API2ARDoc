using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.WebService
{
    /// <summary>
    /// Class Response base
    /// </summary>
    public class cmlResBase
    {
        /// <summary>
        /// System process status.
        /// </summary>
        [JsonProperty("rtCode")]
        public string rtCode { get; set; }

        /// <summary>
        /// System process description.
        /// </summary>
        [JsonProperty("rtDesc")]
        public string rtDesc { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.WebService
{
    /// <summary>
    /// Class model list Item response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class cmlResItem<T> : cmlResBase
    {
        /// <summary>
        /// list Item response
        /// </summary>
        [JsonProperty("roItem")]
        public T roItem { get; set; }
    }
}
using API2ARDoc.Models.WebService;
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
    public class cmlResService<T> : cmlResBase
    {
        /// <summary>
        /// list Item response
        /// </summary>
        public T oItem { get; set; }
    }
}
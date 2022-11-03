using API2ARDoc.Models.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.Base
{
    public class cmlResList<T> : cmlResBase
    {
        public List<T> raItems { get; set; }

        /// <summary>
        /// Current page.
        /// </summary>
        public int rnCurrentPage { get; set; }

        /// <summary>
        /// All pages.
        /// </summary>
        public int rnAllPage { get; set; }
    }
}
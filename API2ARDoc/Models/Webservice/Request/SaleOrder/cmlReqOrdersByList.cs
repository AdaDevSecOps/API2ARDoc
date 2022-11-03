using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Request.SaleOrder
{
    public class cmlReqOrdersByList
    {
        /// <summary>
        /// รหัสสาขา
        /// </summary>
        public string ptBchCode { get; set; }

        /// <summary>
        /// รหัสลูกค้า
        /// </summary>
        public string ptCstCode { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Request.SaleOrder
{
    public class cmlReqOrdersByDoc
    {
        /// <summary>
        /// รหัสสาขา
        /// </summary>
        public string ptBchCode { get; set; }

        /// <summary>
        /// เลขที่เอกสาร SO
        /// </summary>
        public string ptDocNo { get; set; }
    }
}
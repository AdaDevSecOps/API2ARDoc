using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleOrder
{
    public class cmlResInfoOrdersByList
    {
        /// <summary>
        /// รหัสสาขา
        /// </summary>
        public string rtBchCode { get; set; }

        /// <summary>
        /// เลขที่เอกสาร
        /// </summary>
        public string rtDocNo{ get; set; }

        /// <summary>
        /// วันที่เอกสาร
        /// </summary>
        public Nullable<DateTime> rdDocDate { get; set; }

        /// <summary>
        /// ยอดรวม (FCXshGrand)
        /// </summary>
        public Nullable<decimal> rcGrand { get; set; }

        /// <summary>
        /// พนักงาน Key
        /// </summary>
        public string rtUsrKey { get; set; }

        /// <summary>
        /// ผู้อนุมัติ
        /// </summary>
        public string rtUsrApv { get; set; }

        /// <summary>
        /// สด/เครดิต 1:สด 2:credit
        /// </summary>
        public string rtCshOrCrd { get; set; }
    }
}
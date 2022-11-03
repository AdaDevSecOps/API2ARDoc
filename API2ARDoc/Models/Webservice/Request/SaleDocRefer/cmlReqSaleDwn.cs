using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Request.SaleDocRefer
{
    public class cmlReqSaleDwn
    {
        /// <summary>
        /// รหัสสาขา
        /// </summary>
        public string ptBchCode { get; set; }

        /// <summary>
        /// เลขที่เอกสาร
        /// </summary>
        public string ptDocNo { get; set; }

        /// <summary>
        /// วันที่
        /// </summary>
        public Nullable<DateTime> pdSaleDate { get; set; }

        /// <summary>
        /// ประเภท
        /// </summary>
        public Nullable<int> pnDoctype { get; set; }

        /// <summary>
        /// รหัสตัวแทน/เจ้าของกำเนินการ
        /// </summary>
        public string ptMerCode { get; set; }

        /// <summary>
        /// รหัสคู้ค้า/AD
        /// </summary>
        public string ptAgnCode { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Request.SaleDocRefer
{
    public class cmlReqUpdSaleRefer
    {
        /// <summary>
        /// รหัสสาขา
        /// </summary>
        public string ptBchCode { get; set; }

        /// <summary>
        /// รหัสสาขาของเลขที่เอกสารอ้างอิง
        /// </summary>
        public string ptRefBchCode { get; set; }    //*Arm 63-09-16

        /// <summary>
        /// เลขที่เอกสาร
        /// </summary>
        public string ptDocNo { get; set; }

        /// <summary>
        /// เลขที่เอกสารอ้างอิง
        /// </summary>
        public string ptRefDocNo { get; set; }

        /// <summary>
        /// ประเภทการขาย
        /// </summary>
        public Nullable<int> pnSaleType { get; set; }

        /// <summary>
        /// option การคืน
        /// </summary>
        public Nullable<int> pnOptionRfn { get; set; }

        public List<cmlTblRefund> aoRfn { get; set; }
    }

    public class cmlTblRefund
    {
        public Nullable<int> pnSeqNo { get; set; }
        public Nullable<int> pnSeqNoOld { get; set; }
        public Nullable<decimal> pcQty { get; set; }
        public Nullable<decimal> pcQtyRfn { get; set; }
    }
    
}
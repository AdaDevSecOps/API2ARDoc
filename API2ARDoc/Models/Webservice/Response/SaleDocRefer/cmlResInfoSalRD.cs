using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleDocRefer
{
    public class cmlResInfoSalRD
    {
        /// <summary>
        ///สาขาสร้าง
        /// </summary>
        public string rtBchCode { get; set; }

        /// <summary>
        ///เลขที่เอกสาร
        /// </summary>
        public string rtXshDocNo { get; set; }

        /// <summary>
        ///ลำดับการ Redeem
        /// </summary>
        public Nullable<int> rnXrdSeqNo { get; set; }

        /// <summary>
        ///ประเภทเอกสาร 1: Redeem สินค้า แต้ม+เงิน 2: Redeem ส่วนลด
        /// </summary>
        public string rtRdhDocType { get; set; }

        /// <summary>
        ///RD Type 1 อ้างอิงลำดับใน DT ,RD Type 2 อ้างอิงลำดับใน RC
        /// </summary>
        public Nullable<int> rnXrdRefSeq { get; set; }

        /// <summary>
        ///เลขที่อ้างอิง
        /// </summary>
        public string rtXrdRefCode { get; set; }

        /// <summary>
        ///จำนวนสินค้าที่ Redeem
        /// </summary>
        public Nullable<decimal> rcXrdPdtQty { get; set; }

        /// <summary>
        ///จำนวนแต้มที่ใช้แลก
        /// </summary>
        public Nullable<Int64> rnXrdPntUse { get; set; }
    }
}
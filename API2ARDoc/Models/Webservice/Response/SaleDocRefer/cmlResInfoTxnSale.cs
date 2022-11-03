using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleDocRefer
{
    public class cmlResInfoTxnSale
    {
        /// <summary>
        ///รหัสกลุ่มบริษัท
        /// </summary>
        public string rtCgpCode { get; set; }

        /// <summary>
        ///รหัสสมาชิก / เลขที่บัตรประจำตัวประชาชน/Passport
        /// </summary>
        public string rtMemCode { get; set; }

        /// <summary>
        ///เอกสารอ้างอิง
        /// </summary>
        public string rtTxnRefDoc { get; set; }

        /// <summary>
        ///อ้างอิงเอกสาร เช่น กรณีคืนอ้างอิงบิลขาย , บิลขายเก็บค่าเป็นว่าง
        /// </summary>
        public string rtTxnRefInt { get; set; }

        /// <summary>
        ///รหัสผู้จำหน่าย
        /// </summary>
        public string rtTxnRefSpl { get; set; }

        /// <summary>
        ///วันที่เอกสาร
        /// </summary>
        public Nullable<DateTime> rdTxnRefDate { get; set; }

        /// <summary>
        ///ยอดซื้อสุทธิ
        /// </summary>
        public Nullable<decimal> rcTxnRefGrand { get; set; }

        /// <summary>
        ///เงื่อนไข อัตราส่วนมูลค่าซื้อ
        /// </summary>
        public Nullable<decimal> rcTxnPntOptBuyAmt { get; set; }

        /// <summary>
        ///เงื่อนไข อัตราแต้มที่จะได้
        /// </summary>
        public Nullable<decimal> rcTxnPntOptGetQty { get; set; }

        /// <summary>
        ///จำนวนแต้มสะสมขณะสร้างเอกสาร
        /// </summary>
        public Nullable<decimal> rcTxnPntB4Bill { get; set; }

        /// <summary>
        ///วันที่เริ่มใช้งานแต้มได้
        /// </summary>
        public Nullable<DateTime> rdTxnPntStart { get; set; }

        /// <summary>
        ///วันที่เริ่มใช้งานแต้มได้
        /// </summary>
        public Nullable<DateTime> rdTxnPntExpired { get; set; }

        /// <summary>
        ///จำนวนแต้มที่ได้
        /// </summary>
        public Nullable<decimal> rcTxnPntBillQty { get; set; }

        /// <summary>
        ///แต้มที่ใช้ไปแล้ว
        /// </summary>
        public Nullable<decimal> rcTxnPntUsed { get; set; }

        /// <summary>
        ///แต้มที่หมดอายุ
        /// </summary>
        public Nullable<decimal> rcTxnPntExpired { get; set; }

        /// <summary>
        ///สถานะ 1:คำนวนได้ 2:ไม่นำไปคำนวนแล้ว priority สูงกว่าช่วง start-expired
        /// </summary>
        public string rtTxnPntStaClosed { get; set; }

        /// <summary>
        ///วันที่ปรับปรุงรายการล่าสุด
        /// </summary>
        public Nullable<DateTime> rdLastUpdOn { get; set; }

        /// <summary>
        ///ผู้ปรับปรุงรายการล่าสุด
        /// </summary>
        public string rtLastUpdBy { get; set; }

        /// <summary>
        ///วันที่สร้างรายการ
        /// </summary>
        public Nullable<DateTime> rdCreateOn { get; set; }

        /// <summary>
        ///ผู้สร้างรายการ
        /// </summary>
        public string rtCreateBy { get; set; }

        /// <summary>
        ///ประเภทบิล   1 = บิลขาย , 2:บิล Void   Def: 1
        /// </summary>
        public string rtTxnPntDocType { get; set; }
    }
}
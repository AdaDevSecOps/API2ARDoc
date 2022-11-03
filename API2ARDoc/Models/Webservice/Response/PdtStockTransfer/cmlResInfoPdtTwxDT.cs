using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.PdtStockTransfer
{
    public class cmlResInfoPdtTwxDT
    {
        /// <summary>
        ///สาขาสร้าง
        /// </summary>
        public string rtBchCode { get; set; }

        /// <summary>
        ///เลขที่เอกสาร
        /// </summary>
        public string rtXthDocNo { get; set; }

        /// <summary>
        ///ลำดับ
        /// </summary>
        public Nullable<int> rnXtdSeqNo { get; set; }

        /// <summary>
        ///รหัสสินค้า
        /// </summary>
        public string rtPdtCode { get; set; }

        /// <summary>
        ///ชื่อสินค้า
        /// </summary>
        public string rtXtdPdtName { get; set; }

        /// <summary>
        ///รหัสหน่วย
        /// </summary>
        public string rtPunCode { get; set; }

        /// <summary>
        ///ชื่อหน่วยสินค้า
        /// </summary>
        public string rtPunName { get; set; }

        /// <summary>
        ///อัตราส่วนต่อหน่วย
        /// </summary>
        public Nullable<decimal> rcXtdFactor { get; set; }

        /// <summary>
        ///บาร์โค้ด
        /// </summary>
        public string rtXtdBarCode { get; set; }

        /// <summary>
        ///ประเภทภาษี 1:มีภาษี, 2:ไม่มีภาษี
        /// </summary>
        public string rtXtdVatType { get; set; }

        /// <summary>
        ///รหัสภาษี ณ. ซื้อ
        /// </summary>
        public string rtVatCode { get; set; }

        /// <summary>
        ///อัตราภาษี ณ. ซื้อ
        /// </summary>
        public Nullable<decimal> rcXtdVatRate { get; set; }

        /// <summary>
        ///จำนวนชื้น ตาม หน่วย
        /// </summary>
        public Nullable<decimal> rcXtdQty { get; set; }

        /// <summary>
        ///จำนวนรวมหน่วยเล็กสุด (FCXpdQty*FCXpdFactor)
        /// </summary>
        public Nullable<decimal> rcXtdQtyAll { get; set; }

        /// <summary>
        ///ราคาซื้อ ตาม หน่วย * อัตราแลกเปลี่ยน(HD.FCXphRteFac)
        /// </summary>
        public Nullable<decimal> rcXtdSetPrice { get; set; }

        /// <summary>
        ///มูลค่ารวมก่อนลด (Qty*SetPrice) ทุกกรณี (ไม่เปลี่ยน)
        /// </summary>
        public Nullable<decimal> rcXtdAmt { get; set; }

        /// <summary>
        ///มูลค่าภาษี IN: Net-((Net*100)/(100+VatRate)) ,EX: ((Net*(100+VatRate))/100)-Net
        /// </summary>
        public Nullable<decimal> rcXtdVat { get; set; }

        /// <summary>
        ///มูลค่าแยกภาษี (Net-FCXpdVat)
        /// </summary>
        public Nullable<decimal> rcXtdVatable { get; set; }

        /// <summary>
        ///มูลค่าสุทธิก่อนท้ายบิล (FCXpdVat+FCXpdVatable)
        /// </summary>
        public Nullable<decimal> rcXtdNet { get; set; }

        /// <summary>
        ///ต้นทุนรวมใน (FCXpdVat+FCXpdVatable)
        /// </summary>
        public Nullable<decimal> rcXtdCostIn { get; set; }

        /// <summary>
        ///ต้นทุนแยกนอก (FCXpdVatable)
        /// </summary>
        public Nullable<decimal> rcXtdCostEx { get; set; }

        /// <summary>
        ///สถานะตัดสต๊อก ว่าง:ยังไม่ทำ, 1:ทำแล้ว
        /// </summary>
        public string rtXtdStaPrcStk { get; set; }

        /// <summary>
        ///ระดับสิน(ค้าชุด)
        /// </summary>
        public Nullable<int> rnXtdPdtLevel { get; set; }

        /// <summary>
        ///รหัสสินค้าชุด
        /// </summary>
        public string rtXtdPdtParent { get; set; }

        /// <summary>
        ///จำนวนต่อชุด
        /// </summary>
        public Nullable<decimal> rcXtdQtySet { get; set; }

        /// <summary>
        ///สถานะ สินค้าชุด 1:ทั่วไป, 2:สินค้าประกอบ, 3:สินค้าชุด
        /// </summary>
        public string rtXtdPdtStaSet { get; set; }

        /// <summary>
        ///หมายเหตุรายการ
        /// </summary>
        public string rtXtdRmk { get; set; }

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
    }
}
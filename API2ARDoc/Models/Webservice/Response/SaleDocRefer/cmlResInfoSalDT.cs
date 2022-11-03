using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleDocRefer
{
    public class cmlResInfoSalDT
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
        ///ลำดับ
        /// </summary>
        public Nullable<int> rnXsdSeqNo { get; set; }

        /// <summary>
        ///รหัสสินค้า
        /// </summary>
        public string rtPdtCode { get; set; }

        /// <summary>
        ///ชื่อสินค้า
        /// </summary>
        public string rtXsdPdtName { get; set; }

        /// <summary>
        ///รหัสหน่วย
        /// </summary>
        public string rtPunCode { get; set; }

        /// <summary>
        ///ชื่อหน่วยสินค้า
        /// </summary>
        public string rtPunName { get; set; }

        /// <summary>
        /// รหัสกลุ่มราคา
        /// </summary>
        public string rtPplCode { get; set; } //*Net 63-03-25

        /// <summary>
        ///อัตราส่วนต่อหน่วย
        /// </summary>
        public Nullable<decimal> rcXsdFactor { get; set; }

        /// <summary>
        ///บาร์โค้ด
        /// </summary>
        public string rtXsdBarCode { get; set; }

        /// <summary>
        ///รหัส ซีเรียล
        /// </summary>
        public string rtSrnCode { get; set; }

        /// <summary>
        ///ประเภทภาษี 1:มีภาษี, 2:ไม่มีภาษี
        /// </summary>
        public string rtXsdVatType { get; set; }

        /// <summary>
        ///รหัสภาษี ณ. ซื้อ
        /// </summary>
        public string rtVatCode { get; set; }

        /// <summary>
        ///อัตราภาษี ณ. ซื้อ
        /// </summary>
        public Nullable<decimal> rcXsdVatRate { get; set; }

        /// <summary>
        ///ใช้ราคาขาย 1:บังคับ, 2:แก้ไข, 3:เครื่องชั่ง,4: นน.
        /// </summary>
        public string rtXsdSaleType { get; set; }

        /// <summary>
        ///จากราคาซื้อ ตาม หน่วย * อัตราแลกเปลี่ยน(HD.FCXphRteFac)
        /// </summary>
        public Nullable<decimal> rcXsdSalePrice { get; set; }

        /// <summary>
        ///จำนวนชื้น ตาม หน่วย
        /// </summary>
        public Nullable<decimal> rcXsdQty { get; set; }

        /// <summary>
        ///จำนวนรวมหน่วยเล็กสุด (FCXpdQty*FCXpdFactor)
        /// </summary>
        public Nullable<decimal> rcXsdQtyAll { get; set; }

        /// <summary>
        ///ราคาซื้อ ตาม หน่วย * อัตราแลกเปลี่ยน(HD.FCXphRteFac)
        /// </summary>
        public Nullable<decimal> rcXsdSetPrice { get; set; }

        /// <summary>
        ///มูลค่ารวมก่อนลด
        /// </summary>
        public Nullable<decimal> rcXsdAmtB4DisChg { get; set; }

        /// <summary>
        ///ข้อความมูลค่าลดชาร์จ เช่น 5 หรือ 5%
        /// </summary>
        public string rtXsdDisChgTxt { get; set; }

        /// <summary>
        ///มูลค่ารวมส่วนลด
        /// </summary>
        public Nullable<decimal> rcXsdDis { get; set; }

        /// <summary>
        ///มูลค่ารวมส่วนชาร์จ
        /// </summary>
        public Nullable<decimal> rcXsdChg { get; set; }

        /// <summary>
        ///มูลค่าสุทธิก่อนท้ายบิล (FCXpdAmt-FCXpdDis+FCXpdChg)
        /// </summary>
        public Nullable<decimal> rcXsdNet { get; set; }

        /// <summary>
        ///มูลค่าสุทธิหลังท้ายบิล (Net-SUM(Disท้ายบิล))
        /// </summary>
        public Nullable<decimal> rcXsdNetAfHD { get; set; }

        /// <summary>
        ///มูลค่าภาษี IN: NetAfHD-((NetAfHD*100)/(100+VatRate)) ,EX: ((NetAfHD*(100+VatRate))/100)-NetAfHD
        /// </summary>
        public Nullable<decimal> rcXsdVat { get; set; }

        /// <summary>
        ///มูลค่าแยกภาษี (NetAfHD-FCXpdVat)
        /// </summary>
        public Nullable<decimal> rcXsdVatable { get; set; }

        /// <summary>
        ///มูลค่าภาษี ณ. ที่จ่าย (FCXpdVatable* FCXpdWhtRate%)
        /// </summary>
        public Nullable<decimal> rcXsdWhtAmt { get; set; }

        /// <summary>
        ///รหัส ภาษี ณ. ที่จ่าย
        /// </summary>
        public string rtXsdWhtCode { get; set; }

        /// <summary>
        ///อัตราภาษี ณ. ที่จ่าย
        /// </summary>
        public Nullable<decimal> rcXsdWhtRate { get; set; }

        /// <summary>
        ///ต้นทุนรวมใน (FCXpdVat+FCXpdVatable)
        /// </summary>
        public Nullable<decimal> rcXsdCostIn { get; set; }

        /// <summary>
        ///ต้นทุนแยกนอก (FCXpdVatable)
        /// </summary>
        public Nullable<decimal> rcXsdCostEx { get; set; }

        /// <summary>
        ///สถานะ สินค้า 1:ขาย, 2:คืน, 3:แถม, 4: ยกเลิก (Void)
        /// </summary>
        public string rtXsdStaPdt { get; set; }

        /// <summary>
        ///จำนวนคงเหลือ ตามหน่วย (Default:FCXpdQty)
        /// </summary>
        public Nullable<decimal> rcXsdQtyLef { get; set; }

        /// <summary>
        ///จำนวนคืนตามหน่วย (Default:0)
        /// </summary>
        public Nullable<decimal> rcXsdQtyRfn { get; set; }

        /// <summary>
        ///สถานะตัดสต๊อก ว่าง:ยังไม่ทำ, 1:ทำแล้ว
        /// </summary>
        public string rtXsdStaPrcStk { get; set; }

        /// <summary>
        ///สถานะอนุญาต ลด/ชาร์จ  1:อนุญาต , 2:ไม่อนุญาต
        /// </summary>
        public string rtXsdStaAlwDis { get; set; }

        /// <summary>
        ///ระดับสิน(ค้าชุด)
        /// </summary>
        public Nullable<int> rnXsdPdtLevel { get; set; }

        /// <summary>
        ///รหัสสินค้าชุด
        /// </summary>
        public string rtXsdPdtParent { get; set; }

        /// <summary>
        ///จำนวนต่อชุด
        /// </summary>
        public Nullable<decimal> rcXsdQtySet { get; set; }

        /// <summary>
        ///สถานะ สินค้าชุด 1:ทั่วไป, 2:สินค้าประกอบ, 3:สินค้าชุด
        /// </summary>
        public string rtPdtStaSet { get; set; }

        /// <summary>
        ///หมายเหตุรายการ
        /// </summary>
        public string rtXsdRmk { get; set; }

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
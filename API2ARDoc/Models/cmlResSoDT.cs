using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlResSoDT
    {
        ///<summary>สาขาสร้าง</summary>
        [JsonProperty("rtFTBchCode")]
        public string FTBchCode { get; set; }

        ///<summary>เลขที่เอกสาร</summary>
        [JsonProperty("rtFTXshDocNo")]
        public string FTXshDocNo { get; set; }

        ///<summary>ลำดับ</summary>
        [JsonProperty("rtFNXsdSeqNo")]
        public string FNXsdSeqNo { get; set; }

        ///<summary>รหัสสินค้า</summary>
        [JsonProperty("rtFTPdtCode")]
        public string FTPdtCode { get; set; }

        ///<summary>ชื่อสินค้า</summary>
        [JsonProperty("rtFTXsdPdtName")]
        public string FTXsdPdtName { get; set; }

        ///<summary>รหัสหน่วย</summary>
        [JsonProperty("rtFTPunCode")]
        public string FTPunCode { get; set; }

        ///<summary>ชื่อหน่วยสินค้า</summary>
        [JsonProperty("rtFTPunName")]
        public string FTPunName { get; set; }

        ///<summary>อัตราส่วนต่อหน่วย</summary>
        [JsonProperty("rtFCXsdFactor")]
        public string FCXsdFactor { get; set; }

        ///<summary>บาร์โค้ด</summary>
        [JsonProperty("rtFTXsdBarCode")]
        public string FTXsdBarCode { get; set; }

        ///<summary>รหัส ซีเรียล</summary>
        [JsonProperty("rtFTSrnCode")]
        public string FTSrnCode { get; set; }

        ///<summary>ประเภทภาษี 1:มีภาษี, 2:ไม่มีภาษี</summary>
        [JsonProperty("rtFTXsdVatType")]
        public string FTXsdVatType { get; set; }

        ///<summary>รหัสภาษี ณ. ซื้อ</summary>
        [JsonProperty("rtFTVatCode")]
        public string FTVatCode { get; set; }

        ///<summary>อัตราภาษี ณ. ซื้อ</summary>
        [JsonProperty("rtFCXsdVatRate")]
        public string FCXsdVatRate { get; set; }

        ///<summary>ใช้ราคาขาย 1:บังคับ, 2:แก้ไข, 3:เครื่องชั่ง,4: นน.</summary>
        [JsonProperty("rtFTXsdSaleType")]
        public string FTXsdSaleType { get; set; }

        ///<summary>จากราคาซื้อ ตาม หน่วย * อัตราแลกเปลี่ยน(HD.FCXphRteFac)</summary>
        [JsonProperty("rtFCXsdSalePrice")]
        public string FCXsdSalePrice { get; set; }

        ///<summary>จำนวนชื้น ตาม หน่วย</summary>
        [JsonProperty("rtFCXsdQty")]
        public string FCXsdQty { get; set; }

        ///<summary>จำนวนรวมหน่วยเล็กสุด (FCXpdQty*FCXpdFactor)</summary>
        [JsonProperty("rtFCXsdQtyAll")]
        public string FCXsdQtyAll { get; set; }

        ///<summary>ราคาซื้อ ตาม หน่วย * อัตราแลกเปลี่ยน(HD.FCXphRteFac)</summary>
        [JsonProperty("rtFCXsdSetPrice")]
        public string FCXsdSetPrice { get; set; }

        ///<summary>มูลค่ารวมก่อนลด</summary>
        [JsonProperty("rtFCXsdAmtB4DisChg")]
        public string FCXsdAmtB4DisChg { get; set; }

        ///<summary>ข้อความมูลค่าลดชาร์จ เช่น 5 หรือ 5%</summary>
        [JsonProperty("rtFTXsdDisChgTxt")]
        public string FTXsdDisChgTxt { get; set; }

        ///<summary>มูลค่ารวมส่วนลด</summary>
        [JsonProperty("rtFCXsdDis")]
        public string FCXsdDis { get; set; }

        ///<summary>มูลค่ารวมส่วนชาร์จ</summary>
        [JsonProperty("rtFCXsdChg")]
        public string FCXsdChg { get; set; }

        ///<summary>มูลค่าสุทธิก่อนท้ายบิล (FCXpdAmt-FCXpdDis+FCXpdChg)</summary>
        [JsonProperty("rtFCXsdNet")]
        public string FCXsdNet { get; set; }

        ///<summary>มูลค่าสุทธิหลังท้ายบิล (Net-SUM(Disท้ายบิล))</summary>
        [JsonProperty("rtFCXsdNetAfHD")]
        public string FCXsdNetAfHD { get; set; }

        ///<summary>มูลค่าภาษี IN: NetAfHD-((NetAfHD*100)/(100+VatRate)) ,EX: ((NetAfHD*(100+VatRate))/100)-NetAfHD</summary>
        [JsonProperty("rtFCXsdVat")]
        public string FCXsdVat { get; set; }

        ///<summary>มูลค่าแยกภาษี (NetAfHD-FCXpdVat)</summary>
        [JsonProperty("rtFCXsdVatable")]
        public string FCXsdVatable { get; set; }

        ///<summary>มูลค่าภาษี ณ. ที่จ่าย (FCXpdVatable* FCXpdWhtRate%)</summary>
        [JsonProperty("rtFCXsdWhtAmt")]
        public string FCXsdWhtAmt { get; set; }

        ///<summary>รหัส ภาษี ณ. ที่จ่าย</summary>
        [JsonProperty("rtFTXsdWhtCode")]
        public string FTXsdWhtCode { get; set; }

        ///<summary>อัตราภาษี ณ. ที่จ่าย</summary>
        [JsonProperty("rtFCXsdWhtRate")]
        public string FCXsdWhtRate { get; set; }

        ///<summary>ต้นทุนรวมใน (FCXpdVat+FCXpdVatable)</summary>
        [JsonProperty("rtFCXsdCostIn")]
        public string FCXsdCostIn { get; set; }

        ///<summary>ต้นทุนแยกนอก (FCXpdVatable)</summary>
        [JsonProperty("rtFCXsdCostEx")]
        public string FCXsdCostEx { get; set; }

        ///<summary>สถานะ สินค้า 1:ขาย, 2:คืน, 3:แถม, 4: ยกเลิก (Void)</summary>
        [JsonProperty("rtFTXsdStaPdt")]
        public string FTXsdStaPdt { get; set; }

        ///<summary>จำนวนคงเหลือ ตามหน่วย (Default:FCXpdQty)</summary>
        [JsonProperty("rtFCXsdQtyLef")]
        public string FCXsdQtyLef { get; set; }

        ///<summary>จำนวนคืนตามหน่วย (Default:0)</summary>
        [JsonProperty("rtFCXsdQtyRfn")]
        public string FCXsdQtyRfn { get; set; }

        ///<summary>สถานะตัดสต๊อก ว่าง:ยังไม่ทำ, 1:ทำแล้ว</summary>
        [JsonProperty("rtFTXsdStaPrcStk")]
        public string FTXsdStaPrcStk { get; set; }

        ///<summary>สถานะอนุญาต ลด/ชาร์จ  1:อนุญาต , 2:ไม่อนุญาต</summary>
        [JsonProperty("rtFTXsdStaAlwDis")]
        public string FTXsdStaAlwDis { get; set; }

        ///<summary>ระดับสิน(ค้าชุด)</summary>
        [JsonProperty("rtFNXsdPdtLevel")]
        public string FNXsdPdtLevel { get; set; }

        ///<summary>รหัสสินค้าชุด</summary>
        [JsonProperty("rtFTXsdPdtParent")]
        public string FTXsdPdtParent { get; set; }

        ///<summary>จำนวนต่อชุด</summary>
        [JsonProperty("rtFCXsdQtySet")]
        public string FCXsdQtySet { get; set; }

        ///<summary>สถานะ สินค้าชุด 1:ทั่วไป, 2:สินค้าประกอบ, 3:สินค้าชุด</summary>
        [JsonProperty("rtFTPdtStaSet")]
        public string FTPdtStaSet { get; set; }

        ///<summary>หมายเหตุรายการ</summary>
        [JsonProperty("rtFTXsdRmk")]
        public string FTXsdRmk { get; set; }

        ///<summary>วันที่ปรับปรุงรายการล่าสุด</summary>
        [JsonProperty("rtFDLastUpdOn")]
        public string FDLastUpdOn { get; set; }

        ///<summary>ผู้ปรับปรุงรายการล่าสุด</summary>
        [JsonProperty("rtFTLastUpdBy")]
        public string FTLastUpdBy { get; set; }

        ///<summary>วันที่สร้างรายการ</summary>
        [JsonProperty("rtFDCreateOn")]
        public string FDCreateOn { get; set; }

        ///<summary>ผู้สร้างรายการ</summary>
        [JsonProperty("rtFTCreateBy")]
        public string FTCreateBy { get; set; }


    }
}
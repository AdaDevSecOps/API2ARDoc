using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlResSoHD
    {
        [JsonProperty("raTARTSoDT")]
        public List<cmlResSoDT> aSoDT { get; set; }

        [JsonProperty("raTARTSoHDCst")]
        public List<cmlResSoHDCst> aSoHDCst { get; set; }


        [JsonProperty("raTARTSoHDDis")]
        public List<cmlResSoHDDis> aSoHDDis { get; set; }


        [JsonProperty("raTARTSoDTDis")]
        public List<cmlResSoDTDis> aSoDTDis { get; set; }

        ///<summary>สาขาสร้าง</summary>
        [JsonProperty("rtFTBchCode")]
        public string FTBchCode { get; set; }

        ///<summary>เลขที่เอกสาร  Def : XYYPOS-1234567 Gen ตาม TCNTAuto</summary>
        [JsonProperty("rtFTXshDocNo")]
        public string FTXshDocNo { get; set; }

        ///<summary>ร้านค้า</summary>
        [JsonProperty("rtFTShpCode")]
        public string FTShpCode { get; set; }

        ///<summary>ประเภทเอกสาร ดูจาก ตาราง TSysDocType</summary>
        [JsonProperty("rtFNXshDocType")]
        public string FNXshDocType { get; set; }

        ///<summary>วันที่/เวลา เอกสาร dd/mm/yyyy H:mm:ss</summary>
        [JsonProperty("rtFDXshDocDate")]
        public string FDXshDocDate { get; set; }

        ///<summary>สด/เครดิต 1:สด 2:credit</summary>
        [JsonProperty("rtFTXshCshOrCrd")]
        public string FTXshCshOrCrd { get; set; }

        ///<summary>ภาษีมูลค่าเพิ่ม 1:รวมใน, 2:แยกนอก</summary>
        [JsonProperty("rtFTXshVATInOrEx")]
        public string FTXshVATInOrEx { get; set; }

        ///<summary>แผนก</summary>
        [JsonProperty("rtFTDptCode")]
        public string FTDptCode { get; set; }

        ///<summary>คลัง</summary>
        [JsonProperty("rtFTWahCode")]
        public string FTWahCode { get; set; }

        ///<summary>เครื่องจุดขาย</summary>
        [JsonProperty("rtFTPosCode")]
        public string FTPosCode { get; set; }

        ///<summary>รอบ</summary>
        [JsonProperty("rtFTShfCode")]
        public string FTShfCode { get; set; }

        ///<summary>ลำดับการ SignIn DT</summary>
        [JsonProperty("rtFNSdtSeqNo")]
        public string FNSdtSeqNo { get; set; }

        ///<summary>พนักงาน Key</summary>
        [JsonProperty("rtFTUsrCode")]
        public string FTUsrCode { get; set; }

        ///<summary>พนักงานขาย</summary>
        [JsonProperty("rtFTSpnCode")]
        public string FTSpnCode { get; set; }

        ///<summary>ผู้อนุมัติ</summary>
        [JsonProperty("rtFTXshApvCode")]
        public string FTXshApvCode { get; set; }

        ///<summary>ลูกค้า</summary>
        [JsonProperty("rtFTCstCode")]
        public string FTCstCode { get; set; }

        ///<summary>เลขที่ใบกำกับ</summary>
        [JsonProperty("rtFTXshDocVatFull")]
        public string FTXshDocVatFull { get; set; }

        ///<summary>อ้างอิง เลขที่เอกสาร ภายนอก</summary>
        [JsonProperty("rtFTXshRefExt")]
        public string FTXshRefExt { get; set; }

        ///<summary>อ้างอิง วันที่เอกสาร ภายนอก</summary>
        [JsonProperty("rtFDXshRefExtDate")]
        public string FDXshRefExtDate { get; set; }

        ///<summary>อ้างอิง เลขที่เอกสาร ภายใน</summary>
        [JsonProperty("rtFTXshRefInt")]
        public string FTXshRefInt { get; set; }

        ///<summary>อ้างอิง วันที่เอกสาร ภายใน</summary>
        [JsonProperty("rtFDXshRefIntDate")]
        public string FDXshRefIntDate { get; set; }

        ///<summary>อ้างถึงเอกสาร มัดจำ</summary>
        [JsonProperty("rtFTXshRefAE")]
        public string FTXshRefAE { get; set; }

        ///<summary>จำนวนครั้งที่พิมพ์</summary>
        [JsonProperty("rtFNXshDocPrint")]
        public string FNXshDocPrint { get; set; }

        ///<summary>รหัสสกุลเงิน</summary>
        [JsonProperty("rtFTRteCode")]
        public string FTRteCode { get; set; }

        ///<summary>อัตราแลกเปลี่ยน</summary>
        [JsonProperty("rtFCXshRteFac")]
        public string FCXshRteFac { get; set; }

        ///<summary>ยอดรวม</summary>
        [JsonProperty("rtFCXshTotal")]
        public string FCXshTotal { get; set; }

        ///<summary>ยอดรวมสินค้าไม่มีภาษี</summary>
        [JsonProperty("rtFCXshTotalNV")]
        public string FCXshTotalNV { get; set; }

        ///<summary>ยอดรวมสินค้าห้ามลด</summary>
        [JsonProperty("rtFCXshTotalNoDis")]
        public string FCXshTotalNoDis { get; set; }

        ///<summary>ยอมรวมสินค้าลดได้ และมีภาษี</summary>
        [JsonProperty("rtFCXshTotalB4DisChgV")]
        public string FCXshTotalB4DisChgV { get; set; }

        ///<summary>ยอมรวมสินค้าลดได้ และไม่มีภาษี</summary>
        [JsonProperty("rtFCXshTotalB4DisChgNV")]
        public string FCXshTotalB4DisChgNV { get; set; }

        ///<summary>ข้อความมูลค่าลดชาร์จ เช่น 5 หรือ 5%</summary>
        [JsonProperty("rtFTXshDisChgTxt")]
        public string FTXshDisChgTxt { get; set; }

        ///<summary>มูลค่ารวมส่วนลด SUM(HDis.FCXddDisVat+HDis.FCXddDisNoVat)</summary>
        [JsonProperty("rtFCXshDis")]
        public string FCXshDis { get; set; }

        ///<summary>มูลค่ารวมส่วนชาร์จ SUM(HDis.FCXddChgVat+HDis.FCXddChgNoVat)</summary>
        [JsonProperty("rtFCXshChg")]
        public string FCXshChg { get; set; }

        ///<summary>ยอดรวมหลังลด และมีภาษี</summary>
        [JsonProperty("rtFCXshTotalAfDisChgV")]
        public string FCXshTotalAfDisChgV { get; set; }

        ///<summary>ยอดรวมหลังลด และไม่มีภาษี</summary>
        [JsonProperty("rtFCXshTotalAfDisChgNV")]
        public string FCXshTotalAfDisChgNV { get; set; }

        ///<summary>ยอดมัดจำ</summary>
        [JsonProperty("rtFCXshRefAEAmt")]
        public string FCXshRefAEAmt { get; set; }

        ///<summary>ยอดรวมเฉพาะภาษี (FCXshTotal-FCXshTotalNV-(FCXshTotalB4DisChgV-FCXshTotalAfDisChgV))</summary>
        [JsonProperty("rtFCXshAmtV")]
        public string FCXshAmtV { get; set; }

        ///<summary>ยอดรวมเฉพาะไม่มีภาษี (FCXshTotalNV-(FCXshTotalB4DisChgNV-FCXshTotalAfDisChgNV))</summary>
        [JsonProperty("rtFCXshAmtNV")]
        public string FCXshAmtNV { get; set; }

        ///<summary>ยอดภาษี</summary>
        [JsonProperty("rtFCXshVat")]
        public string FCXshVat { get; set; }

        ///<summary>ยอดแยกภาษี (FCXshAmtV-FCXshVat)+FCXshAmt์NV</summary>
        [JsonProperty("rtFCXshVatable")]
        public string FCXshVatable { get; set; }

        ///<summary>รหัสอัตราภาษี ณ ที่จ่าย</summary>
        [JsonProperty("rtFTXshWpCode")]
        public string FTXshWpCode { get; set; }

        ///<summary>ภาษีหัก ณ ที่จ่าย SUM(FCXpdWhtAmt)  /Key In</summary>
        [JsonProperty("rtFCXshWpTax")]
        public string FCXshWpTax { get; set; }

        ///<summary>ยอดรวม FCXshAmtV+FCXshAmtNV+FCXshRnd</summary>
        [JsonProperty("rtFCXshGrand")]
        public string FCXshGrand { get; set; }

        ///<summary>ยอดปัดเศษ (เมื่อชำระด้วยเงินสดเฉพาะขายปลีก)</summary>
        [JsonProperty("rtFCXshRnd")]
        public string FCXshRnd { get; set; }

        ///<summary>ข้อความ ยอดรวมสุทธิ(FCXphGrand)</summary>
        [JsonProperty("rtFTXshGndText")]
        public string FTXshGndText { get; set; }

        ///<summary>ยอดจ่าย</summary>
        [JsonProperty("rtFCXshPaid")]
        public string FCXshPaid { get; set; }

        ///<summary>ยอดค้าง Default: 0</summary>
        [JsonProperty("rtFCXshLeft")]
        public string FCXshLeft { get; set; }

        ///<summary>หมายเหตุ</summary>
        [JsonProperty("rtFTXshRmk")]
        public string FTXshRmk { get; set; }

        ///<summary>สถานะ การคืน 1:ไม่เคยคืน, 2:เคยคืน</summary>
        [JsonProperty("rtFTXshStaRefund")]
        public string FTXshStaRefund { get; set; }

        ///<summary>สถานะ เอกสาร  1:สมบูรณ์, 2:ไม่สมบูรณ์, 3:ยกเลิก</summary>
        [JsonProperty("rtFTXshStaDoc")]
        public string FTXshStaDoc { get; set; }

        ///<summary>สถานะ อนุมัติ เอกสาร ว่าง:ยังไม่ทำ, 1:อนุมัติแล้ว</summary>
        [JsonProperty("rtFTXshStaApv")]
        public string FTXshStaApv { get; set; }

        ///<summary>สถานะอนุมัติ 1: อนุมัติแล้ว  ว่าง null ยังไม่อนุมัติ</summary>
        [JsonProperty("rtFTXshStaPrcDoc")]
        public string FTXshStaPrcDoc { get; set; }

        ///<summary>สถานะ รับ/จ่ายเงิน 1:ยังไม่จ่าย 2:บางส่วน, 3:ครบ</summary>
        [JsonProperty("rtFTXshStaPaid")]
        public string FTXshStaPaid { get; set; }

        ///<summary>สถานะ เคลื่อนไหว 0:NonActive, 1:Active</summary>
        [JsonProperty("rtFNXshStaDocAct")]
        public string FNXshStaDocAct { get; set; }

        ///<summary>สถานะ อ้างอิง 0:ไม่เคยอ้างอิง, 1:อ้างอิงบางส่วน, 2:อ้างอิงหมดแล้ว</summary>
        [JsonProperty("rtFNXshStaRef")]
        public string FNXshStaRef { get; set; }

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
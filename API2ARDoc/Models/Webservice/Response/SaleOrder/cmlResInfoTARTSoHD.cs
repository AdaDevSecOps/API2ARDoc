using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleOrder
{
    public class cmlResInfoTARTSoHD
    {
        /// <summary>
        ///สาขาสร้าง
        /// </summary>
        public string rtBchCode { get; set; }

        /// <summary>
        ///เลขที่เอกสาร  Def : XYYPOS-1234567 Gen ตาม TCNTAuto
        /// </summary>
        public string rtXshDocNo { get; set; }

        /// <summary>
        ///ร้านค้า
        /// </summary>
        public string rtShpCode { get; set; }

        /// <summary>
        ///ประเภทเอกสาร ดูจาก ตาราง TSysDocType
        /// </summary>
        public Nullable<int> rnXshDocType { get; set; }

        /// <summary>
        ///วันที่/เวลา เอกสาร dd/mm/yyyy H:mm:ss
        /// </summary>
        public Nullable<DateTime> rdXshDocDate { get; set; }

        /// <summary>
        ///สด/เครดิต 1:สด 2:credit
        /// </summary>
        public string rtXshCshOrCrd { get; set; }

        /// <summary>
        ///ภาษีมูลค่าเพิ่ม 1:รวมใน, 2:แยกนอก
        /// </summary>
        public string rtXshVATInOrEx { get; set; }

        /// <summary>
        ///แผนก
        /// </summary>
        public string rtDptCode { get; set; }

        /// <summary>
        ///คลัง
        /// </summary>
        public string rtWahCode { get; set; }

        /// <summary>
        ///เครื่องจุดขาย
        /// </summary>
        public string rtPosCode { get; set; }

        /// <summary>
        ///รอบ
        /// </summary>
        public string rtShfCode { get; set; }

        /// <summary>
        ///ลำดับการ SignIn DT
        /// </summary>
        public Nullable<int> rnSdtSeqNo { get; set; }

        /// <summary>
        ///พนักงาน Key
        /// </summary>
        public string rtUsrCode { get; set; }

        /// <summary>
        ///พนักงานขาย
        /// </summary>
        public string rtSpnCode { get; set; }

        /// <summary>
        ///ผู้อนุมัติ
        /// </summary>
        public string rtXshApvCode { get; set; }

        /// <summary>
        ///ลูกค้า
        /// </summary>
        public string rtCstCode { get; set; }

        /// <summary>
        ///เลขที่ใบกำกับ
        /// </summary>
        public string rtXshDocVatFull { get; set; }

        /// <summary>
        ///อ้างอิง เลขที่เอกสาร ภายนอก
        /// </summary>
        public string rtXshRefExt { get; set; }

        /// <summary>
        ///อ้างอิง วันที่เอกสาร ภายนอก
        /// </summary>
        public Nullable<DateTime> rdXshRefExtDate { get; set; }

        /// <summary>
        ///อ้างอิง เลขที่เอกสาร ภายใน
        /// </summary>
        public string rtXshRefInt { get; set; }

        /// <summary>
        ///อ้างอิง วันที่เอกสาร ภายใน
        /// </summary>
        public Nullable<DateTime> rdXshRefIntDate { get; set; }

        /// <summary>
        ///อ้างถึงเอกสาร มัดจำ
        /// </summary>
        public string rtXshRefAE { get; set; }

        /// <summary>
        ///จำนวนครั้งที่พิมพ์
        /// </summary>
        public Nullable<int> rnXshDocPrint { get; set; }

        /// <summary>
        ///รหัสสกุลเงิน
        /// </summary>
        public string rtRteCode { get; set; }

        /// <summary>
        ///อัตราแลกเปลี่ยน
        /// </summary>
        public Nullable<decimal> rcXshRteFac { get; set; }

        /// <summary>
        ///ยอดรวม
        /// </summary>
        public Nullable<decimal> rcXshTotal { get; set; }

        /// <summary>
        ///ยอดรวมสินค้าไม่มีภาษี
        /// </summary>
        public Nullable<decimal> rcXshTotalNV { get; set; }

        /// <summary>
        ///ยอดรวมสินค้าห้ามลด
        /// </summary>
        public Nullable<decimal> rcXshTotalNoDis { get; set; }

        /// <summary>
        ///ยอมรวมสินค้าลดได้ และมีภาษี
        /// </summary>
        public Nullable<decimal> rcXshTotalB4DisChgV { get; set; }

        /// <summary>
        ///ยอมรวมสินค้าลดได้ และไม่มีภาษี
        /// </summary>
        public Nullable<decimal> rcXshTotalB4DisChgNV { get; set; }

        /// <summary>
        ///ข้อความมูลค่าลดชาร์จ เช่น 5 หรือ 5%
        /// </summary>
        public string rtXshDisChgTxt { get; set; }

        /// <summary>
        ///มูลค่ารวมส่วนลด SUM(HDis.FCXddDisVat+HDis.FCXddDisNoVat)
        /// </summary>
        public Nullable<decimal> rcXshDis { get; set; }

        /// <summary>
        ///มูลค่ารวมส่วนชาร์จ SUM(HDis.FCXddChgVat+HDis.FCXddChgNoVat)
        /// </summary>
        public Nullable<decimal> rcXshChg { get; set; }

        /// <summary>
        ///ยอดรวมหลังลด และมีภาษี
        /// </summary>
        public Nullable<decimal> rcXshTotalAfDisChgV { get; set; }

        /// <summary>
        ///ยอดรวมหลังลด และไม่มีภาษี
        /// </summary>
        public Nullable<decimal> rcXshTotalAfDisChgNV { get; set; }

        /// <summary>
        ///ยอดมัดจำ
        /// </summary>
        public Nullable<decimal> rcXshRefAEAmt { get; set; }

        /// <summary>
        ///ยอดรวมเฉพาะภาษี (FCXshTotal-FCXshTotalNV-(FCXshTotalB4DisChgV-FCXshTotalAfDisChgV))
        /// </summary>
        public Nullable<decimal> rcXshAmtV { get; set; }

        /// <summary>
        ///ยอดรวมเฉพาะไม่มีภาษี (FCXshTotalNV-(FCXshTotalB4DisChgNV-FCXshTotalAfDisChgNV))
        /// </summary>
        public Nullable<decimal> rcXshAmtNV { get; set; }

        /// <summary>
        ///ยอดภาษี
        /// </summary>
        public Nullable<decimal> rcXshVat { get; set; }

        /// <summary>
        ///ยอดแยกภาษี (FCXshAmtV-FCXshVat)+FCXshAmt์NV
        /// </summary>
        public Nullable<decimal> rcXshVatable { get; set; }

        /// <summary>
        ///รหัสอัตราภาษี ณ ที่จ่าย
        /// </summary>
        public string rtXshWpCode { get; set; }

        /// <summary>
        ///ภาษีหัก ณ ที่จ่าย SUM(FCXpdWhtAmt)  /Key In
        /// </summary>
        public Nullable<decimal> rcXshWpTax { get; set; }

        /// <summary>
        ///ยอดรวม FCXshAmtV+FCXshAmtNV+FCXshRnd
        /// </summary>
        public Nullable<decimal> rcXshGrand { get; set; }

        /// <summary>
        ///ยอดปัดเศษ (เมื่อชำระด้วยเงินสดเฉพาะขายปลีก)
        /// </summary>
        public Nullable<decimal> rcXshRnd { get; set; }

        /// <summary>
        ///ข้อความ ยอดรวมสุทธิ(FCXphGrand)
        /// </summary>
        public string rtXshGndText { get; set; }

        /// <summary>
        ///ยอดจ่าย
        /// </summary>
        public Nullable<decimal> rcXshPaid { get; set; }

        /// <summary>
        ///ยอดค้าง Default: 0
        /// </summary>
        public Nullable<decimal> rcXshLeft { get; set; }

        /// <summary>
        ///หมายเหตุ
        /// </summary>
        public string rtXshRmk { get; set; }

        /// <summary>
        ///สถานะ การคืน 1:ไม่เคยคืน, 2:เคยคืน
        /// </summary>
        public string rtXshStaRefund { get; set; }

        /// <summary>
        ///สถานะ เอกสาร  1:สมบูรณ์, 2:ไม่สมบูรณ์, 3:ยกเลิก
        /// </summary>
        public string rtXshStaDoc { get; set; }

        /// <summary>
        ///สถานะ อนุมัติ เอกสาร ว่าง:ยังไม่ทำ, 1:อนุมัติแล้ว
        /// </summary>
        public string rtXshStaApv { get; set; }

        /// <summary>
        ///สถานะอนุมัติ 1: อนุมัติแล้ว  ว่าง null ยังไม่อนุมัติ
        /// </summary>
        public string rtXshStaPrcDoc { get; set; }

        /// <summary>
        ///สถานะ รับ/จ่ายเงิน 1:ยังไม่จ่าย 2:บางส่วน, 3:ครบ
        /// </summary>
        public string rtXshStaPaid { get; set; }

        /// <summary>
        ///สถานะ เคลื่อนไหว 0:NonActive, 1:Active
        /// </summary>
        public Nullable<int> rnXshStaDocAct { get; set; }

        /// <summary>
        ///สถานะ อ้างอิง 0:ไม่เคยอ้างอิง, 1:อ้างอิงบางส่วน, 2:อ้างอิงหมดแล้ว
        /// </summary>
        public Nullable<int> rnXshStaRef { get; set; }

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
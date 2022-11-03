using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.PdtStockTransfer
{
    public class cmlResInfoPdtTwxHD
    {
        /// <summary>
        ///สาขาสร้าง
        /// </summary>
        public string rtBchCode { get; set; }

        /// <summary>
        ///เลขที่เอกสาร  XXYYMM-1234567
        /// </summary>
        public string rtXthDocNo { get; set; }

        /// <summary>
        ///วันที่/เวลา เอกสาร dd/mm/yyyy H:mm:ss
        /// </summary>
        public Nullable<DateTime> rdXthDocDate { get; set; }

        /// <summary>
        ///ภาษีมูลค่าเพิ่ม 1:รวมใน, 2:แยกนอก
        /// </summary>
        public string rtXthVATInOrEx { get; set; }

        /// <summary>
        ///แผนก
        /// </summary>
        public string rtDptCode { get; set; }

        /// <summary>
        ///รหัสตัวแทน/เจ้าของกำเนินการ
        /// </summary>
        public string rtXthMerCode { get; set; }

        /// <summary>
        ///ร้านค้า
        /// </summary>
        public string rtXthShopFrm { get; set; }

        /// <summary>
        ///ร้านค้า
        /// </summary>
        public string rtXthShopTo { get; set; }

        /// <summary>
        ///รหัสคลัง จาก
        /// </summary>
        public string rtXthWhFrm { get; set; }

        /// <summary>
        ///รหัสคลัง ไปยัง
        /// </summary>
        public string rtXthWhTo { get; set; }

        /// <summary>
        ///รหัสเครื่องจุดขาย จาก
        /// </summary>
        public string rtXthPosFrm { get; set; }

        /// <summary>
        ///รหัสเครื่องจุดขาย ไปยัง
        /// </summary>
        public string rtXthPosTo { get; set; }

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
        public string rtXthApvCode { get; set; }

        /// <summary>
        ///อ้างอิง เลขที่เอกสาร ภายนอก
        /// </summary>
        public string rtXthRefExt { get; set; }

        /// <summary>
        ///อ้างอิง วันที่เอกสาร ภายนอก
        /// </summary>
        public Nullable<DateTime> rdXthRefExtDate { get; set; }

        /// <summary>
        ///อ้างอิง เลขที่เอกสาร ภายใน
        /// </summary>
        public string rtXthRefInt { get; set; }

        /// <summary>
        ///อ้างอิง วันที่เอกสาร ภายใน
        /// </summary>
        public Nullable<DateTime> rdXthRefIntDate { get; set; }

        /// <summary>
        ///จำนวนครั้งที่พิมพ์
        /// </summary>
        public Nullable<int> rnXthDocPrint { get; set; }

        /// <summary>
        ///ยอดรวมก่อนลด
        /// </summary>
        public Nullable<decimal> rcXthTotal { get; set; }

        /// <summary>
        ///ยอดภาษี
        /// </summary>
        public Nullable<decimal> rcXthVat { get; set; }

        /// <summary>
        ///ยอดแยกภาษี
        /// </summary>
        public Nullable<decimal> rcXthVatable { get; set; }

        /// <summary>
        ///หมายเหตุ
        /// </summary>
        public string rtXthRmk { get; set; }

        /// <summary>
        ///สถานะ เอกสาร  1:สมบูรณ์, 2:ไม่สมบูรณ์, 3:ยกเลิก
        /// </summary>
        public string rtXthStaDoc { get; set; }

        /// <summary>
        ///สถานะ อนุมัติ เอกสาร ว่าง:ยังไม่ทำ, 1:อนุมัติแล้ว
        /// </summary>
        public string rtXthStaApv { get; set; }

        /// <summary>
        ///สถานะ ประมวลผลสต๊อก ว่าง หรือ Null:ยังไม่ทำ, 1:ทำแล้ว
        /// </summary>
        public string rtXthStaPrcStk { get; set; }

        /// <summary>
        ///สถานะ ประมวลผลสต๊อก ว่าง :ยังไม่ทำ, 1:ทำแล้ว
        /// </summary>
        public string rtXthStaDelMQ { get; set; }

        /// <summary>
        ///สถานะ เคลื่อนไหว 0:NonActive, 1:Active
        /// </summary>
        public Nullable<int> rnXthStaDocAct { get; set; }

        /// <summary>
        ///สถานะ อ้างอิง 0:ไม่เคยอ้างอิง, 1:อ้างอิงบางส่วน, 2:อ้างอิงหมดแล้ว
        /// </summary>
        public Nullable<int> rnXthStaRef { get; set; }

        /// <summary>
        ///รหัสเหตุผล
        /// </summary>
        public string rtRsnCode { get; set; }

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
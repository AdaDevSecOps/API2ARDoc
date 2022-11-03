using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleDocRefer
{
    public class cmlResInfoSalRC
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
        public Nullable<int> rnXrcSeqNo { get; set; }

        /// <summary>
        ///รหัสการชำระ
        /// </summary>
        public string rtRcvCode { get; set; }

        /// <summary>
        ///ชื่อการรับชำระ
        /// </summary>
        public string rtRcvName { get; set; }

        /// <summary>
        ///เลขที่อ้างอิง1
        /// </summary>
        public string rtXrcRefNo1 { get; set; }

        /// <summary>
        ///เลขที่อ้างอิง2
        /// </summary>
        public string rtXrcRefNo2 { get; set; }

        /// <summary>
        ///วันที่อ้างอิง
        /// </summary>
        public Nullable<DateTime> rdXrcRefDate { get; set; }

        /// <summary>
        ///สาขาธนาคาร
        /// </summary>
        public string rtXrcRefDesc { get; set; }

        /// <summary>
        ///รหัสธนาคาร
        /// </summary>
        public string rtBnkCode { get; set; }

        /// <summary>
        ///สกุลเงิน
        /// </summary>
        public string rtRteCode { get; set; }

        /// <summary>
        ///อัตราแลกเปลี่ยน
        /// </summary>
        public Nullable<decimal> rcXrcRteFac { get; set; }

        /// <summary>
        ///ยอดคงค้าง เช่น 480+100 (รวมยอดมัดจำ)
        /// </summary>
        public Nullable<decimal> rcXrcFrmLeftAmt { get; set; }

        /// <summary>
        ///ยอดแบงค์  เช่น 1000
        /// </summary>
        public Nullable<decimal> rcXrcUsrPayAmt { get; set; }

        /// <summary>
        ///หักยอดมัดจำสินค้า เช่น 100
        /// </summary>
        public Nullable<decimal> rcXrcDep { get; set; }

        /// <summary>
        ///ยอดชำระจริง  เช่น 480   (ไม่รวมยอดมัดจำ)
        /// </summary>
        public Nullable<decimal> rcXrcNet { get; set; }

        /// <summary>
        ///เงินทอน เช่น 420
        /// </summary>
        public Nullable<decimal> rcXrcChg { get; set; }

        /// <summary>
        ///หมายเหตุ
        /// </summary>
        public string rtXrcRmk { get; set; }

        /// <summary>
        ///รหัสเครื่อง EDC
        /// </summary>
        public string rtPhwCode { get; set; }

        /// <summary>
        ///เลขที่เอกสารอ้างอิง
        /// </summary>
        public string rtXrcRetDocRef { get; set; }

        /// <summary>
        ///สถานะใช้งาน function รับชำระแบบ ว่าง/Null :Online ,1: Offline
        /// </summary>
        public string rtXrcStaPayOffline { get; set; }

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
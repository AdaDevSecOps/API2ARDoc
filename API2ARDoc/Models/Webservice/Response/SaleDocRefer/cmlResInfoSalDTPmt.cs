using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.DownloadSale
{
    public class cmlResInfoSalDTPmt
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
        ///รหัสโปรโมชั่น XXYY-######
        /// </summary>
        public string rtPmhCode { get; set; }

        /// <summary>
        ///กลุ่มโปรโมชั่น
        /// </summary>
        public string rtXdpGrpName { get; set; }

        /// <summary>
        ///รหัสบาร์โค๊ด อ้างอิง DT
        /// </summary>
        public string rtXsdBarCode { get; set; }

        /// <summary>
        ///ลำดับอ้างอิง DT
        /// </summary>
        public Nullable<int> rnXsdSeqNo { get; set; }

        /// <summary>
        ///จำนวน/หน่วย
        /// </summary>
        public Nullable<decimal> rcXdpQtyAll { get; set; }

        /// <summary>
        ///มูลค่ารวม
        /// </summary>
        public Nullable<decimal> rcXdpNet { get; set; }

        /// <summary>
        ///ราคา/หน่วย
        /// </summary>
        public Nullable<decimal> rcXdpSetPrice { get; set; }

        /// <summary>
        ///จำนวนชุดเข้าเงื่อนไข
        /// </summary>
        public Nullable<decimal> rcXdpGetQtyDiv { get; set; }

        /// <summary>
        ///รูปแบบส่วนลด 1:ลดบาท 2:ลด % 3: ปรับราคา 4: ได้แต้ม
        /// </summary>
        public Nullable<decimal> rcXdpGetCond { get; set; }

        /// <summary>
        ///มูลค้า แปรผันตามรูปแบบส่วนลด
        /// </summary>
        public Nullable<decimal> rcXdpGetValue { get; set; }

        /// <summary>
        ///ส่วนลดโปรโมชั่น
        /// </summary>
        public Nullable<decimal> rcXdpDis { get; set; }

        /// <summary>
        ///ส่วนลดโปรโมชั่นเฉลี่ยตาม %
        /// </summary>
        public Nullable<decimal> rcXdpDisAvg { get; set; }

        /// <summary>
        ///แต้มที่ได้รับ
        /// </summary>
        public Nullable<decimal> rcXdpPoint { get; set; }

        /// <summary>
        ///คำนวนรวมสินค้าโปรโมชั่น (1:รวมสินค้าโปรโมชั่น,2:ไม่รวมสินค้า โปรโมชั่น)
        /// </summary>
        public string rtXdpStaExceptPmt { get; set; }

        /// <summary>
        ///สถานะรับสินค้า (รับที่เครื่องจุดขายเป็น 1 เสมอ Else 2)
        /// </summary>
        public string rtXdpStaRcv { get; set; }
    }
}
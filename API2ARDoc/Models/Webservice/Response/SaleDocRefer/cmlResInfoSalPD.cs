using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleDocRefer
{
    public class cmlResInfoSalPD
    {
        /// <summary>
        /// สาขาสร้าง
        /// </summary>
        public string rtBchCode { get; set; }
        /// <summary>
        /// เลขที่เอกสาร
        /// </summary>
        public string rtXshDocNo { get; set; }
        /// <summary>
        /// รหัสโปรโมชั่น
        /// </summary>
        public string rtPmhDocNo { get; set; }
        /// <summary>
        /// ลำดับ
        /// </summary>
        public Nullable<int> rnXsdSeqNo { get; set; }
        /// <summary>
        /// ชื่อกลุ่มจัดรายการ
        /// </summary>
        public string rtPmdGrpName { get; set; }
        /// <summary>
        /// รหัสสินค้า
        /// </summary>
        public string rtPdtCode { get; set; }
        /// <summary>
        /// รหัสหน่วย
        /// </summary>
        public string rtPunCode { get; set; }
        /// <summary>
        /// จำนวนชื้น ตาม หน่วย
        /// </summary>
        public Nullable<decimal> rcXsdQty { get; set; }

        /// <summary>
        /// จำนวนรวมหน่วย
        /// </summary>
        public Nullable<decimal> rcXsdQtyAll { get; set; }

        /// <summary>
        /// ราคาซื้อ ตาม หน่วย * อัตราแลกเปลี่ยน
        /// </summary>
        public Nullable<decimal> rcXsdSetPrice { get; set; }
        /// <summary>
        /// มูลค่าสุทธิก่อนท้ายบิล 
        /// </summary>
        public Nullable<decimal> rcXsdNet { get; set; }
        /// <summary>
        /// จำนวนชุดที่ได้รับโปรโมชั่น
        /// </summary>
        public Nullable<decimal> rcXpdGetQtyDiv { get; set; }


        /// <summary>
        /// 1:ลดบาท 2:ลด% 3:ปรับราคา 4:.ใช้กลุ่มราคา 5:แถม(Free) 6:ไม่กำหนด
        /// </summary>
        public string rtXpdGetType { get; set; }

        /// <summary>
        /// มูลค่า แปรผันตามรูปแบบส่วนลด
        /// </summary>
        public Nullable<decimal> rcXpdGetValue { get; set; }

        /// <summary>
        /// ส่วนลดที่ได้รับจากโปรโมชั่น
        /// </summary>
        public Nullable<decimal> rcXpdDis { get; set; }
        /// <summary>
        /// เปอร์เซ็นส่วนลดที่จะได้รับ
        /// </summary>
        public Nullable<decimal> rcXpdPerDisAvg { get; set; }
        /// <summary>
        /// ส่วนลดที่ได้รับ
        /// </summary>
        public Nullable<decimal> rcXpdDisAvg { get; set; }
        /// <summary>
        /// จำนวนแต้มที่ได้รับ
        /// </summary>
        public Nullable<decimal> rcXpdPoint { get; set; }

        /// <summary>
        /// สถานะรับของแถม 1:จุดขายคำนวนอัตโนมัติ 2:จุดขายเลือกได้ 3:จุดบริการ
        /// </summary>
        public string rtXpdStaRcv { get; set; }
        /// <summary>
        /// รหัสกลุ่มราคา
        /// </summary>
        public string rtPplCode { get; set; }
        /// <summary>
        /// ข้อความ ท้ายบิล
        /// </summary>
        public string rtXpdCpnText { get; set; }
        /// <summary>
        /// รหัสคูปอง
        /// </summary>
        public string rtCpdBarCpn { get; set; }
    }
}
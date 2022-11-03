using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleDocRefer
{
    public class cmlResInfoSalHDCst
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
        ///เลขที่บัตรประจำตัวประชาชน/Passport
        /// </summary>
        public string rtXshCardID { get; set; }

        /// <summary>
        ///เลขบัตรสมาชิก
        /// </summary>
        public string rtXshCardNo { get; set; }

        /// <summary>
        ///ระยะเครดิต
        /// </summary>
        public Nullable<int> rnXshCrTerm { get; set; }

        /// <summary>
        ///วันที่ครบกำหนด
        /// </summary>
        public Nullable<DateTime> rdXshDueDate { get; set; }

        /// <summary>
        ///วันที่จะรับ/วางบิล
        /// </summary>
        public Nullable<DateTime> rdXshBillDue { get; set; }

        /// <summary>
        ///ชื่อผู้ตืดต่อ
        /// </summary>
        public string rtXshCtrName { get; set; }

        /// <summary>
        ///วันที่ส่งของ
        /// </summary>
        public Nullable<DateTime> rdXshTnfDate { get; set; }

        /// <summary>
        ///เลขที่ ใบขนส่ง
        /// </summary>
        public string rtXshRefTnfID { get; set; }

        /// <summary>
        ///ที่อยู่ส่งของ
        /// </summary>
        public Nullable<Int64> rnXshAddrShip { get; set; }

        /// <summary>
        ///ที่อยู่ใบกำกับภาษี
        /// </summary>
        public Nullable<Int64> rnXshAddrTax { get; set; }

        /// <summary>
        ///ชื่อผู้ตืดต่อ
        /// </summary>
        public string rtXshCstName { get; set; }

        /// <summary>
        /// เบอร์โทรลูกค้า
        /// </summary>
        public string rtXshCstTel { get; set; }

        /// <summary>
        /// แต้มที่ได้รับจากบิล
        /// </summary>
        public Nullable<decimal> rcXshCstPnt { get; set; }

        /// <summary>
        /// แต้มที่ได้รับจาก Promotion
        /// </summary>
        public Nullable<decimal> rcXshCstPntPmt { get; set; }
    }
}
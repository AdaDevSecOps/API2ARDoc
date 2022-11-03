using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleOrder
{
    public class cmlResInfoTARTSoDTDis
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
        ///วัน/เวลาทำรายการ [dd/mm/yyyy H:mm:ss]
        /// </summary>
        public Nullable<DateTime> rdXddDateIns { get; set; }

        /// <summary>
        ///สถานะส่วนลด 1: ลดรายการ ,2: ลดท้ายบิล
        /// </summary>
        public Nullable<int> rnXddStaDis { get; set; }

        /// <summary>
        ///ข้อความมูลค่าลดชาร์จ เช่น 5 หรือ 5%
        /// </summary>
        public string rtXddDisChgTxt { get; set; }

        /// <summary>
        ///ประเภทลดชาร์จ 1:ลดบาท 2: ลด % 3: ชาร์จบาท 4: ชาร์จ %
        /// </summary>
        public string rtXddDisChgType { get; set; }

        /// <summary>
        ///มูลค่าสุทธิก่อนลดชาร์จ
        /// </summary>
        public Nullable<decimal> rcXddNet { get; set; }

        /// <summary>
        ///ยอดลด/ชาร์จ
        /// </summary>
        public Nullable<decimal> rcXddValue { get; set; }
    }
}
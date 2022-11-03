using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleDocRefer
{
    public class cmlResInfoTxnRedeem
    {
        /// <summary>
        ///รหัสกลุ่มบริษัท
        /// <summary>
        public string rtCgpCode { get; set; }

        /// <summary>
        ///รหัสสมาชิก / เลขที่บัตรประจำตัวประชาชน/Passport
        /// <summary>
        public string rtMemCode { get; set; }

        /// <summary>
        ///เอกสารอ้างอิง
        /// <summary>
        public string rtRedRefDoc { get; set; }

        /// <summary>
        ///รหัสผู้จำหน่าย
        /// <summary>
        public string rtRedRefSpl { get; set; }

        /// <summary>
        ///อ้างอิงเอกสาร เช่น กรณีคืนอ้างอิงบิลขาย , บิลขายเก็บค่าเป็นว่าง
        /// </summary>
        public string rtRedRefInt { get; set; }     //*Arm 63-03-21

        /// <summary>
        ///วันที่เอกสาร
        /// <summary>
        public Nullable<DateTime> rdRedRefDate { get; set; }

        /// <summary>
        ///จำนวนแต้มสะสม
        /// <summary>
        public Nullable<decimal> rcRedPntB4Bill { get; set; }

        /// <summary>
        ///จำนวนแต้มที่ใช้
        /// <summary>
        public Nullable<decimal> rcRedPntBillQty { get; set; }

        /// <summary>
        ///สถานะ 1:คำนวนได้ 2:ไม่นำไปคำนวนแล้ว priority สูงกว่าช่วง start-expired
        /// <summary>
        public string rtRedPntStaClosed { get; set; }

        /// <summary>
        ///วันที่เริ่มใช้งานแต้มได้
        /// <summary>
        public Nullable<DateTime> rdRedPntStart { get; set; }

        /// <summary>
        /// วันที่แต้มหมดอายุ
        /// </summary>
        public Nullable<DateTime> rdRedPntExpired { get; set; }

        /// <summary>
        ///วันที่ปรับปรุงรายการล่าสุด
        /// <summary>
        public Nullable<DateTime> rdLastUpdOn { get; set; }

        /// <summary>
        ///ผู้ปรับปรุงรายการล่าสุด
        /// <summary>
        public string rtLastUpdBy { get; set; }

        /// <summary>
        ///วันที่สร้างรายการ
        /// <summary>
        public Nullable<DateTime> rdCreateOn { get; set; }

        /// <summary>
        ///ผู้สร้างรายการ
        /// <summary>
        public string rtCreateBy { get; set; }

        /// <summary>
        ///ประเภทบิล   1 = บิลขาย , 2:บิล Void   Def: 1
        /// </summary>
        public string rtRedPntDocType { get; set; } //*Arm 63-03-31
    }
}
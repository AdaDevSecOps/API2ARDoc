using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlResSoHDCst
    {
        ///<summary>สาขาสร้าง</summary>
        [JsonProperty("rtFTBchCode")]
        public string FTBchCode { get; set; }

        ///<summary>เลขที่เอกสาร</summary>
        [JsonProperty("rtFTXshDocNo")]
        public string FTXshDocNo { get; set; }

        ///<summary>เลขที่บัตรประจำตัวประชาชน/Passport</summary>
        [JsonProperty("rtFTXshCardID")]
        public string FTXshCardID { get; set; }

        ///<summary>เลขบัตรสมาชิก</summary>
        [JsonProperty("rtFTXshCardNo")]
        public string FTXshCardNo { get; set; }

        ///<summary>ระยะเครดิต</summary>
        [JsonProperty("rtFNXshCrTerm")]
        public string FNXshCrTerm { get; set; }

        ///<summary>วันที่ครบกำหนด</summary>
        [JsonProperty("rtFDXshDueDate")]
        public string FDXshDueDate { get; set; }

        ///<summary>วันที่จะรับ/วางบิล</summary>
        [JsonProperty("rtFDXshBillDue")]
        public string FDXshBillDue { get; set; }

        ///<summary>ชื่อผู้ตืดต่อ</summary>
        [JsonProperty("rtFTXshCtrName")]
        public string FTXshCtrName { get; set; }

        ///<summary>วันที่ส่งของ</summary>
        [JsonProperty("rtFDXshTnfDate")]
        public string FDXshTnfDate { get; set; }

        ///<summary>เลขที่ ใบขนส่ง</summary>
        [JsonProperty("rtFTXshRefTnfID")]
        public string FTXshRefTnfID { get; set; }

        ///<summary>ที่อยู่ส่งของ</summary>
        [JsonProperty("rtFNXshAddrShip")]
        public string FNXshAddrShip { get; set; }

        ///<summary>ที่อยู่ใบกำกับภาษี</summary>
        [JsonProperty("rtFNXshAddrTax")]
        public string FNXshAddrTax { get; set; }


    }
}
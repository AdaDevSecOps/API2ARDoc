using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlResSoDTDis
    {
        ///<summary>สาขาสร้าง</summary>
        [JsonProperty("rtFTBchCode")]
        public string FTBchCode { get; set; }

        ///<summary>เลขที่เอกสาร</summary>
        [JsonProperty("rtFTXshDocNo")]
        public string FTXshDocNo { get; set; }

        ///<summary>ลำดับ</summary>
        [JsonProperty("rtFNXsdSeqNo")]
        public string FNXsdSeqNo { get; set; }

        ///<summary>วัน/เวลาทำรายการ [dd/mm/yyyy H:mm:ss]</summary>
        [JsonProperty("rtFDXddDateIns")]
        public string FDXddDateIns { get; set; }

        ///<summary>สถานะส่วนลด 1: ลดรายการ ,2: ลดท้ายบิล</summary>
        [JsonProperty("rtFNXddStaDis")]
        public string FNXddStaDis { get; set; }

        ///<summary>ข้อความมูลค่าลดชาร์จ เช่น 5 หรือ 5%</summary>
        [JsonProperty("rtFTXddDisChgTxt")]
        public string FTXddDisChgTxt { get; set; }

        ///<summary>ประเภทลดชาร์จ 1:ลดบาท 2: ลด % 3: ชาร์จบาท 4: ชาร์จ %</summary>
        [JsonProperty("rtFTXddDisChgType")]
        public string FTXddDisChgType { get; set; }

        ///<summary>มูลค่าสุทธิก่อนลดชาร์จ</summary>
        [JsonProperty("rtFCXddNet")]
        public string FCXddNet { get; set; }

        ///<summary>ยอดลด/ชาร์จ</summary>
        [JsonProperty("rtFCXddValue")]
        public string FCXddValue { get; set; }


    }
}
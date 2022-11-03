using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlResSoHDDis
    {
        ///<summary>สาขาสร้าง</summary>
        [JsonProperty("rtFTBchCode")]
        public string FTBchCode { get; set; }

        ///<summary>เลขที่เอกสาร</summary>
        [JsonProperty("rtFTXshDocNo")]
        public string FTXshDocNo { get; set; }

        ///<summary>วัน/เวลาทำรายการ [dd/mm/yyyy H:mm:ss]</summary>
        [JsonProperty("rtFDXhdDateIns")]
        public string FDXhdDateIns { get; set; }

        ///<summary>ข้อความมูลค่าลดชาร์จ เช่น 5 หรือ 5%</summary>
        [JsonProperty("rtFTXhdDisChgTxt")]
        public string FTXhdDisChgTxt { get; set; }

        ///<summary>ประเภทลดชาร์จ 1:ลดบาท 2: ลด % 3: ชาร์จบาท 4: ชาร์จ %</summary>
        [JsonProperty("rtFTXhdDisChgType")]
        public string FTXhdDisChgType { get; set; }

        ///<summary>ยอดรวมหลังลด (FCXshTotalAfDisChgV+FCXshTotalAfDisChgNV)</summary>
        [JsonProperty("rtFCXhdTotalAfDisChg")]
        public string FCXhdTotalAfDisChg { get; set; }

        ///<summary>ยอดลด/ชาร์จ</summary>
        [JsonProperty("rtFCXhdDisChg")]
        public string FCXhdDisChg { get; set; }

        ///<summary>มูลค่าลด/ชาร์จ</summary>
        [JsonProperty("rtFCXhdAmt")]
        public string FCXhdAmt { get; set; }


    }
}
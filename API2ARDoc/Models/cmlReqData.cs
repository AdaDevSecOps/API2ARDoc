using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlReqData
    {
        [JsonProperty("ptFTBchCode")]
        public string tFTBchCode { get; set; }

        [JsonProperty("ptFTShpCode")]
        public string tFTShpCode { get; set; }

        [JsonProperty("ptFTXshDocNo")]
        public string tFTXshDocNo { get; set; }

        [JsonProperty("ptFTXshDocType")]
        public string tFTXshDocType { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlReqJson
    {
        [JsonProperty("ptFunction")]
        public string tFunction { get; set; }

        [JsonProperty("ptSource")]
        public string tSource { get; set; }

        [JsonProperty("ptDest")]
        public string tDest { get; set; }

        [JsonProperty("ptFilter")]
        public string tFilter { get; set; }

        [JsonProperty("ptData")]
        public cmlReqData tData { get; set; }
    }
}
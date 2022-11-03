using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlResMsgJson
    {
        [JsonProperty("rtFunction")]
        public string tFunction { get; set; }

        [JsonProperty("rtSource")]
        public string tSource { get; set; }

        [JsonProperty("rtDest")]
        public string tDest { get; set; }

        [JsonProperty("rtFilter")]
        public string tFilter { get; set; }

        [JsonProperty("rtData")]
        public cmlData tData { get; set; }
        
    }   

}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models
{
    public class cmlData
    {
        [JsonProperty("raTARTSoHD")]
        public List<cmlResSoHD> aSoHD { get; set; }

    }
}
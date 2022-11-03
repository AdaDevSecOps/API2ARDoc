using API2ARDoc.Models.WebService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.WebService
{
    /// <summary>
    ///  Class model response online
    /// </summary>
    public class cmlResIsOnline : cmlResBase
    {
        [JsonProperty("rtResult")]
        public string tResult { get; set; }
    }
}
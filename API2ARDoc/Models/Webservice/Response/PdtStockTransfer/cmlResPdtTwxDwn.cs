using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.PdtStockTransfer
{
    public class cmlResPdtTwxDwn
    {
        public List<cmlResInfoPdtTwxHD> aoPdtTwxHD { get; set; }
        public List<cmlResInfoPdtTwxDT> aoPdtTwxDT { get; set; }
    }
}
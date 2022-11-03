using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleOrder
{
    public class cmlResTARTSo
    {
        public List<cmlResInfoTARTSoHD> aoTARTSoHD { get; set; }
        public List<cmlResInfoTARTSoHDCst> aoTARTSoHDCst { get; set; }
        public List<cmlResInfoTARTSoHDDis> aoTARTSoHDDis { get; set; }
        public List<cmlResInfoTARTSoDT> aoTARTSoDT { get; set; }
        public List<cmlResInfoTARTSoDTDis> aoTARTSoDTDis { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Request.PdtStockTransfer
{
    public class cmlReqPdtTwxDwn
    {
        /// <summary>
        /// รหัสสาขา
        /// </summary>
        public string ptBchCode { get; set; }
        
        /// <summary>
        /// เลขที่เอกสารใบโอนสินค้าระหว่างคลัง
        /// </summary>
        public string ptDocNo { get; set; }
    }

    public class cmlReqManualPdtTwxDwn
    {
        /// <summary>
        /// รหัสสาขา
        /// </summary>
        public string ptBchCode { get; set; }

        /// <summary>
        /// รหัสคลัง
        /// </summary>
        public string ptWahCode { get; set; }

        /// <summary>
        /// List เลขที่เอกสารใบโอนสินค้าระหว่างคลังที่มีในเครื่องตามวันที่ที่ต้องการมา Fromat : 'DocNo1','DocNo2',...
        /// </summary>
        public string ptDocNo { get; set; }

        /// <summary>
        /// วันที่
        /// </summary>
        public Nullable<DateTime> pdDate { get; set; }
    }
}
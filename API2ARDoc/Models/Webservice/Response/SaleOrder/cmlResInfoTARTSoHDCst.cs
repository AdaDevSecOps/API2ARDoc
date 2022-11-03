using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Models.Webservice.Response.SaleOrder
{
    public class cmlResInfoTARTSoHDCst
    {
        /// <summary>
        ///
        /// </summary>
        public string rtBchCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshDocNo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshCardID { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshCstName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshCstTel { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshCardNo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Nullable<int> rnXshCrTerm { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Nullable<DateTime> rdXshDueDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Nullable<DateTime> rdXshBillDue { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshCtrName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Nullable<DateTime> rdXshTnfDate { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshRefTnfID { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Nullable<Int64> rnXshAddrShip { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Nullable<Int64> rnXshAddrTax { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string rtXshStaAlwPosCalSo { get; set; }
    }
}
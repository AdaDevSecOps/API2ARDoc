using API2ARDoc.Class;
using API2ARDoc.Class.Standard;
using API2ARDoc.Models.Database;
using API2ARDoc.Models.Webservice.Request.SaleOrder;
using API2ARDoc.Models.Webservice.Response.Base;
using API2ARDoc.Models.Webservice.Response.SaleOrder;
using API2ARDoc.Models.WebService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;

namespace API2ARDoc.Controllers
{
    /// <summary>
    /// Infomation Sale Order
    /// </summary>
    [Route(cCS.tCS_APIVer+"/SaleOrder")]
    public class cSaleOrderController : ControllerBase
    {
        /// <summary>
        /// Process Get Sale Order By List
        /// </summary>
        /// <param name="poPara"></param>
        /// <returns></returns>
        [Route("OrdersByList")]
        [HttpPost]
        public cmlResList<cmlResInfoOrdersByList> POST_ORDoOrdersByList([FromBody] cmlReqOrdersByList poPara)
        {
            cSP oFunc;
            cCS oCS;
            cMS oMsg;
            cCacheFunc oCacheFunc;

            cmlResList<cmlResInfoOrdersByList> aoResult;
            List<cmlTSysConfig> aoSysConfig;
            StringBuilder oSql;
            cDatabase oDB;
            int nCmdTme;
            string tFuncName, tModelErr, tKeyApi;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                aoResult = new cmlResList<cmlResInfoOrdersByList>();

                oFunc = new cSP();
                oCS = new cCS();
                oMsg = new cMS();
                oCacheFunc = new cCacheFunc(21600, 21600, false);

                // Get method name.
                tFuncName = MethodBase.GetCurrentMethod().Name;

                // Validate parameter.
                tModelErr = "";
                if (oFunc.SP_CHKbParaModel(out tModelErr, ModelState) == false)
                {
                    // Validate parameter model false.
                    aoResult.rtCode = cMS.tMS_RespCode701;
                    aoResult.rtDesc = cMS.tMS_RespDesc701 + tModelErr;
                    return aoResult;
                }

                // Load configuration.
                aoSysConfig = oFunc.SP_SYSaLoadConfiguration();
                oFunc.SP_DATxGetConfigurationFromMem<int>(out nCmdTme, cCS.nCS_CmdTme, aoSysConfig, "2");

                tKeyApi = "";
                // Check KeyApi.
                if (oFunc.SP_CHKbKeyApi(out tKeyApi, aoSysConfig, HttpContext) == false)
                {
                    // Key not allowed to use method.
                    aoResult.rtCode = cMS.tMS_RespCode904;
                    aoResult.rtDesc = cMS.tMS_RespDesc904;
                    return aoResult;
                }

                //Get Data
                oSql = new StringBuilder();
                oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtDocNo, FDXshDocDate AS rdDocDate,FCXshGrand AS rcGrand,");
                oSql.AppendLine("(SELECT FTUsrName FROM TCNMUser_L WHERE FTUsrCode = TARTSoHD.FTUsrCode AND FNLngID = '1') AS rtUsrKey,");
                oSql.AppendLine("(SELECT FTUsrName FROM TCNMUser_L  WHERE FTUsrCode = TARTSoHD.FTXshApvCode AND FNLngID = '1') AS rtUsrApv,");
                oSql.AppendLine("FTXshCshOrCrd AS rtCshOrCrd ");
                oSql.AppendLine("FROM TARTSoHD WITH(NOLOCK)");
                oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' ");
                oSql.AppendLine("AND FTCstCode = '" + poPara.ptCstCode + "' ");
                oSql.AppendLine("AND FTXshStaApv = '1' ");
                oSql.AppendLine("AND FNXshStaRef != '2' ");

                oDB = new cDatabase();
                aoResult.raItems = new List<cmlResInfoOrdersByList>();

                aoResult.raItems = oDB.C_DATaSqlQuery<cmlResInfoOrdersByList>(oSql.ToString());
                if (aoResult.raItems.Count > 0)
                {

                }
                else
                {
                    aoResult.rtCode = cMS.tMS_RespCode800;
                    aoResult.rtDesc = cMS.tMS_RespDesc800;
                    return aoResult;
                }

                aoResult.rtCode = cMS.tMS_RespCode001;
                aoResult.rtDesc = cMS.tMS_RespDesc001;
                return aoResult;

            }
            catch (Exception oEx)
            {
                aoResult = new cmlResList<cmlResInfoOrdersByList>();
                aoResult.rtCode = cMS.tMS_RespCode900;
                aoResult.rtDesc = cMS.tMS_RespDesc900 + Environment.NewLine + oEx.Message.ToString();
                return aoResult;
            }
            finally
            {
                oSql = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }


        /// <summary>
        /// Process Get Sale Order By Doc
        /// </summary>
        /// <param name="poPara"></param>
        /// <returns></returns>
        [Route("OrdersByDoc")]
        [HttpPost]
        public cmlResItem<cmlResTARTSo> POST_ORDoOrdersByDoc([FromBody] cmlReqOrdersByDoc poPara)
        {
            cSP oFunc;
            cCS oCS;
            cMS oMsg;
            cCacheFunc oCacheFunc;

            cmlResItem<cmlResTARTSo> aoResult;
            cmlResTARTSo oTARTSo;
            List<cmlTSysConfig> aoSysConfig;
            StringBuilder oSql;
            cDatabase oDB;
            int nCmdTme;
            string tFuncName, tModelErr, tKeyApi;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                aoResult = new cmlResItem<cmlResTARTSo>();

                oFunc = new cSP();
                oCS = new cCS();
                oMsg = new cMS();

                oCacheFunc = new cCacheFunc(21600, 21600, false);

                // Get method name.
                tFuncName = MethodBase.GetCurrentMethod().Name;

                // Validate parameter.
                tModelErr = "";
                if (oFunc.SP_CHKbParaModel(out tModelErr, ModelState) == false)
                {
                    // Validate parameter model false.
                    aoResult.rtCode = cMS.tMS_RespCode701;
                    aoResult.rtDesc = cMS.tMS_RespDesc701 + tModelErr;
                    return aoResult;
                }

                // Load configuration.
                aoSysConfig = oFunc.SP_SYSaLoadConfiguration();
                oFunc.SP_DATxGetConfigurationFromMem<int>(out nCmdTme, cCS.nCS_CmdTme, aoSysConfig, "2");

                tKeyApi = "";
                // Check KeyApi.
                if (oFunc.SP_CHKbKeyApi(out tKeyApi, aoSysConfig, HttpContext) == false)
                {
                    // Key not allowed to use method.
                    aoResult.rtCode = cMS.tMS_RespCode904;
                    aoResult.rtDesc = cMS.tMS_RespDesc904;
                    return aoResult;
                }
                
                // Get Data TARTSoHD
                oSql = new StringBuilder();
                oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTShpCode AS rtShpCode, FNXshDocType AS rnXshDocType, FDXshDocDate AS rdXshDocDate,");
                oSql.AppendLine("FTXshCshOrCrd AS rtXshCshOrCrd, FTXshVATInOrEx AS rtXshVATInOrEx, FTDptCode AS rtDptCode, FTWahCode AS rtWahCode, FTPosCode AS rtPosCode,");
                oSql.AppendLine("FTShfCode AS rtShfCode, FNSdtSeqNo AS rnSdtSeqNo, FTUsrCode AS rtUsrCode, FTSpnCode AS rtSpnCode, FTXshApvCode AS rtXshApvCode,");
                oSql.AppendLine("FTCstCode AS rtCstCode, FTXshDocVatFull AS rtXshDocVatFull, FTXshRefExt AS rtXshRefExt, FDXshRefExtDate AS rdXshRefExtDate, FTXshRefInt AS rtXshRefInt,");
                oSql.AppendLine("FDXshRefIntDate AS rdXshRefIntDate, FTXshRefAE AS rtXshRefAE, FNXshDocPrint AS rnXshDocPrint, FTRteCode AS rtRteCode, FCXshRteFac AS rcXshRteFac,");
                oSql.AppendLine("FCXshTotal AS rcXshTotal, FCXshTotalNV AS rcXshTotalNV, FCXshTotalNoDis AS rcXshTotalNoDis, FCXshTotalB4DisChgV AS rcXshTotalB4DisChgV, FCXshTotalB4DisChgNV AS rcXshTotalB4DisChgNV,");
                oSql.AppendLine("FTXshDisChgTxt AS rtXshDisChgTxt, FCXshDis AS rcXshDis, FCXshChg AS rcXshChg, FCXshTotalAfDisChgV AS rcXshTotalAfDisChgV, FCXshTotalAfDisChgNV AS rcXshTotalAfDisChgNV,");
                oSql.AppendLine("FCXshRefAEAmt AS rcXshRefAEAmt, FCXshAmtV AS rcXshAmtV, FCXshAmtNV AS rcXshAmtNV, FCXshVat AS rcXshVat, FCXshVatable AS rcXshVatable,");
                oSql.AppendLine("FTXshWpCode AS rtXshWpCode, FCXshWpTax AS rcXshWpTax, FCXshGrand AS rcXshGrand, FCXshRnd AS rcXshRnd, FTXshGndText AS rtXshGndText,");
                oSql.AppendLine("FCXshPaid AS rcXshPaid, FCXshLeft AS rcXshLeft, FTXshRmk AS rtXshRmk, FTXshStaRefund AS rtXshStaRefund, FTXshStaDoc AS rtXshStaDoc,");
                oSql.AppendLine("FTXshStaApv AS rtXshStaApv, FTXshStaPrcDoc AS rtXshStaPrcDoc, FTXshStaPaid AS rtXshStaPaid, FNXshStaDocAct AS rnXshStaDocAct,FNXshStaRef AS rnXshStaRef,");
                oSql.AppendLine("FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy");
                oSql.AppendLine("FROM TARTSoHD WITH(NOLOCK)");
                oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' ");
                oSql.AppendLine("AND FTXshDocNo = '" + poPara.ptDocNo + "' ");
                oSql.AppendLine("AND FTXshStaApv = '1' ");
                oSql.AppendLine("AND FNXshStaRef != '2' ");

                oDB = new cDatabase();
                aoResult.roItem = new cmlResTARTSo();
                oTARTSo = new cmlResTARTSo();

                oTARTSo.aoTARTSoHD = oDB.C_DATaSqlQuery<cmlResInfoTARTSoHD>(oSql.ToString());
                if (oTARTSo.aoTARTSoHD.Count > 0)
                {
                    // TARTSoHDCst
                    oSql = new StringBuilder();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTXshCardID AS rtXshCardID, FTXshCstName AS rtXshCstName, FTXshCstTel AS rtXshCstTel,");
                    oSql.AppendLine("FTXshCardNo AS rtXshCardNo,FNXshCrTerm AS rnXshCrTerm, FDXshDueDate AS rdXshDueDate, FDXshBillDue AS rdXshBillDue,	FTXshCtrName AS rtXshCtrName,");
                    oSql.AppendLine("FDXshTnfDate AS rdXshTnfDate, FTXshRefTnfID AS rtXshRefTnfID, FNXshAddrShip AS rnXshAddrShip, FNXshAddrTax AS rnXshAddrTax, FTXshStaAlwPosCalSo AS rtXshStaAlwPosCalSo");
                    oSql.AppendLine("FROM TARTSoHDCst WITH(NOLOCK)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' ");
                    oSql.AppendLine("AND FTXshDocNo = '" + poPara.ptDocNo + "' ");
                    oTARTSo.aoTARTSoHDCst = oDB.C_DATaSqlQuery<cmlResInfoTARTSoHDCst>(oSql.ToString());

                    // TARTSoHDDis
                    oSql = new StringBuilder();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FDXhdDateIns AS rdXhdDateIns, FTXhdDisChgTxt AS rtXhdDisChgTxt, FTXhdDisChgType AS rtXhdDisChgType,");
                    oSql.AppendLine("FCXhdTotalAfDisChg AS rcXhdTotalAfDisChg, FCXhdDisChg AS rcXhdDisChg, FCXhdAmt AS rcXhdAmt");
                    oSql.AppendLine("FROM TARTSoHDDis WITH(NOLOCK)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' ");
                    oSql.AppendLine("AND FTXshDocNo = '" + poPara.ptDocNo + "' ");
                    oTARTSo.aoTARTSoHDDis = oDB.C_DATaSqlQuery<cmlResInfoTARTSoHDDis>(oSql.ToString());

                    // TARTSoDT
                    oSql = new StringBuilder();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXsdSeqNo AS rnXsdSeqNo,");
                    oSql.AppendLine("FTPdtCode AS rtPdtCode, FTXsdPdtName AS rtXsdPdtName, FTPunCode AS rtPunCode, FTPunName AS rtPunName, FCXsdFactor AS rcXsdFactor,");
                    oSql.AppendLine("FTXsdBarCode AS rtXsdBarCode, FTSrnCode AS rtSrnCode, FTXsdVatType AS rtXsdVatType, FTVatCode AS rtVatCode, FCXsdVatRate AS rcXsdVatRate,");
                    oSql.AppendLine("FTXsdSaleType AS rtXsdSaleType, FCXsdSalePrice AS rcXsdSalePrice, FCXsdQty AS rcXsdQty, FCXsdQtyAll AS rcXsdQtyAll, FCXsdSetPrice AS rcXsdSetPrice,");
                    oSql.AppendLine("FCXsdAmtB4DisChg AS rcXsdAmtB4DisChg, FTXsdDisChgTxt AS rtXsdDisChgTxt, FCXsdDis AS rcXsdDis, FCXsdChg AS rcXsdChg, FCXsdNet AS rcXsdNet,");
                    oSql.AppendLine("FCXsdNetAfHD AS rcXsdNetAfHD, FCXsdVat AS rcXsdVat, FCXsdVatable AS rcXsdVatable, FCXsdWhtAmt AS rcXsdWhtAmt, FTXsdWhtCode AS rtXsdWhtCode,");
                    oSql.AppendLine("FCXsdWhtRate AS rcXsdWhtRate, FCXsdCostIn AS rcXsdCostIn, FCXsdCostEx AS rcXsdCostEx, FTXsdStaPdt AS rtXsdStaPdt, FCXsdQtyLef AS rcXsdQtyLef,");
                    oSql.AppendLine("FCXsdQtyRfn AS rcXsdQtyRfn, FTXsdStaPrcStk AS rtXsdStaPrcStk, FTXsdStaAlwDis AS rtXsdStaAlwDis, FNXsdPdtLevel AS rnXsdPdtLevel, FTXsdPdtParent AS rtXsdPdtParent,");
                    oSql.AppendLine("FCXsdQtySet AS rcXsdQtySet, FTPdtStaSet AS rtPdtStaSet, FTXsdRmk AS rtXsdRmk, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy,");
                    oSql.AppendLine("FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy");
                    oSql.AppendLine("FROM TARTSoDT WITH(NOLOCK)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' ");
                    oSql.AppendLine("AND FTXshDocNo = '" + poPara.ptDocNo + "' ");
                    oTARTSo.aoTARTSoDT = oDB.C_DATaSqlQuery<cmlResInfoTARTSoDT>(oSql.ToString());
                    
                    // TARTSoDTDis
                    oSql = new StringBuilder();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXsdSeqNo AS rnXsdSeqNo, FDXddDateIns AS rdXddDateIns,FNXddStaDis AS rnXddStaDis,");
                    oSql.AppendLine("FTXddDisChgTxt AS rtXddDisChgTxt, FTXddDisChgType AS rtXddDisChgType, FCXddNet AS rcXddNet, FCXddValue AS rcXddValue");
                    oSql.AppendLine("FROM TARTSoDTDis WITH(NOLOCK)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' ");
                    oSql.AppendLine("AND FTXshDocNo = '" + poPara.ptDocNo + "' ");
                    oTARTSo.aoTARTSoDTDis = oDB.C_DATaSqlQuery<cmlResInfoTARTSoDTDis>(oSql.ToString());

                }
                else
                {
                    aoResult.rtCode = cMS.tMS_RespCode800;
                    aoResult.rtDesc = cMS.tMS_RespDesc800;
                    return aoResult;
                }

                aoResult.roItem = oTARTSo;
                aoResult.rtCode = cMS.tMS_RespCode001;
                aoResult.rtDesc = cMS.tMS_RespDesc001;
                return aoResult;

            }
            catch (Exception oEx)
            {
                aoResult = new cmlResItem<cmlResTARTSo>();
                aoResult.rtCode = cMS.tMS_RespCode900;
                aoResult.rtDesc = cMS.tMS_RespDesc900 + Environment.NewLine + oEx.Message.ToString();
                return aoResult;
            }
            finally
            {
                oSql = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
    }
}
using API2ARDoc.Class;
using API2ARDoc.Class.Standard;
using API2ARDoc.Models.Database;
using API2ARDoc.Models.Webservice.Request.PdtStockTransfer;
using API2ARDoc.Models.Webservice.Response.PdtStockTransfer;
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
    ///     Download ใบโอนสินค้าระหว่างคลัง
    /// </summary>
    [Route(cCS.tCS_APIVer + "/PdtStockTransefer")]
    public class cPdtStockTransferController : ControllerBase
    {
        /// <summary>
        /// Download ใบโอนสินค้าระหว่างคลัง
        /// </summary>
        /// <param name="poParam">รหัสสาขา</param>

        /// <returns>
        ///&#8195;     001 : Success.<br/>
        ///&#8195;     700 : all parameter is null.<br/>
        ///&#8195;     701 : Validate parameter model false.<br/>
        ///&#8195;     800 : Data not found.<br/>
        ///&#8195;     900 : Service process false.<br/>
        ///&#8195;     904 : Key not allowed to use method.<br/>
        ///&#8195;     905 : Cannot connect database.<br/>
        /// </returns>
        [Route("Download")]
        [HttpPost]
        public cmlResItem<cmlResPdtTwxDwn> POST_DWNoPdtStockTransefer([FromBody] cmlReqPdtTwxDwn poParam)
        {
            cSP oFunc;
            cCS oCS;
            cMS oMsg;
            cmlResItem<cmlResPdtTwxDwn> oResult;
            cmlResPdtTwxDwn oTwxDwn;
            List<cmlTSysConfig> aoSysConfig;
            StringBuilder oSql;
            cDatabase oDB;
            int nCmdTme;
            string tFuncName, tModelErr, tKeyApi;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                oFunc = new cSP();
                oCS = new cCS();
                oMsg = new cMS();
                oResult = new cmlResItem<cmlResPdtTwxDwn>();

                // Get method name.
                tFuncName = MethodBase.GetCurrentMethod().Name;

                // Validate parameter.
                tModelErr = "";
                if (oFunc.SP_CHKbParaModel(out tModelErr, ModelState) == false)
                {
                    // Validate parameter model false.
                    oResult.rtCode = cMS.tMS_RespCode701;
                    oResult.rtDesc = cMS.tMS_RespDesc701 + tModelErr;
                    return oResult;
                }

                // Load configuration.
                aoSysConfig = oFunc.SP_SYSaLoadConfiguration();
                oFunc.SP_DATxGetConfigurationFromMem<int>(out nCmdTme, cCS.nCS_CmdTme, aoSysConfig, "2");

                tKeyApi = "";
                // Check KeyApi.
                if (oFunc.SP_CHKbKeyApi(out tKeyApi, aoSysConfig, HttpContext) == false)
                {
                    // Key not allowed to use method.
                    oResult.rtCode = cMS.tMS_RespCode904;
                    oResult.rtDesc = cMS.tMS_RespDesc904;
                    return oResult;
                }

                //GET Data
                oSql = new StringBuilder();
                oDB = new cDatabase();
                
                oSql.AppendLine(" SELECT FTBchCode AS rtBchCode, FTXthDocNo AS rtXthDocNo, FDXthDocDate AS rdXthDocDate, FTXthVATInOrEx AS rtXthVATInOrEx, FTDptCode AS rtDptCode");
                oSql.AppendLine(" , FTXthMerCode AS rtXthMerCode, FTXthShopFrm AS rtXthShopFrm, FTXthShopTo AS rtXthShopTo, FTXthWhFrm AS rtXthWhFrm, FTXthWhTo AS rtXthWhTo");
                oSql.AppendLine(" , FTXthPosFrm AS rtXthPosFrm, FTXthPosTo AS rtXthPosTo, FTUsrCode AS rtUsrCode, FTSpnCode AS rtSpnCode, FTXthApvCode AS rtXthApvCode");
                oSql.AppendLine(" , FTXthRefExt AS rtXthRefExt, FDXthRefExtDate AS rdXthRefExtDate, FTXthRefInt AS rtXthRefInt, FDXthRefIntDate AS rdXthRefIntDate, FNXthDocPrint AS rnXthDocPrint");
                oSql.AppendLine(" , FCXthTotal AS rcXthTotal, FCXthVat AS rcXthVat, FCXthVatable AS rcXthVatable, FTXthRmk AS rtXthRmk, FTXthStaDoc AS rtXthStaDoc");
                oSql.AppendLine(" , FTXthStaApv AS rtXthStaApv, FTXthStaPrcStk AS rtXthStaPrcStk, FTXthStaDelMQ AS rtXthStaDelMQ, FNXthStaDocAct AS rnXthStaDocAct, FNXthStaRef AS rnXthStaRef");
                oSql.AppendLine(" , FTRsnCode AS rtRsnCode, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy");
                oSql.AppendLine("FROM TCNTPdtTwxHD WITH(NOLOCK) ");
                oSql.AppendLine("WHERE FTBchCode = '" + poParam.ptBchCode + "' AND FTXthDocNo = '" + poParam.ptDocNo + "' ");
                oSql.AppendLine("AND FTXthStaApv = '1' AND FTXthStaDoc = '1'"); //*Arm 63-10-15

                oResult.roItem = new cmlResPdtTwxDwn();
                oTwxDwn = new cmlResPdtTwxDwn();

                oTwxDwn.aoPdtTwxHD = oDB.C_DATaSqlQuery<cmlResInfoPdtTwxHD>(oSql.ToString());
                if (oTwxDwn.aoPdtTwxHD.Count > 0)
                {
                    oSql.Clear();
                    oSql.AppendLine(" SELECT DT.FTBchCode AS rtBchCode, DT.FTXthDocNo AS rtXthDocNo, DT.FNXtdSeqNo AS rnXtdSeqNo, DT.FTPdtCode AS rtPdtCode, DT.FTXtdPdtName AS rtXtdPdtName");
                    oSql.AppendLine(" , DT.FTPunCode AS rtPunCode, DT.FTPunName AS rtPunName, DT.FCXtdFactor AS rcXtdFactor, DT.FTXtdBarCode AS rtXtdBarCode, DT.FTXtdVatType AS rtXtdVatType");
                    oSql.AppendLine(" , DT.FTVatCode AS rtVatCode, DT.FCXtdVatRate AS rcXtdVatRate, DT.FCXtdQty AS rcXtdQty, DT.FCXtdQtyAll AS rcXtdQtyAll, DT.FCXtdSetPrice AS rcXtdSetPrice");
                    oSql.AppendLine(" , DT.FCXtdAmt AS rcXtdAmt, DT.FCXtdVat rcXtdVat, DT.FCXtdVatable AS rcXtdVatable, FCXtdNet AS rcXtdNet, FCXtdCostIn AS rcXtdCostIn");
                    oSql.AppendLine(" , DT.FCXtdCostEx AS rcXtdCostEx, DT.FTXtdStaPrcStk AS rtXtdStaPrcStk, DT.FNXtdPdtLevel AS rnXtdPdtLevel, DT.FTXtdPdtParent AS rtXtdPdtParent, DT.FCXtdQtySet AS rcXtdQtySet");
                    oSql.AppendLine(" , DT.FTXtdPdtStaSet AS rtXtdPdtStaSet, DT.FTXtdRmk AS rtXtdRmk, DT.FDLastUpdOn AS rdLastUpdOn, DT.FTLastUpdBy AS rtLastUpdBy, DT.FDCreateOn AS rdCreateOn");
                    oSql.AppendLine(" , DT.FTCreateBy AS rtCreateBy");
                    oSql.AppendLine("FROM TCNTPdtTwxDT DT WITH(NOLOCK) ");
                    oSql.AppendLine("INNER JOIN TCNTPdtTwxHD HD WITH(NOLOCK) ON DT.FTBchCode = HD.FTBchCode AND DT.FTXthDocNo = HD.FTXthDocNo");
                    oSql.AppendLine("WHERE HD.FTBchCode = '" + poParam.ptBchCode + "' AND HD.FTXthDocNo = '" + poParam.ptDocNo + "' ");
                    oSql.AppendLine("AND HD.FTXthStaApv = '1' AND HD.FTXthStaDoc = '1'"); //*Arm 63-10-15
                    oTwxDwn.aoPdtTwxDT = oDB.C_DATaSqlQuery<cmlResInfoPdtTwxDT>(oSql.ToString());
                }
                else
                {
                    oResult.rtCode = cMS.tMS_RespCode800;
                    oResult.rtDesc = cMS.tMS_RespDesc800;
                    return oResult;
                }

                oResult.roItem = oTwxDwn;
                oResult.rtCode = cMS.tMS_RespCode001;
                oResult.rtDesc = cMS.tMS_RespDesc001;
                return oResult;
            }
            catch(Exception oEx)
            {
                oResult = new cmlResItem<cmlResPdtTwxDwn>();
                oResult.rtCode = cMS.tMS_RespCode900;
                oResult.rtDesc = cMS.tMS_RespDesc900 + Environment.NewLine + oEx.Message.ToString();
                return oResult;
            }
            finally
            {
                oFunc = null;
                oDB = null;
                oCS = null;
                oMsg = null;
                oSql = null;
                aoSysConfig = null;
                oResult = null;
                oTwxDwn = null;
                poParam = null;
            }
        }

        /// <summary>
        /// Download ใบโอนสินค้าระหว่างคลัง (Manual)
        /// </summary>
        /// <param name="poParam">รหัสสาขา</param>

        /// <returns>
        ///&#8195;     001 : Success.<br/>
        ///&#8195;     700 : all parameter is null.<br/>
        ///&#8195;     701 : Validate parameter model false.<br/>
        ///&#8195;     800 : Data not found.<br/>
        ///&#8195;     900 : Service process false.<br/>
        ///&#8195;     904 : Key not allowed to use method.<br/>
        ///&#8195;     905 : Cannot connect database.<br/>
        /// </returns>
        [Route("Download/Manual")]
        [HttpPost]
        public cmlResItem<cmlResPdtTwxDwn> POST_DWNoManualPdtStkTfnDwn([FromBody] cmlReqManualPdtTwxDwn poParam)
        {
            cSP oFunc;
            cCS oCS;
            cMS oMsg;
            cmlResItem<cmlResPdtTwxDwn> oResult;
            cmlResPdtTwxDwn oTwxDwn;
            List<cmlTSysConfig> aoSysConfig;
            StringBuilder oSql;
            cDatabase oDB;
            int nCmdTme;
            string tFuncName, tModelErr, tKeyApi;

            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                oFunc = new cSP();
                oCS = new cCS();
                oMsg = new cMS();
                oResult = new cmlResItem<cmlResPdtTwxDwn>();

                // Get method name.
                tFuncName = MethodBase.GetCurrentMethod().Name;

                // Validate parameter.
                tModelErr = "";
                if (oFunc.SP_CHKbParaModel(out tModelErr, ModelState) == false)
                {
                    // Validate parameter model false.
                    oResult.rtCode = cMS.tMS_RespCode701;
                    oResult.rtDesc = cMS.tMS_RespDesc701 + tModelErr;
                    return oResult;
                }

                // Load configuration.
                aoSysConfig = oFunc.SP_SYSaLoadConfiguration();
                oFunc.SP_DATxGetConfigurationFromMem<int>(out nCmdTme, cCS.nCS_CmdTme, aoSysConfig, "2");

                tKeyApi = "";
                // Check KeyApi.
                if (oFunc.SP_CHKbKeyApi(out tKeyApi, aoSysConfig, HttpContext) == false)
                {
                    // Key not allowed to use method.
                    oResult.rtCode = cMS.tMS_RespCode904;
                    oResult.rtDesc = cMS.tMS_RespDesc904;
                    return oResult;
                }

                //GET Data
                oSql = new StringBuilder();
                oDB = new cDatabase();

                oSql.AppendLine(" SELECT FTBchCode AS rtBchCode, FTXthDocNo AS rtXthDocNo, FDXthDocDate AS rdXthDocDate, FTXthVATInOrEx AS rtXthVATInOrEx, FTDptCode AS rtDptCode");
                oSql.AppendLine(" , FTXthMerCode AS rtXthMerCode, FTXthShopFrm AS rtXthShopFrm, FTXthShopTo AS rtXthShopTo, FTXthWhFrm AS rtXthWhFrm, FTXthWhTo AS rtXthWhTo");
                oSql.AppendLine(" , FTXthPosFrm AS rtXthPosFrm, FTXthPosTo AS rtXthPosTo, FTUsrCode AS rtUsrCode, FTSpnCode AS rtSpnCode, FTXthApvCode AS rtXthApvCode");
                oSql.AppendLine(" , FTXthRefExt AS rtXthRefExt, FDXthRefExtDate AS rdXthRefExtDate, FTXthRefInt AS rtXthRefInt, FDXthRefIntDate AS rdXthRefIntDate, FNXthDocPrint AS rnXthDocPrint");
                oSql.AppendLine(" , FCXthTotal AS rcXthTotal, FCXthVat AS rcXthVat, FCXthVatable AS rcXthVatable, FTXthRmk AS rtXthRmk, FTXthStaDoc AS rtXthStaDoc");
                oSql.AppendLine(" , FTXthStaApv AS rtXthStaApv, FTXthStaPrcStk AS rtXthStaPrcStk, FTXthStaDelMQ AS rtXthStaDelMQ, FNXthStaDocAct AS rnXthStaDocAct, FNXthStaRef AS rnXthStaRef");
                oSql.AppendLine(" , FTRsnCode AS rtRsnCode, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy");
                oSql.AppendLine("FROM TCNTPdtTwxHD WITH(NOLOCK) ");
                oSql.AppendLine("WHERE FTBchCode = '" + poParam.ptBchCode + "' AND FTXthDocNo NOT IN (" + poParam.ptDocNo +") ");
                oSql.AppendLine("AND FTXthWhTo = '" + poParam.ptWahCode + "' AND CONVERT(date,FDXthDocDate,121) = '" + string.Format("{0: yyyy-MM-dd}",poParam.pdDate) + "' ");
                oSql.AppendLine("AND FTXthStaApv = '1' AND FTXthStaDoc = '1'"); //*Arm 63-10-15

                oResult.roItem = new cmlResPdtTwxDwn();
                oTwxDwn = new cmlResPdtTwxDwn();

                oTwxDwn.aoPdtTwxHD = oDB.C_DATaSqlQuery<cmlResInfoPdtTwxHD>(oSql.ToString());
                if (oTwxDwn.aoPdtTwxHD.Count > 0)
                {
                    oSql.Clear();
                    oSql.AppendLine(" SELECT DT.FTBchCode AS rtBchCode, DT.FTXthDocNo AS rtXthDocNo, DT.FNXtdSeqNo AS rnXtdSeqNo, DT.FTPdtCode AS rtPdtCode, DT.FTXtdPdtName AS rtXtdPdtName");
                    oSql.AppendLine(" , DT.FTPunCode AS rtPunCode, DT.FTPunName AS rtPunName, DT.FCXtdFactor AS rcXtdFactor, DT.FTXtdBarCode AS rtXtdBarCode, DT.FTXtdVatType AS rtXtdVatType");
                    oSql.AppendLine(" , DT.FTVatCode AS rtVatCode, DT.FCXtdVatRate AS rcXtdVatRate, DT.FCXtdQty AS rcXtdQty, DT.FCXtdQtyAll AS rcXtdQtyAll, DT.FCXtdSetPrice AS rcXtdSetPrice");
                    oSql.AppendLine(" , DT.FCXtdAmt AS rcXtdAmt, DT.FCXtdVat rcXtdVat, DT.FCXtdVatable AS rcXtdVatable, FCXtdNet AS rcXtdNet, FCXtdCostIn AS rcXtdCostIn");
                    oSql.AppendLine(" , DT.FCXtdCostEx AS rcXtdCostEx, DT.FTXtdStaPrcStk AS rtXtdStaPrcStk, DT.FNXtdPdtLevel AS rnXtdPdtLevel, DT.FTXtdPdtParent AS rtXtdPdtParent, DT.FCXtdQtySet AS rcXtdQtySet");
                    oSql.AppendLine(" , DT.FTXtdPdtStaSet AS rtXtdPdtStaSet, DT.FTXtdRmk AS rtXtdRmk, DT.FDLastUpdOn AS rdLastUpdOn, DT.FTLastUpdBy AS rtLastUpdBy, DT.FDCreateOn AS rdCreateOn");
                    oSql.AppendLine(" , DT.FTCreateBy AS rtCreateBy");
                    oSql.AppendLine("FROM TCNTPdtTwxDT DT WITH(NOLOCK) ");
                    oSql.AppendLine("INNER JOIN TCNTPdtTwxHD HD WITH(NOLOCK) ON DT.FTBchCode = HD.FTBchCode AND DT.FTXthDocNo = HD.FTXthDocNo");
                    oSql.AppendLine("WHERE HD.FTBchCode = '" + poParam.ptBchCode + "' AND HD.FTXthDocNo NOT IN (" + poParam.ptDocNo + ") ");
                    oSql.AppendLine("AND HD.FTXthWhTo = '" + poParam.ptWahCode + "' AND CONVERT(date,HD.FDXthDocDate,121) = '" + string.Format("{0: yyyy-MM-dd}", poParam.pdDate) + "' ");
                    oSql.AppendLine("AND HD.FTXthStaApv = '1' AND HD.FTXthStaDoc = '1'"); //*Arm 63-10-15
                    oTwxDwn.aoPdtTwxDT = oDB.C_DATaSqlQuery<cmlResInfoPdtTwxDT>(oSql.ToString());
                }
                else
                {
                    oResult.rtCode = cMS.tMS_RespCode800;
                    oResult.rtDesc = cMS.tMS_RespDesc800;
                    return oResult;
                }

                oResult.roItem = oTwxDwn;
                oResult.rtCode = cMS.tMS_RespCode001;
                oResult.rtDesc = cMS.tMS_RespDesc001;
                return oResult;
            }
            catch (Exception oEx)
            {
                oResult = new cmlResItem<cmlResPdtTwxDwn>();
                oResult.rtCode = cMS.tMS_RespCode900;
                oResult.rtDesc = cMS.tMS_RespDesc900 + Environment.NewLine + oEx.Message.ToString();
                return oResult;
            }
            finally
            {
                oFunc = null;
                oDB = null;
                oCS = null;
                oMsg = null;
                oSql = null;
                aoSysConfig = null;
                oResult = null;
                oTwxDwn = null;
                poParam = null;
            }
        }

    }
}
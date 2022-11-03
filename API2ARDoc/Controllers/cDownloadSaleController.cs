using API2ARDoc.Class;
using API2ARDoc.Class.Standard;
using API2ARDoc.Models.Database;
using API2ARDoc.Models.Webservice.Request.SaleDocRefer;
using API2ARDoc.Models.Webservice.Response.SaleDocRefer;
using API2ARDoc.Models.WebService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace API2ARDoc.Controllers
{
    /// <summary>
    ///     Download Sale.
    /// </summary>
    [Route(cCS.tCS_APIVer + "/DownloadSale")]
    public class cDownloadSaleController : ControllerBase
    {
        /// <summary>
        /// Download Sale : ดาวน์โหลดข้อมูลเอกสารการขาย
        /// </summary>
        /// <param name="poPara"></param>
        /// <returns>
        ///&#8195;     001 : Success.<br/>
        ///&#8195;     701 : Validate parameter model false.<br/>
        ///&#8195;     800 : Data not found.<br/>
        ///&#8195;     900 : Service process false.<br/>
        ///&#8195;     904 : Key not allowed to use method.<br/>
        ///&#8195;     905 : Cannot connect database.<br/>
        /// </returns>
        [Route("Data/DwnSale")]
        [HttpPost]
        public cmlResItem<cmlResSaleDwn> POST_DWNoDownloadSale([FromBody] cmlReqSaleDwn poPara)
        {
            string tJsonStr = JsonConvert.SerializeObject(poPara);
            Console.WriteLine("Json File.");
            Console.WriteLine(tJsonStr);

            string tPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string tFileName = Path.Combine(tPath, "api.log").Replace("\\", "/");
            System.IO.File.WriteAllText(tFileName, tJsonStr);

            cSP oFunc;
            cCS oCS;
            //cMS oMsg;

            cmlResItem<cmlResSaleDwn> oResult;
            cmlResSaleDwn oSalDwn;
            List<cmlTSysConfig> aoSysConfig;
            cDatabase oDatabase;
            StringBuilder oSql;
           
            int nCmdTme;
            string tFuncName, tModelErr, tKeyApi;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                oResult = new cmlResItem<cmlResSaleDwn>();
                oDatabase = new cDatabase();
                oFunc = new cSP();
                oCS = new cCS();
                //oMsg = new cMS();

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

                // Get data
                oSql = new StringBuilder();
                oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTShpCode AS rtShpCode, FNXshDocType AS rnXshDocType, FDXshDocDate AS rdXshDocDate, FTXshCshOrCrd AS rtXshCshOrCrd, FTXshVATInOrEx AS rtXshVATInOrEx, FTDptCode AS rtDptCode, FTWahCode AS rtWahCode, FTPosCode AS rtPosCode ");
                oSql.AppendLine(", FTShfCode AS rtShfCode, FNSdtSeqNo AS rnSdtSeqNo, FTUsrCode AS rtUsrCode, FTSpnCode AS rtSpnCode, FTXshApvCode AS rtXshApvCode, FTCstCode AS rtCstCode, FTXshDocVatFull AS rtXshDocVatFull, FTXshRefExt AS rtXshRefExt, FDXshRefExtDate AS rdXshRefExtDate, FTXshRefInt AS rtXshRefInt ");
                oSql.AppendLine(", FDXshRefIntDate AS rdXshRefIntDate, FTXshRefAE AS rtXshRefAE, FNXshDocPrint AS rnXshDocPrint, FTRteCode AS rtRteCode, FCXshRteFac AS rcXshRteFac, FCXshTotal AS rcXshTotal, FCXshTotalNV AS rcXshTotalNV, FCXshTotalNoDis AS rcXshTotalNoDis, FCXshTotalB4DisChgV AS rcXshTotalB4DisChgV, FCXshTotalB4DisChgNV AS rcXshTotalB4DisChgNV");
                oSql.AppendLine(", FTXshDisChgTxt AS rtXshDisChgTxt, FCXshDis AS rcXshDis, FCXshChg AS rcXshChg, FCXshTotalAfDisChgV AS rcXshTotalAfDisChgV, FCXshTotalAfDisChgNV AS rcXshTotalAfDisChgNV, FCXshRefAEAmt AS rcXshRefAEAmt, FCXshAmtV AS rcXshAmtV, FCXshAmtNV AS rcXshAmtNV, FCXshVat AS rcXshVat, FCXshVatable AS rcXshVatable");
                oSql.AppendLine(", FTXshWpCode AS rtXshWpCode, FCXshWpTax AS rcXshWpTax, FCXshGrand AS rcXshGrand, FCXshRnd AS rcXshRnd, FTXshGndText AS rtXshGndText, FCXshPaid AS rcXshPaid, FCXshLeft AS rcXshLeft, FTXshRmk AS rtXshRmk , FTXshStaRefund AS rtXshStaRefund, FTXshStaDoc AS rtXshStaDoc ");
                oSql.AppendLine(", FTXshStaApv AS rtXshStaApv, FTXshStaPrcStk AS rtXshStaPrcStk, FTXshStaPaid AS rtXshStaPaid, FNXshStaDocAct AS rnXshStaDocAct, FNXshStaRef AS rnXshStaRef, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy");
                oSql.AppendLine("FROM TPSTSalHD with(nolock)");
                oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");

                oResult.roItem = new cmlResSaleDwn();
                oSalDwn = new cmlResSaleDwn();

                oSalDwn.aoTPSTSalHD = oDatabase.C_DATaSqlQuery<cmlResInfoSalHD>(oSql.ToString());

                if (oSalDwn.aoTPSTSalHD.Count > 0)
                {
                    // HDCst
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTXshCardID AS rtXshCardID, FTXshCardNo AS rtXshCardNo, FNXshCrTerm AS rnXshCrTerm");
                    oSql.AppendLine(", FDXshDueDate AS rdXshDueDate, FDXshBillDue AS rdXshBillDue, FTXshCtrName AS rtXshCtrName, FDXshTnfDate AS rdXshTnfDate, FTXshRefTnfID AS rtXshRefTnfID ");
                    oSql.AppendLine(", FNXshAddrShip AS rnXshAddrShip, FNXshAddrTax AS rnXshAddrTax, FTXshCstName AS rtXshCstName, FTXshCstTel AS rtXshCstTel, FCXshCstPnt AS rcXshCstPnt, FCXshCstPntPmt AS rcXshCstPntPmt ");
                    oSql.AppendLine("FROM TPSTSalHDCst with(nolock)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                    oSalDwn.aoTPSTSalHDCst = oDatabase.C_DATaSqlQuery<cmlResInfoSalHDCst>(oSql.ToString());

                    // HDDis
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FDXhdDateIns AS rdXhdDateIns, FTXhdRefCode AS rtXhdRefCode, FTXhdDisChgTxt AS rtXhdDisChgTxt ");
                    oSql.AppendLine(", FTXhdDisChgType AS rtXhdDisChgType, FCXhdTotalAfDisChg AS rcXhdTotalAfDisChg, FCXhdDisChg AS rcXhdDisChg, FCXhdAmt AS rcXhdAmt, FTDisCode AS rtDisCode ");
                    oSql.AppendLine(", FTRsnCode AS rtRsnCode ");
                    oSql.AppendLine("FROM TPSTSalHDDis with(nolock)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                    oSalDwn.aoTPSTSalHDDis = oDatabase.C_DATaSqlQuery<cmlResInfoSalHDDis>(oSql.ToString());

                    // DT
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXsdSeqNo AS rnXsdSeqNo, FTPdtCode AS rtPdtCode, FTXsdPdtName AS rtXsdPdtName, FTPunCode AS rtPunCode, FTPunName AS rtPunName, FCXsdFactor AS rcXsdFactor, FTXsdBarCode AS rtXsdBarCode, FTSrnCode AS rtSrnCode");
                    oSql.AppendLine(", FTXsdVatType AS rtXsdVatType, FTVatCode AS rtVatCode, FTPplCode AS rtPplCode, FCXsdVatRate AS rcXsdVatRate, FTXsdSaleType AS rtXsdSaleType, FCXsdSalePrice AS rcXsdSalePrice, FCXsdQty AS rcXsdQty, FCXsdQtyAll AS rcXsdQtyAll, FCXsdSetPrice AS rcXsdSetPrice, FCXsdAmtB4DisChg AS rcXsdAmtB4DisChg");
                    oSql.AppendLine(", FTXsdDisChgTxt AS rtXsdDisChgTxt, FCXsdDis AS rcXsdDis, FCXsdChg AS rcXsdChg, FCXsdNet AS rcXsdNet, FCXsdNetAfHD AS rcXsdNetAfHD, FCXsdVat AS rcXsdVat, FCXsdVatable AS rcXsdVatable, FCXsdWhtAmt AS rcXsdWhtAmt, FTXsdWhtCode AS rtXsdWhtCode, FCXsdWhtRate AS rcXsdWhtRate ");
                    oSql.AppendLine(", FCXsdCostIn AS rcXsdCostIn, FCXsdCostEx AS rcXsdCostEx, FTXsdStaPdt AS rtXsdStaPdt, FCXsdQtyLef AS rcXsdQtyLef, FCXsdQtyRfn AS rcXsdQtyRfn, FTXsdStaPrcStk AS rtXsdStaPrcStk, FTXsdStaAlwDis AS rtXsdStaAlwDis, FNXsdPdtLevel AS rnXsdPdtLevel, FTXsdPdtParent AS rtXsdPdtParent, FCXsdQtySet AS rcXsdQtySet");
                    oSql.AppendLine(", FTPdtStaSet AS rtPdtStaSet, FTXsdRmk AS rtXsdRmk, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy ");
                    oSql.AppendLine("FROM TPSTSalDT with(nolock)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                    oSalDwn.aoTPSTSalDT = oDatabase.C_DATaSqlQuery<cmlResInfoSalDT>(oSql.ToString());

                    // DTDis
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXsdSeqNo AS rnXsdSeqNo, FDXddDateIns AS rdXddDateIns, FTXddRefCode AS rtXddRefCode ");
                    oSql.AppendLine(", FNXddStaDis AS rnXddStaDis, FTXddDisChgTxt AS rtXddDisChgTxt, FTXddDisChgType AS rtXddDisChgType, FCXddNet AS rcXddNet, FCXddValue AS rcXddValue ");
                    oSql.AppendLine(", FTDisCode AS rtDisCode, FTRsnCode AS rtRsnCode");
                    oSql.AppendLine("FROM TPSTSalDTDis with(nolock)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                    oSalDwn.aoTPSTSalDTDis = oDatabase.C_DATaSqlQuery<cmlResInfoSalDTDis>(oSql.ToString());

                    // RC
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXrcSeqNo AS rnXrcSeqNo, FTRcvCode AS rtRcvCode, FTRcvName AS rtRcvName ");
                    oSql.AppendLine(", FTXrcRefNo1 AS rtXrcRefNo1, FTXrcRefNo2 AS rtXrcRefNo2, FDXrcRefDate AS rdXrcRefDate, FTXrcRefDesc AS rtXrcRefDesc, FTBnkCode AS rtBnkCode ");
                    oSql.AppendLine(", FTRteCode AS rtRteCode, FCXrcRteFac AS rcXrcRteFac, FCXrcFrmLeftAmt AS rcXrcFrmLeftAmt, FCXrcUsrPayAmt AS rcXrcUsrPayAmt, FCXrcDep AS rcXrcDep ");
                    oSql.AppendLine(", FCXrcNet AS rcXrcNet, FCXrcChg AS rcXrcChg, FTXrcRmk AS rtXrcRmk, FTPhwCode AS rtPhwCode, FTXrcRetDocRef AS rtXrcRetDocRef ");
                    oSql.AppendLine(", FTXrcStaPayOffline AS rtXrcStaPayOffline, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy ");
                    oSql.AppendLine("FROM TPSTSalRC with(nolock)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                    oSalDwn.aoTPSTSalRC = oDatabase.C_DATaSqlQuery<cmlResInfoSalRC>(oSql.ToString());

                    //RD
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXrdSeqNo AS rnXrdSeqNo, FTRdhDocType AS rtRdhDocType, FNXrdRefSeq AS rnXrdRefSeq ");
                    oSql.AppendLine(", FTXrdRefCode AS rtXrdRefCode, FCXrdPdtQty AS rcXrdPdtQty, FNXrdPntUse AS rnXrdPntUse");
                    oSql.AppendLine("FROM TPSTSalRD with(nolock)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                    oSalDwn.aoTPSTSalRD = oDatabase.C_DATaSqlQuery<cmlResInfoSalRD>(oSql.ToString());

                    //PD
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTPmhDocNo AS rtPmhDocNo, FNXsdSeqNo AS rnXsdSeqNo, FTPmdGrpName AS rtPmdGrpName ");
                    oSql.AppendLine(", FTPdtCode AS rtPdtCode, FTPunCode AS rtPunCode, FCXsdQty AS rcXsdQty, FCXsdQtyAll AS rcXsdQtyAll, FCXsdSetPrice AS rcXsdSetPrice");
                    oSql.AppendLine(", FCXsdNet AS rcXsdNet, FCXpdGetQtyDiv AS rcXpdGetQtyDiv, FTXpdGetType AS rtXpdGetType, FCXpdGetValue AS rcXpdGetValue, FCXpdDis AS rcXpdDis");
                    oSql.AppendLine(", FCXpdPerDisAvg AS rcXpdPerDisAvg, FCXpdDisAvg AS rcXpdDisAvg, FCXpdPoint AS rcXpdPoint, FTXpdStaRcv AS rtXpdStaRcv, FTPplCode AS rtPplCode ");
                    oSql.AppendLine(", FTXpdCpnText AS rtXpdCpnText, FTCpdBarCpn AS rtCpdBarCpn, FTPmhStaGrpPriority AS rtPmhStaGrpPriority");
                    oSql.AppendLine("FROM TPSTSalPD with(nolock)");
                    oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                    oSalDwn.aoTPSTSalPD = oDatabase.C_DATaSqlQuery<cmlResInfoSalPD>(oSql.ToString());
                    
                    // TxnSale
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTCgpCode AS rtCgpCode, FTMemCode AS rtMemCode, FTTxnRefDoc AS rtTxnRefDoc, FTTxnRefInt AS rtTxnRefInt, FTTxnRefSpl AS rtTxnRefSpl,");
                    oSql.AppendLine("FDTxnRefDate AS rdTxnRefDate, FCTxnRefGrand AS rcTxnRefGrand, FCTxnPntOptBuyAmt AS rcTxnPntOptBuyAmt, FCTxnPntOptGetQty AS rcTxnPntOptGetQty, FCTxnPntB4Bill AS rcTxnPntB4Bill,");
                    oSql.AppendLine("FDTxnPntStart AS rdTxnPntStart, FDTxnPntExpired AS rdTxnPntExpired, FCTxnPntBillQty AS rcTxnPntBillQty, FCTxnPntUsed AS rcTxnPntUsed, FCTxnPntExpired AS rcTxnPntExpired,");
                    oSql.AppendLine("FTTxnPntStaClosed AS rtTxnPntStaClosed, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy,");
                    oSql.AppendLine("FTTxnPntDocType AS rtTxnPntDocType");
                    oSql.AppendLine("FROM TCNTMemTxnSale with(nolock)");
                    oSql.AppendLine("WHERE FTTxnRefDoc = '" + poPara.ptDocNo + "' OR FTTxnRefInt = '" + poPara.ptDocNo + "'");
                    oSalDwn.aoTCNTMemTxnSale = oDatabase.C_DATaSqlQuery<cmlResInfoTxnSale>(oSql.ToString());

                    // TxnRedeem
                    oSql.Clear();
                    oSql.AppendLine("SELECT FTCgpCode AS rtCgpCode, FTMemCode AS rtMemCode, FTRedRefDoc AS rtRedRefDoc, FTRedRefInt AS rtRedRefInt, FTRedRefSpl AS rtRedRefSpl,");
                    oSql.AppendLine("FDRedRefDate AS rdRedRefDate, FCRedPntB4Bill AS rcRedPntB4Bill, FCRedPntBillQty AS rcRedPntBillQty, FTRedPntStaClosed AS rtRedPntStaClosed, FDRedPntStart AS rdRedPntStart,");
                    oSql.AppendLine("FDRedPntExpired AS rdRedPntExpired, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy,");
                    oSql.AppendLine("FTRedPntDocType AS rtRedPntDocType");
                    oSql.AppendLine("FROM TCNTMemTxnRedeem with(nolock)");
                    oSql.AppendLine("WHERE FTRedRefDoc = '" + poPara.ptDocNo + "' OR FTRedRefInt = '" + poPara.ptDocNo + "'");
                    oSalDwn.aoTCNTMemTxnRedeem = oDatabase.C_DATaSqlQuery<cmlResInfoTxnRedeem>(oSql.ToString());

                }
                else
                {
                    oResult.rtCode = cMS.tMS_RespCode800;
                    oResult.rtDesc = cMS.tMS_RespDesc800;
                    return oResult;
                }

                oResult.roItem = oSalDwn;
                oResult.rtCode = cMS.tMS_RespCode001;
                oResult.rtDesc = cMS.tMS_RespDesc001;

                return oResult;
            }
            catch (Exception)
            {
                // Return error.
                oResult = new cmlResItem<cmlResSaleDwn>();
                oResult.rtCode = cMS.tMS_RespCode900;
                oResult.rtDesc = cMS.tMS_RespDesc900;
                return oResult;
            }
            finally
            {
                oResult = null;
                oSql = null;
                oDatabase = null;
                //oMsg = null;
                oFunc = null;
            }
        }
    }
}
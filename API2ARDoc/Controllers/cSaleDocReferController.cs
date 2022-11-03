using API2ARDoc.Class;
using API2ARDoc.Class.Standard;
using API2ARDoc.Models.Database;
using API2ARDoc.Models.Webservice.Request.SaleDocRefer;
using API2ARDoc.Models.Webservice.Response.SaleDocRefer;
using API2ARDoc.Models.WebService;
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
    ///     Download Sale Document Refer.
    /// </summary>
    [Route(cCS.tCS_APIVer + "/SaleDocRefer")]
    public class cSaleDocReferController : ControllerBase
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
        [Route("Data")]
        [HttpPost]
        public ActionResult<cmlResItem<cmlResSaleDwn>> POST_DWNoDownloadSale([FromBody] cmlReqSaleDwn poPara)
        {
            string tJsonStr = JsonConvert.SerializeObject(poPara);
            Console.WriteLine("Json File.");
            Console.WriteLine(tJsonStr);

            string tPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string tFileName = Path.Combine(tPath, "SaleDocRefer.log").Replace("\\", "/");
            System.IO.File.WriteAllText(tFileName, tJsonStr);

            cSP oFunc;
            cCS oCS;
            cMS oMsg;

            cmlResItem<cmlResSaleDwn> oResult;
            cmlResSaleDwn oSalDwn;
            List<cmlTSysConfig> aoSysConfig;
            cDatabase oDatabase;
            StringBuilder oSql;

            int nCmdTme;
            string tFuncName, tModelErr, tKeyApi;
            string tWhere = "";
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

                oResult = new cmlResItem<cmlResSaleDwn>();
                oDatabase = new cDatabase();
                oFunc = new cSP();
                oCS = new cCS();
                oMsg = new cMS();

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


                //if(string.IsNullOrEmpty(poPara.ptBchCode) || poPara.pdSaleDate == null)
                //{
                //    oResult.tCode = cMS.tMS_RespCode;
                //    oResult.tDesc = cMS.tMS_RespDesc;
                //    return oResult;
                //}

                // Get data
                oSql = new StringBuilder();
                oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTShpCode AS rtShpCode, FNXshDocType AS rnXshDocType, FDXshDocDate AS rdXshDocDate, FTXshCshOrCrd AS rtXshCshOrCrd, FTXshVATInOrEx AS rtXshVATInOrEx, FTDptCode AS rtDptCode, FTWahCode AS rtWahCode, FTPosCode AS rtPosCode ");
                oSql.AppendLine(", FTShfCode AS rtShfCode, FNSdtSeqNo AS rnSdtSeqNo, FTUsrCode AS rtUsrCode, FTSpnCode AS rtSpnCode, FTXshApvCode AS rtXshApvCode, FTCstCode AS rtCstCode, FTXshDocVatFull AS rtXshDocVatFull, FTXshRefExt AS rtXshRefExt, FDXshRefExtDate AS rdXshRefExtDate, FTXshRefInt AS rtXshRefInt ");
                oSql.AppendLine(", FDXshRefIntDate AS rdXshRefIntDate, FTXshRefAE AS rtXshRefAE, FNXshDocPrint AS rnXshDocPrint, FTRteCode AS rtRteCode, FCXshRteFac AS rcXshRteFac, FCXshTotal AS rcXshTotal, FCXshTotalNV AS rcXshTotalNV, FCXshTotalNoDis AS rcXshTotalNoDis, FCXshTotalB4DisChgV AS rcXshTotalB4DisChgV, FCXshTotalB4DisChgNV AS rcXshTotalB4DisChgNV");
                oSql.AppendLine(", FTXshDisChgTxt AS rtXshDisChgTxt, FCXshDis AS rcXshDis, FCXshChg AS rcXshChg, FCXshTotalAfDisChgV AS rcXshTotalAfDisChgV, FCXshTotalAfDisChgNV AS rcXshTotalAfDisChgNV, FCXshRefAEAmt AS rcXshRefAEAmt, FCXshAmtV AS rcXshAmtV, FCXshAmtNV AS rcXshAmtNV, FCXshVat AS rcXshVat, FCXshVatable AS rcXshVatable");
                oSql.AppendLine(", FTXshWpCode AS rtXshWpCode, FCXshWpTax AS rcXshWpTax, FCXshGrand AS rcXshGrand, FCXshRnd AS rcXshRnd, FTXshGndText AS rtXshGndText, FCXshPaid AS rcXshPaid, FCXshLeft AS rcXshLeft, FTXshRmk AS rtXshRmk , FTXshStaRefund AS rtXshStaRefund, FTXshStaDoc AS rtXshStaDoc ");
                oSql.AppendLine(", FTXshStaApv AS rtXshStaApv, FTXshStaPrcStk AS rtXshStaPrcStk, FTXshStaPaid AS rtXshStaPaid, FNXshStaDocAct AS rnXshStaDocAct, FNXshStaRef AS rnXshStaRef, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy");
                oSql.AppendLine(", FTChnCode AS rtChnCode, FTAppCode AS rtAppCode");  //*Net 64-01-08
                oSql.AppendLine("FROM TPSTSalHD with(nolock)");
                //oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND CONVERT(Date,FDXshDocDate,121) = CONVERT(Date,'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", poPara.pdSaleDate) + "' ,121)");
                //oSql.AppendLine("WHERE CONVERT(Date,FDXshDocDate,121) = CONVERT(Date,'" + string.Format("{0:yyyy-MM-dd HH:mm:ss}", poPara.pdSaleDate) + "' ,121)"); //*Arm 63-09-11

                //*Arm 63-09-16
                if (poPara.pnDoctype == 1)
                {
                    oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' OR FTXshRefInt = '" + poPara.ptDocNo + "'");
                }
                else
                {
                    oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                }
                
                //+++++++++++++

                //if (!string.IsNullOrEmpty(poPara.ptDocNo))
                //{
                //    oSql.AppendLine("AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                //}
                //if (poPara.pnDoctype != null)
                //{
                //    oSql.AppendLine("AND FNXshDocType ='" + poPara.pnDoctype + "' ");
                //}

                oResult.roItem = new cmlResSaleDwn();
                oSalDwn = new cmlResSaleDwn();

                oSalDwn.aoTPSTSalHD = oDatabase.C_DATaSqlQuery<cmlResInfoSalHD>(oSql.ToString());
                tFileName = Path.Combine(tPath, "aoTPSTSalHD.sql").Replace("\\", "/");
                System.IO.File.WriteAllText(tFileName, oSql.ToString());

                if (oSalDwn.aoTPSTSalHD.Count > 0)
                {
                    if (string.IsNullOrEmpty(poPara.ptDocNo))
                    {
                        //* poPara.ptDocNo ไม่มีค่า คือการ กด Browse  ไม่ต้องเอา Detali ไป
                    }
                    else
                    {
                        #region ตรวจสอบคืนข้ามสาขาได้
                        //*Arm 63-09-11 ตรวจสอบคืนข้ามสาขาได้

                        //Check MerChant
                        oSql.Clear();
                        oSql.AppendLine("SELECT ISNULL(FTMerCode,'') AS FTMerCode FROM TCNMShop WITH(NOLOCK)");
                        oSql.AppendLine("WHERE FTBchCode = '" + oSalDwn.aoTPSTSalHD[0].rtBchCode + "'");
                        oSql.AppendLine("AND FTShpCode = '" + oSalDwn.aoTPSTSalHD[0].rtShpCode + "'");
                        string tMerCode = oDatabase.C_DAToSqlQuery<string>(oSql.ToString()) == null ? string.Empty : oDatabase.C_DAToSqlQuery<string>(oSql.ToString());

                        if (tMerCode != poPara.ptMerCode)
                        {
                            // ถ้าไม่ใช่ MerCode เดียวกัน
                            oSalDwn.aoTPSTSalHD = null;
                            oResult.rtCode = cMS.tMS_RespCode800;
                            oResult.rtDesc = cMS.tMS_RespDesc800;
                            return oResult;
                        }

                        //Check AD
                        oSql.Clear();
                        oSql.AppendLine("SELECT ISNULL(FTAgnCode,'') AS FTAgnCode FROM TCNMBranch WITH(NOLOCK)");
                        oSql.AppendLine("WHERE FTBchCode = '" + oSalDwn.aoTPSTSalHD[0].rtBchCode + "'");
                        string tAgnCode = oDatabase.C_DAToSqlQuery<string>(oSql.ToString()) == null ? string.Empty : oDatabase.C_DAToSqlQuery<string>(oSql.ToString());

                        if (tAgnCode != poPara.ptAgnCode)
                        {
                            // ถ้าไม่ใช่ AD เดียวกัน
                            oSalDwn.aoTPSTSalHD = null;
                            oResult.rtCode = cMS.tMS_RespCode800;
                            oResult.rtDesc = cMS.tMS_RespDesc800;
                            return oResult;
                        }
                        //++++++++++++++++
                        #endregion End ตรวจสอบคืนข้ามสาขาได้

                        //* poPara.ptDocNo มีค่า คือการค้นหาเอกสารนั้นตามที่ส่งมาต้องเอา Detail ไปด้วย
                        //// HDCst
                        //oSql.Clear();
                        //oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTXshCardID AS rtXshCardID, FTXshCardNo AS rtXshCardNo, FNXshCrTerm AS rnXshCrTerm");
                        //oSql.AppendLine(", FDXshDueDate AS rdXshDueDate, FDXshBillDue AS rdXshBillDue, FTXshCtrName AS rtXshCtrName, FDXshTnfDate AS rdXshTnfDate, FTXshRefTnfID AS rtXshRefTnfID ");
                        //oSql.AppendLine(", FNXshAddrShip AS rnXshAddrShip, FNXshAddrTax AS rnXshAddrTax, FTXshCstName AS rtXshCstName, FTXshCstTel AS rtXshCstTel, FCXshCstPnt AS rcXshCstPnt, FCXshCstPntPmt AS rcXshCstPntPmt ");
                        //oSql.AppendLine("FROM TPSTSalHDCst with(nolock)");
                        ////oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                        //oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' "); //*Arm 63-09-11
                        //oSalDwn.aoTPSTSalHDCst = oDatabase.C_DATaSqlQuery<cmlResInfoSalHDCst>(oSql.ToString());

                        //// HDDis
                        //oSql.Clear();
                        //oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FDXhdDateIns AS rdXhdDateIns, FTXhdRefCode AS rtXhdRefCode, FTXhdDisChgTxt AS rtXhdDisChgTxt ");
                        //oSql.AppendLine(", FTXhdDisChgType AS rtXhdDisChgType, FCXhdTotalAfDisChg AS rcXhdTotalAfDisChg, FCXhdDisChg AS rcXhdDisChg, FCXhdAmt AS rcXhdAmt, FTDisCode AS rtDisCode ");
                        //oSql.AppendLine(", FTRsnCode AS rtRsnCode ");
                        //oSql.AppendLine("FROM TPSTSalHDDis with(nolock)");
                        ////oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                        //oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' "); //*Arm 63-09-11
                        //oSalDwn.aoTPSTSalHDDis = oDatabase.C_DATaSqlQuery<cmlResInfoSalHDDis>(oSql.ToString());

                        //// DT
                        //oSql.Clear();
                        //oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXsdSeqNo AS rnXsdSeqNo, FTPdtCode AS rtPdtCode, FTXsdPdtName AS rtXsdPdtName, FTPunCode AS rtPunCode, FTPunName AS rtPunName, FCXsdFactor AS rcXsdFactor, FTXsdBarCode AS rtXsdBarCode, FTSrnCode AS rtSrnCode");
                        //oSql.AppendLine(", FTXsdVatType AS rtXsdVatType, FTVatCode AS rtVatCode, FTPplCode AS rtPplCode, FCXsdVatRate AS rcXsdVatRate, FTXsdSaleType AS rtXsdSaleType, FCXsdSalePrice AS rcXsdSalePrice, FCXsdQty AS rcXsdQty, FCXsdQtyAll AS rcXsdQtyAll, FCXsdSetPrice AS rcXsdSetPrice, FCXsdAmtB4DisChg AS rcXsdAmtB4DisChg");
                        //oSql.AppendLine(", FTXsdDisChgTxt AS rtXsdDisChgTxt, FCXsdDis AS rcXsdDis, FCXsdChg AS rcXsdChg, FCXsdNet AS rcXsdNet, FCXsdNetAfHD AS rcXsdNetAfHD, FCXsdVat AS rcXsdVat, FCXsdVatable AS rcXsdVatable, FCXsdWhtAmt AS rcXsdWhtAmt, FTXsdWhtCode AS rtXsdWhtCode, FCXsdWhtRate AS rcXsdWhtRate ");
                        //oSql.AppendLine(", FCXsdCostIn AS rcXsdCostIn, FCXsdCostEx AS rcXsdCostEx, FTXsdStaPdt AS rtXsdStaPdt, FCXsdQtyLef AS rcXsdQtyLef, FCXsdQtyRfn AS rcXsdQtyRfn, FTXsdStaPrcStk AS rtXsdStaPrcStk, FTXsdStaAlwDis AS rtXsdStaAlwDis, FNXsdPdtLevel AS rnXsdPdtLevel, FTXsdPdtParent AS rtXsdPdtParent, FCXsdQtySet AS rcXsdQtySet");
                        //oSql.AppendLine(", FTPdtStaSet AS rtPdtStaSet, FTXsdRmk AS rtXsdRmk, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy ");
                        //oSql.AppendLine("FROM TPSTSalDT with(nolock)");
                        ////oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                        //oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' "); //*Arm 63-09-11
                        //oSalDwn.aoTPSTSalDT = oDatabase.C_DATaSqlQuery<cmlResInfoSalDT>(oSql.ToString());

                        //// DTDis
                        //oSql.Clear();
                        //oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXsdSeqNo AS rnXsdSeqNo, FDXddDateIns AS rdXddDateIns, FTXddRefCode AS rtXddRefCode ");
                        //oSql.AppendLine(", FNXddStaDis AS rnXddStaDis, FTXddDisChgTxt AS rtXddDisChgTxt, FTXddDisChgType AS rtXddDisChgType, FCXddNet AS rcXddNet, FCXddValue AS rcXddValue ");
                        //oSql.AppendLine(", FTDisCode AS rtDisCode, FTRsnCode AS rtRsnCode");
                        //oSql.AppendLine("FROM TPSTSalDTDis with(nolock)");
                        ////oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                        //oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' "); //*Arm 63-09-11
                        //oSalDwn.aoTPSTSalDTDis = oDatabase.C_DATaSqlQuery<cmlResInfoSalDTDis>(oSql.ToString());

                        //// RC
                        //oSql.Clear();
                        //oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXrcSeqNo AS rnXrcSeqNo, FTRcvCode AS rtRcvCode, FTRcvName AS rtRcvName ");
                        //oSql.AppendLine(", FTXrcRefNo1 AS rtXrcRefNo1, FTXrcRefNo2 AS rtXrcRefNo2, FDXrcRefDate AS rdXrcRefDate, FTXrcRefDesc AS rtXrcRefDesc, FTBnkCode AS rtBnkCode ");
                        //oSql.AppendLine(", FTRteCode AS rtRteCode, FCXrcRteFac AS rcXrcRteFac, FCXrcFrmLeftAmt AS rcXrcFrmLeftAmt, FCXrcUsrPayAmt AS rcXrcUsrPayAmt, FCXrcDep AS rcXrcDep ");
                        //oSql.AppendLine(", FCXrcNet AS rcXrcNet, FCXrcChg AS rcXrcChg, FTXrcRmk AS rtXrcRmk, FTPhwCode AS rtPhwCode, FTXrcRetDocRef AS rtXrcRetDocRef ");
                        //oSql.AppendLine(", FTXrcStaPayOffline AS rtXrcStaPayOffline, FDLastUpdOn AS rdLastUpdOn, FTLastUpdBy AS rtLastUpdBy, FDCreateOn AS rdCreateOn, FTCreateBy AS rtCreateBy ");
                        //oSql.AppendLine("FROM TPSTSalRC with(nolock)");
                        ////oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                        //oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' "); //*Arm 63-09-11
                        //oSalDwn.aoTPSTSalRC = oDatabase.C_DATaSqlQuery<cmlResInfoSalRC>(oSql.ToString());

                        ////RD
                        //oSql.Clear();
                        //oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FNXrdSeqNo AS rnXrdSeqNo, FTRdhDocType AS rtRdhDocType, FNXrdRefSeq AS rnXrdRefSeq ");
                        //oSql.AppendLine(", FTXrdRefCode AS rtXrdRefCode, FCXrdPdtQty AS rcXrdPdtQty, FNXrdPntUse AS rnXrdPntUse");
                        //oSql.AppendLine("FROM TPSTSalRD with(nolock)");
                        ////oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                        //oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' "); //*Arm 63-09-11
                        //oSalDwn.aoTPSTSalRD = oDatabase.C_DATaSqlQuery<cmlResInfoSalRD>(oSql.ToString());

                        ////PD
                        //oSql.Clear();
                        //oSql.AppendLine("SELECT FTBchCode AS rtBchCode, FTXshDocNo AS rtXshDocNo, FTPmhDocNo AS rtPmhDocNo, FNXsdSeqNo AS rnXsdSeqNo, FTPmdGrpName AS rtPmdGrpName ");
                        //oSql.AppendLine(", FTPdtCode AS rtPdtCode, FTPunCode AS rtPunCode, FCXsdQty AS rcXsdQty, FCXsdQtyAll AS rcXsdQtyAll, FCXsdSetPrice AS rcXsdSetPrice");
                        //oSql.AppendLine(", FCXsdNet AS rcXsdNet, FCXpdGetQtyDiv AS rcXpdGetQtyDiv, FTXpdGetType AS rtXpdGetType, FCXpdGetValue AS rcXpdGetValue, FCXpdDis AS rcXpdDis");
                        //oSql.AppendLine(", FCXpdPerDisAvg AS rcXpdPerDisAvg, FCXpdDisAvg AS rcXpdDisAvg, FCXpdPoint AS rcXpdPoint, FTXpdStaRcv AS rtXpdStaRcv, FTPplCode AS rtPplCode ");
                        //oSql.AppendLine(", FTXpdCpnText AS rtXpdCpnText, FTCpdBarCpn AS rtCpdBarCpn, FTPmhStaGrpPriority AS rtPmhStaGrpPriority");
                        //oSql.AppendLine("FROM TPSTSalPD with(nolock)");
                        ////oSql.AppendLine("WHERE FTBchCode = '" + poPara.ptBchCode + "' AND FTXshDocNo  = '" + poPara.ptDocNo + "' ");
                        //oSql.AppendLine("WHERE FTXshDocNo  = '" + poPara.ptDocNo + "' "); //*Arm 63-09-11
                        //oSalDwn.aoTPSTSalPD = oDatabase.C_DATaSqlQuery<cmlResInfoSalPD>(oSql.ToString());

                        
                        if (poPara.pnDoctype == 1)
                        {
                            tWhere = "WHERE HD.FTXshDocNo  = '" + poPara.ptDocNo + "' OR HD.FTXshRefInt = '" + poPara.ptDocNo + "'";
                        }
                        else
                        {
                            tWhere = "WHERE HD.FTXshDocNo  = '" + poPara.ptDocNo + "'";
                        }

                        // คืนอ้างขาย ขายอ้างคืน 
                        // DT *Arm 63-09-16
                        oSql.Clear();
                        oSql.AppendLine("SELECT DT.FTBchCode AS rtBchCode, DT.FTXshDocNo AS rtXshDocNo, DT.FNXsdSeqNo AS rnXsdSeqNo, DT.FTPdtCode AS rtPdtCode, DT.FTXsdPdtName AS rtXsdPdtName, DT.FTPunCode AS rtPunCode, DT.FTPunName AS rtPunName, DT.FCXsdFactor AS rcXsdFactor, DT.FTXsdBarCode AS rtXsdBarCode, DT.FTSrnCode AS rtSrnCode");
                        oSql.AppendLine(", DT.FTXsdVatType AS rtXsdVatType, DT.FTVatCode AS rtVatCode, DT.FTPplCode AS rtPplCode, DT.FCXsdVatRate AS rcXsdVatRate, DT.FTXsdSaleType AS rtXsdSaleType, DT.FCXsdSalePrice AS rcXsdSalePrice, DT.FCXsdQty AS rcXsdQty, DT.FCXsdQtyAll AS rcXsdQtyAll, DT.FCXsdSetPrice AS rcXsdSetPrice, DT.FCXsdAmtB4DisChg AS rcXsdAmtB4DisChg");
                        oSql.AppendLine(", DT.FTXsdDisChgTxt AS rtXsdDisChgTxt, DT.FCXsdDis AS rcXsdDis, DT.FCXsdChg AS rcXsdChg, DT.FCXsdNet AS rcXsdNet, DT.FCXsdNetAfHD AS rcXsdNetAfHD, DT.FCXsdVat AS rcXsdVat, DT.FCXsdVatable AS rcXsdVatable, DT.FCXsdWhtAmt AS rcXsdWhtAmt, DT.FTXsdWhtCode AS rtXsdWhtCode, DT.FCXsdWhtRate AS rcXsdWhtRate ");
                        oSql.AppendLine(", DT.FCXsdCostIn AS rcXsdCostIn, DT.FCXsdCostEx AS rcXsdCostEx, DT.FTXsdStaPdt AS rtXsdStaPdt, DT.FCXsdQtyLef AS rcXsdQtyLef, DT.FCXsdQtyRfn AS rcXsdQtyRfn, DT.FTXsdStaPrcStk AS rtXsdStaPrcStk, DT.FTXsdStaAlwDis AS rtXsdStaAlwDis, DT.FNXsdPdtLevel AS rnXsdPdtLevel, DT.FTXsdPdtParent AS rtXsdPdtParent, DT.FCXsdQtySet AS rcXsdQtySet");
                        oSql.AppendLine(", DT.FTPdtStaSet AS rtPdtStaSet, DT.FTXsdRmk AS rtXsdRmk, DT.FDLastUpdOn AS rdLastUpdOn, DT.FTLastUpdBy AS rtLastUpdBy, DT.FDCreateOn AS rdCreateOn, DT.FTCreateBy AS rtCreateBy ");
                        oSql.AppendLine("FROM TPSTSalDT DT with(nolock)");
                        oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = DT.FTBchCode AND HD.FTXshDocNo = DT.FTXshDocNo");
                        oSql.AppendLine(tWhere);
                        oSalDwn.aoTPSTSalDT = oDatabase.C_DATaSqlQuery<cmlResInfoSalDT>(oSql.ToString());

                        // HDCst *Arm 63-10-10
                        oSql.Clear();
                        oSql.AppendLine("SELECT HDCst.FTBchCode AS rtBchCode, HDCst.FTXshDocNo AS rtXshDocNo, HDCst.FTXshCardID AS rtXshCardID, HDCst.FTXshCardNo AS rtXshCardNo, HDCst.FNXshCrTerm AS rnXshCrTerm");
                        oSql.AppendLine(", HDCst.FDXshDueDate AS rdXshDueDate, HDCst.FDXshBillDue AS rdXshBillDue, HDCst.FTXshCtrName AS rtXshCtrName, HDCst.FDXshTnfDate AS rdXshTnfDate, HDCst.FTXshRefTnfID AS rtXshRefTnfID ");
                        oSql.AppendLine(", HDCst.FNXshAddrShip AS rnXshAddrShip, HDCst.FNXshAddrTax AS rnXshAddrTax, HDCst.FTXshCstName AS rtXshCstName, HDCst.FTXshCstTel AS rtXshCstTel, HDCst.FCXshCstPnt AS rcXshCstPnt, HDCst.FCXshCstPntPmt AS rcXshCstPntPmt ");
                        oSql.AppendLine("FROM TPSTSalHDCst HDCst with(nolock)");
                        oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = HDCst.FTBchCode AND HD.FTXshDocNo = HDCst.FTXshDocNo");
                        oSql.AppendLine(tWhere);
                        oSalDwn.aoTPSTSalHDCst = oDatabase.C_DATaSqlQuery<cmlResInfoSalHDCst>(oSql.ToString());
                        //+++++++++++++++

                        // คืนอ้างขาย 
                        if (poPara.pnDoctype == 1)
                        {
                            //// HDCst *Arm 63-09-16
                            //oSql.Clear();
                            //oSql.AppendLine("SELECT HDCst.FTBchCode AS rtBchCode, HDCst.FTXshDocNo AS rtXshDocNo, HDCst.FTXshCardID AS rtXshCardID, HDCst.FTXshCardNo AS rtXshCardNo, HDCst.FNXshCrTerm AS rnXshCrTerm");
                            //oSql.AppendLine(", HDCst.FDXshDueDate AS rdXshDueDate, HDCst.FDXshBillDue AS rdXshBillDue, HDCst.FTXshCtrName AS rtXshCtrName, HDCst.FDXshTnfDate AS rdXshTnfDate, HDCst.FTXshRefTnfID AS rtXshRefTnfID ");
                            //oSql.AppendLine(", HDCst.FNXshAddrShip AS rnXshAddrShip, HDCst.FNXshAddrTax AS rnXshAddrTax, HDCst.FTXshCstName AS rtXshCstName, HDCst.FTXshCstTel AS rtXshCstTel, HDCst.FCXshCstPnt AS rcXshCstPnt, HDCst.FCXshCstPntPmt AS rcXshCstPntPmt ");
                            //oSql.AppendLine("FROM TPSTSalHDCst HDCst with(nolock)");
                            //oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = HDCst.FTBchCode AND HD.FTXshDocNo = HDCst.FTXshDocNo");
                            //oSql.AppendLine(tWhere);
                            //oSalDwn.aoTPSTSalHDCst = oDatabase.C_DATaSqlQuery<cmlResInfoSalHDCst>(oSql.ToString());

                            // HDDis *Arm 63-09-16
                            oSql.Clear();
                            oSql.AppendLine("SELECT HDDis.FTBchCode AS rtBchCode, HDDis.FTXshDocNo AS rtXshDocNo, HDDis.FDXhdDateIns AS rdXhdDateIns, HDDis.FTXhdRefCode AS rtXhdRefCode, HDDis.FTXhdDisChgTxt AS rtXhdDisChgTxt ");
                            oSql.AppendLine(", HDDis.FTXhdDisChgType AS rtXhdDisChgType, HDDis.FCXhdTotalAfDisChg AS rcXhdTotalAfDisChg, HDDis.FCXhdDisChg AS rcXhdDisChg, HDDis.FCXhdAmt AS rcXhdAmt, HDDis.FTDisCode AS rtDisCode ");
                            oSql.AppendLine(", HDDis.FTRsnCode AS rtRsnCode ");
                            oSql.AppendLine("FROM TPSTSalHDDis HDDis with(nolock)");
                            oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = HDDis.FTBchCode AND HD.FTXshDocNo = HDDis.FTXshDocNo");
                            oSql.AppendLine(tWhere);
                            oSalDwn.aoTPSTSalHDDis = oDatabase.C_DATaSqlQuery<cmlResInfoSalHDDis>(oSql.ToString());

                            // DTDis *Arm 63-09-16
                            oSql.Clear();
                            oSql.AppendLine("SELECT DTDis.FTBchCode AS rtBchCode, DTDis.FTXshDocNo AS rtXshDocNo, DTDis.FNXsdSeqNo AS rnXsdSeqNo, DTDis.FDXddDateIns AS rdXddDateIns, DTDis.FTXddRefCode AS rtXddRefCode ");
                            oSql.AppendLine(", DTDis.FNXddStaDis AS rnXddStaDis, DTDis.FTXddDisChgTxt AS rtXddDisChgTxt, DTDis.FTXddDisChgType AS rtXddDisChgType, DTDis.FCXddNet AS rcXddNet, DTDis.FCXddValue AS rcXddValue ");
                            oSql.AppendLine(", DTDis.FTDisCode AS rtDisCode, DTDis.FTRsnCode AS rtRsnCode");
                            oSql.AppendLine("FROM TPSTSalDTDis DTDis with(nolock)");
                            oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = DTDis.FTBchCode AND HD.FTXshDocNo = DTDis.FTXshDocNo");
                            oSql.AppendLine(tWhere);
                            oSalDwn.aoTPSTSalDTDis = oDatabase.C_DATaSqlQuery<cmlResInfoSalDTDis>(oSql.ToString());

                            // RC *Arm 63-09-16
                            oSql.Clear();
                            oSql.AppendLine("SELECT RC.FTBchCode AS rtBchCode, RC.FTXshDocNo AS rtXshDocNo, RC.FNXrcSeqNo AS rnXrcSeqNo, RC.FTRcvCode AS rtRcvCode, RC.FTRcvName AS rtRcvName ");
                            oSql.AppendLine(", RC.FTXrcRefNo1 AS rtXrcRefNo1, RC.FTXrcRefNo2 AS rtXrcRefNo2, RC.FDXrcRefDate AS rdXrcRefDate, RC.FTXrcRefDesc AS rtXrcRefDesc, RC.FTBnkCode AS rtBnkCode ");
                            oSql.AppendLine(", RC.FTRteCode AS rtRteCode, RC.FCXrcRteFac AS rcXrcRteFac, RC.FCXrcFrmLeftAmt AS rcXrcFrmLeftAmt, RC.FCXrcUsrPayAmt AS rcXrcUsrPayAmt, RC.FCXrcDep AS rcXrcDep ");
                            oSql.AppendLine(", RC.FCXrcNet AS rcXrcNet, RC.FCXrcChg AS rcXrcChg, RC.FTXrcRmk AS rtXrcRmk, RC.FTPhwCode AS rtPhwCode, RC.FTXrcRetDocRef AS rtXrcRetDocRef ");
                            oSql.AppendLine(", RC.FTXrcStaPayOffline AS rtXrcStaPayOffline, RC.FDLastUpdOn AS rdLastUpdOn, RC.FTLastUpdBy AS rtLastUpdBy, RC.FDCreateOn AS rdCreateOn, RC.FTCreateBy AS rtCreateBy ");
                            oSql.AppendLine("FROM TPSTSalRC RC with(nolock)");
                            oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = RC.FTBchCode AND HD.FTXshDocNo = RC.FTXshDocNo");
                            oSql.AppendLine(tWhere);
                            oSalDwn.aoTPSTSalRC = oDatabase.C_DATaSqlQuery<cmlResInfoSalRC>(oSql.ToString());

                            //RD *Arm 63-09-16
                            oSql.Clear();
                            oSql.AppendLine("SELECT RD.FTBchCode AS rtBchCode, RD.FTXshDocNo AS rtXshDocNo, RD.FNXrdSeqNo AS rnXrdSeqNo, RD.FTRdhDocType AS rtRdhDocType, RD.FNXrdRefSeq AS rnXrdRefSeq ");
                            oSql.AppendLine(", RD.FTXrdRefCode AS rtXrdRefCode, RD.FCXrdPdtQty AS rcXrdPdtQty, RD.FNXrdPntUse AS rnXrdPntUse");
                            oSql.AppendLine("FROM TPSTSalRD RD with(nolock)");
                            oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = RD.FTBchCode AND HD.FTXshDocNo = RD.FTXshDocNo");
                            oSql.AppendLine(tWhere);
                            oSalDwn.aoTPSTSalRD = oDatabase.C_DATaSqlQuery<cmlResInfoSalRD>(oSql.ToString());

                            //PD *Arm 63-09-16
                            oSql.Clear();
                            oSql.AppendLine("SELECT PD.FTBchCode AS rtBchCode, PD.FTXshDocNo AS rtXshDocNo, PD.FTPmhDocNo AS rtPmhDocNo, PD.FNXsdSeqNo AS rnXsdSeqNo, PD.FTPmdGrpName AS rtPmdGrpName ");
                            oSql.AppendLine(", PD.FTPdtCode AS rtPdtCode, PD.FTPunCode AS rtPunCode, PD.FCXsdQty AS rcXsdQty, PD.FCXsdQtyAll AS rcXsdQtyAll, PD.FCXsdSetPrice AS rcXsdSetPrice");
                            oSql.AppendLine(", PD.FCXsdNet AS rcXsdNet, PD.FCXpdGetQtyDiv AS rcXpdGetQtyDiv, PD.FTXpdGetType AS rtXpdGetType, PD.FCXpdGetValue AS rcXpdGetValue, PD.FCXpdDis AS rcXpdDis");
                            oSql.AppendLine(", PD.FCXpdPerDisAvg AS rcXpdPerDisAvg, PD.FCXpdDisAvg AS rcXpdDisAvg, PD.FCXpdPoint AS rcXpdPoint, PD.FTXpdStaRcv AS rtXpdStaRcv, PD.FTPplCode AS rtPplCode ");
                            oSql.AppendLine(", PD.FTXpdCpnText AS rtXpdCpnText, PD.FTCpdBarCpn AS rtCpdBarCpn, PD.FTPmhStaGrpPriority AS rtPmhStaGrpPriority");
                            oSql.AppendLine("FROM TPSTSalPD PD with(nolock)");
                            oSql.AppendLine("INNER JOIN TPSTSalHD HD with(nolock) ON HD.FTBchCode = PD.FTBchCode AND HD.FTXshDocNo = PD.FTXshDocNo");
                            oSql.AppendLine(tWhere);
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
                    }
                    
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
            catch (Exception oEx)
            {
                tFileName = Path.Combine(tPath, "error.txt").Replace("\\", "/");
                System.IO.File.WriteAllText(tFileName, oEx.Message);
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
                oMsg = null;
                oFunc = null;
            }
        }
    }
}
using API2ARDoc.Class.Standard;
using API2ARDoc.Models;
using API2ARDoc.Models.WebService;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading;

namespace API2ARDoc.Controllers
{
    [Route(cCS.tCS_APIVer)]    //*Arm 63-02-19 [ปรับ Standrad]
    public class cvcSoHDGetController : ControllerBase
    {
        readonly ILog oLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //[Route("v1/TARTSoHDGet")]
        [Route("TARTSoHDGet")]//*Arm 63-02-19 [ปรับ Standrad]
        [HttpPost]
        public cmlResItem<cmlResMsgJson> TARTSoHDGet([FromBody] cmlReqData poReq)
        {
            cmlResItem<cmlResMsgJson> oResult;
            cmlResMsgJson oResData;
            cmlData oDataSoHD;
            cMS oMsg = new cMS(); //*Arm 63-02-19 [ปรับ Standrad]
            string tErrAPI;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                CultureInfo oCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                oCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd HH:mm:ss";
                oCulture.DateTimeFormat.ShortTimePattern = "";
                Thread.CurrentThread.CurrentCulture = oCulture;

                oResData = new cmlResMsgJson();
                oDataSoHD = new cmlData();
                oResult = new cmlResItem<cmlResMsgJson>();
                
                #region Check API Key
                if (cSP.SP_CHKbKeyApi(HttpContext, out tErrAPI) == false)
                {
                    if (tErrAPI == "-1")
                    {
                        //oResult.tCode = cMS.tMS_RespCode905;
                        //oResult.tDesc = cMS.tMS_RespDesc905;
                        oResult.rtCode = cMS.tMS_RespCode905;   //*Arm 63-02-19 [ปรับ Standrad]
                        oResult.rtDesc = cMS.tMS_RespDesc905;   //*Arm 63-02-19 [ปรับ Standrad]
                        oResult.roItem = new cmlResMsgJson();
                        return oResult;
                    }
                    else
                    {
                        //oResult.tCode = cMS.tMS_RespCode904;
                        //oResult.tDesc = cMS.tMS_RespDesc904;
                        oResult.rtCode = cMS.tMS_RespCode904;    //*Arm 63-02-19 [ปรับ Standrad]
                        oResult.rtDesc = cMS.tMS_RespDesc904;    //*Arm 63-02-19 [ปรับ Standrad]
                        oResult.roItem = new cmlResMsgJson();
                        return oResult;
                    }
                }
                #endregion

                oDataSoHD.aSoHD = cSP.SP_GETtTARTSoHD(poReq);
                if (oDataSoHD.aSoHD.Count > 0)
                {
                    oDataSoHD.aSoHD[0].aSoDT = cSP.SP_GETtTARTSoDT(poReq);
                    oDataSoHD.aSoHD[0].aSoHDCst = cSP.SP_GETtTARTSoHDCst(poReq);
                    oDataSoHD.aSoHD[0].aSoHDDis = cSP.SP_GETtTARTSoHDDis(poReq);
                    oDataSoHD.aSoHD[0].aSoDTDis = cSP.SP_GETtTARTSoDTDis(poReq);
                }


                oResData.tFunction = "TARTSoHDGet";
                oResData.tSource = "Database";
                oResData.tDest = "Vending";
                oResData.tFilter = "00001";
                oResData.tData = oDataSoHD;


                //oResult.tCode = cMS.tMS_RespCode001; 
                //oResult.tDesc = cMS.tMS_RespDesc001;
                oResult.rtCode = cMS.tMS_RespCode001;    //*Arm 63-02-19 [ปรับ Standrad]
                oResult.rtDesc = cMS.tMS_RespDesc001;    //*Arm 63-02-19 [ปรับ Standrad]
                oResult.roItem = oResData;

                return oResult;
            }
            catch (Exception oEx)
            {

                oResult = new cmlResItem<cmlResMsgJson>();
                //oResult.tCode = cMS.tMS_RespCode900;
                //oResult.tDesc = cMS.tMS_RespDesc900;
                oResult.rtCode = cMS.tMS_RespCode900;    //*Arm 63-02-19 [ปรับ Standrad]
                oResult.rtDesc = cMS.tMS_RespDesc900;    //*Arm 63-02-19 [ปรับ Standrad]
                oResult.roItem = new cmlResMsgJson();

                return oResult;
            }
           
        }
    }
}
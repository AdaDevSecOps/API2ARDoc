using API2ARDoc.Class;
using API2ARDoc.Class.Standard;
using API2ARDoc.Models.Database;
using API2ARDoc.Models.Webservice.Request.SaleDocRefer;
using API2ARDoc.Models.WebService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace API2ARDoc.Controllers
{
    /// <summary>
    ///     Update Sale Refer.
    /// </summary>
    [Route(cCS.tCS_APIVer + "/UpdSaleRefer")]
    public class cUpdSaleReferController : ControllerBase
    {
        /// <summary>
        /// อัพโหลดข้อมูลเอกสารการขาย
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
        public cmlResBase POST_UPDoUpdSaleRefer([FromBody] cmlReqUpdSaleRefer poPara)
        {
            cmlResBase oResult;
            List<cmlTSysConfig> aoSysConfig;
            cMS oMsg;
            cSP oSP;
            int nCmdTme;
            string tFuncName, tModelErr, tKeyApi;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                oMsg = new cMS();
                oSP = new cSP();

                oResult = new cmlResBase();
                if (poPara == null)
                {
                    oResult.rtCode = cMS.tMS_RespCode700;
                    oResult.rtDesc = cMS.tMS_RespDesc700;
                    return oResult;
                }
                // Get method name.
                tFuncName = MethodBase.GetCurrentMethod().Name;

                // Validate parameter.
                tModelErr = "";
                if (oSP.SP_CHKbParaModel(out tModelErr, ModelState) == false)
                {
                    // Validate parameter model false.
                    oResult.rtCode = cMS.tMS_RespCode701;
                    oResult.rtDesc = cMS.tMS_RespDesc701 + tModelErr;
                    return oResult;
                }

                aoSysConfig = oSP.SP_SYSaLoadConfiguration();
                oSP.SP_DATxGetConfigurationFromMem<int>(out nCmdTme, cCS.nCS_CmdTme, aoSysConfig, "2");

                tKeyApi = "";
                // Check KeyApi.
                if (oSP.SP_CHKbKeyApi(out tKeyApi, aoSysConfig, HttpContext) == false)
                {
                    // Key not allowed to use method.
                    oResult.rtCode = cMS.tMS_RespCode904;
                    oResult.rtDesc = cMS.tMS_RespDesc904;
                    return oResult;
                }

                cRabbitMQ oRQ = new cRabbitMQ();
                oRQ.C_GETbLoadConfigMQ();
                if (!string.IsNullOrEmpty(cRabbitMQ.tC_HostName))
                {
                    if (!string.IsNullOrEmpty(cRabbitMQ.tC_QueueUpdSaleRF))
                    {
                        //string tConnStr = ConfigurationManager.ConnectionStrings["tConnDB"].ConnectionString;
                        string tConnStr = cAppSetting.Default.tConnDB;
                        string tMsgJson = oRQ.C_CRTtMsgDataUpload(Newtonsoft.Json.JsonConvert.SerializeObject(poPara), tConnStr);
                        if (oRQ.C_PRCbSendData2Srv(tMsgJson, cRabbitMQ.tC_QueueUpdSaleRF))
                        {
                            oResult.rtCode = cMS.tMS_RespCode001;
                            oResult.rtDesc = cMS.tMS_RespDesc001;
                        }
                        else
                        {
                            oResult.rtCode = cMS.tMS_RespCode907;
                            oResult.rtDesc = cMS.tMS_RespDesc907;
                        }
                    }
                    else
                    {
                        oResult.rtCode = cMS.tMS_RespCode907;
                        oResult.rtDesc = cMS.tMS_RespDesc907;
                    }
                }
                else
                {
                    oResult.rtCode = cMS.tMS_RespCode907;
                    oResult.rtDesc = cMS.tMS_RespDesc907;
                }
                return oResult;

            }
            catch(Exception oEx)
            {
                oResult = new cmlResBase();
                oResult.rtCode = cMS.tMS_RespCode900;
                oResult.rtDesc = cMS.tMS_RespDesc900;
                return oResult;
            }
        }
    }
}
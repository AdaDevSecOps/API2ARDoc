using API2ARDoc.Class.Standard;
using API2ARDoc.Class.Online;
using API2ARDoc.Models.WebService;
using System;
using System.Globalization;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

namespace API2ARDoc.Controllers
{
    /// <summary>
    /// Information Class online
    /// </summary>
    [Route(cCS.tCS_APIVer + "/CheckAccess")]
    public class cCheckAccessController : ControllerBase
    {
        /// <summary>
        /// Function check online 
        /// </summary>
        /// <returns>
        /// System process status.<br/>
        ///&#8195;     1   : success.<br/>    
        ///&#8195;     900 : service process false.<br/>
        ///&#8195;     904 : key not allowed to use method.<br/>
        ///&#8195;     905 : cannot connect database.<br/>
        /// </returns>
        [Route("IsAccess")]
        [HttpPost]
        public cmlResIsOnline POST_CHKoIsOnline()
        {
            //*Ton 63-05-20 เปลี่ยน cMS เป็น const
            //cMS oMsg = new cMS(); //*Arm 63-02-19 [ปรับ Standrad]

            cOnline oOnline;
            cmlResIsOnline oResult;
            string tErrCode, tErrDesc, tErrAPI;
            bool bChk;
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
                oResult = new cmlResIsOnline();
                oOnline = new cOnline();


                bChk = oOnline.C_CHKbOnline(out tErrCode, out tErrDesc);
                if (bChk == true)
                {
                    #region Check API Key
                    if (cSP.SP_CHKbKeyApi(HttpContext, out tErrAPI) == false)
                    {
                        if (tErrAPI == "-1")
                        {
                            //oResult.tCode = cMS.tMS_RespCode905;
                            //oResult.tDesc = cMS.tMS_RespDesc905;
                            oResult.rtCode = cMS.tMS_RespCode905;   //*Arm 63-02-19 [ปรับ Standrad]
                            oResult.rtDesc = cMS.tMS_RespDesc905;   //*Arm 63-02-19 [ปรับ Standrad]
                            return oResult;
                        }
                        else
                        {
                            //oResult.tCode = cMS.tMS_RespCode904;
                            //oResult.tDesc = cMS.tMS_RespDesc904;
                            oResult.rtCode = cMS.tMS_RespCode904;   //*Arm 63-02-19 [ปรับ Standrad]
                            oResult.rtDesc = cMS.tMS_RespDesc904;   //*Arm 63-02-19 [ปรับ Standrad]
                            return oResult;
                        }
                    }
                    #endregion

                    oResult.tResult = "API : Allow Access";
                    oResult.rtCode = cMS.tMS_RespCode001;   //*Arm 63-02-19 [ปรับ Standrad]
                    oResult.rtDesc = cMS.tMS_RespDesc001;   //*Arm 63-02-19 [ปรับ Standrad]
                    return oResult;
                }
                else
                {
                    oResult.rtCode = tErrCode;
                    oResult.rtDesc = tErrDesc;
                    return oResult;
                }
            }
            catch (Exception)
            {
                oResult = new cmlResIsOnline();
                //oResult.tCode = cMS.tMS_RespCode900;
                //oResult.tDesc = cMS.tMS_RespDesc900;
                oResult.rtCode = cMS.tMS_RespCode900;   //*Arm 63-02-19 [ปรับ Standrad]
                oResult.rtDesc = cMS.tMS_RespDesc900;   //*Arm 63-02-19 [ปรับ Standrad]
                return oResult;
            }
            finally
            {
                oOnline = null;
                oResult = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}

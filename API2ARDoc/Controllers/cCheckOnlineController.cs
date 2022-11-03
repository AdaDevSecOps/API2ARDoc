using System;
using API2ARDoc.Class;
using API2ARDoc.Models.WebService;
using API2ARDoc.Class.Online;
using API2ARDoc.Class.Standard;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace API2ARDoc.Controllers
{
    /// <summary>
    /// Information Class online
    /// </summary>
    [Route(cCS.tCS_APIVer + "/CheckOnline")]
    public class cCheckOnlineController : ControllerBase
    {

        ///// <summary>
        ///// Is online ตรวจสอบ connection
        ///// </summary>
        ///// <returns>
        ///// System process status.<br/>
        /////&#8195;     1   : success.<br/>    
        /////&#8195;     900 : service process false.<br/>
        /////&#8195;     905 : cannot connect database.<br/>
        /////&#8195;     906 : this time not allowed to use method.<br/>
        ///// </returns>
        //[Route("IsOnline")]
        //[HttpGet]
        //public cmlResIsOnline POST_CHKoIsOnline()
        //{
        //    cSP oFunc;
        //    cCS oCons;
        //    cMS oMsg;
        //    cOnline oOnline;
        //    List<cmlTSysConfig> aoSysConfig;
        //    cmlResIsOnline oResIsOnlineErr;
        //    cmlResIsOnline oResult;
        //    string tErrCode, tErrDesc;
        //    bool bVerifyPara;
        //    string tDBName = "";
        //    cDatabase oDatabase;
        //    try
        //    {
        //        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        //        oResult = new cmlResIsOnline();
        //        oFunc = new cSP();
        //        oCons = new cCS();
        //        oMsg = new cMS();

        //        // Load configuration.
        //        aoSysConfig = oFunc.SP_SYSaLoadConfiguration();

        //        // Varify parameter value.
        //        oOnline = new cOnline();
        //        bVerifyPara = oOnline.C_DATbVerifyIsOnline(aoSysConfig, out tErrCode, out tErrDesc, out oResIsOnlineErr);
        //        if (bVerifyPara == true)
        //        {
        //            oDatabase = new cDatabase();
        //            tDBName = new SqlConnection(oDatabase.C_CONoDatabase().ConnectionString).Database;
        //            oResult.tResult = tDBName + " :Ready";
        //            oResult.tCode = cMS.tMS_RespCode001;
        //            oResult.tDesc = cMS.tMS_RespDesc001;
        //            return oResult;
        //        }
        //        else
        //        {
        //            // Varify parameter value false.
        //            oResult.tCode = tErrCode;
        //            oResult.tDesc = tErrDesc;
        //            return oResult;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // Return error.
        //        oResult = new cmlResIsOnline();
        //        oResult.tCode = cMS.tMS_RespCode900;
        //        oResult.tDesc = cMS.tMS_RespDesc900;
        //        return oResult;
        //    }
        //    finally
        //    {
        //        oFunc = null;
        //        oCons = null;
        //        oMsg = null;
        //        aoSysConfig = null;
        //        oResIsOnlineErr = null;
        //        oResult = null;
        //        oResult = null;
        //        oDatabase = null;
        //        tDBName = null;
        //    }
        //}



        /// <summary>
        /// Is online ตรวจสอบ connection
        /// </summary>
        /// <returns>
        /// System process status.<br/>
        ///&#8195;     1   : success.<br/>    
        ///&#8195;     900 : service process false.<br/>
        ///&#8195;     905 : cannot connect database.<br/>
        ///&#8195;     906 : this time not allowed to use method.<br/>
        /// </returns>
        [Route("IsOnline")]
        [HttpGet]
        public cmlResIsOnline GET_CHKoIsOnline()
        {
            //*Ton 64-05-20
            //cMS oMsg = new cMS(); //*Arm 63-02-19 [ปรับ Standrad]

            cmlResIsOnline oResult;
            cOnline oOnline;
            cDatabase oDatabase;    //*Arm 63-02-19 [ปรับ Standrad]
            string tErrCode, tErrDesc;
            string tDBName; //*Arm 63-02-19 [ปรับ Standrad]
            bool bChk;
            try
            {
                oResult = new cmlResIsOnline();
                oOnline = new cOnline();

                bChk = oOnline.C_CHKbOnline(out tErrCode, out tErrDesc);
                if (bChk)
                {
                    //*Arm 63-02-19 [ปรับ Standrad]
                    oDatabase = new cDatabase();
                    tDBName = new SqlConnection(oDatabase.C_CONoDatabase().ConnectionString).Database;
                    oResult.tResult = tDBName + " :Ready";
                    //+++++++++++++++++++
                    //oResult.tResult = "API : Ready";
                    //oResult.tCode = cMS.tMS_RespCode001;
                    //oResult.tDesc = cMS.tMS_RespDesc001;
                    oResult.rtCode = cMS.tMS_RespCode001;   //*Arm 63-02-19 [ปรับ Standrad]
                    oResult.rtDesc = cMS.tMS_RespDesc001;   //*Arm 63-02-19 [ปรับ Standrad]
                    return oResult;
                }
                //oResult.tCode = cMS.tMS_RespCode905;
                //oResult.tDesc = cMS.tMS_RespDesc905;
                oResult.rtCode = cMS.tMS_RespCode905;   //*Arm 63-02-19 [ปรับ Standrad]
                oResult.rtDesc = cMS.tMS_RespDesc905;   //*Arm 63-02-19 [ปรับ Standrad]
                return oResult;
            }
            catch (Exception)
            {
                oResult = new cmlResIsOnline();
                //oResult.tCode = cMS.tMS_RespCode905;
                //oResult.tDesc = cMS.tMS_RespDesc905;
                oResult.rtCode = cMS.tMS_RespCode905;   //*Arm 63-02-19 [ปรับ Standrad]
                oResult.rtDesc = cMS.tMS_RespDesc905;   //*Arm 63-02-19 [ปรับ Standrad]
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

using API2ARDoc.Class.Standard;
using API2ARDoc.Models.Database;
using API2ARDoc.Models.WebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace API2ARDoc.Class.Online
{
    public class cOnline
    {
        /// <summary>
        /// Class online
        /// </summary>
        /// 
        ///&#8195;     1   : success.<br/>    
        ///&#8195;     900 : service process false.<br/>
        ///&#8195;     905 : cannot connect database.<br/>
        /// </returns>
        public bool C_CHKbOnline(out string ptErrCode, out string ptErrDesc)
        {
            cMS oMsg = new cMS(); //*Arm 63-02-19 [ปรับ Standrad]
            cDatabase oDatabase;
            string tDBName;
            try
            {


                //oDatabase = new cDatabase(cConfig.tDB_ConnStr);
                //tDBName = (string)oDatabase.C_GEToQueryScalarObj("SELECT DB_NAME() AS [Current Database];");
                //*Arm 63-02-18
                oDatabase = new cDatabase();
                tDBName = oDatabase.C_GETtSQLScalarString("SELECT DB_NAME() AS [Current Database];");
                //+++++++++++++++

                if (tDBName != null)
                {
                    //ptErrCode = cMS.tMS_RespCode001;
                    //ptErrDesc = cMS.tMS_RespDesc001;
                    ptErrCode = cMS.tMS_RespCode001;   //*Arm 63-02-19 [ปรับ Standrad]
                    ptErrDesc = cMS.tMS_RespDesc001;   //*Arm 63-02-19 [ปรับ Standrad]
                    return true;
                }
                //ptErrCode = cMS.tMS_RespCode905;
                //ptErrDesc = cMS.tMS_RespDesc905;
                ptErrCode = cMS.tMS_RespCode905;   //*Arm 63-02-19 [ปรับ Standrad]
                ptErrDesc = cMS.tMS_RespDesc905;   //*Arm 63-02-19 [ปรับ Standrad]
                return false;
            }
            catch (Exception)
            {
                //ptErrCode = cMS.tMS_RespCode900;
                //ptErrDesc = cMS.tMS_RespDesc900;
                ptErrCode = cMS.tMS_RespCode900;   //*Arm 63-02-19 [ปรับ Standrad]
                ptErrDesc = cMS.tMS_RespDesc900;   //*Arm 63-02-19 [ปรับ Standrad]
                return false;
            }
            finally
            {
                oDatabase = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }



        /// <summary>
        /// ตรวจสอบสถานะ Online
        /// </summary>
        /// <param name="paoSysConfig"></param>
        /// <param name="ptErrCode"></param>
        /// <param name="ptErrDesc"></param>
        /// <param name="poIsOnlineErr"></param>
        /// <returns></returns>
        public bool C_DATbVerifyIsOnline(List<cmlTSysConfig> paoSysConfig, out string ptErrCode
                                            , out string ptErrDesc, out cmlResIsOnline poIsOnlineErr)
        {
            cSP oFunc = new cSP();

            cMS oMsg = new cMS();
            cDatabase oDatabase;
            StringBuilder oSql;
            int nConTme, nCmdTme;
            DataTable oTblComp;
            try
            {
                // Confuguration database.
                nConTme = 0;
                oFunc.SP_DATxGetConfigurationFromMem<int>(out nConTme, cCS.nCS_ConTme, paoSysConfig, "002");
                nCmdTme = 0;
                oFunc.SP_DATxGetConfigurationFromMem<int>(out nCmdTme, cCS.nCS_CmdTme, paoSysConfig, "003");
                oDatabase = new cDatabase(nConTme);

                oSql = new StringBuilder();
                oSql.Clear();
                oSql.AppendLine("SELECT TOP 1 FTCmpCode FROM TCNMComp WITH (NOLOCK)");
                oTblComp = oDatabase.C_DAToSqlQuery(oSql.ToString(), nCmdTme);

                if (!(oTblComp.Rows.Count >= 0))
                {
                    poIsOnlineErr = new cmlResIsOnline();
                    ptErrCode = cMS.tMS_RespCode905;
                    ptErrDesc = cMS.tMS_RespDesc905;
                    return false;
                }

                ptErrCode = "";
                ptErrDesc = "";
                poIsOnlineErr = null;
                return true;
            }
            catch (Exception oEx)
            {
                poIsOnlineErr = new cmlResIsOnline();
                ptErrCode = cMS.tMS_RespCode900;
                ptErrDesc = cMS.tMS_RespDesc900;
                return false;
            }
            finally
            {
                oFunc = null;
                oMsg = null;
                oDatabase = null;
                oSql = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                oTblComp = null;
            }
        }

    }
}
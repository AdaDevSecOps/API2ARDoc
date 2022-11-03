using API2ARDoc.Models;
using API2ARDoc.Models.Database;
using Standard;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data.SqlClient;
using Dapper;
using System.Runtime.Caching;

namespace API2ARDoc.Class.Standard
{
    public class cSP
    {
        /// <summary>
        ///     Get configuration from memory.
        /// </summary>
        /// 
        /// <typeparam name="T">Type data user value.</typeparam>
        /// <param name="poUsrValue">ref Data user value.</param>
        /// <param name="poDefValue">Default data user value.</param>
        /// <param name="paoSysConfig">Valiable TSysConfig in memory.</param>
        /// <param name="ptSysSeq">Sequence.</param>
        public void SP_DATxGetConfigurationFromMem<T>(out T poUsrValue, T poDefValue, List<cmlTSysConfig> paoSysConfig, string ptSysSeq)
        {
            try
            {
                // UsrValue.
                try
                {
                    poUsrValue = (T)Convert.ChangeType(paoSysConfig.Where(
                        oItem => string.Equals(oItem.FTSysSeq, ptSysSeq)).Select(oItem => oItem.FTSysUsrValue).FirstOrDefault(), typeof(T));
                }
                catch (Exception)
                {
                    poUsrValue = poDefValue;
                }
            }
            catch (Exception)
            {
                poUsrValue = poDefValue;
            }
        }


        /// <summary>
        ///     Check key API.
        /// </summary>
        /// 
        /// <param name="ptKeyApi">ref Key API.</param>
        /// <param name="ptFuncName">Function name.</param>
        /// <param name="poHttpContext">HttpContext.</param>
        /// 
        /// <returns>
        ///     true : Verify key API pass.
        ///     false : Verify key API false.
        /// </returns>
        public bool SP_CHKbKeyApi(out string ptKeyApi, List<cmlTSysConfig> paoSysConfig, HttpContext poHttpContext)
        {
            cDatabase oDatabase;
            cCacheFunc oCacheFunc;

            StringBuilder oSql;

            //*Ton 64-05-20
            //NameValueCollection oReqHeaders;
            IHeaderDictionary oReqHeaders;

            string tKeyApi;
            int nConTme, nCmdTme;

            try
            {
                oReqHeaders = poHttpContext.Request.Headers;
                //*Ton 64-05-18
                //tKeyApi = oReqHeaders.Get("X-Api-Key");
                tKeyApi = oReqHeaders["X-Api-Key"];

                //tAgnPwd = oReqHeaders.Get("AgencyPwd");

                // ถ้ามี Key Api ส่งมาใน Header
                if (!string.IsNullOrEmpty(tKeyApi))
                {
                    oCacheFunc = new cCacheFunc();

                    //tCacheKey = tKeyApi + "|" + ptFuncName;

                    if (oCacheFunc.C_CAHbExistsKey(tKeyApi))
                    {
                        // ถ้ามี key อยุ่ใน cache
                        ptKeyApi = tKeyApi;
                        return oCacheFunc.C_CAHoGetKey<bool>(tKeyApi);
                    }

                    // ถ้าไม่มี key อยู่ใน cache
                    oSql = new StringBuilder();
                    oSql.AppendLine("SELECT FTAgnKeyAPI");
                    oSql.AppendLine("FROM TCNMAgency WITH(NOLOCK)");
                    oSql.AppendLine("WHERE FTAgnKeyAPI = '" + tKeyApi + "'");
                    oSql.AppendLine("AND FTAgnStaApv = '1'");
                    oSql.AppendLine("AND FTAgnStaActive = '1'");

                    SP_DATxGetConfigurationFromMem<int>(out nConTme, cCS.nCS_ConTme, paoSysConfig, "1");
                    SP_DATxGetConfigurationFromMem<int>(out nCmdTme, cCS.nCS_CmdTme, paoSysConfig, "2");

                    oDatabase = new cDatabase(nConTme, nCmdTme);
                    //tKeyApi = oDatabase.C_DAToSqlQuery<string>(oSql.ToString());
                    Guid oKeyApi = oDatabase.C_DAToSqlQuery<Guid>(oSql.ToString());
                    tKeyApi = oKeyApi.ToString();
                    if (string.IsNullOrEmpty(tKeyApi))
                    {
                        // ไม่มีข้อมูล KeyApi ในฐานข้อมูล หรือไม่อนุญาตให้ใช้งาน
                        ptKeyApi = "";
                        return false;
                    }

                    // เก็บ KeyApi ลง Cache
                    ptKeyApi = tKeyApi;
                    oCacheFunc.C_CAHxAddKey(ptKeyApi, true);
                    return true;
                }
            }
            catch (Exception)
            {
                ptKeyApi = "";
                return false;
            }
            finally
            {
                oCacheFunc = null;
                oReqHeaders = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            ptKeyApi = "";
            return false;
        }

        /// <summary>
        ///     Validate model.
        /// </summary>
        /// 
        /// <param name="ptModelErr">ref Error message.</param>
        /// <param name="poModelState">Parameter model.</param>
        /// 
        /// <returns>
        ///     true : validate pass.<br/>
        ///     false : validate false.
        /// </returns>
        public bool SP_CHKbParaModel(out string ptModelErr, ModelStateDictionary poModelState)
        {
            try
            {
                if (poModelState.IsValid)
                {
                    // Validate pass.
                    ptModelErr = "";
                    return true;
                }
                else
                {
                    // Validate false.
                    IEnumerable<string> atErrList = from oState in poModelState.Values
                                                    from oError in oState.Errors
                                                    where !string.IsNullOrEmpty(oError.ErrorMessage)
                                                    select oError.ErrorMessage;

                    ptModelErr = string.Join("|", atErrList);
                    return false;
                }
            }
            catch (Exception)
            {

            }

            ptModelErr = "";
            return false;
        }

        /// <summary>
        ///     Load configuration.
        /// </summary>
        /// 
        /// <returns>
        ///     Configuration.
        /// </returns>
        public List<cmlTSysConfig> SP_SYSaLoadConfiguration()
        {
            cDatabase oDatabase;
            cCacheFunc oCache;

            List<cmlTSysConfig> aoSysConfig;
            StringBuilder oSql;

            try
            {
                oCache = new cCacheFunc();

                // Check cache.
                if (oCache.C_CAHbExistsKey("TSysConfig"))
                {
                    aoSysConfig = oCache.C_CAHoGetKey<List<cmlTSysConfig>>("TSysConfig");
                }
                else
                {
                    oSql = new StringBuilder();
                    oSql.AppendLine("SELECT FTSysCode, FTSysSeq, FTSysUsrValue, FTSysUsrRef");
                    oSql.AppendLine("FROM TSysConfig WITH(NOLOCK)");
                    //oSql.AppendLine("WHERE FTSysCode = 'PApi2Master'");
                    oSql.AppendLine("WHERE FTSysCode = 'tCN_API2PSMaster'"); //*Em 62-05-30 AdaFC
                    oSql.AppendLine("ORDER BY FTSysSeq");

                    oDatabase = new cDatabase();
                    aoSysConfig = oDatabase.C_DATaSqlQuery<cmlTSysConfig>(oSql.ToString());

                    if (aoSysConfig != null && aoSysConfig.Count > 0)
                    {
                        // Add cache.
                        oCache.C_CAHxAddKey("TSysConfig", aoSysConfig);
                    }
                }

                return aoSysConfig;
            }
            catch (Exception)
            {

            }
            finally
            {
                oDatabase = null;
                oCache = null;
                oSql = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            return null;
        }

        /// <summary>
        /// *Arm 63-06-01
        /// </summary>
        /// <param name="ptEncryptedData"></param>
        /// <param name="ptKey"></param>
        /// <returns></returns>
        public static string SP_DATtTripleDESDecryptData(string ptEncryptedData, string ptKey)
        {
            TripleDESCryptoServiceProvider oTripleDESSrvPvd;
            MemoryStream oMemStm;
            CryptoStream oDecStm;
            byte[] anEncryptedBytes;
            string tStrDec;

            try
            {
                // Initialize the crypto provider.
                oTripleDESSrvPvd = new TripleDESCryptoServiceProvider();
                oTripleDESSrvPvd.Key = SP_DATaSHA1EncryptData(ptKey, (int)Math.Floor(oTripleDESSrvPvd.KeySize / 8.0));
                oTripleDESSrvPvd.IV = SP_DATaSHA1EncryptData("", (int)Math.Floor(oTripleDESSrvPvd.BlockSize / 8.0));

                // Convert the encrypted text string to a byte array.
                anEncryptedBytes = Convert.FromBase64String(ptEncryptedData);

                // Create the stream.
                oMemStm = new MemoryStream();

                // Create the encoder to write to the stream.
                oDecStm = new CryptoStream(oMemStm, oTripleDESSrvPvd.CreateDecryptor(), CryptoStreamMode.Write);

                // Use the crypto stream to write the byte array to the stream.
                oDecStm.Write(anEncryptedBytes, 0, anEncryptedBytes.Length);
                oDecStm.FlushFinalBlock();

                // Convert the encrypted stream to a printable string.
                tStrDec = Encoding.Unicode.GetString(oMemStm.ToArray());
                return tStrDec;
            }
            catch (Exception)
            {

            }
            finally
            {
                oTripleDESSrvPvd = null;
                oMemStm = null;
                oDecStm = null;
                anEncryptedBytes = null;
                tStrDec = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            return "";
        }

        /// <summary>
        /// *Arm 63-06-01
        /// </summary>
        /// <param name="ptPlaintext"></param>
        /// <param name="pnHashSize"></param>
        /// <returns></returns>
        public static byte[] SP_DATaSHA1EncryptData(string ptPlaintext, int pnHashSize)
        {
            SHA1CryptoServiceProvider oSHA1SrvPvd;
            byte[] anPlaintextBytes, anHash, anTmpHash;

            try
            {
                // Hash the key.
                oSHA1SrvPvd = new SHA1CryptoServiceProvider();
                anPlaintextBytes = Encoding.Unicode.GetBytes(ptPlaintext);
                anHash = oSHA1SrvPvd.ComputeHash(anPlaintextBytes);

                // Truncate or pad the hash.
                anTmpHash = anHash;
                anHash = new byte[pnHashSize];
                Array.Copy(anTmpHash, anHash, Math.Min(anHash.Length, anTmpHash.Length));

                return anHash;
            }
            catch (Exception)
            {

            }
            finally
            {
                oSHA1SrvPvd = null;
                anPlaintextBytes = null;
                anHash = null;
                anTmpHash = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            return null;
        }






        // for Support Old API2ARDoc ก่อนปรับแก้ Standard
        #region Support
        public static List<T> C_GETaQuerytoListObj<T>(string ptSqlCmd)
        {
            List<T> aoItem = new List<T>();
            try
            {
                //using (SqlConnection oDbCon = new SqlConnection(cVB.tVB_CNDbConStr))
                //*Ton 64-05-20
                //using (SqlConnection oDbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["tConnDB"].ConnectionString.ToString()))
                using (SqlConnection oDbCon = new SqlConnection(cAppSetting.Default.tConnDB))
                {
                    oDbCon.Open();
                    aoItem = oDbCon.Query<T>(ptSqlCmd, commandTimeout: 30).ToList();

                    return aoItem;
                }
            }
            catch (Exception oEx)
            {
                cLog.C_SETxLogError($"cSP.{MethodBase.GetCurrentMethod().Name} - {oEx.Message}");
            }
            return null;
        }

        /// <summary>
        /// ดึงขึ้นมูลจากตาราง TARTSoHD โดย Where ด้วยข้อมูลจาก poReq
        /// </summary>
        /// <param name="poReq"></param>
        /// <returns></returns>
        public static List<cmlResSoHD> SP_GETtTARTSoHD(cmlReqData poReq)
        {
            string tQueryHD = "SELECT [FTBchCode],[FTXshDocNo],[FTShpCode],[FNXshDocType]" +
                ", CONVERT(varchar, [FDXshDocDate], 120) [FDXshDocDate],[FTXshCshOrCrd]" +
                ",[FTXshVATInOrEx],[FTDptCode],[FTWahCode],[FTPosCode],[FTShfCode]" +
                ",[FNSdtSeqNo],[FTUsrCode],[FTSpnCode],[FTXshApvCode],[FTCstCode]" +
                ",[FTXshDocVatFull],[FTXshRefExt],CONVERT(varchar, [FDXshRefExtDate],120) [FDXshRefExtDate]" +
                ",[FTXshRefInt],CONVERT(varchar, [FDXshRefIntDate],120) [FDXshRefIntDate]" +
                ",[FTXshRefAE],[FNXshDocPrint],[FTRteCode],[FCXshRteFac],[FCXshTotal]" +
                ",[FCXshTotalNV],[FCXshTotalNoDis],[FCXshTotalB4DisChgV],[FCXshTotalB4DisChgNV]" +
                ",[FTXshDisChgTxt],[FCXshDis],[FCXshChg],[FCXshTotalAfDisChgV],[FCXshTotalAfDisChgNV]" +
                ",[FCXshRefAEAmt],[FCXshAmtV],[FCXshAmtNV],[FCXshVat],[FCXshVatable],[FTXshWpCode]" +
                ",[FCXshWpTax],[FCXshGrand],[FCXshRnd],[FTXshGndText],[FCXshPaid],[FCXshLeft]" +
                ",[FTXshRmk],[FTXshStaRefund],[FTXshStaDoc],[FTXshStaApv],[FTXshStaPrcDoc]" +
                ",[FTXshStaPaid],[FNXshStaDocAct],[FNXshStaRef]" +
                ",CONVERT(varchar, [FDLastUpdOn],120) [FDLastUpdOn],[FTLastUpdBy]" +
                ",CONVERT(varchar, [FDCreateOn],120) [FDCreateOn],[FTCreateBy]" +
                " FROM [dbo].[TARTSoHD]" +
                $" WHERE [FTBchCode]='{poReq.tFTBchCode}' AND [FTXshDocNo]='{poReq.tFTXshDocNo}'" +
                $" AND [FTShpCode]='{poReq.tFTShpCode}' AND [FNXshDocType]='{poReq.tFTXshDocType}'";
            List<cmlResSoHD> oReturn = C_GETaQuerytoListObj<cmlResSoHD>(tQueryHD);
            if (oReturn == null)
                oReturn = new List<cmlResSoHD>();
            return oReturn;
        }

        /// <summary>
        /// ดึงขึ้นมูลจากตาราง TARTSoDT โดย Where ด้วยข้อมูลจาก poReq
        /// </summary>
        /// <param name="poReq"></param>
        /// <returns></returns>
        public static List<cmlResSoDT> SP_GETtTARTSoDT(cmlReqData poReq)
        {
            string tQuery = "SELECT [FTBchCode],[FTXshDocNo],[FNXsdSeqNo],[FTPdtCode],[FTXsdPdtName]" +
                ",[FTPunCode],[FTPunName],[FCXsdFactor],[FTXsdBarCode],[FTSrnCode]" +
                ",[FTXsdVatType],[FTVatCode],[FCXsdVatRate],[FTXsdSaleType],[FCXsdSalePrice]" +
                ",[FCXsdQty],[FCXsdQtyAll],[FCXsdSetPrice],[FCXsdAmtB4DisChg],[FTXsdDisChgTxt]" +
                ",[FCXsdDis],[FCXsdChg],[FCXsdNet],[FCXsdNetAfHD],[FCXsdVat]" +
                ",[FCXsdVatable],[FCXsdWhtAmt],[FTXsdWhtCode],[FCXsdWhtRate],[FCXsdCostIn]" +
                ",[FCXsdCostEx],[FTXsdStaPdt],[FCXsdQtyLef],[FCXsdQtyRfn],[FTXsdStaPrcStk]" +
                ",[FTXsdStaAlwDis],[FNXsdPdtLevel],[FTXsdPdtParent],[FCXsdQtySet],[FTPdtStaSet]" +
                ",[FTXsdRmk], CONVERT(varchar, [FDLastUpdOn], 120) [FDLastUpdOn],[FTLastUpdBy]" +
                ",CONVERT(varchar, [FDCreateOn],120) [FDCreateOn],[FTCreateBy]" +
                " FROM [dbo].[TARTSoDT]" +
                $" WHERE [FTBchCode]='{poReq.tFTBchCode}' AND [FTXshDocNo]='{poReq.tFTXshDocNo}'";

            List<cmlResSoDT> oReturn = C_GETaQuerytoListObj<cmlResSoDT>(tQuery);
            if (oReturn == null)
                oReturn = new List<cmlResSoDT>();
            return oReturn;
        }

        /// <summary>
        /// ดึงขึ้นมูลจากตาราง TARTSoHDCst โดย Where ด้วยข้อมูลจาก poReq
        /// </summary>
        /// <param name="poReq"></param>
        /// <returns></returns>
        public static List<cmlResSoHDCst> SP_GETtTARTSoHDCst(cmlReqData poReq)
        {
            string tQuery = "SELECT [FTBchCode],[FTXshDocNo],[FTXshCardID],[FTXshCardNo],[FNXshCrTerm]" +
                ", CONVERT(varchar, [FDXshDueDate], 120) [FDXshDueDate]" +
                ",CONVERT(varchar, [FDXshBillDue],120) [FDXshBillDue]" +
                ",[FTXshCtrName],CONVERT(varchar, [FDXshTnfDate],120) [FDXshTnfDate]" +
                ",[FTXshRefTnfID],[FNXshAddrShip],[FNXshAddrTax]" +
                " FROM [dbo].[TARTSoHDCst]" +
                $" WHERE [FTBchCode]='{poReq.tFTBchCode}' AND [FTXshDocNo]='{poReq.tFTXshDocNo}'";


            List<cmlResSoHDCst> oReturn = C_GETaQuerytoListObj<cmlResSoHDCst>(tQuery);
            if (oReturn == null)
                oReturn = new List<cmlResSoHDCst>();
            return oReturn;
        }

        /// <summary>
        /// ดึงขึ้นมูลจากตาราง TARTSoHDDis โดย Where ด้วยข้อมูลจาก poReq
        /// </summary>
        /// <param name="poReq"></param>
        /// <returns></returns>
        public static List<cmlResSoHDDis> SP_GETtTARTSoHDDis(cmlReqData poReq)
        {
            string tQuery = "SELECT [FTBchCode],[FTXshDocNo],CONVERT(varchar, [FDXhdDateIns],120) [FDXhdDateIns]" +
                ",[FTXhdDisChgTxt],[FTXhdDisChgType],[FCXhdTotalAfDisChg],[FCXhdDisChg],[FCXhdAmt]" +
                " FROM [dbo].[TARTSoHDDis]" +
                $" WHERE [FTBchCode]='{poReq.tFTBchCode}' AND [FTXshDocNo]='{poReq.tFTXshDocNo}'";


            List<cmlResSoHDDis> oReturn = C_GETaQuerytoListObj<cmlResSoHDDis>(tQuery);
            if (oReturn == null)
                oReturn = new List<cmlResSoHDDis>();
            return oReturn;
        }

        /// <summary>
        /// ดึงขึ้นมูลจากตาราง TARTSoDTDis โดย Where ด้วยข้อมูลจาก poReq
        /// </summary>
        /// <param name="poReq"></param>
        /// <returns></returns>
        public static List<cmlResSoDTDis> SP_GETtTARTSoDTDis(cmlReqData poReq)
        {
            string tQuery = "SELECT [FTBchCode],[FTXshDocNo],[FNXsdSeqNo]" +
                ", CONVERT(varchar, [FDXddDateIns], 120) [FDXddDateIns],[FNXddStaDis]" +
                ",[FTXddDisChgTxt],[FTXddDisChgType],[FCXddNet],[FCXddValue]" +
                " FROM [dbo].[TARTSoDTDis]" +
                $" WHERE [FTBchCode]='{poReq.tFTBchCode}' AND [FTXshDocNo]='{poReq.tFTXshDocNo}'";


            List<cmlResSoDTDis> oReturn = C_GETaQuerytoListObj<cmlResSoDTDis>(tQuery);
            if (oReturn == null)
                oReturn = new List<cmlResSoDTDis>();
            return oReturn;
        }

        /// <summary>
        /// Check API Key 
        /// </summary>
        /// <param name="poHttpContext"></param>
        /// <param name="ptErrAPI"></param>
        /// <returns></returns>
        public static bool SP_CHKbKeyApi(HttpContext poHttpContext, out string ptErrAPI)
        {
            //*Ton 64-05-20
            //NameValueCollection oReqHeaders;
            IHeaderDictionary oReqHeaders;

            string tClientAPIKey, tConfigAPIKey;
            cDatabase oDatabase;
            StringBuilder oSQL;
            var oCache = MemoryCache.Default;
            var oCM_cachePolicty = new CacheItemPolicy();
            try
            {
                //oDatabase = new cDatabase(cConfig.tDB_ConnStr);
                oDatabase = new cDatabase();    //*Arm 63-02-18 - ปรับ Standard ใหม่ 
                oSQL = new StringBuilder();
                tConfigAPIKey = "";

                oCM_cachePolicty.AbsoluteExpiration = DateTime.Now.AddHours(1);

                oReqHeaders = poHttpContext.Request.Headers;
                //*Ton 64-05-20
                //tClientAPIKey = oReqHeaders.Get("X-Api-Key");
                tClientAPIKey = oReqHeaders["X-Api-Key"];

                // Get Config API Key
                if (oCache.Get("cache_API") == null)
                {
                    oSQL.AppendLine("SELECT ISNULL(FTSysStaUsrValue,'') AS FTSysStaUsrValue ");
                    oSQL.AppendLine("FROM  TSysConfig WITH (NOLOCK) WHERE FTSysKey='POS' AND FTSysSeq='1' AND FTSysCode='tCN_AgnKeyAPI'");
                    //tConfigAPIKey = (string)oDatabase.C_GEToQueryScalarObj(oSQL.ToString());
                    tConfigAPIKey = oDatabase.C_GETtSQLScalarString(oSQL.ToString()); //*Arm 63-02-18 - ปรับ Standard ใหม่ 


                    if (tConfigAPIKey == "-1" || tConfigAPIKey == null)
                    {
                        ptErrAPI = tConfigAPIKey;
                        return false;
                    }
                    oCache.Set("cache_API", tConfigAPIKey, oCM_cachePolicty);
                }
                else
                {
                    tConfigAPIKey = (string)oCache.Get("cache_API");
                }

                if (tConfigAPIKey == "")
                {
                    ptErrAPI = "";
                    return false;
                }

                if (tClientAPIKey != tConfigAPIKey)
                {
                    ptErrAPI = "";
                    return false;
                }

                ptErrAPI = "";
                return true;
            }
            catch (Exception)
            {
                ptErrAPI = "";
                return false;
            }
            finally
            {
                oSQL = null;
                oCache = null;
                oCM_cachePolicty = null;
                oDatabase = null;
                oReqHeaders = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        #endregion end
    }
}
using API2ARDoc.Class.Standard;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace API2ARDoc.Class
{
    public class cDatabase
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// 
        /// <param name="pnConTme">Connection time out.</param>
        public cDatabase(int pnConTme = cCS.nCS_ConTme, int pnCmdTme = cCS.nCS_CmdTme)
        {
            
        }


        /// <summary>
        /// SqlConnection
        /// </summary>
        /// <returns></returns>
        public SqlConnection C_CONoDatabase()
        {
            SqlConnection oConn = null;
            //string tConnString;
            try
            {
                //*Ton 64-05-20
                //oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["tConnDB"].ConnectionString.ToString());
                oConn = new SqlConnection(cAppSetting.Default.tConnDB);
                oConn.Open();
            }
            catch (Exception oEx)
            {
                throw oEx;
            }

            return oConn;
        }

        /// <summary>
        ///     Execute sql command insert, update, delete etc.
        /// </summary>
        /// 
        /// <param name="ptSqlCmd">Sql command.</param>
        /// <param name="pnCmdTme">Execute command time out.</param>
        /// 
        /// <returns>
        ///     Row effect of command.
        /// </returns>
        public int C_DATnExecuteSql(string ptSqlCmd, int pnCmdTme = cCS.nCS_CmdTme)
        {
            int nRowEff = 0;
            SqlConnection oConn;
            try
            {
                oConn = C_CONoDatabase();
                nRowEff = oConn.Execute(ptSqlCmd, pnCmdTme);
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                oConn = null;
            }

            return nRowEff;
        }

        /// <summary>
        ///     Query sql command.
        /// </summary>
        /// 
        /// <typeparam name="T">Type return.</typeparam>
        /// <param name="ptSqlCmd">Sql command.</param>
        /// <param name="pnCmdTme">Execute command time out.</param>
        /// 
        /// <returns>
        ///     Result of sql command in list of class model.
        /// </returns>
        public List<T> C_DATaSqlQuery<T>(string ptSqlCmd, int pnCmdTme = cCS.nCS_CmdTme)
        {
            SqlConnection oConn;
            try
            {
                List<T> aoResult = new List<T>();

                oConn = C_CONoDatabase();
                aoResult = oConn.Query<T>(ptSqlCmd, null, null, true, pnCmdTme).ToList();

                return aoResult;
            }
            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                oConn = null;
            }
        }

        /// <summary>
        ///     Query sql command.
        /// </summary>
        /// 
        /// <typeparam name="T">Type return.</typeparam>
        /// <param name="ptSqlCmd">Sql command.</param>
        /// <param name="pnCmdTme">Execute command time out.</param>
        /// 
        /// <returns>
        ///     Result of sql command in class model.
        /// </returns>
        public T C_DAToSqlQuery<T>(string ptSqlCmd, int pnCmdTme = cCS.nCS_CmdTme)
        {
            SqlConnection oConn;
            try
            {
                T oResult = default(T);

                oConn = C_CONoDatabase();
                oResult = oConn.Query<T>(ptSqlCmd, null, null, true, pnCmdTme).FirstOrDefault();

                return oResult;
            }

            catch (Exception oEx)
            {
                throw oEx;
            }
            finally
            {
                oConn = null;
            }
        }

        /// <summary>
        ///     Query sql command.
        /// </summary>
        /// 
        /// <param name="ptSqlCmd">Sql command.</param>
        /// <param name="pnCmdTme">Execute command time out.</param>
        /// <param name="ptTblName">Table name.</param>
        /// 
        /// <returns>
        ///     Result of sql command in DataTable.
        /// </returns>
        public DataTable C_DAToSqlQuery(string ptSqlCmd, int pnCmdTme = cCS.nCS_CmdTme, string ptTblName = "TableTemp")
        {
            DataTable oDbTblResult = new DataTable();
            SqlConnection oConn;
            try
            {
                oConn = C_CONoDatabase();
                IDataReader oDR = oConn.ExecuteReader(ptSqlCmd, pnCmdTme);
                oDbTblResult.Load(oDR);

            }
            catch (Exception oExn)
            {
                throw oExn;
            }
            finally
            {
                oConn = null;
            }

            return oDbTblResult;
        }

        /// <summary>
        /// Query get data type string
        /// </summary>
        /// <param name="ptSql"></param>
        /// <returns>string</returns>
        public string C_GETtSQLScalarString(string ptSql)
        {
            SqlConnection oConn = new SqlConnection();
            SqlCommand oCmd = new SqlCommand();
            SqlDataAdapter oDbAdt = new SqlDataAdapter();
            DataTable oDbTbl = new DataTable();
            string tResult = "";
            try
            {
                try
                {
                    if (oConn.State == ConnectionState.Open)
                    {
                        oConn.Close();
                        //*Ton 64-05-20
                        //oConn.ConnectionString = ConfigurationManager.ConnectionStrings["tConnDB"].ConnectionString;
                        oConn.ConnectionString = cAppSetting.Default.tConnDB;
                        oConn.Open();
                    }
                    else
                    {
                        //*Ton 64-05-20
                        //oConn.ConnectionString = ConfigurationManager.ConnectionStrings["tConnDB"].ConnectionString;
                        oConn.ConnectionString = cAppSetting.Default.tConnDB;
                        oConn.Open();
                    }
                }
                catch { }
                oCmd = new SqlCommand(ptSql, oConn);
                var oResult = oCmd.ExecuteScalar();
                tResult = oResult == null ? "" : oResult.ToString();
            }
            catch (Exception oEx)
            {
                tResult = "-1";
            }
            finally
            {
                oConn.Close();
                oConn = null;
                oCmd = null;
                oDbAdt = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return tResult;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API2ARDoc.Class.Standard
{
    public class cMS
    {
        //*Arm 63-02-19 [ปรับ Standrad]
        //****************************************************


        //# Response code.
        //****************************************************
        //sucess.
        public const string tMS_RespCode001 = "001";
        //Parameter.
        public const string tMS_RespCode700 = "700";
        public const string tMS_RespCode710 = "710";
        public const string tMS_RespCode701 = "701";
        //Data.
        public const string tMS_RespCode800 = "800";
        public const string tMS_RespCode801 = "801";
        public const string tMS_RespCode802 = "802";
        //System.
        public const string tMS_RespCode900 = "900";
        public const string tMS_RespCode903 = "903";
        public const string tMS_RespCode904 = "904";
        public const string tMS_RespCode905 = "905";
        public const string tMS_RespCode907 = "907";

        //****************************************************



        //#Response descript.
        //****************************************************
        //sucess.
        public const string tMS_RespDesc001 = "success.";
        //Parameter.
        public const string tMS_RespDesc700 = "all parameter is null.";
        public const string tMS_RespDesc701 = "validate parameter model false.|";
        //Data.
        public const string tMS_RespDesc800 = "data not found.";
        public const string tMS_RespDesc801 = "Card Date expired";
        public const string tMS_RespDesc802 = "Product received.";
        //System.
        public const string tMS_RespDesc900 = "service process false.";
        public const string tMS_RespDesc903 = "validate parameter encrypt false.";
        public const string tMS_RespDesc904 = "key not allowed to use method.";
        public const string tMS_RespDesc905 = "cannot connect database.";
        public const string tMS_RespDesc907 = "cannot connect server MQ";

        //****************************************************
    }
}
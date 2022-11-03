using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2ARDoc.Models
{
    public class cmlAppSetting
    {
        public string tName { get; set; }
        public string tRQHost { get; set; }
        public string tRQUsr { get; set; }
        public string tRQPwd { get; set; }
        public string tRQVirtual { get; set; }
        public string tAccess { get; set; }
        public string tConnDB { get; set; }
        public string tRedisIpAddress { get; set; }
    }
}

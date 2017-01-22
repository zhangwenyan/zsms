using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace config
{
    public class Config
    {
        public static String databaseType = ConfigurationManager.AppSettings["databaseType"] ?? "mysql";
        public static String connstr = ConfigurationManager.AppSettings["connstr"] ?? "server=127.0.0.1;database=smsdb;Persist Security Info=False;uid=root;pwd=youotech";
        
        /// <summary>
        /// 发送短信间隔
        /// </summary>
        public static int sendSmsInv = int.Parse(ConfigurationManager.AppSettings["sendSmsInv"] ?? "1000");

        /// <summary>
        /// 自动开始服务
        /// </summary>
        public static bool autoStartService = bool.Parse(ConfigurationManager.AppSettings["autoStartService"] ?? "true");


    }
}

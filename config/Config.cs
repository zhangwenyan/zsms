using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using YouoUtil;
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




        public static String smsTool = ConfigurationManager.AppSettings["smsTool"];


        public static String at_portName = null;
        public static int at_bandRate = 0;


        public static String aliDayu_smsFreeSignName = null;
        public static String aliDayu_smsTemplateCode = null;
        public static String alidayu_url = null;
        public static String alidayu_appkey = null;
        public static String alidayu_secret = null;
        public static List<dynamic> smsTemplateList = null;

        public static bool inited = init();


        public static bool init()
        {
            String str = FileUtil.FileToString("zsms.setting");
            var dy = JsonConvert.DeserializeObject<dynamic>(str);
            smsTool = dy.smsTool;
            var aliDayu = dy.aliDayu;
            aliDayu_smsFreeSignName = aliDayu.smsFreeSignName;
            aliDayu_smsTemplateCode = aliDayu.smsTemplateCode;
            alidayu_url = aliDayu.alidayu_url;
            alidayu_appkey = aliDayu.alidayu_appkey;
            alidayu_secret = aliDayu.alidayu_secret;

            smsTemplateList = new List<dynamic>();
            for (var i=0;i< aliDayu.smsTemplateList.Count; i++)
            {
                smsTemplateList.Add(aliDayu.smsTemplateList[i]);
            }


            var at = dy.at;
            at_portName = at.portName;
            at_bandRate = at.bandRate;


            return true;
        }

        



    }
}

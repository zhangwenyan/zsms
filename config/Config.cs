using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ZUtil;
namespace config
{
    public class Config
    {

        public static bool justOne = bool.Parse(ConfigurationManager.AppSettings["justOne"] ?? "true");
        public static String zsmsSetting  = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"zsms.setting";
        public static String databaseType = ConfigurationManager.AppSettings["databaseType"];
        public static String connstr = ConfigurationManager.AppSettings["connstr"];
        
        /// <summary>
        /// 发送短信间隔
        /// </summary>
        public static int sendSmsInv = int.Parse(ConfigurationManager.AppSettings["sendSmsInv"] ?? "1000");

        /// <summary>
        /// 自动开始服务
        /// </summary>
        public static bool autoStartService = bool.Parse(ConfigurationManager.AppSettings["autoStartService"] ?? "true");


        public static bool autoMinimize = bool.Parse(ConfigurationManager.AppSettings["autoMinimize"] ?? "false");




        public static String smsTool = null;
        public static int errorWaitTime = 0;//失败等待时间
        public static int tryCount = 0;//尝试次数

        public static String modem_portName = null;
        public static int modem_bandRate = 0;
        public static bool modem_smsRecover = false;


        public static String aliDayu_smsFreeSignName = null;
        public static String aliDayu_smsTemplateCode = null;
        public static String alidayu_url = null;
        public static String alidayu_appkey = null;
        public static String alidayu_secret = null;
        public static List<dynamic> smsTemplateList = null;



        public static String aliyuncs_smsFreeSignName = null;
        public static String aliyuncs_smsTemplateCode = null;
        public static String aliyuncs_url = null;
        public static String aliyuncs_appkey = null;
        public static String aliyuncs_secret = null;
        public static List<dynamic> aliyuncs_smsTemplateList = null;



        public static String zProxy_url = null;
        public static String zProxy_secret = null;


        public static bool inited = init();


        public static bool init()
        {
            if (!FileUtil.IsExistFile(zsmsSetting))
            {
                return false;
            }

            String str = FileUtil.FileToString(zsmsSetting);

            var dy = JsonConvert.DeserializeObject<dynamic>(str);

            if (String.IsNullOrEmpty(databaseType))
            {
                databaseType = dy.databaseType;
            }
            if (String.IsNullOrEmpty(connstr))
            {
                connstr = dy.connStr;
            }



            smsTool = dy.smsTool;
            errorWaitTime = dy.errorWaitTime;
            tryCount = dy.tryCount;
            var aliDayu = dy.smsTools.aliDayu;
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


            var aliyuncs = dy.smsTools.aliyuncs;
            aliyuncs_smsFreeSignName = aliyuncs.smsFreeSignName;
            aliyuncs_smsTemplateCode = aliyuncs.smsTemplateCode;
            aliyuncs_appkey = aliyuncs.appkey;
            aliyuncs_secret = aliyuncs.secret;

            aliyuncs_smsTemplateList = new List<dynamic>();
            for(var i = 0; i < aliyuncs.smsTemplateList.Count; i++)
            {
                aliyuncs_smsTemplateList.Add(aliyuncs.smsTemplateList[i]);
            }



            var modem = dy.smsTools.modem;
            modem_portName = modem.portName;
            modem_bandRate = modem.bandRate;
            modem_smsRecover = modem.smsRecover;


            var zProxy = dy.smsTools.zProxy;
            zProxy_url = zProxy.url;
            zProxy_secret = zProxy.secret;
            

            return true;
        }

        



    }
}

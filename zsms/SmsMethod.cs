using config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsms
{
    public class SmsMethod
    {
        private static BaseSmsTool smsTool;

        public static void sendSms(String mbno,String msg)
        {

            if (smsTool == null)
            {
                switch (Config.smsTool.ToLower())
                {
                    case "alidayu":
                        List<SmsTemplate> stList = new List<SmsTemplate>();
                        foreach (dynamic template in Config.smsTemplateList)
                        {
                            stList.Add(new SmsTemplate()
                            {
                                code = template.code,
                                content = template.content,
                            });
                        }
                        smsTool = new SmsTool_Alidayu(Config.aliDayu_smsFreeSignName, Config.aliDayu_smsTemplateCode, Config.alidayu_url, Config.alidayu_appkey, Config.alidayu_secret, stList);
                        break;
                    case "aliyuncs":
                        List<SmsTemplate> stList0 = new List<SmsTemplate>();
                        foreach (dynamic template in Config.aliyuncs_smsTemplateList)
                        {
                            stList0.Add(new SmsTemplate()
                            {
                                code = template.code,
                                content = template.content,
                            });
                        }
                        smsTool = new SmsTool_Aliyuncs(Config.aliyuncs_smsFreeSignName, Config.aliyuncs_smsTemplateCode, Config.aliyuncs_url, Config.aliyuncs_appkey, Config.aliyuncs_secret, stList0);
                        break;
                    case "modem":
                        smsTool = new SmsTool_AT(Config.modem_portName, Config.modem_bandRate, Config.modem_smsRecover);
                        break;
                    case "zproxy":
                        smsTool = new SmsTool_ZProxy(Config.zProxy_url, Config.zProxy_secret);
                        break;
                        //case "plugin":
                        //    smsTool = new PluginSmsTool.PluginSmsTool();
                        //    break;
                         
                }
                if (smsTool == null)
                {
                    throw new Exception("unknow smsTool:" + Config.smsTool);
                }

            }

            smsTool.sendSms(new ESms()
            {
                Mbno = mbno,
                Msg = msg
            });

        }
    }
}

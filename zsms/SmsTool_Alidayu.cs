﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace zsms
{
    /// <summary>
    /// 模板
    /// </summary>
    public class SmsTemplate
    {
        public String code { get; set; }
        public String content { get; set; }
    }
    /// <summary>
    /// 阿里大于短信平台短信工具
    /// </summary>
    public class SmsTool_Alidayu : BaseSmsTool
    {
        private String SmsFreeSignName;//签名
        private String SmsTemplateCode;//基本模板编号
        private String alidayu_url;
        private String alidayu_appkey;
        private String alidayu_secret;

        //模板列表
        private List<SmsTemplate> smsTemplateList = new List<SmsTemplate>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SmsFreeSignName">签名</param>
        /// <param name="SmsTemplateCode">模板编号</param>
        /// <param name="alidayu_url">阿里云api地址:http://gw.api.taobao.com/router/rest</param>
        /// <param name="alidayu_appkey">appey</param>
        /// <param name="alidayu_secret">secret</param>
        public SmsTool_Alidayu(String SmsFreeSignName,String SmsTemplateCode,String alidayu_url,String alidayu_appkey,String alidayu_secret)
        {
            this.SmsFreeSignName = SmsFreeSignName;
            this.SmsTemplateCode = SmsTemplateCode;
            this.alidayu_url = alidayu_url;
            this.alidayu_appkey = alidayu_appkey;
            this.alidayu_secret = alidayu_secret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SmsFreeSignName">签名</param>
        /// <param name="SmsTemplateCode">模板编号</param>
        /// <param name="alidayu_url">阿里云api地址:http://gw.api.taobao.com/router/rest</param>
        /// <param name="alidayu_appkey">appey</param>
        /// <param name="alidayu_secret">secret</param>
        /// <param name="smsTemplateList">模板list</param>
        public SmsTool_Alidayu(String SmsFreeSignName, String SmsTemplateCode, String alidayu_url, String alidayu_appkey, String alidayu_secret,List<SmsTemplate> smsTemplateList)
        {
            this.SmsFreeSignName = SmsFreeSignName;
            this.SmsTemplateCode = SmsTemplateCode;
            this.alidayu_url = alidayu_url;
            this.alidayu_appkey = alidayu_appkey;
            this.alidayu_secret = alidayu_secret;
            this.smsTemplateList = smsTemplateList;
        }

        public override event DGRSms onSmsRecover;
        public override void Dispose()
        {
            this.isDispose = true;
        }

        public override string getMsg()
        {
            return "阿里大于短信平台";
        }

        public override void init()
        {
            
        }

        public override void sendSms(ESms esms)
        {
            ITopClient client = new DefaultTopClient(alidayu_url, alidayu_appkey, alidayu_secret, "json");
            AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
            req.SmsType = "normal";
            req.SmsFreeSignName = this.SmsFreeSignName;


            String smsTemplateCode = null;
            String smsParam = null;


            #region 匹配模板

            try
            {
                foreach (var smsTemplate in smsTemplateList)
                {
                    String regStr = Regex.Replace(smsTemplate.content, @"\$\{[a-z0-9]+\}", "(.{0,15})");
                    Regex reg = new Regex(regStr);
                    var m = reg.Match(esms.Msg);
                    if (m.Success)
                    {

                        Regex reg2 = new Regex(@"\$\{([a-z0-9]+)\}");
                        var ms = reg2.Matches(smsTemplate.content);
                        Dictionary<String, string> map = new Dictionary<string, string>();
                        for (var j = 0; j < ms.Count; j++)
                        {
                            var t_m = ms[j];
                            map.Add(t_m.Groups[1].Value, m.Groups[j + 1].Value);
                        }

                        smsTemplateCode = smsTemplate.code;
                        smsParam = Newtonsoft.Json.JsonConvert.SerializeObject(map);
                    }
                }
            }catch(Exception ex)
            {
                Console.Write("代码有缺陷,匹配模板时出错:"+ex.Message);
            }

            #endregion 匹配模板


            if(smsTemplateCode == null)
            {//使用基本模板
                smsTemplateCode = SmsTemplateCode;
                smsParam = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    msg = esms.Msg
                });
            }


            if(smsTemplateCode==null || smsParam == null)
            {
                throw new Exception("短信内容没有匹配的模板");
            }


            req.SmsParam = smsParam;
            req.RecNum = esms.Mbno;
            req.SmsTemplateCode = smsTemplateCode;
            AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);

            if(rsp.Result == null || !rsp.Result.Success)
            {
                throw new Exception("发送失败:"+ rsp.SubErrMsg);
            }
        }
    }
}

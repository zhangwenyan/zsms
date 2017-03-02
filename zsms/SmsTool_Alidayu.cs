using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


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
        private String smsFreeSignName;//签名
        private String smsTemplateCode;//基本模板编号
        private String alidayu_url;
        private String alidayu_appkey;
        private String alidayu_secret;

        //模板列表
        private List<SmsTemplate> smsTemplateList = new List<SmsTemplate>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smsFreeSignName">签名</param>
        /// <param name="smsTemplateCode">模板编号</param>
        /// <param name="alidayu_url">阿里云api地址:http://gw.api.taobao.com/router/rest</param>
        /// <param name="alidayu_appkey">appey</param>
        /// <param name="alidayu_secret">secret</param>
        public SmsTool_Alidayu(String smsFreeSignName, String smsTemplateCode, String alidayu_url, String alidayu_appkey, String alidayu_secret)
        {
            this.smsFreeSignName = smsFreeSignName;
            this.smsTemplateCode = smsTemplateCode;
            this.alidayu_url = alidayu_url;
            this.alidayu_appkey = alidayu_appkey;
            this.alidayu_secret = alidayu_secret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smsFreeSignName">签名</param>
        /// <param name="smsTemplateCode">模板编号</param>
        /// <param name="alidayu_url">阿里云api地址:http://gw.api.taobao.com/router/rest</param>
        /// <param name="alidayu_appkey">appey</param>
        /// <param name="alidayu_secret">secret</param>
        /// <param name="smsTemplateList">模板list</param>
        public SmsTool_Alidayu(String smsFreeSignName, String smsTemplateCode, String alidayu_url, String alidayu_appkey, String alidayu_secret, List<SmsTemplate> smsTemplateList)
        {
            this.smsFreeSignName = smsFreeSignName;
            this.smsTemplateCode = smsTemplateCode;
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


            String msg = esms.Msg.Replace(".", "．");
            String smsTemplateCode = null;
            String smsParam = null;


            #region 匹配模板

            try
            {
                foreach (var smsTemplate in smsTemplateList)
                {
                    String regStr = Regex.Replace(smsTemplate.content, @"\$\{[a-z0-9]+\}", "(.{0,15})");
                    regStr = regStr.Replace("[", "\\[");
                    regStr = regStr.Replace("]", "\\]");
                    regStr = regStr.Replace(".", "．");
                    Regex reg = new Regex("^" + regStr + "$");
                    var m = reg.Match(msg);
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
            }
            catch (Exception ex)
            {
                Console.Write("代码有缺陷,匹配模板时出错:" + ex.Message);
            }

            #endregion 匹配模板


            if (smsTemplateCode == null)
            {//使用基本模板
                smsTemplateCode = this.smsTemplateCode;
                smsParam = Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    msg = msg
                });
            }


            if (String.IsNullOrEmpty(smsTemplateCode) || smsParam == null)
            {
                throw new SmsErrorException("短信内容没有匹配的模板");
            }


            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("app_key", alidayu_appkey);
            dic.Add("format", "json");
            dic.Add("v", "2.0");
            dic.Add("method", "alibaba.aliqin.fc.sms.num.send");
            dic.Add("timestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            dic.Add("sign_method", "md5");


            dic.Add("sms_type", "normal");
            dic.Add("sms_free_sign_name", "" + this.smsFreeSignName);
            dic.Add("rec_num", esms.Mbno);
            dic.Add("sms_param", smsParam);
            dic.Add("sms_template_code", smsTemplateCode);

            dic.Add("sign", SignTopRequest(dic, this.alidayu_secret, "md5"));
            String postStr = "";
            foreach (var d in dic)
            {
                if (postStr != "")
                {
                    postStr += "&";
                }
                postStr += d.Key + "=" + System.Web.HttpUtility.UrlEncode(d.Value);
            }

            var rr = ZUtil.HttpUtil.doPost(this.alidayu_url, postStr);

            var rdy = Newtonsoft.Json.JsonConvert.DeserializeObject<SmsRs>(rr);

            if (rdy.alibaba_aliqin_fc_sms_num_send_response != null && rdy.alibaba_aliqin_fc_sms_num_send_response.result.success)
            {
                return;
            }
            else if (rdy.error_response != null && rdy.error_response.sub_msg != null)
            {
                throw new Exception(rdy.error_response.sub_msg);
            }
            else
            {
                throw new Exception("失败");
            }

        
        }
        public static string SignTopRequest(IDictionary<string, string> parameters, string secret, string signMethod)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder();
            //if (Constants.SIGN_METHOD_MD5.Equals(signMethod))
            //{
            //    query.Append(secret);
            //}
            query.Append(secret);
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(value);
                }
            }

            // 第三步：使用MD5/HMAC加密
            byte[] bytes;
            //if (Constants.SIGN_METHOD_HMAC.Equals(signMethod))
            //{
            //    HMACMD5 hmac = new HMACMD5(Encoding.UTF8.GetBytes(secret));
            //    bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            //}
            //else
            //{
            query.Append(secret);
            MD5 md5 = MD5.Create();
            bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            // }

            // 第四步：把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
    class SmsRs
    {
        public R alibaba_aliqin_fc_sms_num_send_response { get; set; }
        public Error_response error_response { get; set; }

    }
    class Error_response
    {
        public String code { get; set; }
        public String msg { get; set; }
        public String sub_msg { get; set; }

    }
    class R
    {
        public Result result { get; set; }
    }
    class Result
    {
        public bool success { get; set; }

    }

}
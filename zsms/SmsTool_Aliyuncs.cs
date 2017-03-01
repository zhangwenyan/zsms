using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ZUtil;

namespace zsms
{
    public class SmsTool_Aliyuncs:BaseSmsTool
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
        public SmsTool_Aliyuncs(String smsFreeSignName, String smsTemplateCode, String alidayu_url, String alidayu_appkey, String alidayu_secret)
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
        public SmsTool_Aliyuncs(String smsFreeSignName, String smsTemplateCode, String alidayu_url, String alidayu_appkey, String alidayu_secret, List<SmsTemplate> smsTemplateList)
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
            return "阿里云os短信平台";
        }

        public override void init()
        {

        }

        public override void sendSms(ESms esms)
        {

            String smsTemplateCode = null;
            String smsParam = null;
            #region 匹配模板
            try
            {
                foreach (var smsTemplate in smsTemplateList)
                {
                    String regStr = Regex.Replace(smsTemplate.content, @"\$\{[a-z0-9]+\}", "(.{0,15})");
                    Regex reg = new Regex("^"+regStr+"$");
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
                    msg = esms.Msg
                });
            }


            if (String.IsNullOrEmpty(smsTemplateCode) || smsParam == null)
            {
                throw new SmsErrorException("短信内容没有匹配的模板");
            }

            Dictionary<String, String> dic = new Dictionary<string, string>();
            dic.Add("AccessKeyId", this.alidayu_appkey);
            dic.Add("Action", "SingleSendSms");
            dic.Add("Format", "JSON");
            dic.Add("ParamString", smsParam);
            dic.Add("RecNum", esms.Mbno);
            dic.Add("SignName", this.smsFreeSignName);
            dic.Add("SignatureMethod", "HMAC-SHA1");
            dic.Add("SignatureNonce", Guid.NewGuid().ToString());
            dic.Add("SignatureVersion", "1.0");
            dic.Add("TemplateCode", smsTemplateCode);
            dic.Add("Timestamp", DateTime.Now.AddHours(-8).ToString("yyyy-MM-ddTHH:mm:ssZ"));
            dic.Add("Version", "2016-09-27");
            dic.Add("Signature", hsh(dic, this.alidayu_secret));

            var qu = toQueryString(dic);
            String url = "http://sms.aliyuncs.com";
            var str0 = HttpUtil.doPost(url, qu);
            var t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str0);
            if (String.IsNullOrEmpty(t.RequestId))
            {
                //出错
                if (!String.IsNullOrEmpty(t.Message))
                {
                    throw new Exception(t.Message);
                }
                throw new Exception("error");
            }

        }
        private class T
        {
            public String Message { get; set; }
            public String RequestId { get; set; }
        }

        private static string toQueryString(Dictionary<String, String> dic)
        {
            // IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(dic, StringComparer.Ordinal);
            // IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();
            // // 第二步：把所有参数名和参数值串在一起
            String postStr = "";
            foreach (var d in dic)
            {
                string key = d.Key;
                string value = d.Value;
                if (postStr != "")
                {
                    postStr += "&";
                }
                postStr += key + "=" + UrlEncode(value);
            }
            return postStr;

        }

        private static String hsh(Dictionary<String, String> parameters, String skey)
        {
            StringBuilder query = new StringBuilder("POST&%2F&");
            foreach (var d in parameters)
            {
                string key = d.Key;
                string value = d.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    var temp = UrlEncode((query.Length == 9 ? "" : "&") + key + "=" + UrlEncode(value));
                    query.Append(temp);
                }
            }
            String tmp = query.ToString();
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = System.Text.Encoding.UTF8.GetBytes(skey + "&");
            byte[] dataBuffer = System.Text.Encoding.UTF8.GetBytes(query.ToString());
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);
        }

        private static string UrlEncode(string temp)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < temp.Length; i++)
            {
                string t = temp[i].ToString();
                string k = HttpUtility.UrlEncode(t, Encoding.UTF8);
                if (t == k)
                {
                    stringBuilder.Append(t);
                }
                else {
                    stringBuilder.Append(k.ToUpper());
                }
            }
            return stringBuilder.ToString();
        }


    }
}

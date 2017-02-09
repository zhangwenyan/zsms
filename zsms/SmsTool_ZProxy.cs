using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ZUtil;

namespace zsms
{
    public class SmsTool_ZProxy : BaseSmsTool
    {
        private String url;
        private String secret;
        public SmsTool_ZProxy(String url,String secret)
        {
            this.url = url;
            this.secret = secret;
        }

        public override event DGRSms onSmsRecover;

        public override void Dispose()
        {
        }

        public override string getMsg()
        {
            return "z代理";
        }

        public override void init()
        {
            
        }

        public override void sendSms(ESms esms)
        {

            String postStr = "secret=" + HttpUtility.UrlEncode(this.secret) + "&mbno=" + esms.Mbno + "&msg=" + HttpUtility.UrlEncode(esms.Msg);
            var r = HttpUtil.doPost(this.url,postStr);
            dynamic dy = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(r);
            if (dy.success != true)
            {
                throw new Exception(dy.msg.ToString());
            }
        }
    }
}

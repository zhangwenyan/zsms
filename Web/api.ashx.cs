using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using ZUtil;
using Newtonsoft.Json;

namespace Web
{
    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var secret = context.Request["secret"];
            var mbno = context.Request["mbno"];
            var msg = context.Request["msg"];

            try
            {

                if (secret != "admin@888888")
                {
                    throw new Exception("验证失败");
                }

                service.SmsMethod.sendSms(mbno, msg);
                context.Response.ContentType = "text/json";
                context.Response.Write("{\"success\":true}");
            }
            catch(Exception ex)
            {
                context.Response.ContentType = "text/json";
                context.Response.Write(JsonConvert.SerializeObject(new { success = false, msg = ex.Message }));
            }

       

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
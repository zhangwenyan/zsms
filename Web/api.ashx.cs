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

        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void ProcessRequest(HttpContext context)
        {
            Log.Info("api接口有请求----");



            var secret = context.Request["secret"];
            var mbno = context.Request["mbno"];
            var msg = context.Request["msg"];


            Log.Info("mbno:" + mbno + ",msg:" + msg+",secret:"+secret);
            Log.Info("----");


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
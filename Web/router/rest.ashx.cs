using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ZUtil;
namespace Web.router
{
    /// <summary>
    /// rest 的摘要说明
    /// </summary>
    public class rest : IHttpHandler
    {


        public void ProcessRequest(HttpContext context)
        {
            //兼容旧的模式

                var mbno = context.Request["rec_num"];
                var sms_param = context.Request["sms_param"];
                String msg = JsonConvert.DeserializeObject<dynamic>(sms_param).msg;

                try
                {
                    service.SmsMethod.sendSms(mbno, msg);
                    context.Response.ContentType = "text/json";
                    context.Response.Write("{\"success\":true}");
                }
                catch (Exception ex)
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
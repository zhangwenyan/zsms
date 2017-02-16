using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;

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

            if (secret != "admin@888888")
            {
                context.Response.Write("{\"success\":false,\"msg\":\"验证失败\"}");
                return;
            }

            DalFactory.createSms_OutBoxDal().add(new Sms_OutBoxModel()
            {
                mbno = mbno,
                msg = msg
            });

            context.Response.ContentType = "text/plain";
            context.Response.Write("{\"success\":true}");
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
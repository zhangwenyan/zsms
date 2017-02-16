using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace Web.service
{
    public abstract class BaseService: IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            object result = null;
            try
            {
                var action = context.Request["action"];
                Type curType = GetType();
                MethodInfo method = curType.GetMethod(action, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if (method == null)
                {
                    throw new MsgException("该方法尚未实现");
                }


                var ps0 = method.GetParameters();
                var ps = new object[ps0.Length];
                for (var i = 0; i < ps.Length; i++)
                {
                    var p = ps0[i];
                    var type = p.ParameterType;
                    if (type.Equals(typeof(HttpContext)))
                    {
                        ps[i] = context;
                        continue;
                    }



                    String valueStr = context.Request[p.Name];

                    if (type.Equals(typeof(String)))
                    {
                        ps[i] = valueStr;
                    }
                    else
                    {
                        ps[i] = null;
                    }
                }
                result = method.Invoke(this, ps);
                if (result == null && method.ReturnType == typeof(void))
                {
                    result = new { success = true };
                }
            }
            catch (HttpRequestValidationException)
            {
                var r = new Dictionary<string, object>();
                r.Add("success", false);
                r.Add("error", true);
                r.Add("msg", "输入的字符串不能包含危险字符串,例如尖括号");
                result = r;
            }
            catch (Exception ex)
            {
                var r = new Dictionary<String, object>();
                r.Add("success", false);
                r.Add("error", true);
                if(ex is MsgException)
                {
                    r.Add("msg", ex.Message);
                }
                else
                {
                    r.Add("msg", "系统错误");
                }
                result = r;
            }
            finally
            {
                String str = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                context.Response.ContentType = "text/json";
                context.Response.Write(str);
            }


        }

    }
}
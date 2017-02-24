using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.SessionState;
using Dal;
using Model;
using easysql;
namespace Web.service
{
    public abstract class BaseService<T>: IHttpHandler where T : new()
    {
        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected PageInfo<T> requestPageInfo(HttpContext context)
        {
            PageInfo<T> pi = new PageInfo<T>();
            pi.page = int.Parse(context.Request["page"] ?? "1");
            pi.rows = int.Parse(context.Request["rows"] ?? "20");
            pi.query = requestModel(context);
            String tmp = context.Request["startTime"];
            if (!string.IsNullOrEmpty(tmp))
            {
                pi.startTime = DateTime.Parse(tmp);
            }
            tmp = context.Request["endTime"];
            if (!string.IsNullOrEmpty(tmp))
            {
                pi.endTime = DateTime.Parse(tmp);
            }
            return pi;
        }

    

        /// <summary>
        /// 返回当前表单里面的bean
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected T requestModel(HttpContext context)
        {
            T bean = Activator.CreateInstance<T>();
            Type type = typeof(T);
            PropertyInfo[] pis = type.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                string name = pi.Name;
                Type pType = pi.PropertyType;

                if (pType.Equals(typeof(String)))
                {
                    // var a = 
                    string valuestr = context.Request.Form[name];
                    if (valuestr != null)
                    {
                        pi.SetValue(bean, valuestr, null);
                    }
                }
                else if (pType.Equals(typeof(int?)) || pType.Equals(typeof(int)))
                {
                    var valueintstr = context.Request[name];
                    if (!string.IsNullOrEmpty(valueintstr))
                    {
                        pi.SetValue(bean, int.Parse(valueintstr), null);
                    }
                }
                else if (pType.Equals(typeof(long?)) || pType.Equals(typeof(long)))
                {
                    var valuelongstr = context.Request[name];
                    if (!string.IsNullOrEmpty(valuelongstr))
                    {
                        pi.SetValue(bean, long.Parse(valuelongstr), null);
                    }
                }

                else if (pi.PropertyType.Equals(typeof(DateTime?)) || pi.PropertyType.Equals(typeof(DateTime)))
                {
                    string valuestr = context.Request[name];
                    if (!string.IsNullOrEmpty(valuestr))
                    {
                        pi.SetValue(bean, DateTime.Parse(valuestr), null);
                    }
                }
                else if (pi.PropertyType.Equals(typeof(bool?)) || pi.PropertyType.Equals(typeof(bool)))
                {
                    string valuestr = context.Request[name];
                    if (!string.IsNullOrEmpty(valuestr))
                    {
                        pi.SetValue(bean, bool.Parse(valuestr), null);
                    }
                }

            }

            return bean;
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
                    }
                    else if (type.Equals(typeof(T)))
                    {
                        ps[i] = requestModel(context);
                    }
                    else if (type.Equals(typeof(PageInfo<T>)))
                    {
                        ps[i] = requestPageInfo(context);
                    }
                    else
                    {
                        String valueStr = context.Request[p.Name];
                        if (type.Equals(typeof(String)))
                        {
                            ps[i] = valueStr;
                        }
                        else
                        {
                            throw new Exception("无法判断的参数类型");
                        }
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
                if (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

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

                Log.Error("BaseService error", ex);
            }
            finally
            {
                String str = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                context.Response.ContentType = "text/json";
                context.Response.Write(str);
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
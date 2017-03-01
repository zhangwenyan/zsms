using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eweb.controller;
using Model;
using eweb.ex;
using Dal;
namespace Web.controller
{
    public class UserController:BaseController<UserModel>
    {

        public void login(String username,String password,HttpContext context)
        {
            if(username=="admin" && password == "youotech")
            {
                context.Session.Add("user", new { nickname="管理员" });
            }
            else
            {
                throw new MsgException("用户名或密码错误");
            }
        }
        public object getLoginUser(HttpContext context)
        {
            if (context.Session["user"] == null)
            {
                return new
                {
                    nickname = "游客"
                };
            }

            return new
            {
                nickname="管理员"
            };
        }

        public void logout(HttpContext context)
        {
            context.Session.Remove("user");
            context.Response.Redirect("/page/home/Login.html");
        }
      

    }
}
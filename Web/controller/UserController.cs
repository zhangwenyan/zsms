using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eweb.controller;
using Model;
using eweb.ex;
using Dal;
using eweb.attribute;

namespace Web.controller
{
    public class UserController:BaseController<UserModel>
    {
        private UserDal dal = new UserDal();
        public void login(String username,String password,HttpContext context)
        {
            var userModel = dal.queryByUsername(username);
            if (userModel == null)
            {
                throw new MsgException("用户名不存在");
            }

            if(userModel.status != USERSTATUS.NORMAL)
            {
                throw new MsgException("用户当前状态不能登录");
            }
            if (!userModel.password.Equals(password))
            {
                throw new MsgException("用户名或密码错误");
            }
            context.Session.Add("user", userModel);
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

            UserModel um = (UserModel)context.Session["user"];
            return new
            {
                nickname= um.nickname
            };
        }


        public void logout(HttpContext context)
        {
            context.Session.Remove("user");
            context.Response.Redirect("/page/home/Login.html");
        }
      

    }
}
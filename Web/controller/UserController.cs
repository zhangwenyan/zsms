using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Dal;
using eweb;
using easysql;

namespace Web.controller
{
    public class UserController:BaseController<UserModel>
    {
        private UserDal dal = new UserDal();

        public object queryPage(PageInfo<UserModel> pi)
        {

            return dal.queryPage(pi);
        }


        [CheckLogin]
        public void add(UserModel model)
        {
            dal.addOnly(model, "用户名已经存在", Restrain.Eq("username", model.username));
        }
        [CheckLogin]
        public void modify(UserModel model)
        {
            model.username = null;//禁止修改用户名
            dal.modify(model);
        }
        [CheckLogin]
        public void del(String ids)
        {
            dal.del(ids);
        }

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
        [CheckLogin]
        public object getLoginUser(HttpContext context)
        {
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
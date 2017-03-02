using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using eweb.attribute;

namespace Web.controller
{
    public class MenuController
    {
        private MenuDal dal = new MenuDal();
        [CheckLogin]
        public object myMenuTree(HttpContext context)
        {
            UserModel um = (UserModel)context.Session["user"];
            return dal.queryMenuByUserId(um.id);
        }
    }
}
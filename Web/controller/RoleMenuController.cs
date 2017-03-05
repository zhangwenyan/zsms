using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using easysql;
namespace Web.controller
{
    public class RoleMenuController
    {
        private RoleMenuDal dal = new RoleMenuDal();

        //使用页面,权限管理,根据权限id获取联系
        public object queryByRoleId(int roleId)
        {
            return dal.queryByRoleId(roleId);
        }
        public void save(int roleId,String menuIds)
        {
            dal.save(roleId, menuIds);
        }
    }
}
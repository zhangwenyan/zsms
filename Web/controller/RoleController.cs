using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using easysql;

namespace Web.controller
{
    public class RoleController
    {
        private RoleDal dal = new RoleDal();
        public object tree()
        {
            return dal.tree();
        }

        public void add(RoleModel model)
        {
            dal.addOnly(model, "已存在相同名称角色", Restrain.Eq("name", model.name));
        }
        public void modify(RoleModel model)
        {
            dal.modifyOnly(model, "已存在相同名称角色", Restrain.Eq("name", model.name));
        }

        public void delById(int id)
        {
            dal.del(id.ToString());
        }
    }
}
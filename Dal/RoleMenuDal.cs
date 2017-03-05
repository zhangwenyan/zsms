using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using easysql;
using Model;
namespace Dal
{
    public class RoleMenuDal : BaseDal<RoleMenuModel>
    {
        public object queryByRoleId(int roleId)
        {
            return dh.Query<RoleMenuModel>(tbName, null, Restrain.Eq("roleId", roleId));
        }

        public void save(int roleId, string menuIds)
        {
            using(BaseDatabase db = dh.CreateDatabaseAndOpen())
            {
                db.BeginTransaction();
                try
                {
                    db.Del(tbName, new RoleMenuModel()
                    {
                        roleId = roleId
                    });
                    foreach(var menuId in menuIds.Split(','))
                    {
                        RoleMenuModel model = new RoleMenuModel();
                        model.roleId = roleId;
                        model.menuId = int.Parse(menuId);
                        db.Add<RoleMenuModel>(tbName, model);
                    }

                    db.CommitTranscation();
                }catch(Exception ex)
                {
                    db.RollbackTranscation();
                }

            }
        }
    }
}

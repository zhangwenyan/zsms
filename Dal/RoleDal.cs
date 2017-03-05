using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
namespace Dal
{
    public class RoleDal : BaseDal<RoleModel>
    {
        public object tree()
        {
            return dh.Query<RoleModel>(tbName, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
namespace Dal
{
    public class MenuDal:BaseDal<MenuModel>
    {
        public List<MenuModel> queryMenuByUserId(int userid)
        {
            var sql = @"
                SELECT * FROM menu WHERE id IN (
	
	                SELECT menuId FROM roleMenu WHERE roleId IN (
	
		                SELECT roleId FROM userRole WHERE userId={0}
	                )
                )
            ";

            return dh.QueryBySql<MenuModel>(sql, userid);
        }

        public object tree()
        {
            return dh.Query<MenuModel>(tbName, null);
        }
    }
}

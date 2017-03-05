using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
using eweb;

namespace Dal
{
    public class UserDal:BaseDal<UserModel>
    {
        public UserModel queryByUsername(String username)
        {
            return dh.Query<UserModel>(tbName, null, Restrain.Eq("username", username)).FirstOrDefault();
        }
        public override PageResultInfo queryPage(PageInfo<UserModel> pi, params Restrain[] restrains)
        {
            int total = 0;
            var list = queryPage(pi.query, pi.page, pi.rows, out total, restrains);
            list.ForEach(m =>
            {
                m.password = null;
            });
            return new PageResultInfo()
            {
                total = total,
                rows = list
            };
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
namespace Dal
{
    public class UserDal:BaseDal<UserModel>
    {
        public UserModel queryByUsername(String username)
        {
            return dh.Query<UserModel>(tbName, null, Restrain.Eq("username", username)).FirstOrDefault();
        }

    }
}

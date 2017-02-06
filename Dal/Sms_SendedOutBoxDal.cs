using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
namespace Dal
{
    public class Sms_SendedOutBoxDal:BaseDal<Sms_SendedOutBoxModel>
    {
        public Sms_SendedOutBoxDal() : base("SendedOutBox")
        {

        }

        public List<Sms_SendedOutBoxModel> queryByPage(int page, int rows, out int total)
        {
            return dh.QueryByPage<Sms_SendedOutBoxModel>(tbname, null, page, rows, out total,Restrain.OrderDesc("SendTime"));
        }
    }
}

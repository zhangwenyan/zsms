using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;

namespace Dal
{
    public class Sms_BadOutBoxDal:BaseDal<Sms_BadOutBoxModel>
    {
        public Sms_BadOutBoxDal() : base("badoutbox") { }

        public List<Sms_BadOutBoxModel> queryByPage(int page, int rows, out int total)
        {
            return dh.QueryByPage<Sms_BadOutBoxModel>(tbname, null, page, rows, out total,Restrain.OrderDesc("SendTime"));
        }
    }
}

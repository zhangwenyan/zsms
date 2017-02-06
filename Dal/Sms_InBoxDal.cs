using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
namespace Dal
{
    public class Sms_InBoxDal:BaseDal<Sms_InBoxModel>
    {
        public Sms_InBoxDal() : base("inbox") { }


        public void add(Sms_InBoxModel model)
        {
            dh.Add(tbname, model);
        }

        public List<Sms_InBoxModel> queryByPage(int page, int rows, out int total)
        {

            return dh.QueryByPage<Sms_InBoxModel>(tbname, null, page, rows, out total,Restrain.OrderDesc("ArriveTime"));
        }
    }
}

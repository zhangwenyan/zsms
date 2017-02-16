using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Dal;
using easysql;
namespace Web.service
{
    /// <summary>
    /// Sms_OutBoxService 的摘要说明
    /// </summary>
    public class Sms_OutBoxService : BaseService<Sms_OutBoxModel>
    {
        private Sms_OutBoxDal dal = DalFactory.createSms_OutBoxDal();

        public object queryPage(PageInfo<Sms_OutBoxModel> pi)
        {
            int total = 0;
            var list = dal.queryPage(pi.query, pi.page, pi.rows, out total,Restrain.Order("SendTime"));
            return new
            {
                total = total,
                rows = list
            };
        }

        public void add(Sms_OutBoxModel model)
        {
            dal.add(model);
        }
        public void modify(Sms_OutBoxModel model)
        {
            dal.modify(model);
        }
        public void del(String ids)
        {
            dal.del(ids);
        }

    }
}
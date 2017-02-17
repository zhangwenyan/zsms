using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using easysql;
namespace Web.service
{
    /// <summary>
    /// Sms_BadOutBoxService 的摘要说明
    /// </summary>
    public class Sms_BadOutBoxService : BaseService<Sms_BadOutBoxModel>
    {
        private Sms_BadOutBoxDal dal = DalFactory.createSms_BadOutBoxDal();

        public object queryPage(PageInfo<Sms_BadOutBoxModel> pi)
        {
            return dal.queryPage(pi, Restrain.OrderDesc("sendTime"));
        }

        public void del(String ids)
        {
            dal.del(ids);
        }
   
    }
}
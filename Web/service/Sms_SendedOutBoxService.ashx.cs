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
    /// Sms_SendedOutBoxService 的摘要说明
    /// </summary>
    public class Sms_SendedOutBoxService : BaseService<Sms_SendedOutBoxModel>
    {
        private Sms_SendedOutBoxDal dal = DalFactory.createSms_SendedOutBoxDal();
        public object queryPage(PageInfo<Sms_SendedOutBoxModel> pi)
        {
            return dal.queryPage(pi, Restrain.OrderDesc("SendTime"));
        }
        public void del(String ids)
        {
            dal.del(ids);
        }
      
    }
}
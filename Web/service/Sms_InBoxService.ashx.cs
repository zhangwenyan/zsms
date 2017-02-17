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
    /// Sms_InBoxService 的摘要说明
    /// </summary>
    public class Sms_InBoxService : BaseService<Sms_InBoxModel>
    {
        private Sms_InBoxDal dal = DalFactory.createSms_InBoxDal();
        public object queryPage(PageInfo<Sms_InBoxModel> pi)
        {
            return dal.queryPage(pi, Restrain.OrderDesc("ArriveTime"));
        }

    }
}
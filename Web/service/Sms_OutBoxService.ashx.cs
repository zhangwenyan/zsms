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
            return dal.queryPage(pi, Restrain.Order("SendTime"));
        }

        public void add(Sms_OutBoxModel model)
        {
            if (ZUtil.SmsUtil.smsSendWay == "db")
            {
                dal.add(model);
            }
            else
            {
                service.SmsMethod.sendSms(model.mbno, model.msg);
            }

            
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
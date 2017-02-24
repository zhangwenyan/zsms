using Dal;
using eweb.info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using easysql;
using Model;
using Web.service;

namespace Web.controller
{
    public class Sms_OutBoxController
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
                try
                {
                    SmsMethod.sendSms(model.mbno, model.msg);
                }
                catch (Exception ex)
                {
                    throw new MsgException(ex.Message);
                }
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
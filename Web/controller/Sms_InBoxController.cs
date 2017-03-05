using Dal;
using easysql;
using eweb;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.controller
{
    public class Sms_InBoxController
    {
        private Sms_InBoxDal dal = DalFactory.createSms_InBoxDal();
        public object queryPage(PageInfo<Sms_InBoxModel> pi)
        {
            return dal.queryPage(pi, Restrain.OrderDesc("ArriveTime"));
        }
    }
}
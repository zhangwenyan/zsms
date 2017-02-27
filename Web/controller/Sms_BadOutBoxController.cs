using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Dal;
using eweb.info;
using easysql;
using eweb.attribute;

namespace Web.controller
{
    public class Sms_BadOutBoxController
    {
        private Sms_BadOutBoxDal dal = DalFactory.createSms_BadOutBoxDal();

        public object queryPage(PageInfo<Sms_BadOutBoxModel> pi)
        {
            return dal.queryPage(pi, Restrain.OrderDesc("sendTime"));
        }
        [Login]
        public void del(String ids)
        {
            dal.del(ids);
        }
    }
}
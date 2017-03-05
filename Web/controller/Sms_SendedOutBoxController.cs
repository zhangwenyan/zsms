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
    public class Sms_SendedOutBoxController
    {
        private Sms_SendedOutBoxDal dal = DalFactory.createSms_SendedOutBoxDal();
        public object queryPage(PageInfo<Sms_SendedOutBoxModel> pi,String mbnoName)
        {
            return dal.queryPage(pi, mbnoName);
        }
        [CheckLogin]
        public void del(String ids)
        {
            dal.del(ids);
        }
    }
}
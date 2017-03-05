using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using Dal;
using easysql;
using eweb;

namespace Web.controller
{
    public class Sms_BadOutBoxController
    {
        private Sms_BadOutBoxDal dal = DalFactory.createSms_BadOutBoxDal();

        public object queryPage(PageInfo<Sms_BadOutBoxModel> pi,String mbnoName)
        {
            return dal.queryPage(pi,mbnoName);
        }
        [CheckLogin]
        public void del(String ids)
        {
            dal.del(ids);
        }
    }
}
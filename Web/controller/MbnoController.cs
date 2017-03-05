using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using easysql;
using eweb;

namespace Web.controller
{
    public class MbnoController
    {
        private MbnoDal dal = new MbnoDal();
        public object queryPage(PageInfo<MbnoModel> pi)
        {
            return dal.queryPage(pi);
        }

        [CheckLogin]
        public void add(MbnoModel model)
        {
            dal.add(model);
        }
        [CheckLogin]
        public void modify(MbnoModel model)
        {
            dal.modify(model);
        }
        [CheckLogin]
        public void del(String ids)
        {
            dal.del(ids);
        }
    }
}
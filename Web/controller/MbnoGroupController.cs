using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
using eweb.attribute;
using eweb.info;

namespace Web.controller
{
    public class MbnoGroupController
    {
        private MbnoGroupDal dal = new MbnoGroupDal();
        public object queryPage(PageInfo<MbnoGroupModel> pi)
        {
            return dal.queryPage(pi);
        }

        [CheckLogin]
        public void add(MbnoGroupModel model)
        {
            dal.add(model);
        }
        [CheckLogin]
        public void modify(MbnoGroupModel model)
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
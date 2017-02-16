using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Model;
namespace Web.service
{
    /// <summary>
    /// Sms_BadOutBoxService 的摘要说明
    /// </summary>
    public class Sms_BadOutBoxService : BaseService
    {
        private Sms_BadOutBoxDal dal = DalFactory.createSms_BadOutBoxDal();
        public object queryPage()
        {
            int total = 0;
            var list = dal.queryByPage(1, 20, out total);

            return new
            {
                total = total,
                rows = list
            };
        }
        public void del(String ids)
        {

        }


   
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
namespace Dal
{
    public class Sms_InBoxDal:BaseDal<Sms_InBoxModel>
    {
        public Sms_InBoxDal() : base("inbox") { }



     
    }
}

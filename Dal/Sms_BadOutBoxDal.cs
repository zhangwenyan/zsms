using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;

namespace Dal
{
    public class Sms_BadOutBoxDal:BaseDal<Sms_BadOutBoxModel>
    {
        public Sms_BadOutBoxDal() : base("badoutbox") { }

       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class DalFactory
    {
        public static Sms_OutBoxDal createSms_OutBoxDal()
        {
            return new Sms_OutBoxDal();
        }
    }
}

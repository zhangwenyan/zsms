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

        public static Sms_InBoxDal createSms_InBoxDal()
        {
            return new Sms_InBoxDal();
        }

        public static Sms_SendedOutBoxDal createSms_SendedOutBoxDal()
        {
            return new Sms_SendedOutBoxDal();
        }

        public static Sms_BadOutBoxDal createSms_BadOutBoxDal()
        {
            return new Sms_BadOutBoxDal();
        }
    }
}

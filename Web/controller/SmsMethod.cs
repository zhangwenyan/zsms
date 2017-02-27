using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZUtil;

namespace Web.service
{
    public class SmsMethod
    {
        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void sendSms(String mbno, String msg)
        {

            Log.Debug("发送短信:" + mbno + "," + msg);
            try
            {
                SmsUtil.sendSms(mbno, msg);
                if (SmsUtil.smsSendWay != "db")
                {

                    Dal.DalFactory.createSms_SendedOutBoxDal().add(new Model.Sms_SendedOutBoxModel()
                    {
                        mbno = mbno,
                        msg = msg,
                        sendTime = DateTime.Now
                    });
                }

            }
            catch (Exception ex)
            {
                if (SmsUtil.smsSendWay != "db")
                {
                    Dal.DalFactory.createSms_BadOutBoxDal().add(new Model.Sms_BadOutBoxModel()
                    {
                        mbno = mbno,
                        msg = msg,
                        sendTime = DateTime.Now,
                        bad_why = ex.Message
                    });
                }
                throw ex;
            }
        }
    }
}
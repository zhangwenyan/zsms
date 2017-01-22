using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Dal;
using Model;
using easysql;
using zsms;
using config;
namespace service
{
    public class SmsServerThread : BaseThread
    {
        private Sms_OutBoxDal sms_OutBoxDal = DalFactory.createSms_OutBoxDal();

        private BaseSmsTool smsTool = null;
        public SmsServerThread() : base("短信服务线程")
        {
            switch (Config.smsTool.ToLower())
            {
                case "alidayu":
                    List<SmsTemplate> stList = new List<SmsTemplate>();
                    foreach (dynamic template in Config.smsTemplateList)
                    {
                        stList.Add(new SmsTemplate()
                        {
                            code = template.code,
                            content = template.content,
                        });
                    }
                    smsTool = new SmsTool_Alidayu(Config.aliDayu_smsFreeSignName, Config.aliDayu_smsTemplateCode, Config.alidayu_url, Config.alidayu_appkey, Config.alidayu_secret, stList);
                    break;
                case "at":
                    smsTool = new SmsTool_AT(Config.at_portName, Config.at_bandRate);
                    break;
            }


                 smsTool.init();
        }
        public override void Dispose()
        {
            re0.Set();
            this.isDispose = true;
        }
        protected override void heartbeat()
        {
//            addMsg("心跳");
            Log.Debug("心跳");
            while (!isDispose)
            {
                int total = 0;
                var outBox = sms_OutBoxDal.queryTask(out total);
                if (outBox == null)
                {
                    break;
                }
                    addMsg("开始发送短信:" + outBox);
                try
                {
                    smsTool.sendSms(new ESms()
                    {
                        Id = outBox.Id,
                        Mbno = outBox.Mbno,
                        Msg = outBox.Msg
                    });
                    addMsg("发送短信(" + outBox + ")成功");
                    //将该短信从数据库里面转换为成功短信
                    sms_OutBoxDal.changeToSendedById(outBox.Id);
                }
                catch (Exception ex)
                {
                    addMsg("发送短信(" + outBox + ")失败,失败信息:" + ex.Message);
                    Log.Error("发送短信失败", ex);
                    sms_OutBoxDal.changeToBad(outBox.Id, ex.Message);
                }
                if (total > 1)
                {
                    //发送短信后如果还有短信,则暂停一会
                    re0.WaitOne(config.Config.sendSmsInv);
                }
            }


        }
    }
}

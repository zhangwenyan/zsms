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
        private Sms_InBoxDal sms_inBoxDal = DalFactory.createSms_InBoxDal();

        public void sendSms(ESms esms)
        {
            if (smsTool == null)
            {
                throw new Exception("找不到短信设备");
            }

            smsTool.sendSms(esms);
        }


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
                case "modem":
                    smsTool = new SmsTool_AT(Config.modem_portName, Config.modem_bandRate,Config.modem_smsRecover);
                    break;

            }


            if (smsTool == null)
            {
                throw new Exception("短信配置错误");
            }

            smsTool.onSmsRecover += onSmsRec;


        }
        private void onSmsRec(RSms rsms)
        {
            addMsg("接收到短信:" + rsms);

            sms_inBoxDal.add(new Sms_InBoxModel()
            {
                Mbno = rsms.Mbno,
                Msg = rsms.Msg,
                ArriveTime = rsms.DT
            });

        }

        public override BaseThread createRun()
        {
            while (!isDispose)
            {
                try
                {
                    smsTool.init();
                    addMsg(smsTool.getMsg());
                    break;
                }
                catch (Exception ex)
                {
                    Log.Error("短信设备初始化出错", ex);
                    addMsg("短信设备初始化出错:"+ex.Message);
                    re0.WaitOne(config.Config.errorWaitTime);
                }
            }
            if (isDispose)
            {
                throw new Exception("线程已销毁");
            }
            return base.createRun();
        }



        public override void Dispose()
        {
            re0.Set();
            this.isDispose = true;
            if (smsTool != null)
            {
                smsTool.Dispose();
            }
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

                    var i = 0;
                    var tryCount = Config.tryCount;
                    while (!isDispose)
                    {
                        i++;
                        try
                        {
                            smsTool.sendSms(new ESms()
                            {
                                Id = outBox.Id,
                                Mbno = outBox.Mbno,
                                Msg = outBox.Msg
                            });
                            break;
                        }
                        catch (Exception ex)
                        {
                            if (i >= tryCount)
                            {
                                throw ex;
                            }
                            else
                            {
                                addMsg("发送短信失败(" + i + "/" + tryCount + "),失败信息:"+ex.Message);
                                Log.Error("发送短信错误("+i+"/"+tryCount+")", ex);
                                re0.WaitOne(Config.errorWaitTime);
                            }
                        }
                    }
                    if (isDispose)
                    {
                        return;
                    }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using zsms;

namespace service
{

    public class Main:IDisposable
    {
        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<BaseThread> threadList = null;
        public event DGStr onMsg;


        public void addMsg(String str)
        {
            if (onMsg != null)
            {
                onMsg(str);
            }
        }

        public void Dispose()
        {
            if (threadList != null)
            {
                threadList.ForEach(th => {

                    try
                    {
                        th.Dispose();
                    }catch(Exception ex)
                    {
                        Log.Error("销毁线程("+th.Name+")出错", ex);
                    }
                });
            }
        }


        public void sendSms(ESms esms)
        {
            smsServerThread.sendSms(esms);
        }

        private SmsServerThread smsServerThread;


        public void start()
        {
            threadList = new List<BaseThread>();

            #region 启动短信线程
            smsServerThread = new SmsServerThread();
            smsServerThread.onMsg += onMsg;
            threadList.Add(smsServerThread);
            #endregion 启动短信线程

            threadList.ForEach(th =>
            {
               
                    new Thread(delegate ()
                    {
                        try
                        {
                            th.createRun();
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex);
                            addMsg(th.Name + "启动失败(" + ex.Message + ")");
                        }
                    }).Start();
             
            });
        }

       
    }
}

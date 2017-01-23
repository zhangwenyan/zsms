using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace service
{

    public class Main:IDisposable
    {
        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<BaseThread> threadList = null;
        public event DGStr onMsg;


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


        public void start()
        {
            threadList = new List<BaseThread>();

            #region 启动短信线程
            var smsServerThread = new SmsServerThread();
            smsServerThread.onMsg += onMsg;
            threadList.Add(smsServerThread);
            #endregion 启动短信线程

            threadList.ForEach(th =>
            {
                th.createRun();
            });
        }

       
    }
}

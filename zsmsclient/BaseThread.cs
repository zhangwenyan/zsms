using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace zsmsclient
{
    public abstract class BaseThread:IDisposable
    {
        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected Thread thread;


        private String name;
        public BaseThread(String name)
        {
            this.name = name;
        }
        
        public BaseThread createRun()
        {
            thread = new System.Threading.Thread(threadMethod);
            thread.Name = this.name;
            thread.IsBackground = true;
            thread.Start();
            Log.Debug(thread.Name + " 启动成功");
            return this;
        }
        public void threadMethod()
        {
            while (!isDispose)
            {
                try
                {
                    heartbeat();
                }
                catch (Exception ex)
                {
                    Log.Error(thread.Name, ex);
                }
                finally
                {
                    re0.WaitOne(1000 * 10);
                }
            }
        }
        protected abstract void heartbeat();
        protected bool isDispose;
        protected AutoResetEvent re0 = new AutoResetEvent(false);
        public abstract void Dispose();
    }
}

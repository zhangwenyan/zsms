using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace service
{
    public delegate void DGStr(String str);
    public abstract class BaseThread:IDisposable
    {

        public event DGStr onMsg;
        protected void addMsg(String str)
        {
            Log.Debug(str);
            if (onMsg != null)
            {
                onMsg(str);
            }
        }

        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected Thread thread;


        public String Name { get; set; }
        public BaseThread(String name)
        {
            this.Name = name;
        }
        
        public BaseThread createRun()
        {
            thread = new System.Threading.Thread(threadMethod);
            thread.Name = this.Name;
            thread.IsBackground = true;
            thread.Start();
            addMsg(thread.Name + " 启动成功");
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

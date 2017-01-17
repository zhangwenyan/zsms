using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace zsms
{
    public delegate void DGRSms(RSms sms);
    public delegate void DGStr(String str);
    public abstract class BaseSmsTool : IDisposable
    {
        protected bool isDispose;
        


        public abstract void sendSms(ESms esms);

        public abstract void init();
        public abstract String getMsg();

        public abstract event DGRSms onSmsRecover;


        public abstract void Dispose();
    }
}

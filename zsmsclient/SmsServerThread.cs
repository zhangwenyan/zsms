using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace zsmsclient
{
    public class SmsServerThread : BaseThread
    {
        public SmsServerThread() : base("短信服务线程")
        {

        }
        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        protected override void heartbeat()
        {
            throw new NotImplementedException();
        }
    }
}

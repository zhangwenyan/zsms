using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ZUtil.SmsUtil.sendSms("17681109309", "您好呀,今天天气晴朗");
        }
    }
}

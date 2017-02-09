using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsms
{
    class Ex
    {
    }

    public class SmsErrorException:Exception
    {
        public SmsErrorException(string msg) : base(msg)
        {

        }

    }
}

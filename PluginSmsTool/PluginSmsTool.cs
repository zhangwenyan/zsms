﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using zsms;

namespace PluginSmsTool
{
    public class PluginSmsTool : BaseSmsTool
    {
        public override event DGRSms onSmsRecover;

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public override string getMsg()
        {
            throw new NotImplementedException();
        }

        public override void init()
        {
            throw new NotImplementedException();
        }

        public override void sendSms(ESms esms)
        {
            throw new NotImplementedException();
        }
    }
}

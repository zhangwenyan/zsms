using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsms
{
    public enum RSmsType
    {
        接收短信,
        短信发送成功,
        短信发送失败
    }
    public class RSms
    {
        public int Id { get; set; }
        public String Mbno { get; set; }
        public String Msg { get; set; }
        public RSmsType Type { get; set; }
        public String BadWhy { get; set; }
        public DateTime DT { get; set; }

        public String V1 { get; set; }
        public String V2 { get; set; }
        public String V3 { get; set; }
        public String V4 { get; set; }


        public override string ToString()
        {
            return Mbno + ":" + Msg;
        }

    }
}

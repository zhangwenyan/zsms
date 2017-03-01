using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil.eweb.attribute;

namespace Model
{
    [Table(tbName ="InBox")]
    public class Sms_InBoxModel:BaseModel
    {
        public int id { set; get; }
        public string Username { get; set; }
        public string Mbno { set; get; }
        public string Msg { set; get; }
        public DateTime ArriveTime { set; get; }
        public bool Readed { get; set; }
        public int Comport { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eweb;

namespace Model
{
    [Table(tbName ="badOutBox")]
    public class Sms_BadOutBoxModel:BaseModel
    {
        public int id { set; get; }
        public string username { set; get; }
        public string mbno { set; get; }
        public string msg { set; get; }
        public DateTime sendTime { set; get; }
        public string bad_why { set; get; }
        public int comport { set; get; }
        public string v1 { set; get; }
        public string v2 { set; get; }
        public string v3 { set; get; }
        public string v4 { set; get; }
        public string v5 { set; get; }
    }
}

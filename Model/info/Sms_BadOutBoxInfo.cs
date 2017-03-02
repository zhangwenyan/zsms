using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.info
{
    public class Sms_BadOutBoxInfo
    {
        public int id { get; set; }
        public String mbno { get; set; }
        public String mbnoName { get; set; }
        public String msg { get; set; }
        public DateTime sendTime { get; set; }
    }
}

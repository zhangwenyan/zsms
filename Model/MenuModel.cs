using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil.eweb.attribute;

namespace Model
{
    [Table(tbName="menu")]
    public class MenuModel
    {
        public int id { get; set; }
        public String text { get; set; }
        public String url { get; set; }
        public String iconCls { get; set; }
        public String icon { get; set; }
        public int sequence { get; set; }
        public int pid { get; set; }
        public bool open { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil.eweb.attribute;

namespace Model
{
    [Table(tbName="mbno")]
    public class MbnoModel
    {
        public int id { get; set; }
        public String mbno { get; set; }
        public String name { get; set; }
    }
}

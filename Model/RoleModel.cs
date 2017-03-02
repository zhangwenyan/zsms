using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil.eweb.attribute;

namespace Model
{
    [Table(tbName="role")]
    public class RoleModel
    {
        public int id { get; set; }
        public String name { get; set; }
        public String icon { get; set; }
        public int pid { get; set; }
        public String comment { get; set; }

    }
}

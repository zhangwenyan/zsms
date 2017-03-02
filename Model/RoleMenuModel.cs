using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil.eweb.attribute;

namespace Model
{
    [Table(tbName="roleMenu")]
    public class RoleMenuModel
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public int menuId { get; set; }
    }
}

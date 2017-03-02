using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil.eweb.attribute;

namespace Model
{
    [Table(tbName="userRole")]
    public class UserRoleModel
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int roleId { get; set; }
    }
}

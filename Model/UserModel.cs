﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil.eweb.attribute;

namespace Model
{
    [Table(tbName ="user")]
    public class UserModel
    {
        public int id { get; set; }
        public String username { get; set; }
        public String password { get; set; }

    }
}

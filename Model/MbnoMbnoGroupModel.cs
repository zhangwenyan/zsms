﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eweb;

namespace Model
{
    [Table(tbName="mbnoMbnoGroup")]
    public class MbnoMbnoGroupModel
    {
        public int id { get; set; }
        public int mbnoId { get; set; }
          
        public int mbnoGroupId { get; set; }   
    }
}

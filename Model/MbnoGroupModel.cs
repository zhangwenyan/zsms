using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eweb;
namespace Model
{
    [Table(tbName="mbnoGroup")]
    public class MbnoGroupModel
    {
        public int id { get; set; }
        public String name { get; set; }

    }
}

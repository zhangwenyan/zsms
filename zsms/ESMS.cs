using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsms
{
    public class ESms
    {
        public ESms()
        {

        }
        public ESms(String mbno,String msg)
        {
            this.Mbno = mbno;
            this.Msg = msg;
        }
        public int Id { get; set; }
        public String Mbno { get; set; }
        public String Msg { get; set; }

    }
}

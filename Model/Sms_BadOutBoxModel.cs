using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class Sms_BadOutBoxModel:BaseModel
    {
        public int Id { set; get; }
        public string Username { set; get; }
        public string Mbno { set; get; }
        public string Msg { set; get; }
        public DateTime SendTime { set; get; }
        public string Bad_why { set; get; }
        public int Comport { set; get; }
        public string V1 { set; get; }
        public string V2 { set; get; }
        public string V3 { set; get; }
        public string V4 { set; get; }
        public string V5 { set; get; }

    }
}

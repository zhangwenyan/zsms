using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class Sms_OutBoxModel:BaseModel
    {
        public int Id { set; get; }
        public string Username { set; get; }
        public string Mbno { set; get; }
        public string Msg { set; get; }
        public DateTime SendTime { set; get; }
        public int Comport { set; get; }
        public int Report { set; get; }
        /// <summary>
        /// 用于程序中判断短信是否在发送中
        /// </summary>
        public string V1 { set; get; }
        /// <summary>
        /// 短信发送成功或失败将该值复制到sendedoutbox/badoutbox表中
        /// </summary>
        public string V2 { set; get; }
        /// <summary>
        /// 在sendedoutbox/badoutbox中对应该outbox表的id
        /// </summary>
        public string V3 { set; get; }
        public string V4 { set; get; }
        public string V5 { set; get; }


        public override string ToString()
        {
            return "@"+Mbno + ":" + Msg;
        }
    }
}

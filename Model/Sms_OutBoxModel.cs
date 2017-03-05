using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eweb;
namespace Model
{
    [Table(tbName ="outbox")]
    public class Sms_OutBoxModel:BaseModel
    {
        public int id { set; get; }
        public string username { set; get; }
        public string mbno { set; get; }
        public string msg { set; get; }
        public DateTime sendTime { set; get; }
        public int comport { set; get; }
        public int report { set; get; }
        /// <summary>
        /// 用于程序中判断短信是否在发送中
        /// </summary>
        public string v1 { set; get; }
        /// <summary>
        /// 短信发送成功或失败将该值复制到sendedoutbox/badoutbox表中
        /// </summary>
        public string v2 { set; get; }
        /// <summary>
        /// 在sendedoutbox/badoutbox中对应该outbox表的id
        /// </summary>
        public string v3 { set; get; }
        public string v4 { set; get; }
        public string v5 { set; get; }


        public override string ToString()
        {
            return "@"+mbno + ":" + msg;
        }
    }
}

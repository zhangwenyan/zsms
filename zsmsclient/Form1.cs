using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using zsms;
using System.Threading;
namespace zsmsclient
{
    public partial class Form1 : Form
    {
        public delegate void DG();
        public Form1()
        {
            InitializeComponent();
        }
        private BaseSmsTool smsTool;
        private void button1_Click(object sender, EventArgs e)
        {
            String mbno = textBox1.Text;
            String msg = textBox2.Text;
            addMsg("开始发送短信:" + mbno + "," + msg);
            new Thread(delegate ()
            {
                try
                {
                    smsTool.sendSms(new ESms(mbno, msg));
                    addMsg("发送短信完成:" + mbno + "," + msg);
                }
                catch (Exception ex)
                {
                    addMsg("发送短信出错:" + mbno + "," + msg+":"+ex.Message);
                }
            }).Start();
          
        }

        public void addMsg(String str)
        {
            DG dg = delegate ()
            {
                textBox3.AppendText(str + "\r\n");
            };
            if (Disposing || IsDisposed)
            {
                return;
            }
            Invoke(dg);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            smsTool = new SmsTool_AT("com8", 9600);
            List<SmsTemplate> stList = new List<SmsTemplate>();
            stList.Add(new SmsTemplate()
            {
                code = "SMS_5001004",
                content = "淮北vrv指标${msg}"
            });
            stList.Add(new SmsTemplate()
            {
                code = "SMS_5030714",
                content = "一体化${msg}"
            });

            stList.Add(new SmsTemplate()
            {
                code = "SMS_26180244",
                content = "您好${name}今天是${time}"
            });

            smsTool = new SmsTool_Alidayu("燎火", "SMS_5075620", "http://gw.api.taobao.com/router/rest", "23300185", "8b5196bef2e1ebcf5d1f75503e2a4cd8",stList);
            smsTool.init();
            smsTool.onSmsRecover += onSmsRecover;
        }
        private void onSmsRecover(RSms rsms)
        {
            addMsg("收到短信:" + rsms.Mbno + "," + rsms.Msg);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            smsTool.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addMsg(smsTool.getMsg());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                String r = ((SmsTool_AT)smsTool).sendAt(textBox1.Text);
                addMsg(r);
            }catch(Exception ex)
            {
                addMsg(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}

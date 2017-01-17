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
                    addMsg("发送短信出错:" + mbno + "," + msg);
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
    }
}

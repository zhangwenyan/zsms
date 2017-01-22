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
        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private service.Main service;
        public void addMsg(String str)
        {
            Log.Info(str);
            DG dg = delegate () {
                if (txt_msg.TextLength > 10000)
                {
                    //清理一半
                    txt_msg.Text.Remove(0, 5000);
                }
                txt_msg.AppendText(DateTime.Now.ToString("HH:mm:ss") + " " + str + "\r\n");
            };
            if (!txt_msg.Disposing && !this.IsDisposed)
            {
                this.BeginInvoke(dg);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Log.Debug("程序启动");



            if (config.Config.autoStartService)
            {
                startService();
               
            }
            

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;    //取消"关闭窗口"事件
                minimize();
                return;
            }
        }

        /// <summary>
        /// 最小化
        /// </summary>
        private void minimize()
        {
            this.WindowState = FormWindowState.Minimized;
            notifyIcon1.Visible = true;
            this.Hide();
            notifyIcon1.BalloonTipText = this.Text + "正在后台运行";
            notifyIcon1.BalloonTipTitle = "提示";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.ShowBalloonTip(10000);
        }
        /// <summary>
        /// 从最小化显示出来
        /// </summary>
        private void showWin()
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_msg.Clear();
        }

        private void 发送短信ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog.DialogFactory.showFrame_SendSms();
        }
        private void 待发短信ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog.DialogFactory.showFrame_OutBoxList();

        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeApp();
        }
        //关闭程序
        private void closeApp()
        {

            if (service != null)
            {
                try
                {
                    service.Dispose();
                }catch(Exception ex)
                {
                    Log.Error("服务销毁出错", ex);
                }
            }
            this.Dispose();
        }

        private void startService()
        {
            stopService();
            btn_startService.Enabled = false;
            btn_stopService.Enabled = true;
            //开启后台服务
            service = new service.Main();
            service.onMsg += addMsg;
            service.start();
        }
        private void stopService()
        {
            btn_startService.Enabled = true;
            btn_stopService.Enabled = false;
            if (service != null)
            {
                service.Dispose();
            }
        }
        private void btn_stopService_Click(object sender, EventArgs e)
        {
            stopService();
        }

        private void btn_startService_Click(object sender, EventArgs e)
        {
            startService();
        }

        private void 短信设备配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog.DialogFactory.showFrame_SmsToolSetting();

        }

        private void 数据库配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog.DialogFactory.showFrame_DatabaseSetting();
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            closeApp();
        }

        private void 打开主界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showWin();
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimize();
        }
    }
}

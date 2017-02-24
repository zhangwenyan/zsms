using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using config;
using ZUtil;
using Newtonsoft.Json;

namespace zsmsclient.dialog
{
    public partial class Frame_SmsToolSetting : Form
    {
        public Frame_SmsToolSetting()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Frame_SmsToolSetting_Load(object sender, EventArgs e)
        {
            cb_portName.Items.AddRange(SerialPort.GetPortNames());
            cb_portName.Text = Config.modem_portName;
            txt_baudRate.Text = Config.modem_bandRate.ToString();
            cb_smsRecover.Checked = Config.modem_smsRecover;

            txt_alidayu_url.Text = Config.alidayu_url;
            txt_alidayu_appkey.Text = Config.alidayu_appkey;
            txt_alidayu_secret.Text = Config.alidayu_secret;
            txt_smsFreeSignName.Text = Config.aliDayu_smsFreeSignName;
            txt_smsTemplateCode.Text = Config.aliDayu_smsTemplateCode;


            txt_aliyuncs_appkey.Text = Config.aliyuncs_appkey;
            txt_aliyuncs_secret.Text = Config.aliyuncs_secret;
            txt_aliyuncs_smsFreeSignName.Text = Config.aliyuncs_smsFreeSignName;
            txt_aliyuncs_smsTemplateCode.Text = Config.aliyuncs_smsTemplateCode;
             


            txt_zProxy_url.Text = Config.zProxy_url;
            txt_zProxy_sercet.Text = Config.zProxy_secret;



            switch (Config.smsTool.ToLower())
            {
                case "modem":
                    rb_modem.Checked = true;
                    break;
                case "alidayu":
                    rb_alidayu.Checked = true;
                    break;
                case "plugin":
                    rb_plugin.Checked = true;
                    break;
                case "zproxy":
                    rb_zProxy.Checked = true;
                    break;
                case "aliyuncs":
                    rb_aliyuncs.Checked = true;
                    break;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = FileUtil.FileToString(Config.zsmsSetting);
            var dy = JsonConvert.DeserializeObject<dynamic>(str);

            String smsTool = null;
            if (rb_modem.Checked)
            {
                smsTool = "modem";
            }
            else if (rb_alidayu.Checked)
            {
                smsTool = "alidayu";
            }
            else if (rb_plugin.Checked)
            {
                smsTool = "plugin";
            }
            else if (rb_zProxy.Checked)
            {
                smsTool = "zProxy";
            }
            else if (rb_aliyuncs.Checked)
            {
                smsTool = "aliyuncs";
            }

            dy.smsTool = smsTool;
            dy.smsTools.modem.portName = cb_portName.Text;
            dy.smsTools.modem.bandRate = txt_baudRate.Text;

            Config.modem_smsRecover = cb_smsRecover.Checked;
            dy.smsTools.modem.smsRecover = Config.modem_smsRecover;
      
            dy.smsTools.aliDayu.smsFreeSignName = txt_smsFreeSignName.Text;
            dy.smsTools.aliDayu.smsTemplateCode = txt_smsTemplateCode.Text;
            dy.smsTools.aliDayu.alidayu_url = txt_alidayu_url.Text;
            dy.smsTools.aliDayu.alidayu_appkey = txt_alidayu_appkey.Text;
            dy.smsTools.aliDayu.alidayu_secret = txt_alidayu_secret.Text;


            dy.smsTools.aliyuncs.smsFreeSignName = txt_aliyuncs_smsFreeSignName.Text;
            dy.smsTools.aliyuncs.smsTemplateCode = txt_aliyuncs_smsTemplateCode.Text;
            dy.smsTools.aliyuncs.appkey = txt_aliyuncs_appkey.Text;
            dy.smsTools.aliyuncs.secret = txt_aliyuncs_secret.Text;




            dy.smsTools.zProxy.url = txt_zProxy_url.Text;
            dy.smsTools.zProxy.sercet = txt_zProxy_sercet.Text;


            str = JsonConvert.SerializeObject(dy);
            FileUtil.WriteText(Config.zsmsSetting, str);

            MessageBox.Show("保存成功,重启后生效");
            this.Dispose();

        }
    }
}

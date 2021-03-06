﻿namespace zsmsclient.dialog
{
    partial class Frame_SmsToolSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cb_smsRecover = new System.Windows.Forms.CheckBox();
            this.txt_baudRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_portName = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_alidayu_secret = new System.Windows.Forms.TextBox();
            this.txt_alidayu_appkey = new System.Windows.Forms.TextBox();
            this.txt_smsTemplateCode = new System.Windows.Forms.TextBox();
            this.txt_alidayu_url = new System.Windows.Forms.TextBox();
            this.txt_smsFreeSignName = new System.Windows.Forms.TextBox();
            this.alidayu_secret = new System.Windows.Forms.Label();
            this.alidayu_appkey = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_zProxy_sercet = new System.Windows.Forms.TextBox();
            this.txt_zProxy_url = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txt_aliyuncs_secret = new System.Windows.Forms.TextBox();
            this.txt_aliyuncs_appkey = new System.Windows.Forms.TextBox();
            this.txt_aliyuncs_smsTemplateCode = new System.Windows.Forms.TextBox();
            this.txt_aliyuncs_smsFreeSignName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.rb_modem = new System.Windows.Forms.RadioButton();
            this.rb_alidayu = new System.Windows.Forms.RadioButton();
            this.rb_plugin = new System.Windows.Forms.RadioButton();
            this.rb_zProxy = new System.Windows.Forms.RadioButton();
            this.rb_aliyuncs = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(26, 55);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 388);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cb_smsRecover);
            this.tabPage1.Controls.Add(this.txt_baudRate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cb_portName);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "短信猫";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // cb_smsRecover
            // 
            this.cb_smsRecover.AutoSize = true;
            this.cb_smsRecover.Location = new System.Drawing.Point(78, 274);
            this.cb_smsRecover.Name = "cb_smsRecover";
            this.cb_smsRecover.Size = new System.Drawing.Size(89, 19);
            this.cb_smsRecover.TabIndex = 5;
            this.cb_smsRecover.Text = "接收短信";
            this.cb_smsRecover.UseVisualStyleBackColor = true;
            // 
            // txt_baudRate
            // 
            this.txt_baudRate.Location = new System.Drawing.Point(171, 208);
            this.txt_baudRate.Name = "txt_baudRate";
            this.txt_baudRate.Size = new System.Drawing.Size(183, 25);
            this.txt_baudRate.TabIndex = 4;
            this.txt_baudRate.Text = "9600";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "波特率:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "串口:";
            // 
            // cb_portName
            // 
            this.cb_portName.FormattingEnabled = true;
            this.cb_portName.Location = new System.Drawing.Point(171, 140);
            this.cb_portName.Name = "cb_portName";
            this.cb_portName.Size = new System.Drawing.Size(183, 23);
            this.cb_portName.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_alidayu_secret);
            this.tabPage2.Controls.Add(this.txt_alidayu_appkey);
            this.tabPage2.Controls.Add(this.txt_smsTemplateCode);
            this.tabPage2.Controls.Add(this.txt_alidayu_url);
            this.tabPage2.Controls.Add(this.txt_smsFreeSignName);
            this.tabPage2.Controls.Add(this.alidayu_secret);
            this.tabPage2.Controls.Add(this.alidayu_appkey);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "阿里大于短信平台";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_alidayu_secret
            // 
            this.txt_alidayu_secret.Location = new System.Drawing.Point(177, 286);
            this.txt_alidayu_secret.Name = "txt_alidayu_secret";
            this.txt_alidayu_secret.Size = new System.Drawing.Size(202, 25);
            this.txt_alidayu_secret.TabIndex = 5;
            // 
            // txt_alidayu_appkey
            // 
            this.txt_alidayu_appkey.Location = new System.Drawing.Point(177, 224);
            this.txt_alidayu_appkey.Name = "txt_alidayu_appkey";
            this.txt_alidayu_appkey.Size = new System.Drawing.Size(202, 25);
            this.txt_alidayu_appkey.TabIndex = 5;
            // 
            // txt_smsTemplateCode
            // 
            this.txt_smsTemplateCode.Location = new System.Drawing.Point(177, 106);
            this.txt_smsTemplateCode.Name = "txt_smsTemplateCode";
            this.txt_smsTemplateCode.Size = new System.Drawing.Size(202, 25);
            this.txt_smsTemplateCode.TabIndex = 5;
            // 
            // txt_alidayu_url
            // 
            this.txt_alidayu_url.Location = new System.Drawing.Point(177, 160);
            this.txt_alidayu_url.Name = "txt_alidayu_url";
            this.txt_alidayu_url.Size = new System.Drawing.Size(202, 25);
            this.txt_alidayu_url.TabIndex = 5;
            // 
            // txt_smsFreeSignName
            // 
            this.txt_smsFreeSignName.Location = new System.Drawing.Point(177, 38);
            this.txt_smsFreeSignName.Name = "txt_smsFreeSignName";
            this.txt_smsFreeSignName.Size = new System.Drawing.Size(202, 25);
            this.txt_smsFreeSignName.TabIndex = 5;
            // 
            // alidayu_secret
            // 
            this.alidayu_secret.AutoSize = true;
            this.alidayu_secret.Location = new System.Drawing.Point(36, 297);
            this.alidayu_secret.Name = "alidayu_secret";
            this.alidayu_secret.Size = new System.Drawing.Size(63, 15);
            this.alidayu_secret.TabIndex = 4;
            this.alidayu_secret.Text = "secret:";
            // 
            // alidayu_appkey
            // 
            this.alidayu_appkey.AutoSize = true;
            this.alidayu_appkey.Location = new System.Drawing.Point(36, 233);
            this.alidayu_appkey.Name = "alidayu_appkey";
            this.alidayu_appkey.Size = new System.Drawing.Size(63, 15);
            this.alidayu_appkey.TabIndex = 3;
            this.alidayu_appkey.Text = "appkey:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "阿里云接口地址:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "默认模板编号:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "签名:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_zProxy_sercet);
            this.tabPage3.Controls.Add(this.txt_zProxy_url);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(780, 359);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "代理";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_zProxy_sercet
            // 
            this.txt_zProxy_sercet.Location = new System.Drawing.Point(218, 164);
            this.txt_zProxy_sercet.Name = "txt_zProxy_sercet";
            this.txt_zProxy_sercet.Size = new System.Drawing.Size(384, 25);
            this.txt_zProxy_sercet.TabIndex = 3;
            // 
            // txt_zProxy_url
            // 
            this.txt_zProxy_url.Location = new System.Drawing.Point(218, 103);
            this.txt_zProxy_url.Name = "txt_zProxy_url";
            this.txt_zProxy_url.Size = new System.Drawing.Size(384, 25);
            this.txt_zProxy_url.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(114, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "认证字符串:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Url:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txt_aliyuncs_secret);
            this.tabPage4.Controls.Add(this.txt_aliyuncs_appkey);
            this.tabPage4.Controls.Add(this.txt_aliyuncs_smsTemplateCode);
            this.tabPage4.Controls.Add(this.txt_aliyuncs_smsFreeSignName);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(780, 359);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "阿里云cs短信平台";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txt_aliyuncs_secret
            // 
            this.txt_aliyuncs_secret.Location = new System.Drawing.Point(177, 256);
            this.txt_aliyuncs_secret.Name = "txt_aliyuncs_secret";
            this.txt_aliyuncs_secret.Size = new System.Drawing.Size(202, 25);
            this.txt_aliyuncs_secret.TabIndex = 5;
            // 
            // txt_aliyuncs_appkey
            // 
            this.txt_aliyuncs_appkey.Location = new System.Drawing.Point(177, 194);
            this.txt_aliyuncs_appkey.Name = "txt_aliyuncs_appkey";
            this.txt_aliyuncs_appkey.Size = new System.Drawing.Size(202, 25);
            this.txt_aliyuncs_appkey.TabIndex = 5;
            // 
            // txt_aliyuncs_smsTemplateCode
            // 
            this.txt_aliyuncs_smsTemplateCode.Location = new System.Drawing.Point(177, 118);
            this.txt_aliyuncs_smsTemplateCode.Name = "txt_aliyuncs_smsTemplateCode";
            this.txt_aliyuncs_smsTemplateCode.Size = new System.Drawing.Size(202, 25);
            this.txt_aliyuncs_smsTemplateCode.TabIndex = 5;
            // 
            // txt_aliyuncs_smsFreeSignName
            // 
            this.txt_aliyuncs_smsFreeSignName.Location = new System.Drawing.Point(177, 38);
            this.txt_aliyuncs_smsFreeSignName.Name = "txt_aliyuncs_smsFreeSignName";
            this.txt_aliyuncs_smsFreeSignName.Size = new System.Drawing.Size(202, 25);
            this.txt_aliyuncs_smsFreeSignName.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 4;
            this.label9.Text = "secret:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "appkey:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(36, 117);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "默认模板编号:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(36, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "签名:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(440, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(527, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "选择短信工具:";
            // 
            // rb_modem
            // 
            this.rb_modem.AutoSize = true;
            this.rb_modem.Location = new System.Drawing.Point(134, 18);
            this.rb_modem.Name = "rb_modem";
            this.rb_modem.Size = new System.Drawing.Size(73, 19);
            this.rb_modem.TabIndex = 4;
            this.rb_modem.TabStop = true;
            this.rb_modem.Text = "短信猫";
            this.rb_modem.UseVisualStyleBackColor = true;
            // 
            // rb_alidayu
            // 
            this.rb_alidayu.AutoSize = true;
            this.rb_alidayu.Location = new System.Drawing.Point(225, 18);
            this.rb_alidayu.Name = "rb_alidayu";
            this.rb_alidayu.Size = new System.Drawing.Size(148, 19);
            this.rb_alidayu.TabIndex = 5;
            this.rb_alidayu.TabStop = true;
            this.rb_alidayu.Text = "阿里大于短信平台";
            this.rb_alidayu.UseVisualStyleBackColor = true;
            // 
            // rb_plugin
            // 
            this.rb_plugin.AutoSize = true;
            this.rb_plugin.Location = new System.Drawing.Point(657, 20);
            this.rb_plugin.Name = "rb_plugin";
            this.rb_plugin.Size = new System.Drawing.Size(58, 19);
            this.rb_plugin.TabIndex = 6;
            this.rb_plugin.TabStop = true;
            this.rb_plugin.Text = "插件";
            this.rb_plugin.UseVisualStyleBackColor = true;
            // 
            // rb_zProxy
            // 
            this.rb_zProxy.AutoSize = true;
            this.rb_zProxy.Location = new System.Drawing.Point(568, 18);
            this.rb_zProxy.Name = "rb_zProxy";
            this.rb_zProxy.Size = new System.Drawing.Size(58, 19);
            this.rb_zProxy.TabIndex = 6;
            this.rb_zProxy.TabStop = true;
            this.rb_zProxy.Text = "代理";
            this.rb_zProxy.UseVisualStyleBackColor = true;
            // 
            // rb_aliyuncs
            // 
            this.rb_aliyuncs.AutoSize = true;
            this.rb_aliyuncs.Location = new System.Drawing.Point(395, 20);
            this.rb_aliyuncs.Name = "rb_aliyuncs";
            this.rb_aliyuncs.Size = new System.Drawing.Size(149, 19);
            this.rb_aliyuncs.TabIndex = 7;
            this.rb_aliyuncs.TabStop = true;
            this.rb_aliyuncs.Text = "阿里云cs短信平台";
            this.rb_aliyuncs.UseVisualStyleBackColor = true;
            // 
            // Frame_SmsToolSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 516);
            this.Controls.Add(this.rb_aliyuncs);
            this.Controls.Add(this.rb_zProxy);
            this.Controls.Add(this.rb_plugin);
            this.Controls.Add(this.rb_alidayu);
            this.Controls.Add(this.rb_modem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frame_SmsToolSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame_SmsToolSetting";
            this.Load += new System.EventHandler(this.Frame_SmsToolSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_portName;
        private System.Windows.Forms.TextBox txt_baudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label alidayu_appkey;
        private System.Windows.Forms.Label alidayu_secret;
        private System.Windows.Forms.TextBox txt_alidayu_secret;
        private System.Windows.Forms.TextBox txt_alidayu_appkey;
        private System.Windows.Forms.TextBox txt_smsTemplateCode;
        private System.Windows.Forms.TextBox txt_alidayu_url;
        private System.Windows.Forms.TextBox txt_smsFreeSignName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb_modem;
        private System.Windows.Forms.RadioButton rb_alidayu;
        private System.Windows.Forms.CheckBox cb_smsRecover;
        private System.Windows.Forms.RadioButton rb_plugin;
        private System.Windows.Forms.RadioButton rb_zProxy;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_zProxy_sercet;
        private System.Windows.Forms.TextBox txt_zProxy_url;
        private System.Windows.Forms.RadioButton rb_aliyuncs;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txt_aliyuncs_secret;
        private System.Windows.Forms.TextBox txt_aliyuncs_appkey;
        private System.Windows.Forms.TextBox txt_aliyuncs_smsTemplateCode;
        private System.Windows.Forms.TextBox txt_aliyuncs_smsFreeSignName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
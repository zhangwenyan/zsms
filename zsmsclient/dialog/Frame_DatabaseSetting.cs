using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using config;
using System.Reflection;
using System.Configuration;
using ZUtil;
namespace zsmsclient.dialog
{
    public partial class Frame_DatabaseSetting : Form
    {
        public Frame_DatabaseSetting()
        {
            InitializeComponent();
        }

        private void Frame_DatabaseSetting_Load(object sender, EventArgs e)
        {
            txt_connStr.Text = Config.connstr;
            cb_databaseType.Text = Config.dbType;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigUtil.changeSetting("connStr", txt_connStr.Text);
            ConfigUtil.changeSetting("databaseType", cb_databaseType.Text);
            MessageBox.Show("保存成功,重启后生效");
            this.Dispose();
        }

       

    }
}

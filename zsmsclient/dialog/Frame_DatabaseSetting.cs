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
            cb_databaseType.Text = Config.databaseType;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            changeSe("connStr", txt_connStr.Text);
            changeSe("databaseType", cb_databaseType.Text);
            MessageBox.Show("保存成功,重启后生效");
            this.Dispose();
        }

        protected void changeSe(String key, String value)
        {
            //调用  
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            Configuration config = ConfigurationManager.OpenExeConfiguration(assemblyConfigFile);    //获取appSettings节点 
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");
            //删除name，然后添加新值  
            appSettings.Settings.Remove(key);
            appSettings.Settings.Add(key, value);
            //保存配置文件  
            config.Save();
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using config;
using System.Configuration;
using System.Reflection;

namespace zsmsclient.dialog
{
    public partial class Frame_StartSetting : Form
    {
        public Frame_StartSetting()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey loca = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey run = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (run == null)
                {
                    run = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                }
                run.SetValue("AutoStartupTestWinFormApp", Application.ExecutablePath.ToString());
                MessageBox.Show("设置开机启动成功", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置开机启动失败,你可以尝试用管理员账号运行", "失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Win32.RegistryKey loca = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey run = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (run == null)
                {
                    run = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                }
                run.SetValue("AutoStartupTestWinFormApp", false);
                MessageBox.Show("取消开机启动成功", "成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("取消开机启动失败,你可以尝试用管理员账号运行", "失败");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Config.autoStartService = cb_autoStartService.Checked;
            Config.autoMinimize = cb_autoMinimize.Checked;
            Config.justOne = cb_justOne.Checked;

            changeSe("autoStartService", Config.autoStartService.ToString());
            changeSe("autoMinimize", Config.autoMinimize.ToString());
            changeSe("justOne", Config.justOne.ToString());

            MessageBox.Show("保存成功");
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

        private void Frame_StartSetting_Load(object sender, EventArgs e)
        {
            cb_autoStartService.Checked = Config.autoStartService;
            cb_autoMinimize.Checked = Config.autoMinimize;
            cb_justOne.Checked = Config.justOne;
        }
    }
}

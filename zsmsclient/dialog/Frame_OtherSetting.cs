using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using config;
using ZUtil;
using Newtonsoft.Json;

namespace zsmsclient.dialog
{
    public partial class Frame_OtherSetting : Form
    {
        public Frame_OtherSetting()
        {
            InitializeComponent();
        }

        private void Frame_OtherSetting_Load(object sender, EventArgs e)
        {
            num_tryCount.Value = Config.tryCount;
            num_errWaitTime.Value = Config.errorWaitTime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str = FileUtil.FileToString(Config.zsmsSetting);
            var dy = JsonConvert.DeserializeObject<dynamic>(str);


            Config.errorWaitTime = (int)num_errWaitTime.Value;
            Config.tryCount = (int)num_tryCount.Value;

            dy.errWaitTime = Config.errorWaitTime;
            dy.tryCount = Config.tryCount;


            str = JsonConvert.SerializeObject(dy);

            FileUtil.WriteText(Config.zsmsSetting, str);

            MessageBox.Show("保存成功");
            this.Dispose();

        }
    }
}

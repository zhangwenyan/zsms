using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dal;
using Model;
using easysql;
namespace zsmsclient.dialog
{
    public partial class Frame_SendSms : Form
    {
        protected static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Sms_OutBoxDal dal = DalFactory.createSms_OutBoxDal();
        public Frame_SendSms()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            String mbno = txt_mbno.Text;
            String msg = txt_msg.Text;
            Sms_OutBoxModel model = new Sms_OutBoxModel()
            {
                mbno = mbno,
                msg = msg
            };

            try
            {
                dal.add(model);
                if (rb_autoClear.Checked)
                {
                    txt_mbno.Clear();
                    txt_msg.Clear();
                }
                if (rb_autoClose.Checked)
                {
                    this.Dispose();
                }
            }
            catch(Exception ex)
            {
                Log.Error("添加短信出错", ex);
                MessageBox.Show("错误了:" + ex.Message);
                return;
            }
        }
    }
}

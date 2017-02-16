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
    public partial class Frame_SendedOutBoxList : Form
    {
        private Sms_SendedOutBoxDal dal = DalFactory.createSms_SendedOutBoxDal();
        public Frame_SendedOutBoxList()
        {
            InitializeComponent();
        }

        private void Frame_SendedOutBoxList_Load(object sender, EventArgs e)
        {

            zDataGridView1.QueryMethod = queryMethod;
            zDataGridView1.reload();
        }
        private List<object> queryMethod(int page, int rows, out int total)
        {
            List<Sms_SendedOutBoxModel> smsList = dal.queryPage(null, page, rows, out total, Restrain.OrderDesc("SendTime"));
            List<object> result = new List<object>();
            smsList.ForEach(sms =>
            {
                result.Add(sms);
            });

            return result;
        }
    }
}

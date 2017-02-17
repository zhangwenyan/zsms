using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Dal;
using easysql;

namespace zsmsclient.dialog
{
    public partial class Frame_InBoxList : Form
    {
        private Sms_InBoxDal dal = DalFactory.createSms_InBoxDal();
        public Frame_InBoxList()
        {
            InitializeComponent();
        }

        private void Frame_InBoxList_Load(object sender, EventArgs e)
        {
            zDataGridView1.QueryMethod = queryMethod;
            zDataGridView1.reload();
        }
        private List<object> queryMethod(int page, int rows, out int total)
        {
            List<Sms_InBoxModel> smsList = dal.queryPage(null,page, rows, out total, Restrain.OrderDesc("ArriveTime"));
            List<object> result = new List<object>();
            smsList.ForEach(sms =>
            {
                result.Add(sms);
            });

            return result;
        }
    }
}

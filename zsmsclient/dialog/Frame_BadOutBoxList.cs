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

namespace zsmsclient.dialog
{
    public partial class Frame_BadOutBoxList : Form
    {
        private Sms_BadOutBoxDal dal = DalFactory.createSms_BadOutBoxDal();
        public Frame_BadOutBoxList()
        {
            InitializeComponent();
        }

        private void Frame_BadOutBoxList_Load(object sender, EventArgs e)
        {
            zDataGridView1.QueryMethod = queryMethod;
            zDataGridView1.reload();
        }
        private List<object> queryMethod(int page, int rows, out int total)
        {
            List<Sms_BadOutBoxModel> smsList = dal.queryByPage(page, rows, out total);
            List<object> result = new List<object>();
            smsList.ForEach(sms =>
            {
                result.Add(sms);
            });

            return result;
        }
    }
}

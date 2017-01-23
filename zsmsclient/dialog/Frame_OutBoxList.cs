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
    public partial class Frame_OutBoxList : Form
    {
        private Sms_OutBoxDal dal = DalFactory.createSms_OutBoxDal();
        public Frame_OutBoxList()
        {
            InitializeComponent();
        }

        private void Frame_OutBoxList_Load(object sender, EventArgs e)
        {
            zDataGridView1.QueryMethod = queryMethod;
        }
        private List<object> queryMethod(int page, int rows, out int total)
        {
            List<Sms_OutBoxModel> smsList = dal.queryByPage(page, rows, out total);
            List<object> result = new List<object>();
            smsList.ForEach(sms =>
            {
                result.Add(sms);
            });

            return result;
        }
    }
}

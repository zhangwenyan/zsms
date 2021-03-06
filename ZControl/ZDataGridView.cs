﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZControl
{
    public partial class ZDataGridView : UserControl
    {
        public delegate void DG();
        public delegate List<object> DGQueryByPage(int page, int pageSize, out int total);
        public DGQueryByPage QueryMethod;
        /// <summary>
        /// 隐藏列的名称
        /// </summary>
        public String[] hiddenColumns { get; set; }

        public int page { get; set; }

        private int _pageSize;
        public int pageSize { get { return _pageSize; }
            set {
                _pageSize = value;

            } }
        private int total;




        public ZDataGridView()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        public List<dynamic> getSelections()
        {
            List<dynamic> list = new List<dynamic>();
            var srs = dgv.SelectedRows;
            foreach(DataGridViewRow sr in srs)
            {
                dynamic obj = sr.DataBoundItem;
                list.Add(obj);
            }
            return list;
        }
        private void ZDataGridView_Load(object sender, EventArgs e)
        {
            reload();
        }
        
        public void reload()
        {

            if (QueryMethod == null)
            {
                return;
            }

            if (page < 1)
            {
                page = 1;
            }
            var pageSizeStr = toolStripComboBox1.Text;
            if (pageSizeStr == "")
            {
                pageSizeStr = "0";
            }

            pageSize = int.Parse(pageSizeStr);
            if (pageSize < 1)
            {
                pageSize = 20;
                toolStripComboBox1.Text = pageSize.ToString();
            }

            //            toolStripButton5.
            this.loadingPanel1.Start();
            var source = new List<object>();
            try
            {
                source = QueryMethod(page, pageSize, out total);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询数据失败,请检查数据库配置(" + ex.Message + ")");
                return;
            }
            finally
            {
                this.loadingPanel1.Stop();
            }
            btn_pr.Enabled = btn_prs.Enabled = page > 1;
                int max = (int)Math.Ceiling(total * 1.0 / pageSize);
                btn_nexts.Enabled = btn_next.Enabled = page < max;

                if (source.Count == 0 && page != 1)
                {
                    page = 1;
                    reload();
                    return;
                }


                toolStripTextBox1.Text = page.ToString();
                toolStripLabel2.Text = string.Format("共{0}页", max);
                //显示1到8,共8记录
                toolStripLabel3.Text = string.Format("显示{0}到{1},共{2}记录",source.Count == 0?0:(page-1)*pageSize+1, (page-1)*pageSize+source.Count, total);

                this.dgv.DataSource = source;
            if (this.hiddenColumns == null)
            {
                if (this.dgv.Columns.Contains("id"))
                {
                    this.dgv.Columns["id"].Visible = false;
                }
            }
            else
            {
                for(var i = 0; i < hiddenColumns.Length; i++)
                {
                    var columnsName = hiddenColumns[i];
                    if (this.dgv.Columns.Contains(columnsName))
                    {
                        this.dgv.Columns[columnsName].Visible = false;
                    }
                }
            }

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void btn_prs_Click(object sender, EventArgs e)
        {
            page = 1;
            reload();
        }

        private void btn_pr_Click(object sender, EventArgs e)
        {
            page--;
            reload();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            page++;
            reload();
        }

        private void btn_nexts_Click(object sender, EventArgs e)
        {
            int max = (int)Math.Ceiling(total * 1.0 / pageSize);
            page = max;
            reload();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }
    }
}

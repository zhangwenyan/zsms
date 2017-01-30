namespace zsmsclient.dialog
{
    partial class Frame_InBoxList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zDataGridView1 = new ZControl.ZDataGridView();
            this.SuspendLayout();
            // 
            // zDataGridView1
            // 
            this.zDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.zDataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.zDataGridView1.Name = "zDataGridView1";
            this.zDataGridView1.page = 0;
            this.zDataGridView1.pageSize = 0;
            this.zDataGridView1.Size = new System.Drawing.Size(599, 407);
            this.zDataGridView1.TabIndex = 0;
            // 
            // Frame_InBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 407);
            this.Controls.Add(this.zDataGridView1);
            this.Name = "Frame_InBoxList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame_InBoxList";
            this.Load += new System.EventHandler(this.Frame_InBoxList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZControl.ZDataGridView zDataGridView1;
    }
}
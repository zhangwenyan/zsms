namespace zsmsclient.dialog
{
    partial class Frame_SendSms
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
            this.txt_mbno = new System.Windows.Forms.TextBox();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.rb_autoClear = new System.Windows.Forms.CheckBox();
            this.rb_autoClose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txt_mbno
            // 
            this.txt_mbno.Location = new System.Drawing.Point(37, 36);
            this.txt_mbno.Name = "txt_mbno";
            this.txt_mbno.Size = new System.Drawing.Size(274, 25);
            this.txt_mbno.TabIndex = 0;
            this.txt_mbno.Text = "17681109309";
            // 
            // txt_msg
            // 
            this.txt_msg.Location = new System.Drawing.Point(37, 91);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.Size = new System.Drawing.Size(274, 124);
            this.txt_msg.TabIndex = 1;
            this.txt_msg.Text = "test123";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(211, 261);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(100, 35);
            this.btn_add.TabIndex = 2;
            this.btn_add.Text = "添加";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // rb_autoClear
            // 
            this.rb_autoClear.AutoSize = true;
            this.rb_autoClear.Checked = true;
            this.rb_autoClear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rb_autoClear.Location = new System.Drawing.Point(76, 252);
            this.rb_autoClear.Name = "rb_autoClear";
            this.rb_autoClear.Size = new System.Drawing.Size(89, 19);
            this.rb_autoClear.TabIndex = 3;
            this.rb_autoClear.Text = "自动清空";
            this.rb_autoClear.UseVisualStyleBackColor = true;
            // 
            // rb_autoClose
            // 
            this.rb_autoClose.AutoSize = true;
            this.rb_autoClose.Checked = true;
            this.rb_autoClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rb_autoClose.Location = new System.Drawing.Point(76, 290);
            this.rb_autoClose.Name = "rb_autoClose";
            this.rb_autoClose.Size = new System.Drawing.Size(89, 19);
            this.rb_autoClose.TabIndex = 4;
            this.rb_autoClose.Text = "自动关闭";
            this.rb_autoClose.UseVisualStyleBackColor = true;
            // 
            // Frame_SendSms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 330);
            this.Controls.Add(this.rb_autoClose);
            this.Controls.Add(this.rb_autoClear);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.txt_mbno);
            this.Name = "Frame_SendSms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame_SendSms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_mbno;
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.CheckBox rb_autoClear;
        private System.Windows.Forms.CheckBox rb_autoClose;
    }
}
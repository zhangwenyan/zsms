namespace zsmsclient.dialog
{
    partial class Frame_OtherSetting
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_tryCount = new System.Windows.Forms.NumericUpDown();
            this.num_errWaitTime = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_tryCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_errWaitTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "发送短信尝试次数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "失败等待时间:";
            // 
            // num_tryCount
            // 
            this.num_tryCount.Location = new System.Drawing.Point(235, 79);
            this.num_tryCount.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.num_tryCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_tryCount.Name = "num_tryCount";
            this.num_tryCount.Size = new System.Drawing.Size(120, 25);
            this.num_tryCount.TabIndex = 2;
            this.num_tryCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_errWaitTime
            // 
            this.num_errWaitTime.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.num_errWaitTime.Location = new System.Drawing.Point(213, 148);
            this.num_errWaitTime.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.num_errWaitTime.Name = "num_errWaitTime";
            this.num_errWaitTime.Size = new System.Drawing.Size(120, 25);
            this.num_errWaitTime.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(321, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 6;
            // 
            // Frame_OtherSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 368);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.num_errWaitTime);
            this.Controls.Add(this.num_tryCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frame_OtherSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame_OtherSetting";
            this.Load += new System.EventHandler(this.Frame_OtherSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_tryCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_errWaitTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_tryCount;
        private System.Windows.Forms.NumericUpDown num_errWaitTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
    }
}
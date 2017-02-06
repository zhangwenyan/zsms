namespace zsmsclient.dialog
{
    partial class Frame_StartSetting
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cb_autoStartService = new System.Windows.Forms.CheckBox();
            this.cb_autoMinimize = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cb_justOne = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "设置开机启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "取消开机启动";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cb_autoStartService
            // 
            this.cb_autoStartService.AutoSize = true;
            this.cb_autoStartService.Location = new System.Drawing.Point(59, 147);
            this.cb_autoStartService.Name = "cb_autoStartService";
            this.cb_autoStartService.Size = new System.Drawing.Size(119, 19);
            this.cb_autoStartService.TabIndex = 2;
            this.cb_autoStartService.Text = "自动开始服务";
            this.cb_autoStartService.UseVisualStyleBackColor = true;
            // 
            // cb_autoMinimize
            // 
            this.cb_autoMinimize.AutoSize = true;
            this.cb_autoMinimize.Location = new System.Drawing.Point(59, 193);
            this.cb_autoMinimize.Name = "cb_autoMinimize";
            this.cb_autoMinimize.Size = new System.Drawing.Size(104, 19);
            this.cb_autoMinimize.TabIndex = 3;
            this.cb_autoMinimize.Text = "自动最小化";
            this.cb_autoMinimize.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 284);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 34);
            this.button3.TabIndex = 4;
            this.button3.Text = "保存";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(269, 284);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 5;
            this.button4.Text = "取消";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cb_justOne
            // 
            this.cb_justOne.AutoSize = true;
            this.cb_justOne.Location = new System.Drawing.Point(59, 234);
            this.cb_justOne.Name = "cb_justOne";
            this.cb_justOne.Size = new System.Drawing.Size(134, 19);
            this.cb_justOne.TabIndex = 6;
            this.cb_justOne.Text = "只运行一个程序";
            this.cb_justOne.UseVisualStyleBackColor = true;
            // 
            // Frame_StartSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 330);
            this.Controls.Add(this.cb_justOne);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cb_autoMinimize);
            this.Controls.Add(this.cb_autoStartService);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Frame_StartSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frame_StartSetting";
            this.Load += new System.EventHandler(this.Frame_StartSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cb_autoStartService;
        private System.Windows.Forms.CheckBox cb_autoMinimize;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox cb_justOne;
    }
}
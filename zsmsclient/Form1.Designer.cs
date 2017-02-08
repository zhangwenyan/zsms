namespace zsmsclient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_msg = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.短信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.待发短信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.已发短信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.失败短信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接收短信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.短信设备配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送短信ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_startService = new System.Windows.Forms.Button();
            this.btn_stopService = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开主界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_msg
            // 
            this.txt_msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_msg.Location = new System.Drawing.Point(12, 65);
            this.txt_msg.Multiline = true;
            this.txt_msg.Name = "txt_msg";
            this.txt_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_msg.Size = new System.Drawing.Size(434, 383);
            this.txt_msg.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(378, 33);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 28);
            this.button4.TabIndex = 6;
            this.button4.Text = "清空";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.短信ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(458, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.最小化ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 最小化ToolStripMenuItem
            // 
            this.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem";
            this.最小化ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.最小化ToolStripMenuItem.Text = "最小化";
            this.最小化ToolStripMenuItem.Click += new System.EventHandler(this.最小化ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 短信ToolStripMenuItem
            // 
            this.短信ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.待发短信ToolStripMenuItem,
            this.已发短信ToolStripMenuItem,
            this.失败短信ToolStripMenuItem,
            this.接收短信ToolStripMenuItem});
            this.短信ToolStripMenuItem.Name = "短信ToolStripMenuItem";
            this.短信ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.短信ToolStripMenuItem.Text = "短信";
            // 
            // 待发短信ToolStripMenuItem
            // 
            this.待发短信ToolStripMenuItem.Name = "待发短信ToolStripMenuItem";
            this.待发短信ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.待发短信ToolStripMenuItem.Text = "待发短信";
            this.待发短信ToolStripMenuItem.Click += new System.EventHandler(this.待发短信ToolStripMenuItem_Click);
            // 
            // 已发短信ToolStripMenuItem
            // 
            this.已发短信ToolStripMenuItem.Name = "已发短信ToolStripMenuItem";
            this.已发短信ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.已发短信ToolStripMenuItem.Text = "已发短信";
            this.已发短信ToolStripMenuItem.Click += new System.EventHandler(this.已发短信ToolStripMenuItem_Click);
            // 
            // 失败短信ToolStripMenuItem
            // 
            this.失败短信ToolStripMenuItem.Name = "失败短信ToolStripMenuItem";
            this.失败短信ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.失败短信ToolStripMenuItem.Text = "失败短信";
            this.失败短信ToolStripMenuItem.Click += new System.EventHandler(this.失败短信ToolStripMenuItem_Click);
            // 
            // 接收短信ToolStripMenuItem
            // 
            this.接收短信ToolStripMenuItem.Name = "接收短信ToolStripMenuItem";
            this.接收短信ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.接收短信ToolStripMenuItem.Text = "接收短信";
            this.接收短信ToolStripMenuItem.Click += new System.EventHandler(this.接收短信ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.短信设备配置ToolStripMenuItem,
            this.数据库配置ToolStripMenuItem,
            this.启动设置ToolStripMenuItem,
            this.其他设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 短信设备配置ToolStripMenuItem
            // 
            this.短信设备配置ToolStripMenuItem.Name = "短信设备配置ToolStripMenuItem";
            this.短信设备配置ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.短信设备配置ToolStripMenuItem.Text = "短信设备配置";
            this.短信设备配置ToolStripMenuItem.Click += new System.EventHandler(this.短信设备配置ToolStripMenuItem_Click);
            // 
            // 数据库配置ToolStripMenuItem
            // 
            this.数据库配置ToolStripMenuItem.Name = "数据库配置ToolStripMenuItem";
            this.数据库配置ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.数据库配置ToolStripMenuItem.Text = "数据库配置";
            this.数据库配置ToolStripMenuItem.Click += new System.EventHandler(this.数据库配置ToolStripMenuItem_Click);
            // 
            // 启动设置ToolStripMenuItem
            // 
            this.启动设置ToolStripMenuItem.Name = "启动设置ToolStripMenuItem";
            this.启动设置ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.启动设置ToolStripMenuItem.Text = "启动设置";
            this.启动设置ToolStripMenuItem.Click += new System.EventHandler(this.启动设置ToolStripMenuItem_Click);
            // 
            // 其他设置ToolStripMenuItem
            // 
            this.其他设置ToolStripMenuItem.Name = "其他设置ToolStripMenuItem";
            this.其他设置ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.其他设置ToolStripMenuItem.Text = "其他设置";
            this.其他设置ToolStripMenuItem.Click += new System.EventHandler(this.其他设置ToolStripMenuItem_Click);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发送短信ToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 发送短信ToolStripMenuItem
            // 
            this.发送短信ToolStripMenuItem.Name = "发送短信ToolStripMenuItem";
            this.发送短信ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.发送短信ToolStripMenuItem.Text = "添加短信";
            this.发送短信ToolStripMenuItem.Click += new System.EventHandler(this.发送短信ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.日志ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 日志ToolStripMenuItem
            // 
            this.日志ToolStripMenuItem.Name = "日志ToolStripMenuItem";
            this.日志ToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.日志ToolStripMenuItem.Text = "日志";
            this.日志ToolStripMenuItem.Click += new System.EventHandler(this.日志ToolStripMenuItem_Click);
            // 
            // btn_startService
            // 
            this.btn_startService.Location = new System.Drawing.Point(12, 33);
            this.btn_startService.Name = "btn_startService";
            this.btn_startService.Size = new System.Drawing.Size(107, 28);
            this.btn_startService.TabIndex = 8;
            this.btn_startService.Text = "开启服务";
            this.btn_startService.UseVisualStyleBackColor = true;
            this.btn_startService.Click += new System.EventHandler(this.btn_startService_Click);
            // 
            // btn_stopService
            // 
            this.btn_stopService.Location = new System.Drawing.Point(129, 33);
            this.btn_stopService.Name = "btn_stopService";
            this.btn_stopService.Size = new System.Drawing.Size(107, 28);
            this.btn_stopService.TabIndex = 9;
            this.btn_stopService.Text = "关闭服务";
            this.btn_stopService.UseVisualStyleBackColor = true;
            this.btn_stopService.Click += new System.EventHandler(this.btn_stopService_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开主界面ToolStripMenuItem,
            this.退出ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 56);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.DoubleClick += new System.EventHandler(this.contextMenuStrip1_DoubleClick);
            // 
            // 打开主界面ToolStripMenuItem
            // 
            this.打开主界面ToolStripMenuItem.Name = "打开主界面ToolStripMenuItem";
            this.打开主界面ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.打开主界面ToolStripMenuItem.Text = "打开主界面";
            this.打开主界面ToolStripMenuItem.Click += new System.EventHandler(this.打开主界面ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(159, 26);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(272, 43);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(67, 15);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "添加短信";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 454);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "版本:0.0.1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 478);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btn_stopService);
            this.Controls.Add(this.btn_startService);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txt_msg);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "zsmsclient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_msg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 短信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 待发短信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送短信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button btn_startService;
        private System.Windows.Forms.Button btn_stopService;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 短信设备配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库配置ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开主界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 最小化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 已发短信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 失败短信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接收短信ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动设置ToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
    }
}


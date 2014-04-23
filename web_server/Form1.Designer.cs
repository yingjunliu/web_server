namespace web_server
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启动服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.访问日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.错误日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.请求报文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送报文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.服务ToolStripMenuItem,
            this.查看ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加站点ToolStripMenuItem,
            this.修改站点ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 增加站点ToolStripMenuItem
            // 
            this.增加站点ToolStripMenuItem.Name = "增加站点ToolStripMenuItem";
            this.增加站点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.增加站点ToolStripMenuItem.Text = "增加站点";
            this.增加站点ToolStripMenuItem.Click += new System.EventHandler(this.增加站点ToolStripMenuItem_Click);
            // 
            // 修改站点ToolStripMenuItem
            // 
            this.修改站点ToolStripMenuItem.Name = "修改站点ToolStripMenuItem";
            this.修改站点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改站点ToolStripMenuItem.Text = "修改站点";
            this.修改站点ToolStripMenuItem.Click += new System.EventHandler(this.修改站点ToolStripMenuItem_Click);
            // 
            // 服务ToolStripMenuItem
            // 
            this.服务ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.启动服务ToolStripMenuItem,
            this.关闭服务ToolStripMenuItem});
            this.服务ToolStripMenuItem.Name = "服务ToolStripMenuItem";
            this.服务ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.服务ToolStripMenuItem.Text = "服务";
            // 
            // 启动服务ToolStripMenuItem
            // 
            this.启动服务ToolStripMenuItem.Name = "启动服务ToolStripMenuItem";
            this.启动服务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.启动服务ToolStripMenuItem.Text = "启动服务";
            this.启动服务ToolStripMenuItem.Click += new System.EventHandler(this.启动服务ToolStripMenuItem_Click);
            // 
            // 关闭服务ToolStripMenuItem
            // 
            this.关闭服务ToolStripMenuItem.Name = "关闭服务ToolStripMenuItem";
            this.关闭服务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关闭服务ToolStripMenuItem.Text = "关闭服务";
            this.关闭服务ToolStripMenuItem.Click += new System.EventHandler(this.关闭服务ToolStripMenuItem_Click);
            // 
            // 查看ToolStripMenuItem
            // 
            this.查看ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.访问日志ToolStripMenuItem,
            this.错误日志ToolStripMenuItem,
            this.请求报文ToolStripMenuItem,
            this.发送报文ToolStripMenuItem});
            this.查看ToolStripMenuItem.Name = "查看ToolStripMenuItem";
            this.查看ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.查看ToolStripMenuItem.Text = "查看";
            // 
            // 访问日志ToolStripMenuItem
            // 
            this.访问日志ToolStripMenuItem.Name = "访问日志ToolStripMenuItem";
            this.访问日志ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.访问日志ToolStripMenuItem.Text = "访问日志";
            this.访问日志ToolStripMenuItem.Click += new System.EventHandler(this.访问日志ToolStripMenuItem_Click);
            // 
            // 错误日志ToolStripMenuItem
            // 
            this.错误日志ToolStripMenuItem.Name = "错误日志ToolStripMenuItem";
            this.错误日志ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.错误日志ToolStripMenuItem.Text = "错误日志";
            // 
            // 请求报文ToolStripMenuItem
            // 
            this.请求报文ToolStripMenuItem.Name = "请求报文ToolStripMenuItem";
            this.请求报文ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.请求报文ToolStripMenuItem.Text = "请求报文";
            this.请求报文ToolStripMenuItem.Click += new System.EventHandler(this.请求报文ToolStripMenuItem_Click);
            // 
            // 发送报文ToolStripMenuItem
            // 
            this.发送报文ToolStripMenuItem.Name = "发送报文ToolStripMenuItem";
            this.发送报文ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.发送报文ToolStripMenuItem.Text = "发送报文";
            this.发送报文ToolStripMenuItem.Click += new System.EventHandler(this.发送报文ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(0, 29);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(152, 352);
            this.treeView1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(153, 211);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(416, 170);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.Location = new System.Drawing.Point(153, 29);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(416, 181);
            this.richTextBox2.TabIndex = 3;
            this.richTextBox2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 381);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加站点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改站点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启动服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 访问日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 错误日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 请求报文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送报文ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}


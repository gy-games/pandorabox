namespace PandoraBox
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.login_btn = new System.Windows.Forms.Button();
            this.msg_label = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.can_btn = new System.Windows.Forms.Button();
            this.reset_label = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Main_FormClosing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(192, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入您的本地密码：";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(196, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(193, 21);
            this.textBox1.TabIndex = 2;
            // 
            // login_btn
            // 
            this.login_btn.Location = new System.Drawing.Point(196, 180);
            this.login_btn.Name = "login_btn";
            this.login_btn.Size = new System.Drawing.Size(86, 34);
            this.login_btn.TabIndex = 4;
            this.login_btn.Text = "确定";
            this.login_btn.UseVisualStyleBackColor = true;
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // msg_label
            // 
            this.msg_label.AutoSize = true;
            this.msg_label.ForeColor = System.Drawing.Color.Red;
            this.msg_label.Location = new System.Drawing.Point(198, 155);
            this.msg_label.Name = "msg_label";
            this.msg_label.Size = new System.Drawing.Size(53, 12);
            this.msg_label.TabIndex = 8;
            this.msg_label.Text = "用户提示";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(41, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 124);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // can_btn
            // 
            this.can_btn.Location = new System.Drawing.Point(307, 180);
            this.can_btn.Name = "can_btn";
            this.can_btn.Size = new System.Drawing.Size(82, 34);
            this.can_btn.TabIndex = 12;
            this.can_btn.Text = "取消";
            this.can_btn.UseVisualStyleBackColor = true;
            this.can_btn.Click += new System.EventHandler(this.can_btn_Click);
            // 
            // reset_label
            // 
            this.reset_label.AutoSize = true;
            this.reset_label.BackColor = System.Drawing.Color.Transparent;
            this.reset_label.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.reset_label.Location = new System.Drawing.Point(378, 39);
            this.reset_label.Name = "reset_label";
            this.reset_label.Size = new System.Drawing.Size(53, 12);
            this.reset_label.TabIndex = 14;
            this.reset_label.Text = "系统重置";
            this.reset_label.Click += new System.EventHandler(this.reset_label_Click);
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.version.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.version.Location = new System.Drawing.Point(400, 225);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(41, 17);
            this.version.TabIndex = 15;
            this.version.Text = "v0.0.1";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 251);
            this.Controls.Add(this.version);
            this.Controls.Add(this.reset_label);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.can_btn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.msg_label);
            this.Controls.Add(this.login_btn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PandoraBox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button login_btn;
        private System.Windows.Forms.Label msg_label;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button can_btn;
        private System.Windows.Forms.Label reset_label;
        private System.Windows.Forms.Label version;
    }
}


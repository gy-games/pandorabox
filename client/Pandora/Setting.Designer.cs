namespace PandoraBox
{
    partial class Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.panel1 = new System.Windows.Forms.Panel();
            this.change_pwd_btn = new System.Windows.Forms.Button();
            this.pwd_textBox2 = new System.Windows.Forms.TextBox();
            this.pwd_msg = new System.Windows.Forms.Label();
            this.pwd_textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(315, 474);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(0, 0);
            this.panel1.TabIndex = 0;
            // 
            // change_pwd_btn
            // 
            this.change_pwd_btn.Location = new System.Drawing.Point(167, 144);
            this.change_pwd_btn.Name = "change_pwd_btn";
            this.change_pwd_btn.Size = new System.Drawing.Size(182, 27);
            this.change_pwd_btn.TabIndex = 4;
            this.change_pwd_btn.Text = "保存";
            this.change_pwd_btn.UseVisualStyleBackColor = true;
            this.change_pwd_btn.Click += new System.EventHandler(this.change_pwd_btn_Click);
            // 
            // pwd_textBox2
            // 
            this.pwd_textBox2.Location = new System.Drawing.Point(177, 76);
            this.pwd_textBox2.Name = "pwd_textBox2";
            this.pwd_textBox2.PasswordChar = '*';
            this.pwd_textBox2.Size = new System.Drawing.Size(208, 21);
            this.pwd_textBox2.TabIndex = 3;
            // 
            // pwd_msg
            // 
            this.pwd_msg.AutoSize = true;
            this.pwd_msg.ForeColor = System.Drawing.Color.Red;
            this.pwd_msg.Location = new System.Drawing.Point(175, 110);
            this.pwd_msg.Name = "pwd_msg";
            this.pwd_msg.Size = new System.Drawing.Size(53, 12);
            this.pwd_msg.TabIndex = 6;
            this.pwd_msg.Text = "用户提示";
            // 
            // pwd_textBox1
            // 
            this.pwd_textBox1.Location = new System.Drawing.Point(177, 37);
            this.pwd_textBox1.Name = "pwd_textBox1";
            this.pwd_textBox1.PasswordChar = '*';
            this.pwd_textBox1.Size = new System.Drawing.Size(208, 21);
            this.pwd_textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(97, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "确认密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(97, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "新  密  码";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 80);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(488, 235);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.change_pwd_btn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pwd_textBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pwd_msg);
            this.tabPage1.Controls.Add(this.pwd_textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(480, 209);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "修改本地密码";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(512, 332);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Setting";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PandoraBox";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button change_pwd_btn;
        private System.Windows.Forms.TextBox pwd_textBox2;
        private System.Windows.Forms.TextBox pwd_textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label pwd_msg;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
    }
}
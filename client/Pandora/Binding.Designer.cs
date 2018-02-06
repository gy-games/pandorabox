namespace PandoraBox
{
    partial class Binding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Binding));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.oa_usr_textBox = new System.Windows.Forms.TextBox();
            this.msg_label = new System.Windows.Forms.Label();
            this.later_link = new System.Windows.Forms.LinkLabel();
            this.oa_pwd_textBox = new System.Windows.Forms.TextBox();
            this.bind_btn = new System.Windows.Forms.Button();
            this.notic_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "STEP2.绑定帐号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(63, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "帐  号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label5.Location = new System.Drawing.Point(63, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "密  码";
            // 
            // oa_usr_textBox
            // 
            this.oa_usr_textBox.Location = new System.Drawing.Point(119, 107);
            this.oa_usr_textBox.Name = "oa_usr_textBox";
            this.oa_usr_textBox.Size = new System.Drawing.Size(160, 21);
            this.oa_usr_textBox.TabIndex = 5;
            // 
            // msg_label
            // 
            this.msg_label.AutoSize = true;
            this.msg_label.ForeColor = System.Drawing.Color.Red;
            this.msg_label.Location = new System.Drawing.Point(117, 170);
            this.msg_label.Name = "msg_label";
            this.msg_label.Size = new System.Drawing.Size(53, 12);
            this.msg_label.TabIndex = 13;
            this.msg_label.Text = "用户提示";
            // 
            // later_link
            // 
            this.later_link.AutoSize = true;
            this.later_link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.later_link.Location = new System.Drawing.Point(293, 170);
            this.later_link.Name = "later_link";
            this.later_link.Size = new System.Drawing.Size(53, 12);
            this.later_link.TabIndex = 14;
            this.later_link.TabStop = true;
            this.later_link.Text = "以后再说";
            this.later_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.later_link_LinkClicked);
            // 
            // oa_pwd_textBox
            // 
            this.oa_pwd_textBox.Location = new System.Drawing.Point(119, 137);
            this.oa_pwd_textBox.Name = "oa_pwd_textBox";
            this.oa_pwd_textBox.PasswordChar = '*';
            this.oa_pwd_textBox.Size = new System.Drawing.Size(160, 21);
            this.oa_pwd_textBox.TabIndex = 6;
            // 
            // bind_btn
            // 
            this.bind_btn.Location = new System.Drawing.Point(295, 105);
            this.bind_btn.Name = "bind_btn";
            this.bind_btn.Size = new System.Drawing.Size(82, 52);
            this.bind_btn.TabIndex = 8;
            this.bind_btn.Text = "帐号绑定";
            this.bind_btn.UseVisualStyleBackColor = true;
            this.bind_btn.Click += new System.EventHandler(this.bind_btn_Click);
            // 
            // notic_label
            // 
            this.notic_label.AutoSize = true;
            this.notic_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.notic_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.notic_label.Location = new System.Drawing.Point(64, 198);
            this.notic_label.Name = "notic_label";
            this.notic_label.Size = new System.Drawing.Size(308, 34);
            this.notic_label.TabIndex = 16;
            this.notic_label.Text = "绑定帐号后将公开个人公钥,用于接收信息的加密\r\n当且仅当帐号绑定后才可使用本系统进行信息的收发工作";
            // 
            // Binding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(434, 251);
            this.Controls.Add(this.notic_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bind_btn);
            this.Controls.Add(this.oa_pwd_textBox);
            this.Controls.Add(this.later_link);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.msg_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.oa_usr_textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Binding";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PandoraBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Main_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox oa_usr_textBox;
        private System.Windows.Forms.Label msg_label;
        private System.Windows.Forms.LinkLabel later_link;
        private System.Windows.Forms.TextBox oa_pwd_textBox;
        private System.Windows.Forms.Button bind_btn;
        private System.Windows.Forms.Label notic_label;


    }
}
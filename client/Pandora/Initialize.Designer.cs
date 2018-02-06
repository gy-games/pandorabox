namespace PandoraBox
{
    partial class Initialize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Initialize));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.init_btn = new System.Windows.Forms.Button();
            this.msg_label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Main_FormClosing);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(65, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "密       码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(65, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "确认密码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(141, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(139, 21);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(141, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(139, 21);
            this.textBox2.TabIndex = 4;
            // 
            // init_btn
            // 
            this.init_btn.Location = new System.Drawing.Point(301, 105);
            this.init_btn.Name = "init_btn";
            this.init_btn.Size = new System.Drawing.Size(82, 51);
            this.init_btn.TabIndex = 5;
            this.init_btn.Text = "初始化系统";
            this.init_btn.UseVisualStyleBackColor = true;
            this.init_btn.Click += new System.EventHandler(this.init_btn_Click);
            // 
            // msg_label
            // 
            this.msg_label.AutoSize = true;
            this.msg_label.ForeColor = System.Drawing.Color.Red;
            this.msg_label.Location = new System.Drawing.Point(139, 164);
            this.msg_label.Name = "msg_label";
            this.msg_label.Size = new System.Drawing.Size(53, 12);
            this.msg_label.TabIndex = 9;
            this.msg_label.Text = "用户提示";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(66, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(332, 34);
            this.label7.TabIndex = 13;
            this.label7.Text = "初始化操作将在本地生成个人公私密钥(RSA)\r\n私钥将使用此密码进行加密，请妥善保管！遗失将无法还原！";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.title_label.Location = new System.Drawing.Point(12, 74);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(130, 17);
            this.title_label.TabIndex = 14;
            this.title_label.Text = "STEP1.初始化生成密钥";
            // 
            // Initialize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(445, 242);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.msg_label);
            this.Controls.Add(this.init_btn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Initialize";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PandoraBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button init_btn;
        private System.Windows.Forms.Label msg_label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label title_label;
    }
}
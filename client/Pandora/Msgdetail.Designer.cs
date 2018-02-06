namespace PandoraBox
{
    partial class msgDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(msgDetail));
            this.memo_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.msg_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.del_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // memo_textBox
            // 
            this.memo_textBox.Location = new System.Drawing.Point(16, 259);
            this.memo_textBox.Multiline = true;
            this.memo_textBox.Name = "memo_textBox";
            this.memo_textBox.Size = new System.Drawing.Size(480, 54);
            this.memo_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(12, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "备注：";
            // 
            // save_btn
            // 
            this.save_btn.Location = new System.Drawing.Point(204, 326);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(85, 36);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "确定";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // msg_textBox
            // 
            this.msg_textBox.Location = new System.Drawing.Point(16, 104);
            this.msg_textBox.Multiline = true;
            this.msg_textBox.Name = "msg_textBox";
            this.msg_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msg_textBox.Size = new System.Drawing.Size(480, 119);
            this.msg_textBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "发件内容：";
            // 
            // del_label
            // 
            this.del_label.AutoSize = true;
            this.del_label.BackColor = System.Drawing.Color.Transparent;
            this.del_label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.del_label.Location = new System.Drawing.Point(431, 349);
            this.del_label.Name = "del_label";
            this.del_label.Size = new System.Drawing.Size(65, 12);
            this.del_label.TabIndex = 6;
            this.del_label.Text = "删除该消息";
            this.del_label.Click += new System.EventHandler(this.del_label_Click);
            // 
            // msgDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 382);
            this.Controls.Add(this.del_label);
            this.Controls.Add(this.msg_textBox);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.memo_textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "msgDetail";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PandoraBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox memo_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox msg_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label del_label;
    }
}
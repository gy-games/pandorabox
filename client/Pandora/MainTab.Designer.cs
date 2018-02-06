namespace PandoraBox
{
    partial class MainTab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTab));
            this.user_box = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ref_btn = new System.Windows.Forms.Button();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.dictionaryIcon = new System.Windows.Forms.ImageList(this.components);
            this.msg_revc_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.send_msg_btn = new System.Windows.Forms.Button();
            this.msg_body_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.msg_title_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.revice_btn = new System.Windows.Forms.Button();
            this.redict_btn = new System.Windows.Forms.Button();
            this.next_btn = new System.Windows.Forms.Button();
            this.forward_btn = new System.Windows.Forms.Button();
            this.pages_label = new System.Windows.Forms.Label();
            this.page_textBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel_parent = new System.Windows.Forms.Panel();
            this.setting_btn = new System.Windows.Forms.Button();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataTable2 = new System.Data.DataTable();
            this.dataTable3 = new System.Data.DataTable();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.email_label = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.user_box.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel_parent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // user_box
            // 
            this.user_box.Controls.Add(this.tabPage2);
            this.user_box.Controls.Add(this.tabPage1);
            this.user_box.Location = new System.Drawing.Point(3, 4);
            this.user_box.Name = "user_box";
            this.user_box.SelectedIndex = 0;
            this.user_box.Size = new System.Drawing.Size(853, 436);
            this.user_box.TabIndex = 0;
            this.user_box.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ref_btn);
            this.tabPage2.Controls.Add(this.treeView2);
            this.tabPage2.Controls.Add(this.msg_revc_flowLayoutPanel);
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.send_msg_btn);
            this.tabPage2.Controls.Add(this.msg_body_textBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.msg_title_textBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.treeView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(845, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "发送信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ref_btn
            // 
            this.ref_btn.Location = new System.Drawing.Point(11, 372);
            this.ref_btn.Name = "ref_btn";
            this.ref_btn.Size = new System.Drawing.Size(204, 23);
            this.ref_btn.TabIndex = 26;
            this.ref_btn.Text = "刷新组织结构";
            this.ref_btn.UseVisualStyleBackColor = true;
            this.ref_btn.Click += new System.EventHandler(this.ref_btn_Click);
            // 
            // treeView2
            // 
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.dictionaryIcon;
            this.treeView2.Location = new System.Drawing.Point(11, 86);
            this.treeView2.Name = "treeView2";
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.Size = new System.Drawing.Size(204, 280);
            this.treeView2.TabIndex = 25;
            this.treeView2.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // dictionaryIcon
            // 
            this.dictionaryIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("dictionaryIcon.ImageStream")));
            this.dictionaryIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.dictionaryIcon.Images.SetKeyName(0, "1.png");
            this.dictionaryIcon.Images.SetKeyName(1, "2.gif");
            this.dictionaryIcon.Images.SetKeyName(2, "444.png");
            // 
            // msg_revc_flowLayoutPanel
            // 
            this.msg_revc_flowLayoutPanel.AutoScroll = true;
            this.msg_revc_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.msg_revc_flowLayoutPanel.Location = new System.Drawing.Point(300, 53);
            this.msg_revc_flowLayoutPanel.Name = "msg_revc_flowLayoutPanel";
            this.msg_revc_flowLayoutPanel.Size = new System.Drawing.Size(530, 56);
            this.msg_revc_flowLayoutPanel.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.pictureBox3);
            this.panel7.Controls.Add(this.search_textBox);
            this.panel7.Location = new System.Drawing.Point(11, 52);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(204, 28);
            this.panel7.TabIndex = 24;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(4, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // search_textBox
            // 
            this.search_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.search_textBox.Location = new System.Drawing.Point(26, 6);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(173, 14);
            this.search_textBox.TabIndex = 21;
            this.search_textBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged_2);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(11, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(204, 34);
            this.panel5.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(48, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "人员组织结构";
            // 
            // send_msg_btn
            // 
            this.send_msg_btn.Location = new System.Drawing.Point(300, 350);
            this.send_msg_btn.Name = "send_msg_btn";
            this.send_msg_btn.Size = new System.Drawing.Size(530, 46);
            this.send_msg_btn.TabIndex = 14;
            this.send_msg_btn.Text = "发送消息";
            this.send_msg_btn.UseVisualStyleBackColor = true;
            this.send_msg_btn.Click += new System.EventHandler(this.send_msg_Click);
            // 
            // msg_body_textBox
            // 
            this.msg_body_textBox.Location = new System.Drawing.Point(300, 123);
            this.msg_body_textBox.Multiline = true;
            this.msg_body_textBox.Name = "msg_body_textBox";
            this.msg_body_textBox.Size = new System.Drawing.Size(530, 213);
            this.msg_body_textBox.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.Location = new System.Drawing.Point(238, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "密 文*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(236, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "收件人";
            // 
            // msg_title_textBox
            // 
            this.msg_title_textBox.Location = new System.Drawing.Point(300, 21);
            this.msg_title_textBox.Name = "msg_title_textBox";
            this.msg_title_textBox.Size = new System.Drawing.Size(530, 21);
            this.msg_title_textBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.Location = new System.Drawing.Point(238, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "标   题";
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.dictionaryIcon;
            this.treeView1.Location = new System.Drawing.Point(11, 86);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(204, 280);
            this.treeView1.TabIndex = 1;
            this.treeView1.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.BCollapse);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BCollapse);
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeMouseDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(848, 419);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "收取信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.revice_btn);
            this.panel1.Controls.Add(this.redict_btn);
            this.panel1.Controls.Add(this.next_btn);
            this.panel1.Controls.Add(this.forward_btn);
            this.panel1.Controls.Add(this.pages_label);
            this.panel1.Controls.Add(this.page_textBox);
            this.panel1.Location = new System.Drawing.Point(3, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 29);
            this.panel1.TabIndex = 5;
            // 
            // revice_btn
            // 
            this.revice_btn.Location = new System.Drawing.Point(0, 3);
            this.revice_btn.Name = "revice_btn";
            this.revice_btn.Size = new System.Drawing.Size(75, 23);
            this.revice_btn.TabIndex = 5;
            this.revice_btn.Text = "立即收取";
            this.revice_btn.UseVisualStyleBackColor = true;
            this.revice_btn.Click += new System.EventHandler(this.revice_btn_Click);
            // 
            // redict_btn
            // 
            this.redict_btn.Location = new System.Drawing.Point(733, 3);
            this.redict_btn.Name = "redict_btn";
            this.redict_btn.Size = new System.Drawing.Size(42, 23);
            this.redict_btn.TabIndex = 4;
            this.redict_btn.Text = "跳转";
            this.redict_btn.UseVisualStyleBackColor = true;
            this.redict_btn.Click += new System.EventHandler(this.redict_btn_Click);
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(787, 3);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(53, 23);
            this.next_btn.TabIndex = 3;
            this.next_btn.Text = "下一页";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // forward_btn
            // 
            this.forward_btn.Location = new System.Drawing.Point(571, 3);
            this.forward_btn.Name = "forward_btn";
            this.forward_btn.Size = new System.Drawing.Size(53, 23);
            this.forward_btn.TabIndex = 2;
            this.forward_btn.Text = "上一页";
            this.forward_btn.UseVisualStyleBackColor = true;
            this.forward_btn.Click += new System.EventHandler(this.forward_btn_Click);
            // 
            // pages_label
            // 
            this.pages_label.AutoSize = true;
            this.pages_label.Location = new System.Drawing.Point(682, 9);
            this.pages_label.Name = "pages_label";
            this.pages_label.Size = new System.Drawing.Size(41, 12);
            this.pages_label.TabIndex = 1;
            this.pages_label.Text = "label1";
            // 
            // page_textBox
            // 
            this.page_textBox.Location = new System.Drawing.Point(643, 5);
            this.page_textBox.Name = "page_textBox";
            this.page_textBox.Size = new System.Drawing.Size(29, 21);
            this.page_textBox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(842, 375);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel_parent
            // 
            this.panel_parent.BackColor = System.Drawing.Color.White;
            this.panel_parent.Controls.Add(this.user_box);
            this.panel_parent.Location = new System.Drawing.Point(1, 63);
            this.panel_parent.Name = "panel_parent";
            this.panel_parent.Size = new System.Drawing.Size(859, 466);
            this.panel_parent.TabIndex = 0;
            // 
            // setting_btn
            // 
            this.setting_btn.Location = new System.Drawing.Point(766, 34);
            this.setting_btn.Name = "setting_btn";
            this.setting_btn.Size = new System.Drawing.Size(72, 23);
            this.setting_btn.TabIndex = 3;
            this.setting_btn.Text = "系统配置";
            this.setting_btn.UseVisualStyleBackColor = true;
            this.setting_btn.Click += new System.EventHandler(this.setting_btn_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("zh-Hans");
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.dataTable1,
            this.dataTable2,
            this.dataTable3});
            // 
            // dataTable1
            // 
            this.dataTable1.TableName = "Table1";
            // 
            // dataTable2
            // 
            this.dataTable2.TableName = "Table2";
            // 
            // dataTable3
            // 
            this.dataTable3.TableName = "Table3";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Pandora";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Controls.Add(this.version);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 509);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(861, 30);
            this.panel6.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(9, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 26);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(27, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "未关联";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.email_label);
            this.panel4.Location = new System.Drawing.Point(218, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 24);
            this.panel4.TabIndex = 6;
            this.panel4.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.email_label.Location = new System.Drawing.Point(29, 4);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(44, 17);
            this.email_label.TabIndex = 0;
            this.email_label.Text = "用户名";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(808, 10);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(41, 12);
            this.version.TabIndex = 7;
            this.version.Text = "label1";
            // 
            // MainTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(861, 539);
            this.Controls.Add(this.setting_btn);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel_parent);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainTab";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PandoraBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.F_Main_FormClosing);
            this.SizeChanged += new System.EventHandler(this.F_Main_SizeChanged);
            this.user_box.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel_parent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl user_box;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel_parent;
        private System.Data.DataSet dataSet1;
        private System.Data.DataTable dataTable1;
        private System.Data.DataTable dataTable2;
        private System.Data.DataTable dataTable3;
        private System.Windows.Forms.Label pages_label;
        private System.Windows.Forms.TextBox page_textBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button redict_btn;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.Button forward_btn;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList dictionaryIcon;
        private System.Windows.Forms.Button send_msg_btn;
        private System.Windows.Forms.TextBox msg_body_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox msg_title_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button setting_btn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox search_textBox;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.FlowLayoutPanel msg_revc_flowLayoutPanel;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Button revice_btn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button ref_btn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.Label version;

    }
}
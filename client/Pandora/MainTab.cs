using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Collections;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Threading;

namespace PandoraBox
{
    public partial class MainTab : MaterialForm
    {
        //每页条数
        int pagesize = 50;    
        //当前页
        int pagenow = 1;
        //总页数
        int pagecount = 0;

        public int m_MouseClicks = 0;

        public MainTab()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            email_label.Text = Config.username;
            version.Text = Program.Version;

            //初始化两个treeview
            treeView2.Hide();
            treeView1.BringToFront();

            if (Config.uid == null || Config.uid.Equals("0"))
            {
                //未关联
                panel3.Visible = true;
                panel3.BringToFront();
                panel4.Visible = false;
            }
            else
            {
                //已关联
                panel4.Visible = true;
                panel4.BringToFront();
                panel3.Visible = false;
                panel4.Location = panel3.Location;
            }


            //进程-1 显示信息列表
            Thread tshowDataTable = new Thread(new ThreadStart(showDataTable));
            tshowDataTable.IsBackground = true;
            tshowDataTable.Start();

            //初始化左侧树状人员列表
            userTreeInit("1");
        }
        
        //左侧树鼠标点击事件
        private void TreeMouseDown(object sender, MouseEventArgs e)
        {
            this.m_MouseClicks = e.Clicks;
        }
         
        //禁用树状结构的双击展开
        private void BCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (this.m_MouseClicks > 1)
            { //如果是鼠标双击则禁止结点折叠 
                e.Cancel = true;
            }
            else
            { //如果是鼠标单击则允许结点折叠 
                e.Cancel = false;
            }
        }

        //显示信息列表
        public void showDataTable() {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + Program.DbPath + ";Version=3;");
            dbConn.Open();
            //总记录数
            int allCount = 0;
            DataSet ds = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("select 1  FROM message order by id desc ;", dbConn);
            dataAdapter.Fill(ds);
            allCount = ds.Tables[0].Rows.Count;
            this.pagecount = allCount % pagesize;
            //只能显示一页,判断是否是整除
            if (this.pagecount == 0)
            {
                this.pagecount = allCount / pagesize;
            }
            else
            {
                this.pagecount = allCount / pagesize + 1;
            }
            this.pages_label.Text = " / " + this.pagecount.ToString();
            page_textBox.Text = this.pagenow.ToString();
            dbConn.Close();

            //分页显示
            showDataList(this.pagesize, 0);
        }
             
        //初始化左侧树
        private void userTreeInit(String did) { 
            String uri = "/api/get_list_by_depart_id";
            Hashtable param = new Hashtable();
            param["did"] = did;
            Boolean flag = false;
            String result_str = "";
            String error = "";
            Util.HttpGet(out flag, out result_str, out error, uri, param);
            if (flag)
            {
                List<Hashtable> listTable = JsonConvert.DeserializeObject<List<Hashtable>>(result_str);
                foreach (Hashtable ht in listTable)
                {
                    TreeNode node = new TreeNode();
                    node.Text = ht["name"].ToString();
                    node.Tag  = ht["id"].ToString();

                    if (ht["type"].ToString().Equals("1") && ht["has_key"].ToString().Equals("0"))
                    {
                        node.ImageIndex = 2;
                    }
                    else
                    {
                        node.ImageIndex = int.Parse(ht["type"].ToString());
                    }
                    if (did == "1")
                    {
                        //node.Tag = "dpt";
                        treeView1.Nodes.Add(node);
                    }
                    else {
                        RefreshChildNode(treeView1, node, int.Parse(did));
                    }

                    if (ht["type"].ToString() == "0")
                    {
                        //node.Tag = "dpt";
                        //组装部门下的所有部门
                        if (Config.depart_all_depart.ContainsKey(did))
                        {
                            Config.depart_all_depart[did].Add(ht["id"].ToString());
                        }
                        else {
                            List<String> dids = new List<string>();
                            dids.Add(ht["id"].ToString());
                            Config.depart_all_depart.Add(did, dids);
                        }
                        
                        userTreeInit(node.Tag.ToString());
                    }
                    else {
                        Config.all_user.Add(ht["name"].ToString());
                        Hashtable user_tmp = new Hashtable();
                        user_tmp["name"]    = ht["name"].ToString();
                        user_tmp["id"]      = ht["id"].ToString();
                        user_tmp["has_key"] = ht["has_key"].ToString();

                        Config.all_user_map.Add(ht["id"].ToString(), user_tmp); ;

                        //Config.all_user_search.Add(user_tmp);
                        //组装部门下的所有员工
                        if (Config.depart_all_user.ContainsKey(did))
                        {
                            Config.depart_all_user[did].Add(ht["id"].ToString());
                        }
                        else {
                            List<String> uids = new List<string>();
                            uids.Add(ht["id"].ToString());
                            Config.depart_all_user.Add(did, uids);
                        }
                    }
                }
            }
            else {
                MessageBox.Show(error, "获取用户树错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //显示信息列表
        private void showDataList(int pagesize,int offset)
        {
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + Program.DbPath + ";Version=3;");
            dbConn.Open();
            DataSet ds = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT id,send_user as '发件人', title as '标题',msg as '密文信息',mem as '备注',time as '发送时间' FROM message order by id desc  limit "+pagesize.ToString()+" offset "+offset.ToString()+";", dbConn);
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Columns["发送时间"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["id"].ReadOnly = true;
            dataGridView1.Columns["发件人"].ReadOnly = true;
            dataGridView1.Columns["标题"].ReadOnly = true;
            dataGridView1.Columns["密文信息"].Visible = false;
            dataGridView1.Columns["备注"].ReadOnly = true;
            dataGridView1.Columns["发送时间"].ReadOnly = true;

            //左侧第一列固定宽度
            dataGridView1.Columns["id"].Width = 40;
            dataGridView1.Columns[0].Resizable = DataGridViewTriState.False;

            //左侧第二列固定宽度
            dataGridView1.Columns["发件人"].Width = 80;
            dataGridView1.Columns[1].Resizable = DataGridViewTriState.False;

            //左侧第六列固定宽度
            dataGridView1.Columns["发送时间"].Width = 120;
            dataGridView1.Columns["发送时间"].Resizable = DataGridViewTriState.False;

            ds = null;
            dbConn.Close();
        } 

        //显示完整信息
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1) { 
                String msg =  dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                String memo =  dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                msgDetail dialog = new msgDetail( msg, memo);
                Config.row_index = e.RowIndex;
                Config.column_index = 4;
                Config.id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                dialog.Owner = this;
                dialog.ShowDialog();
            }
        }

        //根据页码跳转
        private void redict_btn_Click(object sender, EventArgs e)
        {
            int page = int.Parse(page_textBox.Text);
            if (page > this.pagecount)
            {
                MessageBox.Show("页数超限！请重试！");
                return;
            }
            this.pagenow = page;
            int offset = (this.pagenow-1) * this.pagesize;
            showDataList(this.pagesize, offset);
        }

        //跳转到上一页
        private void forward_btn_Click(object sender, EventArgs e)
        {
            if (this.pagenow > 1)
            {
                this.pagenow = this.pagenow - 1;
            }
            else {
                this.pagenow = 1;
            }
            int offset = (this.pagenow - 1) * this.pagesize;
            page_textBox.Text = this.pagenow.ToString();
            showDataList(this.pagesize, offset);
        }

        //跳转到下一页
        private void next_btn_Click(object sender, EventArgs e)
        {
            if (this.pagenow < this.pagecount)
            {
                this.pagenow = this.pagenow + 1;
            }
            else
            {
                this.pagenow = ((this.pagecount == 0) ? 1 : this.pagecount);
            }
            int offset = (this.pagenow - 1) * this.pagesize;
            page_textBox.Text = this.pagenow.ToString();
            showDataList(this.pagesize, offset);
        }

        //保存备注信息
        public void saveMsgMemo()
        {
            dataGridView1.Rows[Config.row_index].Cells[Config.column_index].Value = Config.mem.Replace("'","");
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + Program.DbPath + ";Version=3;");
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();
            string sql = " UPDATE message set  mem = '" + Config.mem.Replace("'","") + "' WHERE id = " + Config.id.ToString();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            dbConn.Close();
        }

        //删除信息
        public void delMsg()
        {
            dataGridView1.Rows.Remove(dataGridView1.Rows[Config.row_index]);
            SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + Program.DbPath + ";Version=3;");
            dbConn.Open();
            SQLiteCommand cmd = dbConn.CreateCommand();
            string sql = " delete from message WHERE id = " + Config.id.ToString();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            dbConn.Close();
        }

        //选择发送人
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String uid =e.Node.Tag.ToString();
            String name = e.Node.Text;
            Boolean isDepart = true;
            Config.depart_user_ids.Clear();
            int allCnt = 0, okCnt = 0;
            if (Config.all_user.Contains(name))
            {
                isDepart = false;
                Config.depart_user_ids.Add(uid);
            }
            else {
                get_person_by_id(uid);
                allCnt = Config.depart_user_ids.Count;
            }
            String uids = string.Join(",", Config.depart_user_ids);
            //远程获取公钥
            String uri = "/api/get_pub_key";
            Hashtable param = new Hashtable();
            param["uid"] = Config.uid;
            param["uids"] = uids;
            Boolean flag = false;
            String result_str = "";
            String error = "";
            Util.HttpGet(out flag, out result_str, out error, uri, param, Config.security_id);
            Hashtable resultTable = new Hashtable();
            if (flag)
            {
                resultTable = JsonConvert.DeserializeObject<Hashtable>(result_str);
                foreach (String cuid in Config.depart_user_ids)
                {
                    if (resultTable[cuid] != null && resultTable[cuid].ToString()!="")
                    {
                        Hashtable user_map = new Hashtable();
                        user_map["uid"] = cuid;
                        user_map["pubkey"] = resultTable[cuid];
                        //添加待发送人
                        if (!Config.send_user.ContainsKey(Config.all_user_map[cuid]["name"]))
                        {
                            Config.send_user.Add(Config.all_user_map[cuid]["name"], user_map);
                            Button bt = new Button();
                            bt.Text = Config.all_user_map[cuid]["name"].ToString();
                            bt.Width = bt.Text.Length * 20;
                            bt.Height = 20;
                            bt.Left = 5;
                            bt.Top = 3;
                            bt.Click += new System.EventHandler(this.removeRevc_Click);
                            msg_revc_flowLayoutPanel.Controls.Add(bt);
                        }
                        if (isDepart)
                        {
                            okCnt = okCnt + 1;
                        }
                    }
                    else {
                        if (!isDepart) {
                            MessageBox.Show("收件人："+name+" 未初始化系统，无法发送信息！");
                            return;
                        }
                    }
                }
                if (isDepart)
                {
                    if (allCnt != okCnt)
                    {
                        MessageBox.Show("该部门下存在 " + (allCnt - okCnt) + " 人未初始化系统，将无法收到信息！");
                    }
                }
            }
        }

        //根据ID获取部门下所有人员
        private void get_person_by_id(String pdid) {
            //追加人员
            if (Config.depart_all_user.ContainsKey(pdid))
            {
                Config.depart_user_ids = Config.depart_user_ids.Union(Config.depart_all_user[pdid]).ToList<String>();
            }
            //遍历部门
            if (Config.depart_all_depart.ContainsKey(pdid))
            {
                foreach (String did in Config.depart_all_depart[pdid])
                {
                    get_person_by_id(did);
                }
            }
        }

        //点击删除待发送人
        private void removeRevc_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            msg_revc_flowLayoutPanel.Controls.Remove(bt);
            String name = bt.Text.ToString().Trim();
            Config.send_user.Remove(name);
        }

        //更新子节点数据
        private void RefreshChildNode(TreeView tr1, TreeNode treeNode, int parentId)
        {
            foreach (TreeNode node in tr1.Nodes)
            {

                if (int.Parse(node.Tag.ToString()) == parentId && node.ImageIndex == 0)
                {
                   
                    try {
                        node.Nodes.Add(treeNode);
                    }
                    catch { 
                    }
                    return;
                }
                else if (node.Nodes.Count > 0)
                {
                    FindChildNode(node, treeNode, parentId);
                }

            }
        }

        //处理根节点的子节点的子节点
        private void FindChildNode(TreeNode tNode, TreeNode treeNode, int parentId)
        {
            foreach (TreeNode node in tNode.Nodes)
            {
                if (int.Parse(node.Tag.ToString()) == parentId && node.ImageIndex == 0)
                {
                    try { 
                        node.Nodes.Add(treeNode);
                    }catch
                    {
                    }
                    
                    return;
                }
                else if (node.Nodes.Count > 0)
                {
                    FindChildNode(node, treeNode, parentId);
                }
            }
        }

        //判断是否最小化,然后显示托盘
        private void F_Main_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮
            if (WindowState == FormWindowState.Minimized)
            {
                //隐藏任务栏区图标
                this.ShowInTaskbar = false;
                //图标显示在托盘区
                notifyIcon1.Visible = true;
            }
        }

        //确认是否退出
        private void F_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                // 关闭所有的线程
                this.Dispose();
                this.Close();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
            
        }

        //发送数据
        private void send_msg_Click(object sender, EventArgs e)
        {
            if (Config.uid.Equals("0"))
            {
                MessageBox.Show("当前账号未关联OA,不能发送信息。");
                return;
            }
            send_msg_btn.Enabled = false;
            String uid = Config.uid.ToString();
            String title = msg_title_textBox.Text.Trim();
            String text = msg_body_textBox.Text.Trim();

            if (Config.send_user.Count == 0 )
            {
                MessageBox.Show("收件人不能为空");
                send_msg_btn.Enabled = true;
                return;
            }
            if("".Equals(title))
            {
                MessageBox.Show("标题不能为空");
                send_msg_btn.Enabled = true;
                msg_title_textBox.Focus();
                return;
                
            }
            if (title.Length>60)
            {
                MessageBox.Show("标题过长，请限制在60字以内");
                send_msg_btn.Enabled = true;
                msg_title_textBox.Focus();
                return;

            }
            if("".Equals(text)){
                MessageBox.Show("信息不能为空");
                send_msg_btn.Enabled = true;
                msg_body_textBox.Focus();
                return;
                
            }

            ArrayList datalist = new ArrayList();
            foreach (Hashtable uid_tmp in Config.send_user.Values)
            {
                try
                {
                    Hashtable dmsg = new Hashtable();
                    //获取公钥对text进行加密
                    String pub_key = Util.DecodeBase64(uid_tmp["pubkey"].ToString());
                    dmsg["text"] = Util.RSAEncrypt(pub_key, text);
                    dmsg["uid"] = uid_tmp["uid"];
                    datalist.Add(dmsg);
                }
                catch{
                    //MessageBox.Show(ex.ToString(), Config.all_user_map[uid_tmp["uid"].ToString()]["name"].ToString()+"信息发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }

            Boolean send_flag = false;
            String  send_result_str = "";
            String  send_error = "";

            String send_uri = "/api/send_msg";
            Hashtable send_param = new Hashtable();
            send_param["data"]  = datalist;
            send_param["uid"]   = uid;
            send_param["title"] = title;

            Util.HttpPost(out send_flag, out send_result_str, out send_error, send_uri, send_param, Config.security_id);

            if (send_flag)
            {
                MessageBox.Show("信息发送成功！");
                msg_body_textBox.Text = "";
                msg_title_textBox.Text = "";
                Config.send_user.Clear();
                msg_revc_flowLayoutPanel.Controls.Clear();
            }
            else {
                MessageBox.Show(send_error, "信息发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            send_msg_btn.Enabled = true;
        }
        
        //切换标签页
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (user_box.SelectedTab.Name == "tabPage1")
            {
                //收取信息-刷新收件列表
                freshTable();
            }
            else
            {
                //发送信息，请空表单
                msg_body_textBox.Text = "";
                msg_title_textBox.Text = "";
                Config.send_user.Clear();
                //Config.send_depart.Clear();
                msg_revc_flowLayoutPanel.Controls.Clear();
            }
        
        }

        //点击系统配置
        private void setting_btn_Click(object sender, EventArgs e)
        {
            Form setform = new Setting();
            setform.Show();
        }

        //人员搜索
        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {
            Boolean status = true;
            String username = search_textBox.Text.Trim();
            if ("".Equals(username) || username == null)
            {
                status = false;
            }
            if (status)
            {
                treeView2.Nodes.Clear();
                treeView2.BringToFront();
                treeView2.Show();
                foreach (Hashtable ht in Config.all_user_map.Values)
                {
                    String user_now = ht["name"].ToString();
                    if (user_now.Contains(username))
                    {
                        TreeNode node = new TreeNode();
                        node.Text = ht["name"].ToString();
                        node.Tag = ht["id"].ToString();
                        if (ht["has_key"].ToString().Equals("0"))
                        {
                            node.ImageIndex = 2;
                        }
                        else
                        {
                            node.ImageIndex = 1;
                        }
                        treeView2.Nodes.Add(node);
                    }
                }
            }
            else
            {
                treeView2.Hide();
                treeView1.BringToFront();
                treeView1.Show();
            }
        }

        //刷新收件列表
        public void freshTable()
        {
            if (Config.uid == null || Config.uid.Equals("0"))
            {
                return;
            }
                String uri = "/api/get_msg";
                Hashtable param = new Hashtable();
                param["uid"] = Config.uid;

                Boolean flag = false;
                String result_str = "";
                String error = "";
                Util.HttpGet(out flag, out result_str, out error, uri, param, Config.security_id);

                if (flag)
                {
                    List<Hashtable> listTable = JsonConvert.DeserializeObject<List<Hashtable>>(result_str);
                    SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + Program.DbPath + ";Version=3;");
                    dbConn.Open();
                    SQLiteCommand cmd = dbConn.CreateCommand();

                    if (listTable != null && listTable.Count > 0)
                    {
                        foreach (Hashtable ht in listTable)
                        {
                            String send_name = ht["send_name"].ToString();
                            String message = ht["message"].ToString();
                            String title = ht["title"].ToString();
                            String send_time = ht["send_time"].ToString();

                            String sql = " insert into message (title,send_user,msg,time,mem) values ('" + title.Replace("'", "") + "','" + send_name.Replace("'", "") + "','" + message + "','" + send_time + "','无')";
                            //MessageBox.Show(sql);
                            //执行插入
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //关闭数据库
                    dbConn.Close();
                }
                else
                {
                    MessageBox.Show(error, "信件收取错误！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //初始化datagrid
                SQLiteConnection dbConn_datagrid = new SQLiteConnection("Data Source=" + Program.DbPath + ";Version=3;");
                dbConn_datagrid.Open();
                int allCount = 0;    //总记录数
                DataSet ds = new DataSet();
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("select *  FROM message order by id desc ;", dbConn_datagrid);
                dataAdapter.Fill(ds);
                allCount = ds.Tables[0].Rows.Count;
                this.pagecount = allCount % pagesize;

                //只能显示一页,判断是否是整除
                if (this.pagecount == 0)
                {
                    this.pagecount = allCount / pagesize;
                }
                else
                {
                    this.pagecount = allCount / pagesize + 1;
                }

                this.pages_label.Text = " / " + ((this.pagecount==0)?"1":this.pagecount.ToString());
                page_textBox.Text = this.pagenow.ToString();
                dbConn_datagrid.Close();
                showDataList(this.pagesize, 0);
                
        }
        
        //刷新按钮
        private void revice_btn_Click(object sender, EventArgs e)
        {
            freshTable();
        }

        //双击小图标
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //还原窗体显示    
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点
                this.Activate();
                //任务栏区显示图标
                this.ShowInTaskbar = true;
                //托盘区图标隐藏
                //notifyIcon1.Visible = false;
            }
        }

        //刷新组织结构
        private void ref_btn_Click(object sender, EventArgs e)
        {
            search_textBox.Text = "";
            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();
            Config.all_user.Clear();
            Config.all_user_map.Clear();
            Config.depart_all_depart.Clear();
            Config.depart_all_user.Clear();
            Config.depart_user_ids.Clear();
            userTreeInit("1");
            MessageBox.Show("组织结构刷新成功！");
        }


    }
}

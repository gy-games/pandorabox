using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Threading;


namespace PandoraBox
{
    public partial class Binding : MaterialForm
    {
        public Binding()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            msg_label.Text = "";
            later_link.Visible = false;
        }


        private void bind_btn_Click(object sender, EventArgs e)
        {
            msg_label.ForeColor = Color.ForestGreen;
            msg_label.Text = "绑定中...";

            bind_btn.Enabled = false;
            String username = oa_usr_textBox.Text.Trim();
            String password = oa_pwd_textBox.Text.Trim();
            //Thread.Sleep(1500);

            //调用远程接口
            Boolean flag = false;
            String error = "";
            String result_data = "";
            try
            {
                String uri = "/api/save_pub_key";
                Hashtable param = new Hashtable();
                param["username"] = username;
                param["password"] = password;
                param["pubkey"] = Util.EncodeBase64(Config.pub_key);

                Util.HttpPost(out flag, out result_data, out error, uri, param);
                if (flag)
                {
                    //销毁个人缓存文件
                    File.Delete(Program.ConfigPath);

                    //认证成功修改缓存文件
                    Hashtable userHashTable = new Hashtable();
                    //MessageBox.Show(result_data);
                    userHashTable      = JsonConvert.DeserializeObject<Hashtable>(result_data);
                    String security_id = userHashTable["security_id"].ToString();
                    String uid         = userHashTable["uid"].ToString();
                    //String email       = userHashTable["email"].ToString();
                    string path        = Config.path;
                    
                    Config.uid         = uid;
                    Config.username    = username;
                    Config.security_id = security_id;
                    //Config.email = email;

                    Hashtable pandoraConfig = new Hashtable();
                    pandoraConfig["uid"]         = Config.uid;
                    pandoraConfig["security_id"] = Config.security_id;
                    pandoraConfig["username"]    = Config.username;
                    //pandoraConfig["email"]       = Config.email;
                    pandoraConfig["pri_key_des"] = Config.pri_key_des;
                    pandoraConfig["pub_key"]     = Config.pub_key;

                    //写入缓存文件
                    Util.savePandoraCache(pandoraConfig);
                    
                    MainTab maintab = new MainTab();
                    maintab.Show();

                    this.Dispose();
                }
                else
                {
                    //认证失败，提示错误信息
                    msg_label.ForeColor = Color.Red;
                    msg_label.Text = "绑定失败！错误:" + error;
                    oa_usr_textBox.Focus();
                    bind_btn.Enabled = true;
                }
            }
            catch(Exception ee) {
                msg_label.ForeColor = Color.Red;
                msg_label.Text = "绑定失败！错误:"+ee.ToString();
                bind_btn.Enabled = true;
            }
        }

        private void later_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("OA帐号不绑定将无法进行信息的收发操作！", "友情提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                msg_label.ForeColor = Color.ForestGreen;
                msg_label.Text = "加载中...";
                MainTab tab = new MainTab();
                tab.Show();
                this.Dispose();
                
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
    }
}

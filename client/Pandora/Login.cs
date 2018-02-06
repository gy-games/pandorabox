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
using System.Data.SQLite;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Threading;


namespace PandoraBox
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            msg_label.Text = "";
            version.Text = Program.Version;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void login_btn_Click(object sender, EventArgs e)
        {
            String password_1 = textBox1.Text.Trim();
            msg_label.Text = "";
            //判断密码是否为空
            if (password_1 == "")
            {
                msg_label.ForeColor = Color.Red;
                msg_label.Text = "密码不能为空!";
                textBox1.Focus();
                return;
            }
           
            //读取Pandora配置
            Util.getPandoraCache();

            try
            {
                login_btn.Enabled = false;
                Config.pri_key = Util.DESDecrypt(Config.pri_key_des, password_1, "12345678");
                msg_label.ForeColor = Color.ForestGreen;
                msg_label.Text = "登录中...";
                if (!Config.uid.Equals("0"))
                {
                    /*/判断mac地址是否与
                    Config.mac = Util.getMac();
                    String mac_remote = Util.getRemoteMac(Config.uid);
                    if (!Config.mac.Equals(mac_remote))
                    {
                        MessageBox.Show("您的OA账号已被MAC地址(" + mac_remote + ")绑定，已无法收取新的加密信息。请重新尝试绑定OA帐号！"); 
                    }
                    */
                }
            }
            catch
            {
                msg_label.ForeColor = Color.Red;
                msg_label.Text = "密码错误,请重新输入!";
                msg_label.BringToFront();
                login_btn.Enabled = true;
                return;
            }
            Application.DoEvents();
            MainTab tab = new MainTab();
            tab.Show();
            this.Dispose();
        }
        
        private void can_btn_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            F_Main_FormClosing(null,null);
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

        private void reset_label_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("请注意！重置系统后,原接收消息及绑定信息将全部重置！", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                DialogResult drr = MessageBox.Show("请再次确认！确定重置系统？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (drr == DialogResult.OK)
                {
                    Util.initPandoraCache();

                    Config.uid = null;
                    Config.pri_key = "";
                    Config.pri_key_des = "";
                    Config.pub_key = "";
                    Config.security_id = "";

                    Initialize init = new Initialize();
                    init.Show();

                    this.Dispose();
                }
            }
        }
    }
}

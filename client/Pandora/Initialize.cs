using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using MaterialSkin.Controls;
using MaterialSkin;

namespace PandoraBox
{
    public partial class Initialize : MaterialForm
    {
        public Initialize()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            msg_label.Text = "";
        }


        private void init_btn_Click(object sender, EventArgs e)
        {
            String password_1 = textBox1.Text;
            String password_2 = textBox2.Text;
            msg_label.Text = "";
            if (password_1 != password_2)
            {
                msg_label.Text = "两次输入的密码不一致！";
                textBox1.Focus();
            }else if(password_1.Length<8){
                msg_label.Text = "密码至少8位！";
                textBox1.Focus();
            }
            else
            {
                //删除以前旧文件
                File.Delete(Program.ConfigPath);

                //生成公私秘钥
                RSACryptoServiceProvider rsa  = new RSACryptoServiceProvider();
                string pub_key = rsa.ToXmlString(false);
                string pri_key = rsa.ToXmlString(true);
                //保存公钥
                Config.pub_key = pub_key;
                Config.pri_key = pri_key;

                //获取desKey
                String pri_key_des = Util.DESEncrypt(pri_key, password_1, "12345678");
                Config.pri_key_des = pri_key_des;
                
                //保存pri_key_des
                Hashtable pandoraConfig = new Hashtable();
                pandoraConfig.Add("uid", "0");
                pandoraConfig.Add("username", " ");
                pandoraConfig.Add("security_id", "");
                pandoraConfig.Add("pri_key_des", pri_key_des);
                pandoraConfig.Add("pub_key", Config.pub_key);

                Util.savePandoraCache(pandoraConfig);

                Binding binding = new Binding();
                binding.Show();
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

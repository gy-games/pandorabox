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
using System.Security.Cryptography;
using System.Configuration;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Threading;



namespace PandoraBox
{
    public partial class Setting :  MaterialForm
    {
        public Setting()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            //oa_usr_text.Text = Config.email;
            pwd_msg.Text = "";
            //bind_msg.Text = "";
            //tabControl1.Visible = false;
            //tabPage2.IsAccessible = false;
        }

        /*/改绑OA
        private void bind_btn_Click(object sender, EventArgs e)
        {
            String email=oa_usr_text.Text.ToString().Trim();
            String password=oa_pwd_text.Text.ToString().Trim();
            bind_msg.ForeColor = Color.ForestGreen;
            bind_msg.Text = "绑定中...";
            bind_btn.Enabled = false;
            if ("".Equals(email)) {
                bind_msg.ForeColor = Color.Red;
                bind_msg.Text = "OA账号不能为空";
                oa_usr_text.Focus();
                bind_btn.Enabled = true;
                return;
            }
            else if ("".Equals(password))
            {
                bind_msg.ForeColor = Color.Red;
                bind_msg.Text = "OA密码不能为空";
                oa_pwd_text.Focus();
                bind_btn.Enabled = true;
                return;
            }
            else {

                String uri = "/api/save_pub_key";
                Hashtable param = new Hashtable();
                param["email"] = email;
                param["password"] = password;
                param["pubkey"] = Util.EncodeBase64(Config.pub_key);
                //param["email"] = email;


                Boolean flag = false;
                String  error = "";
                String  result_data = "";
                try
                {
                    Util.HttpPost(out flag, out result_data, out error, uri, param);
                    if (result_data != "" && flag)
                    {
                        //销毁个人缓存文件
                        File.Delete(Program.ConfigPath);

                        //认证成功修改缓存文件
                        Hashtable userHashTable = JsonConvert.DeserializeObject<Hashtable>(result_data);
                        String security_id = userHashTable["security_id"].ToString();
                        String uid = userHashTable["uid"].ToString();
                        string path = Config.path;

                        Config.uid         = uid;
                        Config.email       = email;
                        Config.security_id = security_id;

                        //保存配置
                        Hashtable pandoraConfig = new Hashtable();
                        pandoraConfig["uid"] = Config.uid;
                        pandoraConfig["security_id"] = Config.security_id;
                        pandoraConfig["email"] = Config.email;
                        pandoraConfig["pri_key_des"] = Config.pri_key_des;
                        pandoraConfig["pub_key"] = Config.pub_key;
                        Util.savePandoraCache(pandoraConfig);

                        oa_pwd_text.Text = "";
                        bind_msg.Text = "";
                        bind_btn.Enabled = true;
                        MessageBox.Show("帐号绑定成功！");
                    }
                    else
                    {
                        //认证失败，提示错误信息
                        bind_msg.ForeColor = Color.Red;
                        bind_msg.Text = "绑定失败！错误:" + error;
                        oa_usr_text.Focus();
                        bind_btn.Enabled = true;
                    }
                }
                catch (Exception ee)
                {
                    bind_msg.ForeColor = Color.Red;
                    bind_msg.Text = "绑定失败！错误:" + ee.ToString();
                    bind_btn.Enabled = true;
                }
            }
        }
        */

        private void change_pwd_btn_Click(object sender, EventArgs e)
        {
            //判断两次密码是否一致
            String password_1 = pwd_textBox1.Text;
            String password_2 = pwd_textBox2.Text;
            change_pwd_btn.Enabled = false;
            pwd_msg.ForeColor = Color.ForestGreen;
            pwd_msg.Text = "修改中...";
            
            if (password_1 != password_2)
            {
                pwd_msg.ForeColor = Color.Red;
                pwd_msg.Text = "两次输入的密码不一致！";
                pwd_textBox1.Focus();
                change_pwd_btn.Enabled = true;
            }
            else if (password_1.Length < 8)
            {
                pwd_msg.ForeColor = Color.Red;
                pwd_msg.Text = "密码至少为8位！";
                pwd_textBox1.Focus();
                change_pwd_btn.Enabled = true;
            }
            else
            {
                //销毁个人缓存文件
                File.Delete(Program.ConfigPath);

                //获取新加密私钥
                Config.pri_key_des = Util.DESEncrypt(Config.pri_key, password_1, "12345678");

                //保存配置
                Hashtable pandoraConfig = new Hashtable();
                pandoraConfig.Add("uid", Config.uid);
                pandoraConfig.Add("username", Config.username);
                //pandoraConfig.Add("mac", Config.mac);
                pandoraConfig.Add("security_id", Config.security_id);
                pandoraConfig.Add("pri_key_des", Config.pri_key_des);
                pandoraConfig.Add("pub_key", Config.pub_key);
                Util.savePandoraCache(pandoraConfig);

                pwd_textBox1.Text = "";
                pwd_textBox2.Text = "";

                pwd_msg.Text = "";
                change_pwd_btn.Enabled = true;
                MessageBox.Show("密码修改成功！");
            }
        }
        

    }
}

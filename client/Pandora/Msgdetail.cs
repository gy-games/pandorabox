using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;

namespace PandoraBox
{
    public partial class msgDetail : MaterialForm
    {
        public msgDetail(String msg,String memo)
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            memo_textBox.Text = memo;
            msg_textBox.ReadOnly = true;
            try
            {
                msg_textBox.Text = Util.RSADecrypt(Config.pri_key, msg);
            }
            catch
            {
                msg_textBox.Text = "本地秘钥已经失效，消息无法解密！";
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            MainTab tab = (MainTab)this.Owner;
            Config.mem = this.memo_textBox.Text;
            tab.saveMsgMemo();
            this.Close();
        }

        private void del_label_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("请确认！消息删除后将不可恢复！", "删除提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                MainTab tab = (MainTab)this.Owner;
                Config.mem = this.memo_textBox.Text;
                tab.delMsg();
                this.Close();
            }
            
        }

    }
}

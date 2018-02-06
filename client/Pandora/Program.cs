using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Diagnostics;

namespace PandoraBox
{
    

    static class Program
    {
        public static String Version = "v0.1.5";
        public static String AuthKey = "123qweasdzxc456rtyfghvbn";
        public static String ConfigPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "/file/pandoraCache.txt";
        public static String DbPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "/file/Pandora.sqlite";
        public static String ApiPath = System.Configuration.ConfigurationManager.AppSettings["host"];

        [STAThread]
        static void Main()
        {
            Process[] processes = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            if (processes.Length > 1)
            {
                MessageBox.Show("Pandora已启动！请勿多次启动！");
                System.Environment.Exit(1);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                Config.path = path;

                //读取Pandora配置
                Util.getPandoraCache();

                //判断用户状态
                if (Config.uid == null || "".Equals(Config.uid.Trim()) || "0".Equals(Config.uid.Trim()))
                {
                    Initialize register = new Initialize();
                    register.Show();
                }
                else
                {
                    Login login = new Login();
                    login.Show();
                }

                Application.Run();
            }

        }

    }
}

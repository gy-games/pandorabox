using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace PandoraBox
{
    class Config
    {
        //public static String autoClose = "1";  //1自动关闭  2 手动关闭
        public static int row_index=0;
        public static int column_index=0;

        public static String mem = "";
        public static int id = 0;
        //public static String mac = "";
        public static String path = "";

        public static List<String> all_user = new List<string>();

        public static Dictionary<String,Hashtable> all_user_map = new Dictionary<String,Hashtable>();

        //部门下的部门列表
        public static Dictionary<String, List<String>> depart_all_depart = new Dictionary<String, List<String>>();
        //部门下的员工列表
        public static Dictionary<String, List<String>> depart_all_user = new Dictionary<String, List<String>>();

        public static List<String> depart_user_ids = new List<string>();
        public static Hashtable send_user = new Hashtable();
        

        //持久化数据
        public static String uid = "0";
        //public static String email = "";
        public static String username = "";
        public static String security_id = "";
        public static String pri_key_des = "";
        public static String pub_key = "";

        public static String pri_key = "";

        //用于搜索
        public static List<Hashtable> all_user_search = new List<Hashtable>();

    }
}

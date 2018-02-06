using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Net;
using System.Data.SQLite;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;

namespace PandoraBox
{
    class Util
    {

        //Base64加码
        public static string EncodeBase64(string source)
        {
            Encoding encode=Encoding.UTF8;
            string enString = "";
            byte[] bytes = encode.GetBytes(source);
            try
            {
                enString = Convert.ToBase64String(bytes);
            }
            catch
            {
                enString = source;
            }
            return enString;
        }

        //Base64解码
        public static string DecodeBase64( string result)
        {
            Encoding encode=Encoding.UTF8;
            string decode = "";
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = result;
            }
            return decode;
        }

        //RSA加密
        public static string RSAEncrypt(string publicKey, string rawInput)
        {
            if (string.IsNullOrEmpty(rawInput))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(publicKey))
            {
                throw new ArgumentException("Invalid Public Key");
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var inputBytes = Encoding.UTF8.GetBytes(rawInput);//有含义的字符串转化为字节流
                rsaProvider.FromXmlString(publicKey);//载入公钥
                int bufferSize = (rsaProvider.KeySize / 8) - 11;//单块最大长度
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    { //分段加密
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var encryptedBytes = rsaProvider.Encrypt(temp, false);
                        outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return Convert.ToBase64String(outputStream.ToArray());//转化为字节流方便传输
                }
            }

        }

        //RSA解密
        public static string RSADecrypt(string privateKey, string encryptedInput)
        {
            if (string.IsNullOrEmpty(encryptedInput))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw new ArgumentException("Invalid Private Key");
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var inputBytes = Convert.FromBase64String(encryptedInput);
                rsaProvider.FromXmlString(privateKey);
                int bufferSize = rsaProvider.KeySize / 8;
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var rawBytes = rsaProvider.Decrypt(temp, false);
                        outputStream.Write(rawBytes, 0, rawBytes.Length);
                    }
                    return Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }
        }

        //初始化Prandora
        public static void initPandoraCache() {
            try
            {
                //清理数据库
                SQLiteConnection dbConn = new SQLiteConnection("Data Source=" + Program.DbPath + ";Version=3;");
                dbConn.Open();
                SQLiteCommand cmd = dbConn.CreateCommand();
                string sql = " delete from message;";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                dbConn.Close();
                //清理配置文件
                File.Delete(Program.ConfigPath);
                Hashtable pandoraConfig = new Hashtable();
                pandoraConfig.Add("uid", " ");
                pandoraConfig.Add("security_id", " ");
                pandoraConfig.Add("pri_key_des", " ");
                pandoraConfig.Add("username", " ");
                pandoraConfig.Add("pub_key", " ");
            
                //初始化操作，生成缓存文件
                FileStream fs = new FileStream(Program.ConfigPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                string result = JsonConvert.SerializeObject(pandoraConfig);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(result);
                sw.Flush();
                sw.Close();
                fs.Close(); 
            }
            catch (Exception e)
            {
                MessageBox.Show("系统错误,程序初始化失败！" + e.ToString());
                Application.Exit();
            }
             
        }

        //保存缓存文件
        public static void savePandoraCache(Hashtable pandoraConfig)
        {
            try
            {
                FileStream fs = new FileStream(Program.ConfigPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                string result = JsonConvert.SerializeObject(pandoraConfig);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(result);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception e) {
                MessageBox.Show("系统错误,配置文件保存失败！"+e.ToString());
                Application.Exit();
            }
        }

        //读取配置文件
        public static void getPandoraCache() {
            //读取缓存文件
            StreamReader sr = null;
            String path = Config.path;
            try
            {
                sr = new StreamReader(Program.ConfigPath, Encoding.Default);
                String line = sr.ReadLine();
                Hashtable pandoraConfig = new Hashtable();
                pandoraConfig = JsonConvert.DeserializeObject<Hashtable>(line);
                Config.uid         = pandoraConfig["uid"].ToString();
                Config.security_id = pandoraConfig["security_id"].ToString();
                Config.pri_key_des = pandoraConfig["pri_key_des"].ToString();
                Config.username     = pandoraConfig["username"].ToString();
                Config.pub_key     = pandoraConfig["pub_key"].ToString();
                sr.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("系统错误,配置文件读取失败！" + e.ToString());
                Application.Exit();
            }
        }

        //C# DES解密方法  
        public static string DESDecrypt(string encryptedValue, string key, string iv)
        {
            key = Util.MD5Encrypt32(key).Substring(0, 8);
            using (DESCryptoServiceProvider sa = new DESCryptoServiceProvider { Key = Encoding.UTF8.GetBytes(key), IV = Encoding.UTF8.GetBytes(iv) })
            {
                using (ICryptoTransform ct = sa.CreateDecryptor())
                {
                    byte[] byt = Convert.FromBase64String(encryptedValue);

                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            cs.Write(byt, 0, byt.Length);
                            cs.FlushFinalBlock();
                        }
                        return Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
        }

        //C# DES加密方法  
        public static string DESEncrypt(string originalValue, string key, string iv)
        {
            key = Util.MD5Encrypt32(key).Substring(0,8);
            using (DESCryptoServiceProvider sa  = new DESCryptoServiceProvider { Key = Encoding.UTF8.GetBytes(key), IV = Encoding.UTF8.GetBytes(iv) })
            {
                using (ICryptoTransform ct = sa.CreateEncryptor())
                {
                    byte[] by = Encoding.UTF8.GetBytes(originalValue);
                    using (var ms = new MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, ct, CryptoStreamMode.Write))
                        {
                            cs.Write(by, 0, by.Length);
                            cs.FlushFinalBlock();
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        //GET请求
        public static void HttpGet(out Boolean flag, out String result, out String error, string uri, Hashtable param, String sec_key = "")
        {
            Hashtable Result = new Hashtable();
            flag = false;
            result = "";
            error = "";
            try
            {
                param["timestamp"] = Util.GetTimeStamp();
                param["sign_type"] = "md5";
                ArrayList akeys = new ArrayList(param.Keys);
                akeys.Sort();
                String pre_sign = uri + "?";
                foreach (string skey in akeys)
                {
                    pre_sign = pre_sign + skey + "=" + param[skey].ToString().Replace(" ", "") + "&";
                }
                String sign = Util.MD5Encrypt32(pre_sign.Substring(0, pre_sign.Length - 1) + Program.AuthKey + sec_key);
                String url = Program.ApiPath+pre_sign + "&sign=" + sign;
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method         = "GET";
                request.Accept         = "text/html, application/xhtml+xml, */*";
                request.ContentType    = "application/json";
                request.Timeout        = 5 * 1000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    Result = JsonConvert.DeserializeObject<Hashtable>(reader.ReadToEnd());
                    flag   = Result.ContainsKey("flag") ? bool.Parse(Result["flag"].ToString()) : false;
                    result = Result.ContainsKey("result") ? (Result["result"] != null ? Result["result"].ToString() : "") : "";
                    error = Result.ContainsKey("error") ? (Result["error"]!=null ? Result["error"].ToString() : "") : "";
                }
            }
            catch(Exception e) {
                error = e.ToString();
            }
            
        }

        //POST请求
        public static void HttpPost(out Boolean flag, out String result, out String error, String uri, Hashtable param, String sec_key="")
        {
            flag = false;
            result = "";
            error = "";
            try {

                param["timestamp"] = Util.GetTimeStamp();
                param["sign_type"] = "md5";
                ArrayList akeys = new ArrayList(param.Keys);
                akeys.Sort();
                String pre_sign = uri + "?";
                foreach (string skey in akeys)
                {
                    if (skey != "data")
                    {
                        pre_sign = pre_sign + skey + "=" + param[skey].ToString().Replace(" ", "") + "&";
                    }
                }
                //MessageBox.Show(pre_sign);
                String sign = Util.MD5Encrypt32(pre_sign.Substring(0, pre_sign.Length - 1) + Program.AuthKey + sec_key);
                param["sign"] = sign;
                String url = Program.ApiPath + uri;
                String body = JsonConvert.SerializeObject(param);
                Encoding encoding = Encoding.UTF8;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.ContentType = "application/json";
                request.Timeout = 5 * 1000;
                byte[] buffer = encoding.GetBytes(body);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    Hashtable Result = JsonConvert.DeserializeObject<Hashtable>(reader.ReadToEnd());
                    flag   = Result.ContainsKey("flag") ? bool.Parse(Result["flag"].ToString()) : false;
                    result = Result.ContainsKey("result") ? (Result["result"] != null ? Result["result"].ToString() : "") : "";
                    error = Result.ContainsKey("error") ? (Result["error"]!=null ? Result["error"].ToString() : "") : "";
                }
            }
            catch (Exception e)
            {
                error = e.ToString();
            }
        }

        //32位MD5加密
        public static string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create(); 
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X2");
            }
            return pwd;
        }

        //获取当前时间戳
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            Int64 timeint= Convert.ToInt64(ts.TotalMilliseconds);
            return (timeint / 1000).ToString();
        }  

    }
}

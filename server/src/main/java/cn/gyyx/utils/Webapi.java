package cn.gyyx.utils;

import com.alibaba.fastjson.JSON;
import org.springframework.beans.factory.annotation.Value;

import java.io.*;
import java.util.Map;
import java.util.TreeMap;
import java.net.HttpURLConnection;
import java.net.URL;
import java.security.MessageDigest;

public class Webapi{

	private String SECRETKEY;
	private String DOMAIN;
	private String URI;

    public Webapi(String SECRETKEY,String DOMAIN,String URI){

		this.SECRETKEY	= SECRETKEY;
		this.DOMAIN		= DOMAIN;
		this.URI		= URI;
	}

	/**
	 * 发送信息
	 *
	 */
	public String send(Map<String, String> query, Boolean post){

		String url = "http://"+this.DOMAIN+this.URI+"?";
		String sign = this.create_sign(query);

		String info = "";
		for(Object m: query.keySet()){
				url = url + m + "=" + query.get(m) + "&";
		}
		url  =url+"sign_type=MD5&sign="+sign;

		info = this.urlConnect(url);

		return info;

	}

	/**
	 * 发送信息
	 *
	 */
	public String sendPost(Map<String, String> query, Map<String,String> param){
		String url = "http://"+this.DOMAIN+this.URI+"?";
		String sign = this.create_sign(query);
		String info = "";
		for(Object m: query.keySet()){
			url = url + m + "=" + query.get(m) + "&";
		}
		url  =url+"sign_type=MD5&sign="+sign;
		info = this.urlConnectPOST(url,param);
		return info;

	}

	/**
	 * 生成URL签名
	 * @param query
	 * @return 签名
	 */
	private String create_sign(Map<String, String> query){
		query.put("timestamp", Long.toString(System.currentTimeMillis()).substring(0, 10));
		String url = this.URI+"?";
		for(Object m: query.keySet()){
			url = url+m+"="+query.get(m)+"&";
		}
		String urltomd5 = url.substring(0,url.length()-1)+this.SECRETKEY;   //根据OA签名规则获取将要签名的串
		String sign = this.MD5(urltomd5);  //进行签名操作
		return sign;
	}

	/**
	 * MD5加密实现
	 * @param s
	 * @return
	 */
	private  String MD5(String s) {
		char hexDigits[]={'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'};
		try {
			byte[] btInput = s.getBytes();
			// 获得MD5摘要算法的 MessageDigest 对象
			MessageDigest mdInst = MessageDigest.getInstance("MD5");
			// 使用指定的字节更新摘要
			mdInst.update(btInput);
			// 获得密文
			byte[] md = mdInst.digest();
			// 把密文转换成十六进制的字符串形式
			int j = md.length;
			char str[] = new char[j * 2];
			int k = 0;
			for (int i = 0; i < j; i++) {
				byte byte0 = md[i];
				str[k++] = hexDigits[byte0 >>> 4 & 0xf];
				str[k++] = hexDigits[byte0 & 0xf];
			}
			return new String(str);
		} catch (Exception e) {
			e.printStackTrace();
			return null;
		}
	}

	/**
	 * 发送请求
	 * @param urlAddr
	 * @return
	 */
	private  String urlConnect(String urlAddr){
		URL u = null;
		HttpURLConnection con = null;
		try {
			u = new URL(urlAddr);
			con = (HttpURLConnection) u.openConnection();
			con.setDoOutput(true);
			con.setDoInput(true);
			con.setUseCaches(false);
			con.setRequestMethod("GET");
			con.connect();

		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			if (con != null) {
				con.disconnect();
			}
		}
		String result = "";
		try {
			BufferedReader reader = new BufferedReader(new InputStreamReader(
					con.getInputStream()));
			result = reader.readLine();//读取请求结果
			reader.close();
		} catch(Exception e){
			try {
				BufferedReader reader = new BufferedReader(new InputStreamReader(
						con.getErrorStream()));
				result = reader.readLine();//读取请求结果
				reader.close();
			}catch (Exception ex){
				ex.printStackTrace();
			}
		}
		return result.toString();
	}

	/**
	 * 发送请求    POST
	 * @param urlAddr
	 * @return
	 */
	private  String urlConnectPOST(String urlAddr, Map query){
		URL u = null;
		HttpURLConnection con = null;
		try {
			u = new URL(urlAddr);
			con = (HttpURLConnection) u.openConnection();
			con.setDoOutput(true);
			con.setDoInput(true);
			// 设置不用缓存
			con.setUseCaches(false);
			// 设置传递方式
			con.setRequestMethod("POST");
			// 设置维持长连接
			con.setRequestProperty("Connection", "Keep-Alive");
			// 设置文件字符集:
			con.setRequestProperty("Charset", "UTF-8");
			//转换为字节数组
			byte[] data = (JSON.toJSONString(query).toString()).getBytes();
			// 设置文件长度
			con.setRequestProperty("Content-Length", String.valueOf(data.length));
			// 设置文件类型:
			con.setRequestProperty("Content-Type", "application/json");
			// 开始连接请求
			con.connect();
			OutputStreamWriter writer = new OutputStreamWriter(con.getOutputStream());
			//发送参数
			writer.write(JSON.toJSONString(query).toString());
			//清理当前编辑器的左右缓冲区，并使缓冲区数据写入基础流
			writer.flush();

		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			if (con != null) {
				con.disconnect();
			}
		}
		String result = "";
		try {
			BufferedReader reader = new BufferedReader(new InputStreamReader(
					con.getInputStream()));
			result = reader.readLine();//读取请求结果
			reader.close();
		} catch(Exception e){
			try {
				BufferedReader reader = new BufferedReader(new InputStreamReader(
						con.getErrorStream()));
				result = reader.readLine();//读取请求结果
				reader.close();
			}catch (Exception ex){
				ex.printStackTrace();
			}
		}
		return result.toString();
	}

	/*
     * ##################################### 以下为测试内容, 请删除####################
     */
	public static void main(String[] args)
	{
		//param1:秘钥
		//param2:接口域名 域名不需要写 http://
		//param1:接口URI
		Webapi test = new Webapi("","","");

		//参数(注意：必须是TreeMap)
		Map<String,String> map =  new TreeMap<String,String>();
		map.put("a", "a");
		map.put("b", "b");
		map.put("c", "c");
		map.put("d", "d");

		String info = test.send(map,false);

		System.out.println(info);

	}


}
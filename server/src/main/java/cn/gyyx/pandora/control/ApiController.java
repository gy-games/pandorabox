package cn.gyyx.pandora.control;

import cn.gyyx.Application;
import cn.gyyx.pandora.business.ApiBusiness;
import cn.gyyx.pandora.model.*;

import com.alibaba.fastjson.JSON;

import com.alibaba.fastjson.JSONArray;
import org.apache.commons.lang.StringUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.RequestAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.*;
import java.lang.String;


@RestController
public class ApiController {

    protected static Logger logger= LoggerFactory.getLogger(Application.class);

    @Autowired
    private ApiBusiness userBusiness;

    //获取组织结构
    @RequestMapping("api/get_list_by_depart_id")
    public String get_list_by_depart_id(@RequestAttribute("param") HashMap<String,String> data) {
        HashMap<String,String> result = new HashMap<>();
        result.put("flag","false");
        result.put("error","");
        result.put("result","");
        if(StringUtils.isEmpty(data.get("did"))){
            result.put("error","Did Missing");
            return JSON.toJSONString(result);
        }
        try{
            List<DptUsr> msgList = userBusiness.getDptUsr(data.get("did"));
            result.put("flag","true");
            result.put("result", JSON.toJSONString(msgList));
        }catch(Exception e){
            result.put("error",e.toString());
        }
        logger.info(JSON.toJSONString(result));
        return JSON.toJSONString(result);
    }

    //获取当前用户未读的密文信息
    @RequestMapping("/api/get_msg")
    public String get_msg(@RequestAttribute("param") HashMap<String,String> data) {
        HashMap<String,String> result = new HashMap<>();
        result.put("flag","false");
        result.put("error","");
        result.put("result","");
        if(StringUtils.isEmpty(data.get("uid"))){
            result.put("error","Uid Missing");
            return JSON.toJSONString(result);
        }
        try{
            List<Message> msgList = userBusiness.getMsg(data.get("uid"));
            result.put("flag","true");
            result.put("result", JSON.toJSONString(msgList));
        }catch(Exception e){
            result.put("error",e.toString());
        }
        logger.info(JSON.toJSONString(result));
        return JSON.toJSONString(result);
    }

    //绑定用户
    @RequestMapping(value = "/api/save_pub_key")
    public String save_pub_key(@RequestAttribute("param") HashMap<String,String> data) {
        HashMap result = new HashMap();
        result.put("flag","false");
        result.put("error","");
        result.put("result","");
        if(StringUtils.isEmpty(data.get("username"))){
            result.put("error","User Name Missing");
            return JSON.toJSONString(result);
        }
        if(StringUtils.isEmpty(data.get("password"))){
            result.put("error","User Password Missing");
            return JSON.toJSONString(result);
        }
        if(StringUtils.isEmpty(data.get("pubkey"))){
            result.put("error","User Pubkey Missing");
            return JSON.toJSONString(result);
        }
        HashMap<String ,String > rst = userBusiness.savePubkey(data.get("pubkey"),data.get("username"),data.get("password"));
        if(rst!=null){
            result.put("flag","true");
            result.put("result",rst);
        }else{
            result.put("error","Password Error or User Not Found!");
        }
        logger.info(JSON.toJSONString(result));
        return JSON.toJSONString(result);
    }

    //保存用户发送的密文信息
    @RequestMapping("/api/send_msg")
    public String send_msg(@RequestAttribute("param") HashMap<String,Object> data) {
        HashMap<String,String> result = new HashMap<>();
        result.put("flag","false");
        result.put("error","");
        result.put("result","");
        if(data.get("title").toString()==""){
            result.put("error","Title不可为空！");
            return JSON.toJSONString(result);
        }
        if(data.get("title").toString().contains("'")){
            result.put("error","Title包含非法字符(')！");
            return JSON.toJSONString(result);
        }
        try{
            userBusiness.sendMsg(data.get("uid").toString(),data.get("title").toString(),(JSONArray) data.get("data"));
            result.put("flag","true");
        }catch(Exception e){
            result.put("error",e.toString());
        }
        logger.info(JSON.toJSONString(result));
        return JSON.toJSONString(result);
    }

    //根据用户uids获取pubkey列表
    @RequestMapping("/api/get_pub_key")
    public Object get_pub_key(@RequestAttribute("param") HashMap<String,String> data) {
        HashMap<String,Object> result = new HashMap<>();
        result.put("flag","false");
        result.put("error","");
        result.put("result","");
        if(StringUtils.isEmpty(data.get("uids"))){
            result.put("error","Uids Missing");
            return JSON.toJSONString(result);
        }
        try{
            HashMap<String,String> pbkList = userBusiness.getPubkey(data.get("uids"));
            result.put("flag","true");
            result.put("result", pbkList);
        }catch(Exception e){
            e.printStackTrace();
            result.put("error",e.toString());
        }
        //System.out.println(JSON.toJSONString(result));
        logger.info(JSON.toJSONString(result));
        return JSON.toJSONString(result);
    }
}

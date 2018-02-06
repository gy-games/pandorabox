package cn.gyyx.pandora.business;

import cn.gyyx.pandora.model.DptUsr;
import cn.gyyx.pandora.model.Message;
import com.alibaba.fastjson.JSONArray;

import java.util.HashMap;
import java.util.List;

public interface ApiBusiness {

    //获取组织结构
    List<DptUsr> getDptUsr(String did);

    //获取未读信息
    List<Message> getMsg(String uid);

    //保存信息
    Boolean sendMsg(String uid, String title,JSONArray data);

    //保存用户公钥
    HashMap<String,String> savePubkey(String pubkey,String username,String passwd);

    //获取用户公钥
    HashMap<String,String> getPubkey(String uids);

}

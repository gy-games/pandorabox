package cn.gyyx.pandora.business.impl;

import cn.gyyx.pandora.model.*;
import cn.gyyx.pandora.business.ApiBusiness;

import cn.gyyx.pandora.thirdparty.CommonImpl;
import com.alibaba.fastjson.JSONArray;
import com.alibaba.fastjson.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import cn.gyyx.pandora.dao.ApiDao;
import org.springframework.transaction.annotation.Transactional;


import java.util.*;

@Service
@Transactional
public class ApiBusinessImpl implements ApiBusiness {

	@Autowired(required = false)
	private ApiDao apiDao;

	@Override
	public List<DptUsr> getDptUsr(String did){
		List<DptUsr> msgList = apiDao.queryDepartById(did);
		return msgList;
	}

	@Override
	public List<Message> getMsg(String uid){
		//获取未读信息
		List<Message> msgList = apiDao.queryMsgByUid(uid);
		//更新读取标识
		apiDao.updateMsgFlag(uid);
		return msgList;
	}

	@Override
	public Boolean sendMsg(String uid, String title,JSONArray data){
		Boolean result = false;
		for (int i = 0; i < data.size(); i++) {
			JSONObject oneMsg = (JSONObject)data.get(i);
			Map msg  = new HashMap();
			msg.put("title", title);
			msg.put("text", oneMsg.get("text"));
			msg.put("send_id", uid);
			msg.put("receive_id", oneMsg.get("uid"));
			apiDao.saveMsg(msg);
		}
		result = true;
		return result;
	}



	@Override
	public HashMap<String,String> savePubkey(String pubkey,String username,String passwd) {
		HashMap<String,String> result = new HashMap<>();
		User localPwd = apiDao.queryPwdByUsername(username);
		if (localPwd==null){
			return null;
		}
		if(localPwd.getPassword()==null){
			if(CommonImpl.thridAuth(username,passwd)){
				HashMap usermap = new HashMap();
				usermap.put("pubkey", pubkey);
				usermap.put("username", username);
				Random random = new Random();
				String security_id="";
				for (int i=0;i<8;i++)
				{
					security_id+=random.nextInt(16);
				}
				usermap.put("security_id", security_id);
				result.put("security_id",security_id);
				//result.put("email",security_id);
				result.put("uid",localPwd.getUid().toString());
				apiDao.savePubkey(usermap);
			}else{
				return null;
			}
		}else{
			if(!localPwd.equals(passwd)){
				return null;
			}
		}
		return result;
	}

	@Override
	public HashMap<String,String> getPubkey(String uids){
		HashMap<String,String> result = new HashMap<>();
		List<Pubkey> pubkeyList = apiDao.queryPubkeysBuUids(uids);
		for (Pubkey pbk : pubkeyList) {
			result.put(pbk.getUid().toString(),pbk.getPublic_key()==null?"":pbk.getPublic_key().toString());
		}
		return result;
	}
}
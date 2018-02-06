package cn.gyyx.pandora.dao;

import cn.gyyx.pandora.model.*;
import org.apache.ibatis.annotations.*;

import java.util.List;
import java.util.Map;

@Mapper
public interface ApiDao {

    //保存当前用户的PubKey
    @Update("UPDATE user SET public_key = #{pubkey},security_id = #{security_id} WHERE username = #{username}")
    void savePubkey(Map<String, String> map);

    //获取当前用户未读的密文信息
    @Select("SELECT send_name,message,title,send_time FROM message WHERE receive_id = #{uid} and flag = 0")
    List<Message> queryMsgByUid(String uid);

    //更改信息获取后的状态
    @Update("UPDATE message SET read_time = now(),flag = 1 WHERE receive_id = #{uid}")
    void updateMsgFlag(String uid);

    //根据用户uids获取publickey
    @Select("SELECT uid,public_key FROM user WHERE uid in (${uids})  AND off_work != 0")
    List<Pubkey> queryPubkeysBuUids(@Param("uids")String uids);

    //保存用户发送的密文信息
    @Insert("INSERT INTO message(title,message,send_id,send_name,receive_id,send_time,flag) values(#{title},#{text},#{send_id},(SELECT `name` from `user` where uid = #{send_id}),#{receive_id},now(),0)")
    Integer saveMsg(Map map);

    //根据收件id获取收件人姓名
    @Select("SELECT uid FROM user WHERE email = #{email} AND off_work != 0")
    String queryUidByEmail(String email);

    //根据UID获取用户SecurityId
    @Select("SELECT security_id FROM user WHERE uid = #{uid} AND off_work != 0")
    String querySecIdByUid(String uid);

    //根据Email获取用户密码
    @Select("SELECT uid,password,email FROM user WHERE username = #{username} AND off_work != 0 limit 1")
    User queryPwdByUsername(String email);

    //根据部门ID获取组织结构
    @Select("select did as `id`,`name` as `name`,0 as `has_key`,0 as `type` from `department` where pcode = #{did} union all SELECT uid,`name`,IF(public_key is null,0,1),1 FROM `user` WHERE did = #{did}")
    List<DptUsr> queryDepartById(String did);

}

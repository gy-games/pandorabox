package cn.gyyx.pandora.dao;

import org.apache.ibatis.annotations.Insert;
import org.apache.ibatis.annotations.Mapper;
import org.apache.ibatis.annotations.Update;
import java.util.Map;

@Mapper
public interface StaffDao {

    //保存用户列表
    @Insert("INSERT INTO `user`(`username`,`name`,`email`,`did`,`off_work`,`refresh_time`) VALUES(#{username},#{name},#{email},#{did},2,NOW()) ON DUPLICATE KEY UPDATE did=#{did},off_work=2")
    void saveUserList(Map map);

    //保存部门列表
    @Insert("REPLACE INTO department(did,name,pcode) VALUES(#{did},#{name},#{pcode})")
    void saveDeptList(Map map);

    //更新员工状态
    @Update("UPDATE user SET off_work = IF(off_work=2,1,0)")
    void updateOffwork();

}

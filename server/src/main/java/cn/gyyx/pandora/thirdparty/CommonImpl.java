package cn.gyyx.pandora.thirdparty;

import cn.gyyx.pandora.dao.StaffDao;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Configurable;
import org.springframework.scheduling.annotation.EnableScheduling;
import org.springframework.scheduling.annotation.Scheduled;
import org.springframework.stereotype.Component;


@Component
@Configurable
@EnableScheduling
public class CommonImpl  {

    @Autowired(required = false)
    private StaffDao staffDao;

    //每天晚上02:00执行
    @Scheduled(cron = "0 0 2 * * ?")
    public void run() {
		saveDeptList("1");
		saveUserList();
		updateOffwork();
    }

    //第三方接口用户认证
    public static Boolean thridAuth(String username,String passwd){
        return false;
    }

    //第三方接口获取员工列表
    public void saveUserList() {
        /*
            Map<String,String>  uInfo = new HashMap();
            uInfo.put("name",name);
            uInfo.put("email",email);
            uInfo.put("did", did);
            uInfo.put("username", username);
            staffDao.saveUserList(uInfo);
        */
    }

    //第三方接口获取部门列表
    public void saveDeptList(String pdid) {
        /*
            Map deptmap = new HashMap();
            deptmap.put("did", did);
            deptmap.put("name", name);
            deptmap.put("pcode", pdid);
            System.out.println(deptmap);
            staffDao.saveDeptList(deptmap);
         */
    }

    //第三方接口更新员工状态
    public void updateOffwork() {
        staffDao.updateOffwork();
    }

}

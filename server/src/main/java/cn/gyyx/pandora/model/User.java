package cn.gyyx.pandora.model;

public class User {

    private Integer uid;            //员工id
    private String name;            //员工名称
    private String email;           //员工邮箱
    private String password;        //员工邮箱
    private Integer did;            //员工所属部门
    private String public_key;      //公钥
    private Integer security_id;    //随机生成四位数
    private Integer off_work;       //状态 （在职：1 离职：0）
    private String refresh_time;

    public String getRefresh_time() {
        return refresh_time;
    }

    public void setRefresh_time(String refresh_time) {
        this.refresh_time = refresh_time;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Integer getUid() {
        return uid;
    }

    public void setUid(Integer uid) {
        this.uid = uid;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Integer getDid() {
        return did;
    }

    public void setDid(Integer did) {
        this.did = did;
    }

    public String getPublic_key() {
        return public_key;
    }

    public void setPublic_key(String public_key) {
        this.public_key = public_key;
    }

    public Integer getSecurity_id() {
        return security_id;
    }

    public void setSecurity_id(Integer security_id) {
        this.security_id = security_id;
    }

    public Integer getOff_work() {
        return off_work;
    }

    public void setOff_work(Integer off_work) {
        this.off_work = off_work;
    }
}

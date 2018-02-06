package cn.gyyx.pandora.filter;

import cn.gyyx.pandora.dao.ApiDao;
import cn.gyyx.utils.Md5Util;
import com.alibaba.fastjson.JSON;
import org.apache.commons.io.IOUtils;
import org.apache.commons.lang.StringUtils;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import java.io.IOException;
import java.io.InputStream;
import java.util.*;
import cn.gyyx.utils.SpringContextUtil;

@WebFilter(urlPatterns = "/api/*")
public class SecurityFilter  implements Filter {

    private String authkey = "123qweasdzxc456rtyfghvbn";

    @Override
    public void destroy() {
        //System.out.println("过滤器销毁");
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response,
                         FilterChain chain) throws IOException, ServletException {
        HashMap<String,String> params = new HashMap();
        HttpServletRequest req = (HttpServletRequest)request;
        if("POST".equals(req.getMethod())){
            String contentStr="";
            InputStream is= null;
            try {
                is = request.getInputStream();
                contentStr= IOUtils.toString(is, "utf-8");
                params = JSON.parseObject(contentStr,HashMap.class);
            } catch (IOException e) {
                e.printStackTrace();
            }
        }else{
            for (Map.Entry<String, String[]> entry : request.getParameterMap().entrySet()) {
                params.put(entry.getKey(),entry.getValue()[0]);
            }
        }
        request.setAttribute("param",params);
        String result = validateSign(params,req);
        if("".equals(result)){
            chain.doFilter(request, response);
        }else{
            java.io.PrintWriter out = response.getWriter();
            HashMap rst = new HashMap();
            rst.put("flag","false");
            rst.put("error",result);
            rst.put("result","");
            out.println(JSON.toJSONString(rst));
        }
    }

    private String validateSign(HashMap<String,String> params, HttpServletRequest request){
        String sign = params.get("sign");
        String timestamp = params.get("timestamp");
        String sign_type = params.get("sign_type");
        String uid = params.get("uid");
        String signKey = authkey;
        if(StringUtils.isBlank(timestamp)){
            return "[301]Timestamp Missing!";
        }
        if(StringUtils.isBlank(sign_type)){
            return "[302]SignType Missing!";
        }
        if(StringUtils.isBlank(sign)){
            return "[303]Sign Missing!";
        }

        if((System.currentTimeMillis()/1000-60)> Long.valueOf(timestamp) || (System.currentTimeMillis()/1000+60) < Long.valueOf(timestamp)){
            return "[304]Sign Timeout!";
        }

        if(uid!=null){
            ApiDao apiService= SpringContextUtil.getBean(ApiDao.class);
            signKey=signKey+apiService.querySecIdByUid(uid);
        }

        StringBuffer sortUri = new StringBuffer();
        Set<String> keys = params.keySet();
        List<String> list = new ArrayList<String>();
        list.addAll(keys);
        Collections.sort(list);
        for (String k : list) {
            if (!"sign".equals(k)) {
                if(!k.equals("data")){
                    sortUri.append(k + "=");
                    sortUri.append((params.get(k) != null && params.get(k).length() > 0) ? params.get(k).toString() : "");
                    sortUri.append("&");
                }
            }
        }
        if(list!=null&&list.size()>0){
            sortUri.deleteCharAt(sortUri.length() - 1);
        }
        String signFinal = Md5Util.MD5(request.getRequestURI()+"?"+sortUri.toString().trim()+signKey);
        //System.out.println(request.getRequestURI()+"?"+sortUri.toString().trim()+signKey);
        if (sign.equalsIgnoreCase(signFinal)) {
            return "";
        }
        return "[305]Sign Failure!";
    }

    @Override
    public void init(FilterConfig config) throws ServletException {
        ///System.out.println("过滤器初始化");
    }
}

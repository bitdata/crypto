import java.io.File;  
import java.io.FileInputStream;  
import java.io.FileNotFoundException;  
import java.io.IOException;  
import java.io.UnsupportedEncodingException;  
import java.net.URLDecoder;  
import java.util.logging.Level;  
import java.util.logging.Logger;  
  
/** 
 * �ļ������� 
 * @author happyqing 
 */  
public class FileUtil {  
      
    /** 
     * �����Ļ�·�������jar��Ҳ������ȷ���·�� 
     * @return  
     */  
    public static String getBasePath(){  
        /* 
        /D:/zhao/Documents/NetBeansProjects/docCompare/build/classes/ 
        /D:/zhao/Documents/NetBeansProjects/docCompare/dist/bundles/docCompare/app/docCompare.jar 
        */  
        String filePath = FileUtil.class.getProtectionDomain().getCodeSource().getLocation().getFile();  
          
          
        if (filePath.endsWith(".jar")){  
            filePath = filePath.substring(0, filePath.lastIndexOf("/"));  
            try {  
                filePath = URLDecoder.decode(filePath, "UTF-8"); //���·�����пո�%20������  
            } catch (UnsupportedEncodingException ex) {  
  
            }  
  
        }  
        File file = new File(filePath);  
        filePath = file.getAbsolutePath();  
        return filePath;  
    }  
      
    public static void main(String[] args) throws Exception {  
        System.out.println(getBasePath());  
    }  
}  

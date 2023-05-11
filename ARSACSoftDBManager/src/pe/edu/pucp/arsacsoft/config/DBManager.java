package pe.edu.pucp.arsacsoft.config;
import java.sql.Connection;
import java.sql.DriverManager;
/**
 *
 * @author User
 */
public class DBManager {
    private static DBManager dbManager;
    private String url = "arsac-database.cxnwwqi3a0be.us-east-1.rds.amazonaws.com";
    private String user = "admin";
    private String password = "4L9b1mb0cqld01nfh2720b";
    private Connection con;
    
    private synchronized static void createInstance(){
        if(dbManager == null){
            dbManager = new DBManager();
        }
    }
    
    public Connection getConnection(){
        try{
            //Registrar el driver JDBC
            Class.forName("com.mysql.cj.jdbc.Driver");
            //Realizar la conexión
            con = DriverManager.getConnection(url,user,password);
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return con;
    }
    
    public static DBManager getInstance(){
        if(dbManager == null){
            createInstance();
        }
        return dbManager;
    }    
}

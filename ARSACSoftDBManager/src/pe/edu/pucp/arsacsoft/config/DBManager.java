package pe.edu.pucp.arsacsoft.config;

import java.sql.Connection;
import java.sql.DriverManager;

/**
 *
 * @author User
 */
public class DBManager {

    private static DBManager dbManager;
    private String url = "jdbc:mysql://" +
    "lp2-loshackersdelurin.cszyz9dgmmp6.us-east-1.rds.amazonaws.com" +
            ":3306/lp2-gino?useSSL=false";
    private String user = "admin";
    private String password = "Q1dpio1tu4kS4hYdmD2R";
    private Connection con;

    private synchronized static void createInstance() {
        if (dbManager == null) {
            dbManager = new DBManager();
        }
    }

    public Connection getConnection() {
        try {
            //Registrar el driver JDBC
            Class.forName("com.mysql.cj.jdbc.Driver");
            //Realizar la conexión
            con = DriverManager.getConnection(url, user, password);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return con;
    }

    public static DBManager getInstance() {
        if (dbManager == null) {
            createInstance();
        }
        return dbManager;
    }
}

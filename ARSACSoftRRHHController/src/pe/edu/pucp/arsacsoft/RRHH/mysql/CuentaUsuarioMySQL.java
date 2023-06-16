package pe.edu.pucp.arsacsoft.RRHH.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import pe.edu.pucp.arsacsoft.RRHH.dao.CuentaUsuarioDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;

public class CuentaUsuarioMySQL implements CuentaUsuarioDAO {

    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
    @Override
    public int verificar(String usuario, String contrasenha) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call VERIFICAR_CUENTA_USUARIO"
                    + "(?,?)}");
            cs.setString("_username", usuario);
            cs.setString("_contrasenha", contrasenha);
            rs = cs.executeQuery();
            if(rs.next()){
                resultado = rs.getInt("id_empleado");
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }
    
}

package pe.edu.pucp.arsacsoft.RRHH.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import pe.edu.pucp.arsacsoft.RRHH.dao.CuentaUsuarioDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.CuentaUsuario;
import pe.edu.pucp.arsacsoft.config.DBManager;

public class CuentaUsuarioMySQL implements CuentaUsuarioDAO {
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
    @Override
    public int verificar(CuentaUsuario cuenta) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call VERIFICAR_CUENTA_USUARIO"
                    + "(?,?)}");
            cs.setString(1, cuenta.getUsername());
            cs.setString(2, cuenta.getPassword());
            rs = cs.executeQuery();
            while(rs.next()){
                
                resultado = rs.getInt("fid_empleado");
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    @Override
    public int insertarCuenta(CuentaUsuario cuenta) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_CUENTA_USUARIO"
                    + "(?,?,?,?)}");
            cs.registerOutParameter("_id_cuenta_usuario", java.sql.Types.INTEGER);
            cs.setInt("_fid_empleado", cuenta.getIdEmpleado());
            cs.setString("_usuario", cuenta.getUsername());
            cs.setString("_contrasena", cuenta.getPassword());
            rs = cs.executeQuery();
            resultado = rs.getInt("fid_empleado");
            
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }
}

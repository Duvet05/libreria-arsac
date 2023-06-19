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
    
        @Override
    public CuentaUsuario buscar(int idEmpleado) {
        CuentaUsuario cuenta = null;
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL BUSCAR_CUENTA_POR_EMPLEADO(?)}");
            cs.setInt(1, idEmpleado);
            

            rs = cs.executeQuery();
            if (rs.next())
            {
                cuenta = new CuentaUsuario();
                cuenta.setUsername(rs.getString("usuario"));
                byte[] contrasena = rs.getBytes("contrasena");
                
                cs = con.prepareCall("{CALL DecryptPassword(?,?)}");
                cs.clearParameters();
                cs.setBytes(1, contrasena);
                cs.registerOutParameter(2, java.sql.Types.VARCHAR);
                
                rs = cs.executeQuery();
                cuenta.setPassword(cs.getString(2));
                
            }
            
            
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        } 
        return cuenta;
    }

    @Override
    public int actualizar(CuentaUsuario cuenta) {
        int resultado = 0;
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL ACTUALIZAR_CUENTA_USUARIO(?,?,?)}");
            cs.setInt(1, cuenta.getIdEmpleado());
            cs.setString(2, cuenta.getUsername());
            cs.setString(3, cuenta.getPassword());
            
            cs.executeUpdate();
            resultado = 1;
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }  
        
        return resultado;
    }

}

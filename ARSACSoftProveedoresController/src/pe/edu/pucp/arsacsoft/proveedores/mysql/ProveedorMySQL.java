package pe.edu.pucp.arsacsoft.proveedores.mysql;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.proveedores.dao.ProveedorDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;
/**
 *
 * @author User
 */
public class ProveedorMySQL implements ProveedorDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    @Override
    public ArrayList<Proveedor> listarTodas() {
        ArrayList<Proveedor> proveedores = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            rs = cs.executeQuery();
            while(rs.next()){
                Proveedor proveedor = new Proveedor();
                
                proveedores.add(proveedor);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return proveedores;          
    }

    @Override
    public int insertar(Proveedor proveedor) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.registerOutParameter("", java.sql.Types.INTEGER);
            
            cs.executeUpdate();
            proveedor.setIdProveedor(cs.getInt(""));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;         
    }

    @Override
    public int modificar(Proveedor proveedor) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            
            cs.executeUpdate();      
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;            
    }

    @Override
    public int eliminar(int idproveedor) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("",idproveedor);
            cs.executeUpdate();
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;            
    }
    
}

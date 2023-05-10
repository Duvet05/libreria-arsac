
package pe.edu.pucp.arsacsoft.empleados.mysql;
import pe.edu.pucp.arsacsoft.empleados.model.Vendedor;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.empleados.dao.VendedorDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;
/**
 *
 * @author User
 */
public class VendedorMySQL implements VendedorDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    @Override
    public ArrayList<Vendedor> listarTodas(){
        ArrayList<Vendedor> vendedores = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            rs = cs.executeQuery();
            while(rs.next()){
                Vendedor vendedor = new Vendedor();
                
                vendedores.add(vendedor);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return vendedores;          
    }

    @Override
    public int insertar(Vendedor vendedor){
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.registerOutParameter("", java.sql.Types.INTEGER);
            
            cs.executeUpdate();
            vendedor.setIdUsuario(cs.getInt(""));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;         
    }

    @Override
    public int modificar(Vendedor vendedor){
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
    public int eliminar(int idempleado){
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("",idempleado);
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

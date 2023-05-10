
package pe.edu.pucp.arsacsoft.mayorista.mysql;
import pe.edu.pucp.arsacsoft.mayorista.model.ClienteMayorista;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.mayorista.dao.ClienteMayoristaDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;
/**
 *
 * @author User
 */
public class ClienteMayoristaMySQL implements ClienteMayoristaDAO{   
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    
    @Override
    public ArrayList<ClienteMayorista> listarTodas() {
        ArrayList<ClienteMayorista> clientes = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            rs = cs.executeQuery();
            while(rs.next()){
                ClienteMayorista cliente = new ClienteMayorista();
                
                clientes.add(cliente);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return clientes;           
    }

    @Override
    public int insertar(ClienteMayorista clienteMayorista) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.registerOutParameter("", java.sql.Types.INTEGER);
            
            cs.executeUpdate();
            clienteMayorista.setIdCliente(cs.getInt(""));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;          
    }

    @Override
    public int modificar(ClienteMayorista clienteMayorista) {
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
    public int eliminar(int idcliente) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("",idcliente);
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

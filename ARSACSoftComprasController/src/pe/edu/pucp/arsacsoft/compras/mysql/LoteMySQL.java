
package pe.edu.pucp.arsacsoft.compras.mysql;
import pe.edu.pucp.arsacsoft.compras.model.Lote;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.compras.dao.LoteDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;
/**
 *
 * @author User
 */
public class LoteMySQL implements LoteDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    @Override
    public ArrayList<Lote> listarTodas() {
        ArrayList<Lote> lotes = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            rs = cs.executeQuery();
            while(rs.next()){
                Lote lote = new Lote();
                
                lotes.add(lote);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return lotes;        
    }

    @Override
    public int insertar(Lote lote) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.registerOutParameter("", java.sql.Types.INTEGER);
            
            cs.executeUpdate();
            lote.setIdLote(cs.getInt(""));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;        
    }

    @Override
    public int modificar(Lote lote) {
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
    public int eliminar(int idlote) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("",idlote);
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

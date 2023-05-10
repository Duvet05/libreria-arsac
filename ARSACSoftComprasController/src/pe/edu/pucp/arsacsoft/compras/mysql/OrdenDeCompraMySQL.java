
package pe.edu.pucp.arsacsoft.compras.mysql;
import pe.edu.pucp.arsacsoft.compras.model.OrdenDeCompra;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.compras.dao.OrdenDeCompraDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;
/**
 *
 * @author User
 */
public class OrdenDeCompraMySQL implements OrdenDeCompraDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    @Override
    public ArrayList<OrdenDeCompra> listarTodas() {
        ArrayList<OrdenDeCompra> ordenes = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            rs = cs.executeQuery();
            while(rs.next()){
                OrdenDeCompra orden = new OrdenDeCompra();
                orden.setIdOrden(rs.getInt(""));
                orden.setFechaDeOrden(rs.getDate(""));
                orden.setEstado(rs.getBoolean(""));
                orden.setPreciotTotalCompra(rs.getDouble(""));
                ordenes.add(orden);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return ordenes;
    }

    @Override
    public int insertar(OrdenDeCompra ordenDeCompra) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.registerOutParameter("", java.sql.Types.INTEGER);
            cs.setDate("",new java.sql.Date(ordenDeCompra.getFechaDeOrden().getTime()));
            cs.setBoolean("", ordenDeCompra.isEstado());
            cs.setDouble("", ordenDeCompra.getPreciotTotalCompra());
            cs.setInt("", ordenDeCompra.getProveedor().getIdProveedor());
            cs.executeUpdate();
            ordenDeCompra.setIdOrden(cs.getInt(""));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    @Override
    public int modificar(OrdenDeCompra ordenDeCompra) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("", ordenDeCompra.getIdOrden());
            cs.setDate("",new java.sql.Date(ordenDeCompra.getFechaDeOrden().getTime()));
            cs.setBoolean("", ordenDeCompra.isEstado());
            cs.setDouble("", ordenDeCompra.getPreciotTotalCompra());
            cs.setInt("", ordenDeCompra.getProveedor().getIdProveedor());
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
    public int eliminar(int idorden) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("",idorden);
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

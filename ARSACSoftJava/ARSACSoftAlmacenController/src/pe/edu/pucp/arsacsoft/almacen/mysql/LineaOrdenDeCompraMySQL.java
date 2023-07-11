/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.dao.LineaOrdenDeCompraDAO;
import pe.edu.pucp.arsacsoft.almacen.model.LineaOrdenDeCompra;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Producto;

/**
 *
 * @author User
 */
public class LineaOrdenDeCompraMySQL implements LineaOrdenDeCompraDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
//    @Override
//    public ArrayList<LineaOrdenDeCompra> listarPorIdOrdenCompra(int idOrdenCompra) {
//        ArrayList<LineaOrdenDeCompra> lineasOrdenCompra = new ArrayList<>();
//        try{
//            con = DBManager.getInstance().getConnection();
//            cs = con.prepareCall("{call LISTAR_LINEAS_ORDEN_VENTA_X_ID_ORDEN_VENTA(?)}");
//            cs.setInt("_id_orden_venta", idOrdenCompra);
//            rs = cs.executeQuery();
//            while(rs.next()){
//                LineaOrdenDeCompra loc = new LineaOrdenDeCompra();
//                loc.setCantidad(rs.getInt(""));
//                loc.setCosto(rs.getDouble(""));
//                loc.setIdLineaOrdenDeCompra(rs.getInt(""));
//                loc.setProducto(new Producto());
//                loc.getProducto().setIdProducto(rs.getInt("id_producto"));
//                loc.getProducto().setNombre(rs.getString("nombre"));
//                loc.getProducto().setPrecioPorMayor(rs.getDouble(""));
//                loc.getProducto().setPrecioPorMenor(rs.getDouble(""));
//                lineasOrdenCompra.add(loc);
//            }
//        }catch(Exception ex){
//            System.out.println(ex.getMessage());
//        }finally{
//            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
//        }
//        return lineasOrdenCompra;        
//    }
    
}

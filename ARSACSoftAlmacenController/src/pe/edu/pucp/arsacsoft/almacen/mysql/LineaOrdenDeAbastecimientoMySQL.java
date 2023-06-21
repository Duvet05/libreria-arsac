/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.dao.LineaOrdenDeAbastecimientoDAO;
import pe.edu.pucp.arsacsoft.almacen.model.LineaDeOrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Producto;

/**
 *
 * @author User
 */
public class LineaOrdenDeAbastecimientoMySQL implements LineaOrdenDeAbastecimientoDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    @Override
    public ArrayList<LineaDeOrdenDeAbastecimiento> listarPorIdOrdenAbastecimiento(int idOrdenAbastecimiento) {
        ArrayList<LineaDeOrdenDeAbastecimiento> lineasOrdenAbastecimiento = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_LINEAS_ORDEN_ABASTECIMIENTO_X_ID_ORDEN_ABASTECIMIENTO(?)}");
            cs.setInt("_id_orden_de_abastecimiento", idOrdenAbastecimiento);
            rs = cs.executeQuery();
            while(rs.next()){
                LineaDeOrdenDeAbastecimiento loa = new LineaDeOrdenDeAbastecimiento();
                loa.setCantidad(rs.getInt("cantidad"));
                loa.setIdLineaOrdenDeAbastecimiento(rs.getInt("id_linea_orden_abastecimiento"));
                loa.setProducto(new Producto());
                loa.getProducto().setIdProducto(rs.getInt("id_producto"));
                loa.getProducto().setNombre(rs.getString("nombre"));
                loa.getProducto().setPrecioPorMayor(rs.getDouble("precio_por_mayor"));
                loa.getProducto().setPrecioPorMenor(rs.getDouble("precio_por_menor"));
                lineasOrdenAbastecimiento.add(loa);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return lineasOrdenAbastecimiento;          
    }
    
}

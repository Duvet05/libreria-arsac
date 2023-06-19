/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.dao.OrdenDeCompraDAO;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeCompra;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.almacen.model.LineaOrdenDeCompra;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User
 */
public class OrdenDeCompraMySQL implements OrdenDeCompraDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
    @Override
    public int insertar(OrdenDeCompra ordenCompra) {
                int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_ORDEN_COMPRA(?,?,?,?,?)}");
            cs.registerOutParameter("_id_orden_de_compra", java.sql.Types.INTEGER);
            cs.setInt("_fid_empleado", ordenCompra.getEmpleado().getIdPersona());
            cs.setInt("_fid_proveedor", ordenCompra.getProveedor().getIdProveedor());
            cs.setDate("_fecha_orden", new java.sql.Date(ordenCompra.getFechaOrden().getTime()));
            cs.setDouble("_total", ordenCompra.getCostototal());
            cs.executeUpdate();
            ordenCompra.setIdOrdenDeCompra(cs.getInt("_id_orden_de_compra"));
            for(LineaOrdenDeCompra lineaOrdenCompra : ordenCompra.getLineas()){
                cs = con.prepareCall("{INSERTAR_LINEA_ORDEN_COMPRA call (?,?,?,?,?)}");
                cs.registerOutParameter("_id_linea_orden_compra", java.sql.Types.INTEGER);
                cs.setInt("_fid_orden_de_compra", ordenCompra.getIdOrdenDeCompra());
                cs.setInt("_fid_producto", lineaOrdenCompra.getProducto().getIdProducto());
                cs.setInt("_cantidad", lineaOrdenCompra.getCantidad());
                cs.setDouble("_subtotal", lineaOrdenCompra.getCosto());
                cs.executeUpdate();
            }
            resultado = ordenCompra.getIdOrdenDeCompra();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    @Override
    public int modificar(OrdenDeCompra ordenCompra) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_ORDEN_COMPRA(?,?,?,?,?)}");
            cs.setInt("_id_orden_de_compra", ordenCompra.getIdOrdenDeCompra());
            cs.setInt("_fid_empleado", ordenCompra.getEmpleado().getIdPersona());
            cs.setInt("_fid_proveedor", ordenCompra.getProveedor().getIdProveedor());
            cs.setDate("_fecha_orden", new java.sql.Date(ordenCompra.getFechaOrden().getTime()));
            cs.setDouble("_total", ordenCompra.getCostototal());
            cs.executeUpdate();
            ordenCompra.setIdOrdenDeCompra(cs.getInt("_id_orden_de_compra"));
            for(LineaOrdenDeCompra lineaOrdenCompra : ordenCompra.getLineas()){
                cs = con.prepareCall("{call (?,?,?,?,?)}");
                cs.registerOutParameter("_id_linea_orden_compra", java.sql.Types.INTEGER);
                cs.setInt("_fid_orden_de_compra", ordenCompra.getIdOrdenDeCompra());
                cs.setInt("_fid_producto", lineaOrdenCompra.getProducto().getIdProducto());
                cs.setInt("_cantidad", lineaOrdenCompra.getCantidad());
                cs.setDouble("_subtotal", lineaOrdenCompra.getCosto());
                cs.executeUpdate();
            }
            resultado = ordenCompra.getIdOrdenDeCompra();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;        
    }

    @Override
    public int eliminar(int idOrdenCompra) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ELIMINAR_ORDEN_COMPRA(?)}");
            cs.setInt("_id_orden_de_compra", idOrdenCompra);
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
    public ArrayList<OrdenDeCompra> listarPorIdDNINombreEmpleado(String idDNINombreEmpleado) {
        ArrayList<OrdenDeCompra> ordenesCompra = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ORDENES_COMPRA_X_ID_NOMBRE_DNI_EMPLEADO(?)}");
            cs.setString("_id_nombre_dni_empleado", idDNINombreEmpleado);
            rs = cs.executeQuery();
            while(rs.next()){
                OrdenDeCompra ordenCompra = new OrdenDeCompra();
                ordenCompra.setIdOrdenDeCompra(rs.getInt("id_orden_de_compra"));
                ordenCompra.setCostototal(rs.getDouble("total"));
                ordenCompra.setEmpleado(new Empleado());
                ordenCompra.getEmpleado().setIdPersona(rs.getInt("fid_empleado"));
                ordenCompra.getEmpleado().setNombre(rs.getString("nombre"));
                ordenCompra.getEmpleado().setApellidos(rs.getString("apellidos"));
                ordenCompra.getEmpleado().setDNI(rs.getString("DNI"));
                ordenCompra.setFechaOrden(rs.getDate("fecha_orden"));
                ordenesCompra.add(ordenCompra);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return ordenesCompra;        
    }
    
}

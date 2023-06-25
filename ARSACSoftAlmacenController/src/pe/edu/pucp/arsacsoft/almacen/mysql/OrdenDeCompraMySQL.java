/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.almacen.dao.OrdenDeCompraDAO;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeCompra;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.almacen.model.LineaOrdenDeCompra;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Categoria;
import pe.edu.pucp.arsacsoft.producto.model.Marca;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.proveedores.model.ProductoXProveedor;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

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
                cs = con.prepareCall("{CALL INSERTAR_LINEA_ORDEN_COMPRA(?,?,?,?,?)}");
                cs.registerOutParameter("_id_linea_orden_compra", java.sql.Types.INTEGER);
                cs.setInt("_fid_orden_de_compra", ordenCompra.getIdOrdenDeCompra());
                cs.setInt("_fid_producto", lineaOrdenCompra.getProductoProveedor().getProducto().getIdProducto());
                cs.setInt("_cantidad", lineaOrdenCompra.getCantidad());
                cs.setDouble("_subtotal", lineaOrdenCompra.getSubtotal());
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
//
    @Override
    public int modificar(OrdenDeCompra ordenCompra) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_ORDEN_COMPRA(?,?,?,?)}");
            cs.setInt("_id_orden_de_compra", ordenCompra.getIdOrdenDeCompra());
            cs.setInt("_fid_empleado", ordenCompra.getEmpleado().getIdPersona());
            cs.setDouble("_total", ordenCompra.getCostototal());
            cs.setString("_estado", ordenCompra.getEstado());
            cs.executeUpdate();
            //ordenCompra.setIdOrdenDeCompra(cs.getInt("_id_orden_de_compra"));
            for(LineaOrdenDeCompra lineaOrdenCompra : ordenCompra.getLineas()){
                cs = con.prepareCall("{CALL INSERTAR_LINEA_ORDEN_COMPRA(?,?,?,?,?)}");
                cs.registerOutParameter("_id_linea_orden_compra", java.sql.Types.INTEGER);
                cs.setInt("_fid_orden_de_compra", ordenCompra.getIdOrdenDeCompra());
                cs.setInt("_fid_producto", lineaOrdenCompra.getProductoProveedor().getProducto().getIdProducto());
                cs.setInt("_cantidad", lineaOrdenCompra.getCantidad());
                cs.setDouble("_subtotal", lineaOrdenCompra.getSubtotal());
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

//    @Override
//    public int eliminar(int idOrdenCompra) {
//        int resultado = 0;
//        try{
//            con = DBManager.getInstance().getConnection();
//            cs = con.prepareCall("{call ELIMINAR_ORDEN_COMPRA(?)}");
//            cs.setInt("_id_orden_de_compra", idOrdenCompra);
//            cs.executeUpdate();
//            resultado = 1;
//        }catch(Exception ex){
//            System.out.println(ex.getMessage());
//        }finally{
//            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
//        }
//        return resultado;        
//    }
//
    @Override
    public ArrayList<OrdenDeCompra> listarPorProveedor(int idProveedor, Date fechaInicio, Date fechaFin, String estado) {
        ArrayList<OrdenDeCompra> ordenesCompra = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ORDENES_COMPRA_X_PROVEEDOR(?,?,?,?)}");
            cs.setInt("_id_proveedor", idProveedor);
            cs.setDate("_fecha_inicio", new java.sql.Date (fechaInicio.getTime()));
            cs.setDate("_fecha_fin", new java.sql.Date (fechaFin.getTime()));
            cs.setString("_estado", estado);
            
            rs = cs.executeQuery();
            while(rs.next()){
                OrdenDeCompra ordenCompra = new OrdenDeCompra();
                ordenCompra.setIdOrdenDeCompra(rs.getInt("id_orden_de_compra"));
                ordenCompra.setCostototal(rs.getDouble("total"));
                ordenCompra.setFechaOrden(rs.getDate("fecha_orden"));
                ordenCompra.setCostototal(rs.getDouble("total"));
                ordenCompra.setEstado(rs.getString("estado"));
                
                ordenCompra.setEmpleado(new Empleado());
                ordenCompra.getEmpleado().setIdPersona(rs.getInt("fid_empleado"));
                
                ordenCompra.setProveedor(new Proveedor());
                ordenCompra.getProveedor().setIdProveedor(rs.getInt("fid_proveedor"));
                ordenCompra.getProveedor().setNombre(rs.getString("nombre"));
                ordenCompra.getProveedor().setRUC(rs.getString("RUC"));
                ordenCompra.getProveedor().setTelefono(rs.getString("telefono"));
                ordenCompra.getProveedor().setDireccion(rs.getString("direccion"));
                
                ordenesCompra.add(ordenCompra);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return ordenesCompra;        
    }

//            cs = con.prepareCall("{CALL INSERTAR_LINEA_ORDEN_COMPRA(?,?,?,?,?)}");
//            cs.registerOutParameter("_id_linea_orden_compra", java.sql.Types.INTEGER);
//            cs.setInt("_fid_orden_de_compra", ordenCompra.getIdOrdenDeCompra());
//            cs.setInt("_fid_producto", lineaOrdenCompra.getProductoProveedor().getProducto().getIdProducto());
//            cs.setInt("_cantidad", lineaOrdenCompra.getCantidad());
//            cs.setDouble("_subtotal", lineaOrdenCompra.getSubtotal());
//            cs.executeUpdate();
    @Override
    public ArrayList<LineaOrdenDeCompra> listarLineasOrdenDeCompra(int idOrdenCompra) {
       ArrayList<LineaOrdenDeCompra> lineas = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_LINEAS_ORDEN_COMPRA_X_ID_ORDEN_COMPRA(?)}");
            cs.setInt("_id_orden_de_compra", idOrdenCompra);
            rs = cs.executeQuery();
            while(rs.next()){
                LineaOrdenDeCompra linea = new LineaOrdenDeCompra();
                linea.setIdLineaOrdenDeCompra(rs.getInt("id_linea_orden_compra"));
                linea.setCantidad(rs.getInt("cantidad"));
                linea.setSubtotal(rs.getDouble("subtotal"));
                
                linea.setProductoProveedor(new ProductoXProveedor());
                linea.getProductoProveedor().setCosto(rs.getDouble("costo"));
                linea.getProductoProveedor().setProducto(new Producto());
                linea.getProductoProveedor().getProducto().setIdProducto(rs.getInt("id_producto"));
                linea.getProductoProveedor().getProducto().setNombre(rs.getString("nombre"));
                linea.getProductoProveedor().getProducto().setMarca(new Marca());
                linea.getProductoProveedor().getProducto().setCategoria(new Categoria());
                linea.getProductoProveedor().getProducto().getMarca().setIdMarca(rs.getInt("id_marca"));
                linea.getProductoProveedor().getProducto().getMarca().setDescripcion(rs.getString("marca_descripcion"));
                linea.getProductoProveedor().getProducto().getCategoria().setIdCategoria(rs.getInt("id_categoria"));
                linea.getProductoProveedor().getProducto().getCategoria().setDescripcion(rs.getString("categoria_descripcion"));
                
                lineas.add(linea);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return lineas; 
    }
}

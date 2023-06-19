package pe.edu.pucp.arsacsoft.ordenes.mysql;


import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;

import pe.edu.pucp.arsacsoft.ordenes.model.LineaDeOrdenDeVenta;
import pe.edu.pucp.arcacsoft.ordenes.dao.LineaDeOrdenDeVentaDAO;

import pe.edu.pucp.arsacsoft.ordenes.model.OrdenDeVenta;
import pe.edu.pucp.arcacsoft.ordenes.dao.OrdenDeVentaDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.ClienteMayorista;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;

import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Producto;

public class OrdenDeVentaMySQL implements OrdenDeVentaDAO{

    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    //INSERTAR ORDEN DE VENTA CON TODAS LAS LINEAS EN ELLA
    @Override 
    public int insertar(OrdenDeVenta ordenV) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_ORDEN_DE_VENTA_MAYORISTA(?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_orden_de_venta", java.sql.Types.INTEGER);
            cs.setInt("_fid_empleado",ordenV.getEmpleadoID());
            cs.setInt("_fid_cliente_mayorista",ordenV.getClienteMayoristaID());
            cs.setDouble("_total",ordenV.getPrecioTotal());
            cs.setDate("_fecha_orden",new java.sql.Date(ordenV.getFechaOrden().getTime()));
            cs.setBoolean("_activo",ordenV.isActivo());
            cs.executeUpdate();
            ordenV.setIdOrdenDeVenta(cs.getInt("_id_orden_de_venta"));
            resultado = ordenV.getIdOrdenDeVenta();  
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{
                if (cs != null) {
                    cs.close();
                }
                if (con != null) {
                    con.close();
                }
            } catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        
        try{
            LineaDeOrdenDeVentaDAO daoLinea = new LineaOrdenDeVentaMySQL();
            for(LineaDeOrdenDeVenta linea: ordenV.getLineas()){
                daoLinea.insertar(linea, ordenV.getIdOrdenDeVenta());
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    //ACTUALIZA TODOS LOS DATOS CON OTRO OBJETO SIMILAR
    @Override
    public int modificar(OrdenDeVenta ordenV) {
       int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_ORDEN_DE_VENTA(?,?,?,?)}");
            cs.setInt("_id_orden_de_venta", ordenV.getIdOrdenDeVenta());
            cs.setInt("_fid_cliente_mayorista", ordenV.getClienteMayoristaID());
            cs.setDouble("_total", ordenV.getPrecioTotal());
            cs.setDate("_fecha_orden", 
                    new java.sql.Date(ordenV.getFechaOrden().getTime()));
            cs.executeUpdate();
            resultado = 1;
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                if (cs != null) {
                    cs.close();
                }
                if (con != null) {
                    con.close();
                }
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        
        try{
            LineaDeOrdenDeVentaDAO daoLinea = new LineaOrdenDeVentaMySQL();
            for(LineaDeOrdenDeVenta linea: ordenV.getLineas()){
                daoLinea.modificar(linea, ordenV.getIdOrdenDeVenta()
                        , linea.getProductoID());
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    //SE CAMBIA EL ESTADO DE UNA COLUMNA - QUEDA PARA EL REGISTRO
    @Override
    public int CancelarVenta(int idOrdenDeVenta) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call CANCELAR_VENTA_MAYORISTA(?)}");
            cs.setInt("_id_orden_de_venta", idOrdenDeVenta);
            cs.executeUpdate();
            resultado = 1;
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                if (cs != null) {
                    cs.close();
                }
                if (con != null) {
                    con.close();
                }
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return resultado;
    }
    //DEVUELVE LA LISTA DE PRODUCTOS DE UNA ORDEN DE VENTA
    @Override
    public ArrayList<LineaDeOrdenDeVenta> ListarProductos(int idOrdenDeVenta){
        ArrayList<LineaDeOrdenDeVenta> lineaVenta = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_PRODUCTOS_ORDEN_MAYORISTA(?)}");
            cs.setInt(1, idOrdenDeVenta);
            rs = cs.executeQuery();
            while (rs.next()) {
                LineaDeOrdenDeVenta lineaN = new LineaDeOrdenDeVenta();
                lineaN.setActivo(rs.getBoolean("estado"));
                lineaN.setCantidad(rs.getInt("cantidad"));
                lineaN.setDescuento(rs.getDouble("descuento"));
                lineaN.setPrecio(rs.getDouble("subtotal"));
                
                lineaN.setProducto(new Producto());
                lineaN.getProducto().setIdProducto(
                        rs.getInt("fid_producto"));
                lineaVenta.add(lineaN);
            }
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return lineaVenta;
    }

    //DEVUELVE UNA LISTA DE LAS ORDENES POR FECHA
    @Override
    public ArrayList<OrdenDeVenta> listarPorFecha() {
        ArrayList<OrdenDeVenta> ordenVentas = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ORDEN_MAYORISTA_POR_FECHA()}");
            rs = cs.executeQuery();
            while (rs.next()) {
                OrdenDeVenta ordenN = new OrdenDeVenta();
                ordenN.setActivo(rs.getBoolean("activo"));
                ordenN.setIdOrdenDeVenta(rs.getInt(
                        "id_orden_de_venta"));
                ordenN.setFechaOrden(rs.getDate("fecha_orden"));
                ordenN.setPrecioTotal(rs.getDouble("total"));
                
                ordenN.setClienteMayorista(new ClienteMayorista());
                ordenN.setEmpleado(new Empleado());
                ordenN.setLineas(new ArrayList<>());
                ordenVentas.add(ordenN);
            }
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }   
        return ordenVentas;
    }
    //DEVUELVE UNA LISTA DE LAS ORDENES POR CLIENTE
    @Override
    public ArrayList<OrdenDeVenta> listarPorClienteMayorista() {
        ArrayList<OrdenDeVenta> ordenVentas = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ORDEN_MAYORISTA_POR_CLIENTES()}");
            rs = cs.executeQuery();
            while (rs.next()) {
                OrdenDeVenta ordenN = new OrdenDeVenta();
                ordenN.setActivo(rs.getBoolean("activo"));
                ordenN.setIdOrdenDeVenta(rs.getInt(
                        "id_orden_de_venta"));
                ordenN.setFechaOrden(rs.getDate("fecha_orden"));
                ordenN.setPrecioTotal(rs.getDouble("total"));
                
                ordenN.setClienteMayorista(new ClienteMayorista());
                ordenN.setEmpleado(new Empleado());
                ordenN.setLineas(new ArrayList<>());
                ordenVentas.add(ordenN);
            }
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }   
        return ordenVentas;
    }
    //DEVUELVE UNA LISTA DE LAS ORDENES POR VENDEDOR
    @Override
    public ArrayList<OrdenDeVenta> listarPorVendedor(int idPersona) {
        ArrayList<OrdenDeVenta> ordenVentas = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ORDEN_MAYORISTA_POR_VENDEDOR()}");
            rs = cs.executeQuery();
            while (rs.next()) {
                OrdenDeVenta ordenN = new OrdenDeVenta();
                ordenN.setActivo(rs.getBoolean("activo"));
                ordenN.setIdOrdenDeVenta(rs.getInt(
                        "id_orden_de_venta"));
                ordenN.setFechaOrden(rs.getDate("fecha_orden"));
                ordenN.setPrecioTotal(rs.getDouble("total"));
                
                ordenN.setClienteMayorista(new ClienteMayorista());
                ordenN.setEmpleado(new Empleado());
                ordenN.setLineas(new ArrayList<>());
                ordenVentas.add(ordenN);
            }
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }   
        return ordenVentas;
    }

    //DEVUELVE UNA FILA
    @Override
    public OrdenDeVenta buscarPorID(int idOrdenDeVenta) {
        OrdenDeVenta ordenN = new OrdenDeVenta();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call BUSCAR_ORDEN_POR_ID(?)}");
            cs.setInt("ordenID", idOrdenDeVenta);
            rs = cs.executeQuery();

            ordenN.setActivo(rs.getBoolean("activo"));
            ordenN.setIdOrdenDeVenta(rs.getInt(
                        "id_orden_de_venta"));
            ordenN.setFechaOrden(rs.getDate("fecha_orden"));
            ordenN.setPrecioTotal(rs.getDouble("total"));
                
            ordenN.setClienteMayorista(new ClienteMayorista());
            ordenN.setEmpleado(new Empleado());
            ordenN.setLineas(new ArrayList<>());
            
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }   
        return ordenN;
    }
    
}

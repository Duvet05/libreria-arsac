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

public class OrdenDeVentaMySQL implements OrdenDeVentaDAO {

    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;

    @Override
    public int insertar(OrdenDeVenta ordenV) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_ORDEN_DE_VENTA_MAYORISTA(?,?,?,?,?,?,?)}");
            cs.registerOutParameter(1, java.sql.Types.INTEGER);
            cs.setInt(2, ordenV.getEmpleado().getIdPersona());
            cs.setInt(3, ordenV.getClienteMayorista().getIdPersona());
            cs.setDouble(4, ordenV.getPrecioTotal());
            System.out.println(ordenV.getFechaOrden().getDate());
            cs.setDate(5, new java.sql.Date(ordenV.getFechaOrden().getDate()));
            cs.setDate(6, new java.sql.Date(ordenV.getFechaEnvio().getDate()));
            cs.setString(7, ordenV.getEstado());
            cs.executeUpdate();
            ordenV.setIdOrdenDeVenta(cs.getInt(1));

            for (LineaDeOrdenDeVenta linea : ordenV.getLineaDeOrdenDeVenta()) {
                cs = con.prepareCall("{call INSERTAR_LINEA_ORDEN_VENTA_MAYORISTA(?,?,?,?,?)}");
                cs.setInt(1, ordenV.getIdOrdenDeVenta());
                cs.setInt(2, linea.getProducto().getIdProducto());
                cs.setInt(3, linea.getCantidad());
                cs.setDouble(4, linea.getDescuento());
                cs.setDouble(5, linea.getPrecio());
                cs.executeUpdate();
            }
            resultado = ordenV.getIdOrdenDeVenta();
        } catch (Exception ex) {
            System.out.println("Error in insertar: " + ex.getMessage());
            ex.printStackTrace();
        } finally {
            try {
                if (cs != null) {
                    cs.close();
                }
                if (con != null) {
                    con.close();
                }
            } catch (Exception ex) {
                System.out.println("Error closing resources: " + ex.getMessage());
                ex.printStackTrace();
            }
        }
        return resultado;
    }

    @Override
    public int modificar(OrdenDeVenta ordenV) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_ORDEN_DE_VENTA(?,?,?,?)}");
            cs.setInt("_id_orden_de_venta", ordenV.getIdOrdenDeVenta());
            cs.setInt("_fid_cliente_mayorista", ordenV.getClienteMayorista().getIdPersona());
            cs.setDouble("_total", ordenV.getPrecioTotal());
            cs.setDate("_fecha_orden", new java.sql.Date(ordenV.getFechaOrden().getTime()));
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

        try {
            LineaDeOrdenDeVentaDAO daoLinea = new LineaOrdenDeVentaMySQL();
            for (LineaDeOrdenDeVenta linea : ordenV.getLineaDeOrdenDeVenta()) {
                daoLinea.modificar(linea, ordenV.getIdOrdenDeVenta(), linea.getProducto().getIdProducto());
            }
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

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

    @Override
    public ArrayList<LineaDeOrdenDeVenta> ListarProductos(int idOrdenDeVenta) {
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
                lineaN.getProducto().setIdProducto(rs.getInt("fid_producto"));
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
                ordenN.setIdOrdenDeVenta(rs.getInt("id_orden_de_venta"));
                ordenN.setFechaOrden(rs.getDate("fecha_orden"));
                ordenN.setPrecioTotal(rs.getDouble("total"));
                ordenN.setClienteMayorista(new ClienteMayorista());
                ordenN.setEmpleado(new Empleado());
                ordenN.setLineaDeOrdenDeVenta(new ArrayList<>());
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
                ordenN.setIdOrdenDeVenta(rs.getInt("id_orden_de_venta"));
                ordenN.setFechaOrden(rs.getDate("fecha_orden"));
                ordenN.setPrecioTotal(rs.getDouble("total"));
                ordenN.setClienteMayorista(new ClienteMayorista());
                ordenN.setEmpleado(new Empleado());
                ordenN.setLineaDeOrdenDeVenta(new ArrayList<>());
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
                ordenN.setIdOrdenDeVenta(rs.getInt("id_orden_de_venta"));
                ordenN.setFechaOrden(rs.getDate("fecha_orden"));
                ordenN.setPrecioTotal(rs.getDouble("total"));
                ordenN.setClienteMayorista(new ClienteMayorista());
                ordenN.setEmpleado(new Empleado());
                ordenN.setLineaDeOrdenDeVenta(new ArrayList<>());
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

    @Override
    public OrdenDeVenta buscarPorID(int idOrdenDeVenta) {
        OrdenDeVenta ordenN = new OrdenDeVenta();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call BUSCAR_ORDEN_POR_ID(?)}");
            cs.setInt("ordenID", idOrdenDeVenta);
            rs = cs.executeQuery();

            if (rs.next()) {
                ordenN.setActivo(rs.getBoolean("activo"));
                ordenN.setIdOrdenDeVenta(rs.getInt("id_orden_de_venta"));
                ordenN.setFechaOrden(rs.getDate("fecha_orden"));
                ordenN.setPrecioTotal(rs.getDouble("total"));
                ordenN.setClienteMayorista(new ClienteMayorista());
                ordenN.setEmpleado(new Empleado());
                ordenN.setLineaDeOrdenDeVenta(new ArrayList<>());
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
        return ordenN;
    }

    @Override
    public int eliminar(int idOrdenDeVenta) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}

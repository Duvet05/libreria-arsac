package pe.edu.pucp.arsacsoft.ordenes.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import java.util.Date;

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
    public int insertarMayorista(OrdenDeVenta ordenV) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_ORDEN_DE_VENTA_MAYORISTA(?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter(1, java.sql.Types.INTEGER);
            cs.setInt(2, ordenV.getEmpleado().getIdPersona());
            cs.setInt(3, ordenV.getClienteMayorista().getIdPersona());
            cs.setDouble(4, ordenV.getPrecioTotal());
            System.out.println(ordenV.getFechaOrden().getDate());
            cs.setDate(5, new java.sql.Date(ordenV.getFechaOrden().getDate()));
            cs.setDate(6, new java.sql.Date(ordenV.getFechaEnvio().getDate()));
            cs.setString(7, ordenV.getEstado());
            cs.setString(8, ordenV.getDireccion());
            cs.executeUpdate();
            ordenV.setIdOrdenDeVenta(cs.getInt(1));

            for (LineaDeOrdenDeVenta linea : ordenV.getLineaDeOrdenDeVenta()) {
                cs = con.prepareCall("{call INSERTAR_LINEA_ORDEN_VENTA(?,?,?,?,?)}");
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
    public int insertarMinorista(OrdenDeVenta ordenV) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_ORDEN_DE_VENTA_MINORISTA(?,?,?,?,?)}");
            cs.registerOutParameter(1, java.sql.Types.INTEGER);
            cs.setInt(2, ordenV.getEmpleado().getIdPersona());
            cs.setDouble(3, ordenV.getPrecioTotal());
            cs.setDate(4, new java.sql.Date(ordenV.getFechaOrden().getTime()));
            cs.setString(5, ordenV.getEstado());
            cs.executeUpdate();
            ordenV.setIdOrdenDeVenta(cs.getInt(1));

            for (LineaDeOrdenDeVenta linea : ordenV.getLineaDeOrdenDeVenta()) {
                cs = con.prepareCall("{call INSERTAR_LINEA_ORDEN_VENTA(?,?,?,?,?)}");
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

    @Override
    public ArrayList<OrdenDeVenta> listarPorPeriodo(Date fechaInicio, Date fechaFin) {
        ArrayList<OrdenDeVenta> ordenes = new ArrayList<OrdenDeVenta>();
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ORDENES_DE_VENTA_REGISTRADAS_EN_PERIODO(?,?)}");
            cs.setDate(1, (new java.sql.Date(fechaInicio.getTime())));
            cs.setDate(2, (new java.sql.Date(fechaFin.getTime())));
            
            rs = cs.executeQuery();
            
            while (rs.next())
            {
                OrdenDeVenta orden = new OrdenDeVenta();
                
                /*
                ov.id_orden_de_venta,
		ov.fid_cliente_mayorista,
                ov.fecha_orden,
                ov.fecha_envio,
                ov.total
                */
                
                orden.setIdOrdenDeVenta(rs.getInt("id_orden_de_venta"));
                orden.setClienteMayorista(new ClienteMayorista());
                orden.getClienteMayorista().setIdPersona(rs.getInt("fid_cliente_mayorista"));
                orden.setFechaOrden(new java.util.Date((rs.getDate("fecha_orden")).getTime()));
                if (rs.getDate("fecha_envio") != null)
                    orden.setFechaEnvio(new java.util.Date((rs.getDate("fecha_envio")).getTime()));
                orden.setPrecioTotal(rs.getDouble("total"));
                
                ordenes.add(orden);
            }
            
            
            
        }catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        
        return ordenes;
    }

    @Override
    public ArrayList<LineaDeOrdenDeVenta> listarLineasDeOrdenDeVenta(int idOrdenDeVenta) {
        ArrayList<LineaDeOrdenDeVenta> lineas = new ArrayList<LineaDeOrdenDeVenta>();
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_LINEAS_DE_ORDEN_DE_VENTA(?)}");
            cs.setInt(1, idOrdenDeVenta);
            rs= cs.executeQuery();
            while (rs.next())
            {
                LineaDeOrdenDeVenta linea = new LineaDeOrdenDeVenta();
                
                /*
                    p.id_producto,
                    p.nombre,
                    lov.cantidad,
                    p.precio,
                    p.precio_por_mayor,
                    lov.descuento,
                    lov.precio
                */
                
                linea.setProducto(new Producto());
                linea.getProducto().setIdProducto(rs.getInt("id_producto"));
                linea.getProducto().setNombre(rs.getString("nombre"));
                linea.setCantidad(rs.getInt("cantidad"));
                linea.getProducto().setPrecioPorMenor(rs.getDouble("precio"));
                linea.getProducto().setPrecioPorMayor(rs.getDouble("precio_por_mayor"));
                linea.setDescuento(rs.getDouble("descuento"));
                linea.setPrecio(rs.getDouble("precio"));
                
                lineas.add(linea);
            }
            
        }catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        
        return lineas;
    }

}

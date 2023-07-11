package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import java.util.Date;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.ws.rs.PathParam;
import pe.edu.pucp.arcacsoft.ordenes.dao.LineaDeOrdenDeVentaDAO;
import pe.edu.pucp.arcacsoft.ordenes.dao.OrdenDeVentaDAO;
import pe.edu.pucp.arsacsoft.ordenes.model.LineaDeOrdenDeVenta;
import pe.edu.pucp.arsacsoft.ordenes.model.OrdenDeVenta;
import pe.edu.pucp.arsacsoft.ordenes.mysql.LineaOrdenDeVentaMySQL;
import pe.edu.pucp.arsacsoft.ordenes.mysql.OrdenDeVentaMySQL;

/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "VentasWS")
public class VentasWS {

    private OrdenDeVentaDAO ordenDeVentaDAO = new OrdenDeVentaMySQL();
    private LineaDeOrdenDeVentaDAO lovDAO = new LineaOrdenDeVentaMySQL();

    @WebMethod(operationName = "insertarOrdenDeVentaMayorista")
    public int insertarOrdenDeVentaMayorista(OrdenDeVenta ordenV) {
        int idOrdenDeVenta = 0;
        try {
            idOrdenDeVenta = ordenDeVentaDAO.insertarMayorista(ordenV);
        } catch (Exception ex) {
            System.out.println("Error in insertarOrdenDeVenta: " + ex.getMessage());
            ex.printStackTrace();
        }
        return idOrdenDeVenta;
    }

    @WebMethod(operationName = "insertarOrdenDeVentaMinorista")
    public int insertarOrdenDeVentaMinorista(OrdenDeVenta ordenV) {
        int idOrdenDeVenta = 0;
        try {
            idOrdenDeVenta = ordenDeVentaDAO.insertarMinorista(ordenV);
        } catch (Exception ex) {
            System.out.println("Error in insertarOrdenDeVenta: " + ex.getMessage());
            ex.printStackTrace();
        }
        return idOrdenDeVenta;
    }

    @WebMethod(operationName = "modificarOrdenDeVenta")
    public int modificarOrdenDeVenta(OrdenDeVenta ordenV) {
        int resultado = 0;
        try {
            resultado = ordenDeVentaDAO.modificar(ordenV);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "cancelarOrdenDeVenta")
    public int cancelarOrdenDeVenta(@PathParam("id") int idOrdenDeVenta) {
        int resultado = 0;
        try {
            resultado = ordenDeVentaDAO.CancelarVenta(idOrdenDeVenta);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "listarLineasDeOrdenDeVenta")
    public ArrayList<LineaDeOrdenDeVenta> listarLineasDeOrdenDeVenta(@PathParam("id") int idOrdenDeVenta) {
        ArrayList<LineaDeOrdenDeVenta> lineas = null;
        try {
            lineas = ordenDeVentaDAO.ListarProductos(idOrdenDeVenta);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return lineas;
    }

    @WebMethod(operationName = "listarOrdenesPorFecha")
    public ArrayList<OrdenDeVenta> listarOrdenesPorFecha() {
        ArrayList<OrdenDeVenta> ordenes = null;
        try {
            ordenes = ordenDeVentaDAO.listarPorFecha();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ordenes;
    }

    @WebMethod(operationName = "listarOrdenesPorClienteMayorista")
    public ArrayList<OrdenDeVenta> listarOrdenesPorClienteMayorista() {
        ArrayList<OrdenDeVenta> ordenes = null;
        try {
            ordenes = ordenDeVentaDAO.listarPorClienteMayorista();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ordenes;
    }

    @WebMethod(operationName = "listarOrdenesPorVendedor")
    public ArrayList<OrdenDeVenta> listarOrdenesPorVendedor(@PathParam("id") int idVendedor) {
        ArrayList<OrdenDeVenta> ordenes = null;
        try {
            ordenes = ordenDeVentaDAO.listarPorVendedor(idVendedor);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ordenes;
    }

    @WebMethod(operationName = "buscarOrdenPorID")
    public OrdenDeVenta buscarOrdenPorID(@PathParam("id") int idOrdenDeVenta) {
        OrdenDeVenta orden = null;
        try {
            orden = ordenDeVentaDAO.buscarPorID(idOrdenDeVenta);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return orden;
    }

    @WebMethod(operationName = "eliminarOrdenDeVenta")
    public int eliminarOrdenDeVenta(@PathParam("id") int idOrdenDeVenta) {
        int resultado = 0;
        try {
            resultado = ordenDeVentaDAO.eliminar(idOrdenDeVenta);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "insertarLineaOrdenDeVenta")
    public int insertarLineaOrdenDeVenta(LineaDeOrdenDeVenta lineaOrden, int idOrdenVenta) {
        int resultado = 0;
        try {
            resultado = lovDAO.insertar(lineaOrden, idOrdenVenta);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "modificarLineaOrdenDeVenta")
    public int modificarLineaOrdenDeVenta(LineaDeOrdenDeVenta lineaOrden, int idOrdenVenta, int idProducto) {
        int resultado = 0;
        try {
            resultado = lovDAO.modificar(lineaOrden, idOrdenVenta, idProducto);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "verificarStockSuficiente")
    public int verificarStockSuficiente(int idSede, int idProducto, int cantidad) {
        int tieneStock = 0;
        try {
            // Comprobar si los parámetros son válidos
            if (idProducto <= 0 || idSede <= 0 || cantidad <= 0) {
                throw new IllegalArgumentException("Los parámetros proporcionados son inválidos");
            }

            // Lógica para verificar el stock del producto con el ID dado
            tieneStock = lovDAO.verificarStockSuficiente(idSede, idProducto, cantidad);

        } catch (IllegalArgumentException ex) {
            // Manejar la excepción de parámetros inválidos
            System.out.println("Error: " + ex.getMessage());
        } catch (Exception ex) {
            // Manejar otras excepciones
            System.out.println("Error: " + ex.getMessage());
        }
        return tieneStock;
    }

    @WebMethod(operationName = "listarOrdenesDeVentaPorPeriodo")
    public ArrayList<OrdenDeVenta> listarOrdenesDeVentaPorPeriodo(int idEmpleado, Date fechaInicio, Date fechaFin)
    {
        return ordenDeVentaDAO.listarPorPeriodo(idEmpleado, fechaInicio, fechaFin);
    }
    
    @WebMethod(operationName = "listarLineasDeOrdenDeVentaPorID")
    public ArrayList<LineaDeOrdenDeVenta> listarLineasDeOrdenDeVentaPorID(int idOrdenDeVenta)
    {
        return ordenDeVentaDAO.listarLineasDeOrdenDeVenta(idOrdenDeVenta);
    }
}

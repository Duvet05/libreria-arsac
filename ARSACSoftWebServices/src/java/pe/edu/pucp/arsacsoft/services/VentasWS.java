package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.ws.rs.PathParam;
import pe.edu.pucp.arsacsoft.ordenes.model.LineaDeOrdenDeVenta;
import pe.edu.pucp.arsacsoft.ordenes.model.OrdenDeVenta;
import pe.edu.pucp.arsacsoft.ordenes.mysql.OrdenDeVentaMySQL;

/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "VentasWS")
public class VentasWS {

    private OrdenDeVentaMySQL ordenDeVentaDAO = new OrdenDeVentaMySQL();

    @WebMethod(operationName = "insertarOrdenDeVenta")
    public int insertarOrdenDeVenta(OrdenDeVenta ordenV) {
        int idOrdenDeVenta = ordenDeVentaDAO.insertar(ordenV);
        return idOrdenDeVenta;
    }

    @WebMethod(operationName = "modificarOrdenDeVenta")
    public int modificarOrdenDeVenta(OrdenDeVenta ordenV) {
        int resultado = ordenDeVentaDAO.modificar(ordenV);
        return resultado;
    }

    @WebMethod(operationName = "cancelarOrdenDeVenta")
    public int cancelarOrdenDeVenta(@PathParam("id") int idOrdenDeVenta) {
        int resultado = ordenDeVentaDAO.CancelarVenta(idOrdenDeVenta);
        return resultado;
    }

    @WebMethod(operationName = "cancelarOrdenDeVenta")
    public ArrayList<LineaDeOrdenDeVenta> listarLineasDeOrdenDeVenta(@PathParam("id") int idOrdenDeVenta) {
        ArrayList<LineaDeOrdenDeVenta> lineas = ordenDeVentaDAO.ListarProductos(idOrdenDeVenta);
        return lineas;
    }

    @WebMethod(operationName = "listarOrdenesPorFecha")
    public ArrayList<OrdenDeVenta> listarOrdenesPorFecha() {
        ArrayList<OrdenDeVenta> ordenes = ordenDeVentaDAO.listarPorFecha();
        return ordenes;
    }

    @WebMethod(operationName = "listarOrdenesPorClienteMayorista")
    public ArrayList<OrdenDeVenta> listarOrdenesPorClienteMayorista() {
        ArrayList<OrdenDeVenta> ordenes = ordenDeVentaDAO.listarPorClienteMayorista();
        return ordenes;
    }

    @WebMethod(operationName = "listarOrdenesPorVendedor")
    public ArrayList<OrdenDeVenta> listarOrdenesPorVendedor(@PathParam("id") int idVendedor) {
        ArrayList<OrdenDeVenta> ordenes = ordenDeVentaDAO.listarPorVendedor(idVendedor);
        return ordenes;
    }

    @WebMethod(operationName = "buscarOrdenPorID")
    public OrdenDeVenta buscarOrdenPorID(@PathParam("id") int idOrdenDeVenta) {
        OrdenDeVenta orden = ordenDeVentaDAO.buscarPorID(idOrdenDeVenta);
        return orden;
    }

    @WebMethod(operationName = "eliminarOrdenDeVenta")
    public int eliminarOrdenDeVenta(@PathParam("id") int idOrdenDeVenta) {
        int resultado = ordenDeVentaDAO.eliminar(idOrdenDeVenta);
        return resultado;
    }
}

package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import pe.edu.pucp.arsacsoft.almacen.dao.LineaOrdenDeCompraDAO;
import pe.edu.pucp.arsacsoft.almacen.dao.OrdenDeCompraDAO;
import pe.edu.pucp.arsacsoft.almacen.model.LineaOrdenDeCompra;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeCompra;
import pe.edu.pucp.arsacsoft.almacen.mysql.LineaOrdenDeCompraMySQL;
import pe.edu.pucp.arsacsoft.almacen.mysql.OrdenDeCompraMySQL;

@WebService(serviceName = "AlmacenWS")
public class AlmacenWS {

    private OrdenDeCompraDAO ordenDeCompraDAO = new OrdenDeCompraMySQL();
    private LineaOrdenDeCompraDAO lineaOrdenDeCompraDAO = new LineaOrdenDeCompraMySQL();

    @WebMethod
    public ArrayList<LineaOrdenDeCompra> listarLineasOrdenCompraPorIdOrdenCompra(
            @WebParam(name = "idOrdenCompra") int idOrdenCompra) {
        try {
            return lineaOrdenDeCompraDAO.listarPorIdOrdenCompra(idOrdenCompra);
        } catch (Exception ex) {
            // Manejar la excepción de acuerdo a tus necesidades
            ex.printStackTrace();
            return new ArrayList<>();
        }
    }

    @WebMethod
    public int insertarOrdenCompra(@WebParam(name = "ordenCompra") OrdenDeCompra ordenCompra) {
        try {
            return ordenDeCompraDAO.insertar(ordenCompra);
        } catch (Exception ex) {
            // Manejar la excepción de acuerdo a tus necesidades
            ex.printStackTrace();
            return -1;
        }
    }

    @WebMethod
    public int modificarOrdenCompra(@WebParam(name = "ordenCompra") OrdenDeCompra ordenCompra) {
        try {
            return ordenDeCompraDAO.modificar(ordenCompra);
        } catch (Exception ex) {
            // Manejar la excepción de acuerdo a tus necesidades
            ex.printStackTrace();
            return -1;
        }
    }

    @WebMethod
    public int eliminarOrdenCompra(@WebParam(name = "idOrdenCompra") int idOrdenCompra) {
        try {
            return ordenDeCompraDAO.eliminar(idOrdenCompra);
        } catch (Exception ex) {
            // Manejar la excepción de acuerdo a tus necesidades
            ex.printStackTrace();
            return -1;
        }
    }

    @WebMethod
    public ArrayList<OrdenDeCompra> listarOrdenesCompraPorIdDNINombreEmpleado(
            @WebParam(name = "idDNINombreEmpleado") String idDNINombreEmpleado) {
        try {
            return ordenDeCompraDAO.listarPorIdDNINombreEmpleado(idDNINombreEmpleado);
        } catch (Exception ex) {
            // Manejar la excepción de acuerdo a tus necesidades
            ex.printStackTrace();
            return new ArrayList<>();
        }
    }
}

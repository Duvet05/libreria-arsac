package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import java.util.Date;
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

    private OrdenDeCompraDAO daoOrdenDeCompra = new OrdenDeCompraMySQL();
    private LineaOrdenDeCompraDAO daoLineaOrdenCompra = new LineaOrdenDeCompraMySQL();

//    @WebMethod
//    public ArrayList<LineaOrdenDeCompra> listarLineasOrdenCompraPorIdOrdenCompra(
//            @WebParam(name = "idOrdenCompra") int idOrdenCompra) {
//        try {
//            return lineaOrdenDeCompraDAO.listarPorIdOrdenCompra(idOrdenCompra);
//        } catch (Exception ex) {
//            // Manejar la excepción de acuerdo a tus necesidades
//            ex.printStackTrace();
//            return new ArrayList<>();
//        }
//    }
//
    @WebMethod
    public int insertarOrdenCompra(OrdenDeCompra ordenCompra) {
        int resultado=0;
        try {
            resultado =  daoOrdenDeCompra.insertar(ordenCompra);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarOrdenesDeCompraXProveedor")
    public ArrayList<OrdenDeCompra> listarOrdenesDeCompraXProveedor(int idProveedor, Date fechaInicio, 
                                        Date fechaFin, String estado) {
        ArrayList<OrdenDeCompra> ordenes = null;
        try {
            ordenes = daoOrdenDeCompra.listarPorProveedor(idProveedor, fechaInicio, fechaFin, estado);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ordenes;
    }
    
    @WebMethod(operationName = "listarLineasDeOrdenDeCompra")
    public ArrayList<LineaOrdenDeCompra> listarLineasDeOrdenDeCompra(int idOrdenDeCompra) {
        ArrayList<LineaOrdenDeCompra> lineas = null;
        try {
            lineas = daoOrdenDeCompra.listarLineasOrdenDeCompra(idOrdenDeCompra);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return lineas;
    }
//
//    @WebMethod
//    public int modificarOrdenCompra(@WebParam(name = "ordenCompra") OrdenDeCompra ordenCompra) {
//        try {
//            return ordenDeCompraDAO.modificar(ordenCompra);
//        } catch (Exception ex) {
//            // Manejar la excepción de acuerdo a tus necesidades
//            ex.printStackTrace();
//            return -1;
//        }
//    }
//
//    @WebMethod
//    public int eliminarOrdenCompra(@WebParam(name = "idOrdenCompra") int idOrdenCompra) {
//        try {
//            return ordenDeCompraDAO.eliminar(idOrdenCompra);
//        } catch (Exception ex) {
//            // Manejar la excepción de acuerdo a tus necesidades
//            ex.printStackTrace();
//            return -1;
//        }
//    }
//
//    @WebMethod
//    public ArrayList<OrdenDeCompra> listarOrdenesCompraPorIdDNINombreEmpleado(
//            @WebParam(name = "idDNINombreEmpleado") String idDNINombreEmpleado) {
//        try {
//            return ordenDeCompraDAO.listarPorIdDNINombreEmpleado(idDNINombreEmpleado);
//        } catch (Exception ex) {
//            // Manejar la excepción de acuerdo a tus necesidades
//            ex.printStackTrace();
//            return new ArrayList<>();
//        }
//    }
}

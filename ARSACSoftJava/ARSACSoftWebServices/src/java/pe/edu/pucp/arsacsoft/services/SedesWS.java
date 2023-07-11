/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.sedes.dao.OrdenDeAbastecimientoDAO;
import pe.edu.pucp.arsacsoft.sedes.dao.SedeDAO;
import pe.edu.pucp.arsacsoft.sedes.model.LineaOrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.sedes.model.OrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;
import pe.edu.pucp.arsacsoft.sedes.model.SedeXProducto;
import pe.edu.pucp.arsacsoft.sedes.mysql.OrdenDeAbastecimientoMySQL;
import pe.edu.pucp.arsacsoft.sedes.mysql.SedeMySQL;

/**
 *
 * @author Gino
 */
@WebService(serviceName = "SedesWS")
public class SedesWS {
    private SedeDAO daoSede = new SedeMySQL();
    private OrdenDeAbastecimientoDAO daoOrden = new OrdenDeAbastecimientoMySQL();
    
    @WebMethod(operationName = "insertarSede")
    public int insertarSede(Sede sede)
    {
        return daoSede.insertar(sede);
    }
    
    @WebMethod(operationName = "listarSedes")
    public ArrayList<Sede> listarSedes()
    {
        return daoSede.listarTodas();
    }
    
    @WebMethod(operationName = "modificarSede")
    public int modificarSede(Sede sede)
    {
        return daoSede.modificar(sede);
    }
    
    @WebMethod(operationName = "listarProductosDeSede")
    public ArrayList<SedeXProducto> listarProductoDeSede(int idSede)
    {
        return daoSede.listarProductos(idSede);
    }
    
    @WebMethod(operationName = "listarProductosDeSedePorNombreMarcaCategoria")
    public ArrayList<SedeXProducto> listarProductosDeSedePorNombreMarcaCategoria(int idSede, String nombre, int idMarca, int idCategoria)
    {
        return daoSede.listarProductosPorNombreMarcaCategoria(idSede, nombre, idMarca, idCategoria);
    }
    
    @WebMethod(operationName = "insertarOrdenDeAbastecimiento")
    public int insertarOrdenDeAbastecimiento(OrdenDeAbastecimiento orden)
    {
        return daoOrden.insertar(orden);
    }
    
    @WebMethod(operationName = "verificarEntregaDeOrdenDeAbastecimiento")
    public int verificarEntregaDeOrdenDeAbastecimiento(OrdenDeAbastecimiento orden)
    {
        return daoOrden.verificarEntrega(orden);
    }
    
    @WebMethod(operationName = "entregarOrdenDeAbastecimiento")
    public int entregarOrdenDeAbastecimiento(OrdenDeAbastecimiento orden)
    {
        return daoOrden.entregar(orden);
    }
    
    @WebMethod(operationName = "cancelarOrdenDeAbastecimiento")
    public int cancelarOrdenDeAbastecimiento(int idOrdenDeAbastecimiento)
    {
        return daoOrden.cancelar(idOrdenDeAbastecimiento);
    }
    
    @WebMethod(operationName = "listarOrdenesDeAbastecimientoPorIdEmpleadoEstado")
    public ArrayList<OrdenDeAbastecimiento> listarOrdenesDeAbastecimientoPorIdEmpleadoEstado(int idEmpleado, String estado)
    {
        return daoOrden.listarPorIdEmpleadoEstado(idEmpleado, estado);
    }
    
    @WebMethod(operationName = "listarLineasDeOrdenDeAbastecimiento")
    public ArrayList<LineaOrdenDeAbastecimiento> listarLineasDeOrdenDeAbastecimiento(int idOrdenDeAbastecimiento)
    {
        return daoOrden.listarLineasDeOrdenDeAbastecimiento(idOrdenDeAbastecimiento);
    }
    
    @WebMethod(operationName = "obtenerStockDeProductoEnSedePrincipal")
    public int obtenerStockDeProductoEnSedePrincipal(int idProducto)
    {
        return daoOrden.obtenerStockDeProductoEnSedePrincipal(idProducto);
    }
    
    @WebMethod(operationName = "obtenerStockDeProductoEnSede")
    public int obtenerStockDeProductoEnSede(int idProducto, int idSede)
    {
        return daoOrden.obtenerStockDeProductoEnSede(idProducto, idSede);
    }
    
}

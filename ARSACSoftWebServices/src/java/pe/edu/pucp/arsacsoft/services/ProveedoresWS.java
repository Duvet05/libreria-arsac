
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;

import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;
import pe.edu.pucp.arsacsoft.proveedores.dao.ProveedorDAO;
import pe.edu.pucp.arsacsoft.proveedores.mysql.ProveedorMySQL;

/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "ProveedoresWS")
public class ProveedoresWS {

    ProveedorDAO daoProveedor = new ProveedorMySQL();
    
    @WebMethod(operationName = "listarProveedoresPorCategoria")
    public ArrayList<Proveedor> listarProveedoresPorCategoria(int idCategoria) {
        ArrayList<Proveedor> proveedores = null;
        try {
            proveedores = daoProveedor.listarPorCategoriaDeProducto(idCategoria);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return proveedores;
    }
    
    @WebMethod(operationName = "listarProveedoresAfabeticamente")
    public ArrayList<Proveedor> listarProveedoresAfabeticamente() {
        ArrayList<Proveedor> proveedores = null;
        try {
            proveedores = daoProveedor.listarAlfabeticamente();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return proveedores;
    }
    
    @WebMethod(operationName = "insertarProveedor")
    public int insertarProveedor(Proveedor proveedor) {
        int resultado = 0;
        try {
            resultado = daoProveedor.insertar(proveedor);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "eliminarProveedor")
    public int eliminarProveedor(int idProveedor) {
        int resultado = 0;
        try {
            resultado = daoProveedor.eliminar(idProveedor);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarProveedor")
    public int modificarProveedor(Proveedor proveedor) {
        int resultado = 0;
        try {
            resultado = daoProveedor.modificar(proveedor);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}
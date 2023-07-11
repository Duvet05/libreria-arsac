
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeCompra;
import pe.edu.pucp.arsacsoft.proveedores.dao.ProductoXProveedorDAO;

import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;
import pe.edu.pucp.arsacsoft.proveedores.dao.ProveedorDAO;
import pe.edu.pucp.arsacsoft.proveedores.model.ProductoXProveedor;
import pe.edu.pucp.arsacsoft.proveedores.mysql.ProductoXProveedorMySQL;
import pe.edu.pucp.arsacsoft.proveedores.mysql.ProveedorMySQL;

/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "ProveedoresWS")
public class ProveedoresWS {

    ProveedorDAO daoProveedor = new ProveedorMySQL();
    ProductoXProveedorDAO daoProductoPorProveedor = new ProductoXProveedorMySQL();
    
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
    
    @WebMethod(operationName = "listarProveedoresXNombreXRUC")
    public ArrayList<Proveedor> listarProveedoresXNombreXRUC(String nombre) {
        ArrayList<Proveedor> proveedores = null;
        try {
            proveedores = daoProveedor.listarProveedoresXNombreXRuc(nombre);
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
    /*Productos por proveedor*/
    
    @WebMethod(operationName = "listarProductosXProveedor")
    public ArrayList<ProductoXProveedor> listarProductosXProveedor(String nombre, int _fid_categoria, 
                                int _fid_marca, int _fid_proveedor) {
        ArrayList<ProductoXProveedor> productos = null;
        try {
            productos = daoProductoPorProveedor.listarProductosXProveedor(nombre, _fid_categoria,_fid_marca,
                                    _fid_proveedor);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return productos;
    }
    
            @WebMethod(operationName = "listarTodasOrdenesCompraXProveedor")
    public ArrayList<OrdenDeCompra> listarTodasOrdenesCompraXProveedor(
            String nombre_proveedor) {
        ArrayList<OrdenDeCompra> ordenesXProveedor = null;
        try {
            ordenesXProveedor = daoProductoPorProveedor.listarTodasOrdenesCompraXProveedor(nombre_proveedor);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return ordenesXProveedor;
    }

}


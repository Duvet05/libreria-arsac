/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.almacen.dao.ProductoDAO;
import pe.edu.pucp.arsacsoft.almacen.model.Producto;
import pe.edu.pucp.arsacsoft.almacen.mysql.ProductoMySQL;
/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "productoWS")
public class productoWS {
    /**
     * This is a sample web service operation
     */
    private ProductoDAO daoProducto = new ProductoMySQL();
    
    @WebMethod(operationName = "listarProductosTodas")
    public ArrayList<Producto> listarProductosTodas() {
        ArrayList<Producto> productos = new ArrayList<Producto>();
        
        return productos;
    }
}

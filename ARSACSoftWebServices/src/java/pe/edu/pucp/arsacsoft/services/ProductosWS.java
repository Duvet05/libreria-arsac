/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.producto.model.Categoria;
import pe.edu.pucp.arsacsoft.producto.model.Marca;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.productos.dao.CategoriaDAO;
import pe.edu.pucp.arsacsoft.productos.dao.MarcaDAO;
import pe.edu.pucp.arsacsoft.productos.dao.ProductoDAO;
import pe.edu.pucp.arsacsoft.productos.mysql.CategoriaMySQL;
import pe.edu.pucp.arsacsoft.productos.mysql.MarcaMySQL;
import pe.edu.pucp.arsacsoft.productos.mysql.ProductoMySQL;

/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "Productos")
public class ProductosWS {

    CategoriaDAO daoCategoria = new CategoriaMySQL();
    ProductoDAO daoProducto = new ProductoMySQL();
    
    
    @WebMethod(operationName = "listarCategoriasTodas")
    public ArrayList<Categoria> listarCategoriasTodas() {
        ArrayList<Categoria> categorias = null;
        try {
            categorias = daoCategoria.listarTodas();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return categorias;
    }
    
    MarcaDAO daoMarca = new MarcaMySQL();
    @WebMethod(operationName = "listarMarcaTodas")
    public ArrayList<Marca> listarMarcaTodas() {
        ArrayList<Marca> marcas = null;
        try {
            marcas = daoMarca.listarTodas();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return marcas;
    }
    
    @WebMethod(operationName = "insertarProducto")
    public int insertarProducto(Producto prod) {
        int resultado = 0;
        try {
            resultado = daoProducto.insertar(prod);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "modificarProducto")
    public int modificarProducto(Producto prod) {
        int resultado = 0;
        try {
            resultado = daoProducto.modificar(prod);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
    
    @WebMethod(operationName = "listarProductosXNombreXCategoriaXMarca")
    public ArrayList<Producto> listarProductosXNombreXCategoriaXMarca(String nombre, int _fid_categoria, int _fid_marca) {
        ArrayList<Producto> productos = null;
        try {
            productos = daoProducto.listarXnombreXcategoriaXmarca(nombre, _fid_categoria, _fid_marca);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return productos;
    }
}

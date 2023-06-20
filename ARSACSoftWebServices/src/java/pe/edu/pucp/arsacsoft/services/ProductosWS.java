/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import pe.edu.pucp.arsacsoft.producto.model.Categoria;
import pe.edu.pucp.arsacsoft.producto.model.Marca;
import pe.edu.pucp.arsacsoft.productos.dao.CategoriaDAO;
import pe.edu.pucp.arsacsoft.productos.dao.MarcaDAO;
import pe.edu.pucp.arsacsoft.productos.mysql.CategoriaMySQL;
import pe.edu.pucp.arsacsoft.productos.mysql.MarcaMySQL;

/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "Productos")
public class ProductosWS {

    CategoriaDAO daoCategoria = new CategoriaMySQL();
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
}

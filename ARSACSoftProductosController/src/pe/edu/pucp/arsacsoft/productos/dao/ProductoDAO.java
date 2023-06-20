/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.productos.dao;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
/**
 *
 * @author User
 */
public interface ProductoDAO {
    ArrayList<Producto> listarXnombreXcategoriaXmarca(String nombre, int _fid_categoria, int _fid_marca);
    int insertar(Producto producto);
    int modificar(Producto producto);
    int eliminar(int idproducto);      
}
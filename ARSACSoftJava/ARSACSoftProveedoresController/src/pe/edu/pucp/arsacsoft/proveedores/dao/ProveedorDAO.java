/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.proveedores.dao;

import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;
import java.util.ArrayList;

/**
 *
 * @author User
 */
public interface ProveedorDAO {
    int insertar(Proveedor proveedor);
    int modificar(Proveedor proveedor);
    int eliminar(int idProveedor);
    ArrayList<Proveedor> listarAlfabeticamente();
    ArrayList<Proveedor> listarProveedoresXNombreXRuc(String nombre);
    ArrayList<Proveedor> listarPorCategoriaDeProducto(int idCategoria);
}

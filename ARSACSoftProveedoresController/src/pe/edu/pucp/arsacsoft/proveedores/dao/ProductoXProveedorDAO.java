/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.proveedores.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.proveedores.model.ProductoXProveedor;

/**
 *
 * @author User
 */
public interface ProductoXProveedorDAO {
    ArrayList<ProductoXProveedor> listarProductosXProveedor(String nombre, int _fid_categoria, 
                                int _fid_marca, int _fid_proveedor);
}

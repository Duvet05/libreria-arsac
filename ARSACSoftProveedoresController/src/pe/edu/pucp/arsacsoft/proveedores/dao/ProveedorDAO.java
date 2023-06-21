/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.proveedores.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

/**
 *
 * @author User
 */
public interface ProveedorDAO {
    ArrayList<Proveedor> listarProveedoresXNombreRUC(String nombre);
}

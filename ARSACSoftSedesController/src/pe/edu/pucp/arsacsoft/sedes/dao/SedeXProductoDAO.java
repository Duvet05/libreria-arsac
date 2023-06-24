/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.sedes.model.SedeXProducto;

/**
 *
 * @author Gino
 */
public interface SedeXProductoDAO {
    ArrayList<SedeXProducto> listarProductos(int idSede, String nombre);
    int eliminarProductos(int idSede);
}

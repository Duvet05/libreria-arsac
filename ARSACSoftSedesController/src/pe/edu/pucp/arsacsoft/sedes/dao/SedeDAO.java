/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;
import pe.edu.pucp.arsacsoft.sedes.model.SedeXProducto;
/**
 *
 * @author User
 */
public interface SedeDAO {
    ArrayList<Sede> listarTodas();
    int insertar(Sede sede);
    int modificar(Sede sede);
    int eliminar(int idsede);     
    
    ArrayList<SedeXProducto> listarProductos(int idSede);
    ArrayList<SedeXProducto> listarProductosPorNombreMarcaCategoria(int idSede, String nombre, int idMarca, int idCategoria);
    int eliminarProductos(int idSede);
}
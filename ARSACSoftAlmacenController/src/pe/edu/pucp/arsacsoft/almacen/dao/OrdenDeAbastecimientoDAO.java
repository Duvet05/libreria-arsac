/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeAbastecimiento;

/**
 *
 * @author User
 */
public interface OrdenDeAbastecimientoDAO {
    int insertar(OrdenDeAbastecimiento ordenAbastecimiento);
    int modificar(OrdenDeAbastecimiento ordenAbastecimiento);
    int eliminar(int idOrdenAbastecimiento);
    ArrayList<OrdenDeAbastecimiento> listarPorIdDNINombreEmpleado(String idDNINombreEmpleado);       
}

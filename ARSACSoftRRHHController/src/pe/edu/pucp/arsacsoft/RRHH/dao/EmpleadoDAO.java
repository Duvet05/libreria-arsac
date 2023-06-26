/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;

/**
 *
 * @author User
 */
public interface EmpleadoDAO {
    int insertar(Empleado empleado);
    int modificar(Empleado empleado);
    int eliminar(int idEmpleado);
    ArrayList<Empleado> listarPorSedeNombreDNI(int idSede, String DNINombre);    
    ArrayList<Empleado> listarPorNombreDNI( String DNINombre);
    Empleado buscarPorID(int idEmpleado);
    String obtenerDireccionDeSede(int idEmpleado);
}

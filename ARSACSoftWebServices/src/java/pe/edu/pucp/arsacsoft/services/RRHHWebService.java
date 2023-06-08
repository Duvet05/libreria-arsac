/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.sql.Date;
import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.RRHH.dao.EmpleadoDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.RRHH.model.TipoDeEmpleado;
import pe.edu.pucp.arsacsoft.RRHH.mysql.EmpleadoMySQL;

/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "RRHHWebService")
public class RRHHWebService {

    /**
     * This is a sample web service operation
     */
    private EmpleadoDAO daoEmpleado = new EmpleadoMySQL();

    @WebMethod(operationName = "listarporNombreDNI")
    public ArrayList<Empleado> listarporNombreDNI(String cadena) {

        ArrayList<Empleado> empleados = new ArrayList<Empleado>();
        try {
            empleados = daoEmpleado.listarporNombreDNI(cadena);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return empleados;
    }

    @WebMethod(operationName = "insertarEmpleado")
    public int insertarEmpleado(Empleado empleado) {
        int resultado = 0;
        try {
            //resultado = daoEmpleado.insertar(empleado);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}

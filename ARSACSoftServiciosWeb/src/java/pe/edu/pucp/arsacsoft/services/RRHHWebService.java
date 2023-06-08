package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.RRHH.dao.EmpleadoDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
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
        ArrayList<Empleado> empleados = null;
        try {
            empleados = daoEmpleado.listarporNombreDNI(cadena);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return empleados;
    }
//No funciona!

    @WebMethod(operationName = "insertarEmpleado")
    public int insertarEmpleado(Empleado empleado) {
        int resultado = 0;
        try {
            resultado = daoEmpleado.insertar(empleado);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}

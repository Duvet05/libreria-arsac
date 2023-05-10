package pe.edu.pucp.arsacsoft.empleados.dao;
import pe.edu.pucp.arsacsoft.empleados.model.Empleado;
import java.util.ArrayList;
/**
 *
 * @author User
 */
public interface EmpleadoDAO {
    ArrayList<Empleado> listarTodas();
    int insertar(Empleado empleado);
    int modificar(Empleado empleado);
    int eliminar(int idempleado);       
}

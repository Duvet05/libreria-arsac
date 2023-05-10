package pe.edu.pucp.arsacsoft.empleados.dao;
import pe.edu.pucp.arsacsoft.empleados.model.Vendedor;
import java.util.ArrayList;
/**
 *
 * @author User
 */
public interface VendedorDAO {
    ArrayList<Vendedor> listarTodas();
    int insertar(Vendedor vendedor);
    int modificar(Vendedor vendedor);
    int eliminar(int idempleado);   
}

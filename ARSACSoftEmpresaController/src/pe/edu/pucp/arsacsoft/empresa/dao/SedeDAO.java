package pe.edu.pucp.arsacsoft.empresa.dao;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.empresa.model.Sede;
/**
 *
 * @author User
 */
public interface SedeDAO {
    ArrayList<Sede> listarTodas();
    int insertar(Sede sede);
    int modificar(Sede sede);
    int eliminar(int idsede);      
}

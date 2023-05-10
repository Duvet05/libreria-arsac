package pe.edu.pucp.arsacsoft.empresa.dao;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.empresa.model.Empresa;
/**
 *
 * @author User
 */
public interface EmpresaDAO {
    ArrayList<Empresa> listarTodas();
    int insertar(Empresa empresa);
    int modificar(Empresa empresa);
    int eliminar(int idempresa);       
}

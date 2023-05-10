package pe.edu.pucp.arsacsoft.proveedores.dao;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;
/**
 *
 * @author User
 */
public interface ProveedorDAO {
    ArrayList<Proveedor> listarTodas();
    int insertar(Proveedor proveedor);
    int modificar(Proveedor proveedor);
    int eliminar(int idproveedor);      
}

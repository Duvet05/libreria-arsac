package pe.edu.pucp.arsacsoft.productos.dao;
import pe.edu.pucp.arsacsoft.productos.model.Producto;
import java.util.ArrayList;
/**
 *
 * @author User
 */
public interface ProductoDAO {
    ArrayList<Producto> listarTodas();
    int insertar(Producto producto);
    int modificar(Producto producto);
    int eliminar(int idproducto);      
}

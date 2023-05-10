package pe.edu.pucp.arsacsoft.compras.dao;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.compras.model.Lote;
/**
 *
 * @author User
 */
public interface LoteDAO {
    ArrayList<Lote> listarTodas();
    int insertar(Lote lote);
    int modificar(Lote lote);
    int eliminar(int idlote);    
}

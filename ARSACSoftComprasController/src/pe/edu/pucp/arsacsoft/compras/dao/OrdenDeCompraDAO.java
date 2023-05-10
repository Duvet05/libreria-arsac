package pe.edu.pucp.arsacsoft.compras.dao;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.compras.model.OrdenDeCompra;
/**
 *
 * @author User
 */
public interface OrdenDeCompraDAO {
    ArrayList<OrdenDeCompra> listarTodas();
    int insertar(OrdenDeCompra ordenDeCompra);
    int modificar(OrdenDeCompra ordenDeCompra);
    int eliminar(int idorden);       
}

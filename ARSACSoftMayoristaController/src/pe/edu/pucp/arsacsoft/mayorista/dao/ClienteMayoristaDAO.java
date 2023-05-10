
package pe.edu.pucp.arsacsoft.mayorista.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.mayorista.model.ClienteMayorista;

/**
 *
 * @author User
 */
public interface ClienteMayoristaDAO {
     ArrayList<ClienteMayorista> listarTodas();
    int insertar(ClienteMayorista clienteMayorista);
    int modificar(ClienteMayorista clienteMayorista);
    int eliminar(int idcliente);      
}

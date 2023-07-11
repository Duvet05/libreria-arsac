package pe.edu.pucp.arsacsoft.productos.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.producto.model.Promocion;

public interface PromocionDAO {

    ArrayList<Promocion> listarTodas();

    int insertar(Promocion promocion);

    int modificar(Promocion promocion);

    int eliminar(int idPromocion);
}

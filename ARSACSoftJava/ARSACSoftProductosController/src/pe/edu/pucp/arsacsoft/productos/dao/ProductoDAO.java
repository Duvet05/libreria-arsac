package pe.edu.pucp.arsacsoft.productos.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.producto.model.Producto;

public interface ProductoDAO {

    ArrayList<Producto> listarXnombreXcategoriaXmarca(String nombre, int _fid_categoria, int _fid_marca);

    ArrayList<Producto> listarProductosXSede(String _nombre, int _fid_sede, int _fid_categoria, int _fid_marca);

    int insertar(Producto producto);

    int modificar(Producto producto);

    int eliminar(int idproducto);
}

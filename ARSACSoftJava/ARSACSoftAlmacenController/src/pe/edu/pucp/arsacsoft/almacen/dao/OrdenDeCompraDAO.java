package pe.edu.pucp.arsacsoft.almacen.dao;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.almacen.model.LineaOrdenDeCompra;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeCompra;

public interface OrdenDeCompraDAO {
    int insertar(OrdenDeCompra ordenCompra);
    int modificar(OrdenDeCompra ordenCompra);
    ArrayList<OrdenDeCompra> listarPorProveedor(int idProveedor, Date fechaInicio, Date fechaFin, String estado);   
    ArrayList<LineaOrdenDeCompra> listarLineasOrdenDeCompra(int idOrdenCompra);
    int cancelar(int IdOrdenCompra);
    int registrarIngresoDeMercaderia(OrdenDeCompra ordenCompra);
}

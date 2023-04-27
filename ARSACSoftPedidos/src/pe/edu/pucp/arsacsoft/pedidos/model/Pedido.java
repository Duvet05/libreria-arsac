
package pe.edu.pucp.arsacsoft.pedidos.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.empleados.model.Vendedor;

public class Pedido {
    private int idPedido;
    private double montoTotal;
    private boolean estado;
    private Date fechaPedido;
    private Date fechaEntrega;
    private String direccionEnvio;
    private boolean clienteMinor;
    private double descTotal;
    private ArrayList<LineaPedido> lineasPedido;
    private EstadoPedido estadoPedido;
    
    private boolean ventaConBoleta;
    private Factura factura;
    private Boleta boleta;
    
    private Vendedor vendedor;
    //ver la posibilidad de tambien contar con la referencia al cajero
}

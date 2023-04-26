
package pe.edu.pucp.arsacsoft.pedido.model;

import java.util.ArrayList;
import java.util.Date;

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
    private DocumentoPago documentoPago;
    //private Vendedor vendedor;
}

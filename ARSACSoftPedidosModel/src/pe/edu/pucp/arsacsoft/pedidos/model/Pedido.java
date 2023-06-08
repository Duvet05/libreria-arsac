package pe.edu.pucp.arsacsoft.pedidos.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;

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
    private Empleado vendedor;

    public Pedido() {
    }

    public Pedido(int idPedido, double montoTotal, boolean estado, Date fechaPedido, Date fechaEntrega, String direccionEnvio, boolean clienteMinor, double descTotal, ArrayList<LineaPedido> lineasPedido, EstadoPedido estadoPedido, boolean ventaConBoleta, Factura factura, Boleta boleta, Empleado vendedor) {
        this.idPedido = idPedido;
        this.montoTotal = montoTotal;
        this.estado = estado;
        this.fechaPedido = fechaPedido;
        this.fechaEntrega = fechaEntrega;
        this.direccionEnvio = direccionEnvio;
        this.clienteMinor = clienteMinor;
        this.descTotal = descTotal;
        this.lineasPedido = lineasPedido;
        this.estadoPedido = estadoPedido;
        this.ventaConBoleta = ventaConBoleta;
        this.factura = factura;
        this.boleta = boleta;
        this.vendedor = vendedor;
    }

    public int getIdPedido() {
        return idPedido;
    }

    public void setIdPedido(int idPedido) {
        this.idPedido = idPedido;
    }

    public double getMontoTotal() {
        return montoTotal;
    }

    public void setMontoTotal(double montoTotal) {
        this.montoTotal = montoTotal;
    }

    public boolean isEstado() {
        return estado;
    }

    public void setEstado(boolean estado) {
        this.estado = estado;
    }

    public Date getFechaPedido() {
        return fechaPedido;
    }

    public void setFechaPedido(Date fechaPedido) {
        this.fechaPedido = fechaPedido;
    }

    public Date getFechaEntrega() {
        return fechaEntrega;
    }

    public void setFechaEntrega(Date fechaEntrega) {
        this.fechaEntrega = fechaEntrega;
    }

    public String getDireccionEnvio() {
        return direccionEnvio;
    }

    public void setDireccionEnvio(String direccionEnvio) {
        this.direccionEnvio = direccionEnvio;
    }

    public boolean isClienteMinor() {
        return clienteMinor;
    }

    public void setClienteMinor(boolean clienteMinor) {
        this.clienteMinor = clienteMinor;
    }

    public double getDescTotal() {
        return descTotal;
    }

    public void setDescTotal(double descTotal) {
        this.descTotal = descTotal;
    }

    public ArrayList<LineaPedido> getLineasPedido() {
        return lineasPedido;
    }

    public void setLineasPedido(ArrayList<LineaPedido> lineasPedido) {
        this.lineasPedido = lineasPedido;
    }

    public EstadoPedido getEstadoPedido() {
        return estadoPedido;
    }

    public void setEstadoPedido(EstadoPedido estadoPedido) {
        this.estadoPedido = estadoPedido;
    }

    public boolean isVentaConBoleta() {
        return ventaConBoleta;
    }

    public void setVentaConBoleta(boolean ventaConBoleta) {
        this.ventaConBoleta = ventaConBoleta;
    }

    public Factura getFactura() {
        return factura;
    }

    public void setFactura(Factura factura) {
        this.factura = factura;
    }

    public Boleta getBoleta() {
        return boleta;
    }

    public void setBoleta(Boleta boleta) {
        this.boleta = boleta;
    }

    public Empleado getVendedor() {
        return vendedor;
    }

    public void setVendedor(Empleado vendedor) {
        this.vendedor = vendedor;
    }

}

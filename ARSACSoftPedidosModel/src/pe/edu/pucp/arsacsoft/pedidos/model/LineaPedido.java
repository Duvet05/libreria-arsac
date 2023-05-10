
package pe.edu.pucp.arsacsoft.pedidos.model;

import pe.edu.pucp.arsacsoft.productos.model.Producto;


public class LineaPedido {
    private int idLineaPedido;
    private int cantidad;
    private double subTotal;
    private boolean activo;
    private double descuento;
    private Producto producto;
    public LineaPedido(){}
    public LineaPedido(int cantidad, double subTotal, boolean activo, double descuento, Producto producto) {
        this.cantidad = cantidad;
        this.subTotal = subTotal;
        this.activo = activo;
        this.descuento = descuento; 
        this.producto = producto;
    }

    public int getIdLineaPedido() {
        return idLineaPedido;
    }

    public void setIdLineaPedido(int idLineaPedido) {
        this.idLineaPedido = idLineaPedido;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public double getSubTotal() {
        return subTotal;
    }

    public void setSubTotal(double subTotal) {
        this.subTotal = subTotal;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public double getDescuento() {
        return descuento;
    }

    public void setDescuento(double descuento) {
        this.descuento = descuento;
    }

    public Producto getProducto() {
        return producto;
    }

    public void setProducto(Producto producto) {
        this.producto = producto;
    }
    
    
}

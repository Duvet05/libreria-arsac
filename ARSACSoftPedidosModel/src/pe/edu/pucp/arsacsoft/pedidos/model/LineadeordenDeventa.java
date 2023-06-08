/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.pedidos.model;

import pe.edu.pucp.arsacsoft.almacen.model.Producto;

/**
 *
 * @author User
 */
public class LineadeordenDeventa {

    public LineadeordenDeventa() {
    }

    public int getIdLineadeordenDeventa() {
        return idLineadeordenDeventa;
    }

    public void setIdLineadeordenDeventa(int idLineadeordenDeventa) {
        this.idLineadeordenDeventa = idLineadeordenDeventa;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public double getDescuento() {
        return descuento;
    }

    public void setDescuento(double descuento) {
        this.descuento = descuento;
    }

    public double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(double subtotal) {
        this.subtotal = subtotal;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public Producto getProducto() {
        return producto;
    }

    public void setProducto(Producto producto) {
        this.producto = producto;
    }

    private int idLineadeordenDeventa;
    private int cantidad;
    private double descuento;
    private double subtotal;
    private boolean activo;   
    private Producto producto;        
}

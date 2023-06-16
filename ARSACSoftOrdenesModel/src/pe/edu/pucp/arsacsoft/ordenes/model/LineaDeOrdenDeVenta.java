/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.ordenes.model;

import pe.edu.pucp.arsacsoft.producto.model.Producto;

/**
 *
 * @author Gino
 */
public class LineaDeOrdenDeVenta {
    private int idLineaDeOrdenDeVenta;
    private int cantidad;
    private double precio;
    private double descuento;
    private boolean activo;
    private Producto producto;

    public int getIdLineaDeOrdenDeVenta() {
        return idLineaDeOrdenDeVenta;
    }

    public void setIdLineaDeOrdenDeVenta(int idLineaDeOrdenDeVenta) {
        this.idLineaDeOrdenDeVenta = idLineaDeOrdenDeVenta;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public double getPrecio() {
        return precio;
    }

    public void setPrecio(double precio) {
        this.precio = precio;
    }

    public double getDescuento() {
        return descuento;
    }

    public void setDescuento(double descuento) {
        this.descuento = descuento;
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
    
}

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
public class LineaDeOrdenDeCompra {
    private int idLineaDeOrdenDeCompra;
    private int cantidad;
    private double costo;
    private boolean activo;
    private Producto producto;

    public int getIdLineaDeOrdenDeCompra() {
        return idLineaDeOrdenDeCompra;
    }

    public void setIdLineaDeOrdenDeCompra(int idLineaDeOrdenDeCompra) {
        this.idLineaDeOrdenDeCompra = idLineaDeOrdenDeCompra;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public double getCosto() {
        return costo;
    }

    public void setCosto(double costo) {
        this.costo = costo;
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

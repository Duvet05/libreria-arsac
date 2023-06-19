/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.model;

/**
 *
 * @author User
 */
public class LineaOrdenDeCompra {

    public LineaOrdenDeCompra() {
    }

    public int getIdLineaOrdenDeCompra() {
        return idLineaOrdenDeCompra;
    }

    public void setIdLineaOrdenDeCompra(int idLineaOrdenDeCompra) {
        this.idLineaOrdenDeCompra = idLineaOrdenDeCompra;
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
    private int idLineaOrdenDeCompra;
    private int cantidad;
    private double costo;
    private boolean activo;   
    private Producto producto;      
}
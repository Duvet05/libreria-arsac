/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.proveedores.model;

import pe.edu.pucp.arsacsoft.almacen.model.Producto;

/**
 *
 * @author User
 */
public class ProductoXProveedor {

    public ProductoXProveedor() {
    }

    public int getIdProductoXProveedor() {
        return idProductoXProveedor;
    }

    public void setIdProductoXProveedor(int idProductoXProveedor) {
        this.idProductoXProveedor = idProductoXProveedor;
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
    private int idProductoXProveedor;
    private double costo ;
    private boolean activo ;
    private Producto producto;
}

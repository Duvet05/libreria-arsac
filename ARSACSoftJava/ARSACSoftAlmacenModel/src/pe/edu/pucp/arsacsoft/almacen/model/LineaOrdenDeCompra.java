/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.model;

import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.proveedores.model.ProductoXProveedor;

/**
 *
 * @author User
 */
public class LineaOrdenDeCompra {

    private int idLineaOrdenDeCompra;
    private int cantidad;
    private double subtotal;
    private boolean activo;   
    private ProductoXProveedor productoProveedor;   
    
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

    public double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(double costo) {
        this.subtotal = costo;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public ProductoXProveedor getProductoProveedor() {
        return productoProveedor;
    }

    public void setProductoProveedor(ProductoXProveedor producto) {
        this.productoProveedor = producto;
    }
       
}

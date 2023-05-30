/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.compras.model;

import pe.edu.pucp.arsacsoft.productos.model.Producto;

/**
 *
 * @author duvet
 */
public class Lote {

    private Producto producto;
    private int cantProducto;

    public Lote() {
    }

    public Lote(Producto producto, int cantProducto) {
        this.producto = producto;
        this.cantProducto = cantProducto;
    }

    public Producto getProducto() {
        return producto;
    }

    public void setProducto(Producto producto) {
        this.producto = producto;
    }

    public int getCantProducto() {
        return cantProducto;
    }

    public void setCantProducto(int cantProducto) {
        this.cantProducto = cantProducto;
    }

}

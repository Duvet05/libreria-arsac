/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.model;

import pe.edu.pucp.arsacsoft.almacen.model.Producto;

/**
 *
 * @author User
 */
public class SedexProducto {

    public SedexProducto() {
    }

    public int getIdSedexProducto() {
        return idSedexProducto;
    }

    public void setIdSedexProducto(int idSedexProducto) {
        this.idSedexProducto = idSedexProducto;
    }

    public int getStock() {
        return stock;
    }

    public void setStock(int stock) {
        this.stock = stock;
    }

    public int getStockBase() {
        return stockBase;
    }

    public void setStockBase(int stockBase) {
        this.stockBase = stockBase;
    }

    public int getStockMaximo() {
        return stockMaximo;
    }

    public void setStockMaximo(int stockMaximo) {
        this.stockMaximo = stockMaximo;
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
    private int idSedexProducto;
    private int stock ;
    private int stockBase;
    private int stockMaximo; 
    private boolean activo; 
    private Producto producto;
}

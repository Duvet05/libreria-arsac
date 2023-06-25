/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.model;

import pe.edu.pucp.arsacsoft.producto.model.Producto;

/**
 *
 * @author Gino
 */
public class LineaOrdenDeAbastecimiento {
    private int idLineaOrdenDeAbastecimiento;
    private int cantidad;
    private boolean activo;
    private Producto producto;

    public LineaOrdenDeAbastecimiento() {
    }

    public int getIdLineaOrdenDeAbastecimiento() {
        return idLineaOrdenDeAbastecimiento;
    }

    public void setIdLineaOrdenDeAbastecimiento(int idLineaOrdenDeAbastecimiento) {
        this.idLineaOrdenDeAbastecimiento = idLineaOrdenDeAbastecimiento;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
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

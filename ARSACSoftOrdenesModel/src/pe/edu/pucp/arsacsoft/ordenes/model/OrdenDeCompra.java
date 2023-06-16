/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.ordenes.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

/**
 *
 * @author Gino
 */
public class OrdenDeCompra {
    private int idOrdenDeCompra;
    private Date fechaOrden;
    private double costoTotal;
    private boolean activo;
    private Empleado empleadpo;
    private Proveedor proveedor;
    private ArrayList<LineaDeOrdenDeCompra> lineas;

    public ArrayList<LineaDeOrdenDeCompra> getLineas() {
        return lineas;
    }

    public void setLineas(ArrayList<LineaDeOrdenDeCompra> lineas) {
        this.lineas = lineas;
    }

    public int getIdOrdenDeCompra() {
        return idOrdenDeCompra;
    }

    public void setIdOrdenDeCompra(int idOrdenDeCompra) {
        this.idOrdenDeCompra = idOrdenDeCompra;
    }

    public Date getFechaOrden() {
        return fechaOrden;
    }

    public void setFechaOrden(Date fechaOrden) {
        this.fechaOrden = fechaOrden;
    }

    public double getCostoTotal() {
        return costoTotal;
    }

    public void setCostoTotal(double costoTotal) {
        this.costoTotal = costoTotal;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public Empleado getEmpleadpo() {
        return empleadpo;
    }

    public void setEmpleadpo(Empleado empleadpo) {
        this.empleadpo = empleadpo;
    }

    public Proveedor getProveedor() {
        return proveedor;
    }

    public void setProveedor(Proveedor proveedor) {
        this.proveedor = proveedor;
    }
    
}

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.pedidos.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;

/**
 *
 * @author User
 */
public class OrdenDeVenta {
    private int idOrdenDeVenta;
    private Date fechaOrden;
    private double precioTotal;
    private EstadoPedido estado;
    private Empleado empleado;
    private ArrayList<LineadeordenDeventa> lineas;
    private boolean activo;
    public OrdenDeVenta() {
    }

    public int getIdOrdenDeVenta() {
        return idOrdenDeVenta;
    }

    public void setIdOrdenDeVenta(int idOrdenDeVenta) {
        this.idOrdenDeVenta = idOrdenDeVenta;
    }

    public Date getFechaOrden() {
        return fechaOrden;
    }

    public void setFechaOrden(Date fechaOrden) {
        this.fechaOrden = fechaOrden;
    }

    public double getPrecioTotal() {
        return precioTotal;
    }

    public void setPrecioTotal(double precioTotal) {
        this.precioTotal = precioTotal;
    }

    public EstadoPedido getEstado() {
        return estado;
    }

    public void setEstado(EstadoPedido estado) {
        this.estado = estado;
    }

    public Empleado getEmpleado() {
        return empleado;
    }

    public void setEmpleado(Empleado empleado) {
        this.empleado = empleado;
    }

    public ArrayList<LineadeordenDeventa> getLineas() {
        return lineas;
    }

    public void setLineas(ArrayList<LineadeordenDeventa> lineas) {
        this.lineas = lineas;
    }
    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }    
}

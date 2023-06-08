/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;

/**
 *
 * @author User
 */
public class OrdenDeCompra {

    public OrdenDeCompra() {
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

    public double getCostototal() {
        return costototal;
    }

    public void setCostototal(double costototal) {
        this.costototal = costototal;
    }

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }    
    
    public Empleado getEmpleado() {
        return empleado;
    }

    public void setEmpleado(Empleado empleado) {
        this.empleado = empleado;
    }
    public ArrayList<LineaOrdenDeCompra> getLineas() {
        return lineas;
    }

    public void setLineas(ArrayList<LineaOrdenDeCompra> lineas) {
        this.lineas = lineas;
    }    
    private int idOrdenDeCompra;
    private Date fechaOrden;
    private double costototal;
    private String estado;        
    private boolean activo; 
    private Empleado empleado;
     private ArrayList<LineaOrdenDeCompra> lineas;
}
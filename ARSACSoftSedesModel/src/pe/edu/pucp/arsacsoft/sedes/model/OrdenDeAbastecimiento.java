/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;

/**
 *
 * @author User
 */
public class OrdenDeAbastecimiento {

    public OrdenDeAbastecimiento() {
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

    public Date getFechaEntrega() {
        return fechaEntrega;
    }

    public void setFechaEntrega(Date fechaEntrega) {
        this.fechaEntrega = fechaEntrega;
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
    
    public Sede getSede() {
        return sede;
    }

    public void setSede(Sede sede) {
        this.sede = sede;
    }
    public Empleado getEmpleado() {
        return empleado;
    }

    public void setEmpleado(Empleado empleado) {
        this.empleado = empleado;
    } 
    public ArrayList<LineaOrdenDeAbastecimiento> getLineas() {
        return lineas;
    }

    public void setLineas(ArrayList<LineaOrdenDeAbastecimiento> lineas) {
        this.lineas = lineas;
    }    
    private int idOrdenDeCompra;
    private Date fechaOrden;
    private Date fechaEntrega;
    private String estado;        
    private boolean activo;    
    private Sede sede;
    private Empleado empleado;
    private ArrayList<LineaOrdenDeAbastecimiento> lineas;
}

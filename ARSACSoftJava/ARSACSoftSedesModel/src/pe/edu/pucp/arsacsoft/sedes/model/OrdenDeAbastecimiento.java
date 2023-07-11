/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.model;

import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author Gino
 */
public class OrdenDeAbastecimiento {
    
    private int idOrdenDeAbastecimiento;
    
    private Date fechaRegistro;
    private Date fechaEntrega;
    private Date fechaCancelacion;
    
    private int idEmpleado;

    private String estado;
    private boolean activo;    
    private Sede sede;
    private ArrayList<LineaOrdenDeAbastecimiento> lineas;

    public int getIdEmpleado() {
        return idEmpleado;
    }

    public void setIdEmpleado(int idEmpleado) {
        this.idEmpleado = idEmpleado;
    }
    
    public int getIdOrdenDeAbastecimiento() {
        return idOrdenDeAbastecimiento;
    }

    public void setIdOrdenDeAbastecimiento(int idOrdenDeAbastecimiento) {
        this.idOrdenDeAbastecimiento = idOrdenDeAbastecimiento;
    }

    public Date getFechaRegistro() {
        return fechaRegistro;
    }

    public void setFechaRegistro(Date fechaRegistro) {
        this.fechaRegistro = fechaRegistro;
    }

    public Date getFechaEntrega() {
        return fechaEntrega;
    }

    public void setFechaEntrega(Date fechaEntrega) {
        this.fechaEntrega = fechaEntrega;
    }

    public Date getFechaCancelacion() {
        return fechaCancelacion;
    }

    public void setFechaCancelacion(Date fechaCancelacion) {
        this.fechaCancelacion = fechaCancelacion;
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

    public ArrayList<LineaOrdenDeAbastecimiento> getLineas() {
        return lineas;
    }

    public void setLineas(ArrayList<LineaOrdenDeAbastecimiento> lineas) {
        this.lineas = lineas;
    }

    

}

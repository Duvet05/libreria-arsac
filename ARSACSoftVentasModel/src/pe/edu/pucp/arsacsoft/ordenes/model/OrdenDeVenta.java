/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.ordenes.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.ClienteMayorista;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;

/**
 *
 * @author Gino
 */
public class OrdenDeVenta {
    private int idOrdenDeVenta;
    private Date fechaOrden;
    private Date fechaEnvio;
    private double precioTotal;
    private boolean activo;
    private Empleado empleado;
    private ClienteMayorista clienteMayorista;
    private ArrayList<LineaDeOrdenDeVenta> lineaDeOrdenDeVenta;
    private String estado;

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }
    
    public Date getFechaEnvio() {
        return fechaEnvio;
    }

    public void setFechaEnvio(Date fechaEnvio) {
        this.fechaEnvio = fechaEnvio;
    }
    
    public ArrayList<LineaDeOrdenDeVenta> getLineaDeOrdenDeVenta() {
        return lineaDeOrdenDeVenta;
    }

    public void setLineaDeOrdenDeVenta(ArrayList<LineaDeOrdenDeVenta> lineaDeOrdenDeVenta) {
        this.lineaDeOrdenDeVenta = lineaDeOrdenDeVenta;
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

    public ClienteMayorista getClienteMayorista() {
        return clienteMayorista;
    }

    public void setClienteMayorista(ClienteMayorista clienteMayorista) {
        this.clienteMayorista = clienteMayorista;
    }
    
    
}

package pe.edu.pucp.arsacsoft.almacen.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;

public class OrdenDeAbastecimiento {

    public OrdenDeAbastecimiento() {
    }

    public int getIdOrdenDeAbastecimiento() {
        return idOrdenDeAbastecimiento;
    }

    public void setIdOrdenDeAbastecimiento(int idOrdenDeAbastecimiento) {
        this.idOrdenDeAbastecimiento = idOrdenDeAbastecimiento;
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

    public boolean isEntregado() {
        return entregado;
    }

    public void setEntregado(boolean entregado) {
        this.entregado = entregado;
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
    public ArrayList<LineaDeOrdenDeAbastecimiento> getLineas() {
        return lineas;
    }

    public void setLineas(ArrayList<LineaDeOrdenDeAbastecimiento> lineas) {
        this.lineas = lineas;
    }    
    private int idOrdenDeAbastecimiento;
    private Date fechaOrden;
    private Date fechaEntrega;
    private boolean entregado;
    private boolean activo;    
    private Sede sede;
    private Empleado empleado;
    private ArrayList<LineaDeOrdenDeAbastecimiento> lineas;
}

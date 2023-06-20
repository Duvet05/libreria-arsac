package pe.edu.pucp.arsacsoft.almacen.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;

public class OrdenDeAbastecimiento {

    private int idOrdenDeCompra;
    private Date fechaOrden;
    private boolean activo;
    private Sede sede;
    private Empleado empleado;
    private ArrayList<LineaDeOrdenDeAbastecimiento> lineas;

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
}

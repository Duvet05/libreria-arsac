
package pe.edu.pucp.arsacsoft.empleados.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.compras.model.OrdenDeCompra;


public class Empleado extends Persona{
    private TipoEmpleado cargo;
    private Date fechaContratacion;
    private double salario;
    private String direccion;
    private String contrasena;
    private ArrayList<OrdenDeCompra> ordenesDeCompra;
    public Empleado(){}

    public Empleado(TipoEmpleado cargo, Date fechaContratacion, double salario, String direccion, String contrasena, String nombre, String apellidos, String DNI, String correo, int telefono) {
        super(nombre, apellidos, DNI, correo, telefono);
        this.cargo = cargo;
        this.fechaContratacion = fechaContratacion;
        this.salario = salario;
        this.direccion = direccion;
        this.contrasena = contrasena;
    }

    public ArrayList<OrdenDeCompra> getOrdenesDeCompra() {
        return ordenesDeCompra;
    }

    public void setOrdenesDeCompra(ArrayList<OrdenDeCompra> ordenesDeCompra) {
        this.ordenesDeCompra = ordenesDeCompra;
    }
    
    public TipoEmpleado getCargo() {
        return cargo;
    }

    public void setCargo(TipoEmpleado cargo) {
        this.cargo = cargo;
    }

    public Date getFechaContratacion() {
        return fechaContratacion;
    }

    public void setFechaContratacion(Date fechaContratacion) {
        this.fechaContratacion = fechaContratacion;
    }

    public double getSalario() {
        return salario;
    }

    public void setSalario(double salario) {
        this.salario = salario;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getContrasena() {
        return contrasena;
    }

    public void setContrasena(String contrasena) {
        this.contrasena = contrasena;
    }
    
    
}

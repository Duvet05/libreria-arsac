
package pe.edu.pucp.arsacsoft.empleados.model;

import java.util.Date;


public class Vendedor extends Empleado{
    private int cantVentas;
    private double totalVendido;
    public Vendedor(){}
    
    public Vendedor(int cantVentas, double totalVendido,int idPersona, TipoEmpleado cargo, Date fechaContratacion, double salario, String direccion, String contrasena, String nombre, String apellidos, String DNI, String correo, int telefono) {
        super(cargo, fechaContratacion, salario, direccion, contrasena, idPersona,nombre, apellidos, DNI, correo, telefono);
        this.cantVentas = cantVentas;
        this.totalVendido = totalVendido;
    }

    public int getCantVentas() {
        return cantVentas;
    }

    public void setCantVentas(int cantVentas) {
        this.cantVentas = cantVentas;
    }

    public double getTotalVendido() {
        return totalVendido;
    }

    public void setTotalVendido(double totalVendido) {
        this.totalVendido = totalVendido;
    }
    
    
}

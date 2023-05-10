
package pe.edu.pucp.arsacsoft.empresa.model;

import java.time.LocalTime;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.empleados.model.Empleado;
import pe.edu.pucp.arsacsoft.productos.model.Producto;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;


public class Sede {
    private int idSede;
    private String direccion;
    private int telefono;
    private String correo;
    private LocalTime horaIniAtencion;
    private LocalTime horaFinAtencion;
    private String descripcion;
    private boolean esPrincipal;
    private ArrayList<Empleado> empleados;
    private ArrayList<Proveedor> proveedores;
    private ArrayList<Producto> productos;
    private Empresa empresa;

   
   
    public Sede(){}
    public Sede(int idSede, String direccion, int telefono, String correo, LocalTime horaIniAtencion, LocalTime horaFinAtencion, String descripcion, boolean esPrincipal) {
        this.idSede = idSede;
        this.direccion = direccion;
        this.telefono = telefono;
        this.correo = correo;
        this.horaIniAtencion = horaIniAtencion;
        this.horaFinAtencion = horaFinAtencion;
        this.descripcion = descripcion;
        this.esPrincipal = esPrincipal;
    }

    public int getIdSede() {
        return idSede;
    }

    public void setIdSede(int idSede) {
        this.idSede = idSede;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public LocalTime getHoraIniAtencion() {
        return horaIniAtencion;
    }

    public void setHoraIniAtencion(LocalTime horaIniAtencion) {
        this.horaIniAtencion = horaIniAtencion;
    }

    public LocalTime getHoraFinAtencion() {
        return horaFinAtencion;
    }

    public void setHoraFinAtencion(LocalTime horaFinAtencion) {
        this.horaFinAtencion = horaFinAtencion;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public boolean isEsPrincipal() {
        return esPrincipal;
    }

    public void setEsPrincipal(boolean esPrincipal) {
        this.esPrincipal = esPrincipal;
    }

    public ArrayList<Empleado> getEmpleados() {
        return empleados;
    }

    public void setEmpleados(ArrayList<Empleado> empleados) {
        this.empleados = empleados;
    }

    public ArrayList<Proveedor> getProveedores() {
        return proveedores;
    }

    public void setProveedores(ArrayList<Proveedor> proveedores) {
        this.proveedores = proveedores;
    }

    public ArrayList<Producto> getProductos() {
        return productos;
    }

    public void setProductos(ArrayList<Producto> productos) {
        this.productos = productos;
    }
   
    public Empresa getEmpresa() {
        return empresa;
    }

    public void setEmpresa(Empresa empresa) {
        this.empresa = empresa;
    }
}

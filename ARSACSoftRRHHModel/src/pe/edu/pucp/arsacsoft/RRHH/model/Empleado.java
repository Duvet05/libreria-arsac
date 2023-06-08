/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.model;

import java.util.Date;

/**
 *
 * @author User
 */
public class Empleado extends Persona{

    public Empleado() {
    }

    public Empleado(Date fechaContratacion, double salario, String direccion, String usuario, String contrasenha, TipoDeEmpleado tipo, int idPersona, String nombre, String apellidos, String DNI, String correo, String telefono, boolean activo) {
        super(idPersona, nombre, apellidos, DNI, correo, telefono, activo);
        this.fechaContratacion = fechaContratacion;
        this.salario = salario;
        this.direccion = direccion;
        this.usuario = usuario;
        this.contrasenha = contrasenha;
        this.tipo = tipo;
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

    public String getUsuario() {
        return usuario;
    }

    public void setUsuario(String usuario) {
        this.usuario = usuario;
    }

    public String getContrasenha() {
        return contrasenha;
    }

    public void setContrasenha(String contrasenha) {
        this.contrasenha = contrasenha;
    }

    public TipoDeEmpleado getTipo() {
        return tipo;
    }

    public void setTipo(TipoDeEmpleado tipo) {
        this.tipo = tipo;
    }  
    private Date fechaContratacion;
    private double salario;
    private String direccion;
    private String usuario;
    private String contrasenha;
    private TipoDeEmpleado tipo;
}

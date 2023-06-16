/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.model;

import java.util.Date;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;

/**
 *
 * @author User
 */
public class Empleado extends Persona{

    private Date fechaContratacion;
    private double salario;
    private String direccion;
    private String usuario;
    private String contrasenha;
    private TipoDeEmpleado tipo;
    private Sede sede;
    
    public Empleado(){}

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

    public Sede getSede() {
        return sede;
    }

    public void setSede(Sede sede) {
        this.sede = sede;
    }
    
    
    

}

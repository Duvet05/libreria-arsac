/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.model;

/**
 *
 * @author User
 */
public class TipoDeEmpleado {

    public TipoDeEmpleado() {
    }

    public int getIdTipoDeEmpleado() {
        return idTipoDeEmpleado;
    }

    public void setIdTipoDeEmpleado(int idTipoDeEmpleado) {
        this.idTipoDeEmpleado = idTipoDeEmpleado;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }
    private int idTipoDeEmpleado;
    private String descripcion;
    private boolean activo;
}

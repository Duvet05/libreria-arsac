/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.model;

import java.util.ArrayList;

/**
 *
 * @author User
 */
public class Sede {

    public Sede() {
    }

    public int getIdSede() {
        return idSede;
    }

    public void setIdSede(int idSede) {
        this.idSede = idSede;
    }

    public boolean isEsAlmacen() {
        return esAlmacen;
    }

    public void setEsAlmacen(boolean esAlmacen) {
        this.esAlmacen = esAlmacen;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public ArrayList<SedexProducto> getProductosPorSede() {
        return productosPorSede;
    }

    public void setProductosPorSede(ArrayList<SedexProducto> productosPorSede) {
        this.productosPorSede = productosPorSede;
    }
    
    private int idSede;
    private boolean esAlmacen;
    private String direccion;
    private String telefono;
    private String correo;
    private boolean activo;
    private ArrayList<SedexProducto> productosPorSede;
    
}

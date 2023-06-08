/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.pedidos.model;

/**
 *
 * @author User
 */
public class OrdenDeVentaMinorista extends OrdenDeVenta{

    public OrdenDeVentaMinorista() {
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getEsPagoTargeta() {
        return esPagoTargeta;
    }

    public void setEsPagoTargeta(String esPagoTargeta) {
        this.esPagoTargeta = esPagoTargeta;
    }
    private String nombre;
    private String esPagoTargeta;
}

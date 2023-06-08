/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.pedidos.model;

import java.util.Date;
import pe.edu.pucp.arsacsoft.RRHH.model.ClienteMayorista;
/**
 *
 * @author User
 */
public class OrdenDeVentaMayorista extends OrdenDeVenta{
    public Date getFechaEntrega() {
        return fechaEntrega;
    }

    public void setFechaEntrega(Date fechaEntrega) {
        this.fechaEntrega = fechaEntrega;
    }    
    
    public ClienteMayorista getCliente() {
        return cliente;
    }

    public void setCliente(ClienteMayorista cliente) {
        this.cliente = cliente;
    }
    private Date fechaEntrega;
    private ClienteMayorista cliente;


}

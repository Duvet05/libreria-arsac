
package pe.edu.pucp.arsacsoft.mayorista.model;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.empleados.model.Persona;
import pe.edu.pucp.arsacsoft.pedidos.model.Factura;


public class ClienteMayorista extends Persona{
    private int idCliente;
    private int RUC;
    private String razonSocial;
    private ArrayList<Factura> facturas;

    public ClienteMayorista(int RUC, String razonSocial, String nombre, 
            String apellidos, String DNI, String correo, int telefono) {
        super(nombre, apellidos, DNI, correo, telefono);
        this.RUC = RUC;
        this.razonSocial = razonSocial;
    }

    public ArrayList<Factura> getFactura() {
        return facturas;
    }

    public void setFactura(ArrayList<Factura> facturas) {
        this.facturas = facturas;
    }

    public int getIdCliente() {
        return idCliente;
    }

    public void setIdCliente(int idCliente) {
        this.idCliente = idCliente;
    }

    public int getRUC() {
        return RUC;
    }

    public void setRUC(int RUC) {
        this.RUC = RUC;
    }

    public String getRazonSocial() {
        return razonSocial;
    }

    public void setRazonSocial(String razonSocial) {
        this.razonSocial = razonSocial;
    }
    
    
}

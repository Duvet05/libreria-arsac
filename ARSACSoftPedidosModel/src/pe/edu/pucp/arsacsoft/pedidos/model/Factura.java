
package pe.edu.pucp.arsacsoft.pedidos.model;
/**
 *
 * @author a2018
 */
public class Factura extends DocumentoDePago{
    private int idFactura;
    private String razonzocial;
    private int DNI;
    private int RUC;
    private String Nombre;
    public Factura(){}
    public Factura(int idFactura, String razonzocial, int DNI, int RUC, String Nombre, int idDocumento) {
        super(idDocumento);
        this.idFactura = idFactura;
        this.razonzocial = razonzocial;
        this.DNI = DNI;
        this.RUC = RUC;
        this.Nombre = Nombre;
    }
    public int getIdFactura() {
        return idFactura;
    }

    public void setIdFactura(int idFactura) {
        this.idFactura = idFactura;
    }

    public String getRazonzocial() {
        return razonzocial;
    }

    public void setRazonzocial(String razonzocial) {
        this.razonzocial = razonzocial;
    }

    public int getDNI() {
        return DNI;
    }

    public void setDNI(int DNI) {
        this.DNI = DNI;
    }

    public int getRUC() {
        return RUC;
    }

    public void setRUC(int RUC) {
        this.RUC = RUC;
    }

    public String getNombre() {
        return Nombre;
    }

    public void setNombre(String Nombre) {
        this.Nombre = Nombre;
    }
    
}

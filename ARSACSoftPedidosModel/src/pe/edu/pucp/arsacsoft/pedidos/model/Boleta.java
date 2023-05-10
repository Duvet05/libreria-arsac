
package pe.edu.pucp.arsacsoft.pedidos.model;



public class Boleta extends DocumentoDePago{
    private int idBoleta;
    private String descripcion;
    public Boleta(){}
    public Boleta(int idBoleta, String descripcion, int idDocumento) {
        super(idDocumento);
        this.idBoleta = idBoleta;
        this.descripcion = descripcion;
    }  
    public int getIdBoleta() {
        return idBoleta;
    }

    public void setIdBoleta(int idBoleta) {
        this.idBoleta = idBoleta;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }    
}

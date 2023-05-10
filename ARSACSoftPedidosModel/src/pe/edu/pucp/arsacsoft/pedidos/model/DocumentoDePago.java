
package pe.edu.pucp.arsacsoft.pedidos.model;

/**
 *
 * @author User
 */
abstract public class DocumentoDePago {
    private int idDocumento;
    public DocumentoDePago() {
    }    
    public DocumentoDePago(int idDocumento) {
        this.idDocumento = idDocumento;
    }

    public int getIdDocumento() {
        return idDocumento;
    }

    public void setIdDocumento(int idDocumento) {
        this.idDocumento = idDocumento;
    }    
}

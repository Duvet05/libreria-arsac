
package pe.edu.pucp.arsacsoft.empresa.model;

public class Empresa {
    private String nombre;
    private String RUC;
    private String direccion;
    private String telefono;
    private String email;

    public String getNombre() {
        return nombre;
    }

    public String getDireccion() {
        return direccion;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setNombre(String aNombre) {
        nombre = aNombre;
    }

    public void setDireccion(String aDireccion) {
        direccion = aDireccion;
    }

    public void setTelefono(String aTelefono) {
        telefono = aTelefono;
    }

    /**
     * @return the RUC
     */
    public String getRUC() {
        return RUC;
    }

    /**
     * @param aRUC the RUC to set
     */
    public void setRUC(String aRUC) {
        RUC = aRUC;
    }

    /**
     * @return the email
     */
    public String getEmail() {
        return email;
    }

    /**
     * @param aEmail the email to set
     */
    public void setEmail(String aEmail) {
        email = aEmail;
    }
}

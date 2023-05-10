
package pe.edu.pucp.arsacsoft.empresa.model;

import java.util.ArrayList;


public class Empresa {
    private int idEmpresa;
    private String RUC;
    private int telefono;
    private String correo;
    private String razonSocial;
    private ArrayList<Sede> sedes;
    public Empresa(){}
    public Empresa(int idEmpresa, String RUC, int telefono, String correo, String razonSocial) {
        this.idEmpresa = idEmpresa;
        this.RUC = RUC;
        this.telefono = telefono;
        this.correo = correo;
        this.razonSocial = razonSocial;
    }

    public int getIdEmpresa() {
        return idEmpresa;
    }

    public void setIdEmpresa(int idEmpresa) {
        this.idEmpresa = idEmpresa;
    }

    public ArrayList<Sede> getSedes() {
        return sedes;
    }

    public void setSedes(ArrayList<Sede> sedes) {
        this.sedes = sedes;
    }

 
    public String getRUC() {
        return RUC;
    }

    public void setRUC(String RUC) {
        this.RUC = RUC;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public String getRazonSocial() {
        return razonSocial;
    }

    public void setRazonSocial(String razonSocial) {
        this.razonSocial = razonSocial;
    }
    
    
}

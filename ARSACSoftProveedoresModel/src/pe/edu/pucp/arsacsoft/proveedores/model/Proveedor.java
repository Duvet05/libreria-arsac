package pe.edu.pucp.arsacsoft.proveedores.model;

public class Proveedor {
    private int idProveedor;
    private String nombre;
    private int RUC;
    private String direccion1;
    private String direccion2;
    private String correo;
    private int telefono;
    private String descripcion;
    public Proveedor(){}
    public Proveedor(int idProveedor, String nombre, int RUC, String direccion1, String direccion2, String correo, int telefono, String descripcion) {
        this.idProveedor = idProveedor;
        this.nombre = nombre;
        this.RUC = RUC;
        this.direccion1 = direccion1;
        this.direccion2 = direccion2;
        this.correo = correo;
        this.telefono = telefono;
        this.descripcion = descripcion;
    }

    public int getIdProveedor() {
        return idProveedor;
    }

    public void setIdProveedor(int idProveedor) {
        this.idProveedor = idProveedor;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getRUC() {
        return RUC;
    }

    public void setRUC(int RUC) {
        this.RUC = RUC;
    }

    public String getDireccion1() {
        return direccion1;
    }

    public void setDireccion1(String direccion1) {
        this.direccion1 = direccion1;
    }

    public String getDireccion2() {
        return direccion2;
    }

    public void setDireccion2(String direccion2) {
        this.direccion2 = direccion2;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public int getTelefono() {
        return telefono;
    }

    public void setTelefono(int telefono) {
        this.telefono = telefono;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    
    
}

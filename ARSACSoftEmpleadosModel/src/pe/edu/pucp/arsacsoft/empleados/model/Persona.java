
package pe.edu.pucp.arsacsoft.empleados.model;

abstract public class Persona {
    private int idUsuario;
    private String nombre;
    private String apellidos;
    private String DNI;
    private String correo;
    private int telefono;
    
    public Persona(){}
    
    public Persona(int idUsuario,String nombre, String apellidos, String DNI, String correo, int telefono) {
        this.idUsuario= idUsuario;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.DNI = DNI;
        this.correo = correo;
        this.telefono = telefono;
    }

    public int getIdUsuario() {
        return idUsuario;
    }

    public void setIdUsuario(int idUsuario) {
        this.idUsuario = idUsuario;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public String getDNI() {
        return DNI;
    }

    public void setDNI(String DNI) {
        this.DNI = DNI;
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
    
    
}

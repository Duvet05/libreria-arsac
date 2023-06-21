package pe.edu.pucp.arsacsoft.proveedores.model;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.producto.model.Producto;

public class Proveedor {

    private int idProveedor;
    private String nombre;
    private String RUC;
    private String direccion;
    private String telefono;
    private boolean activo;
    private ArrayList<ProductoXProveedor> productosXProveedor;

    public Proveedor() {
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

    public String getRUC() {
        return RUC;
    }

    public void setRUC(String RUC) {
        this.RUC = RUC;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public boolean isActivo() {
        return activo;
    }

    public void setActivo(boolean activo) {
        this.activo = activo;
    }

    public ArrayList<ProductoXProveedor> getProductosXProveedor() {
        return productosXProveedor;
    }

    public void setProductosXProveedor(ArrayList<ProductoXProveedor> productos) {
        this.productosXProveedor = productosXProveedor;
    }


}

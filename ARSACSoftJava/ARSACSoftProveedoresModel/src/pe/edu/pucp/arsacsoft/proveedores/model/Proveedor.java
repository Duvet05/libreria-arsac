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
    private int cantProductos;

    public int getCantProductos() {
        return cantProductos;
    }

    public void setCantProductos(int cantProductos) {
        this.cantProductos = cantProductos;
    }

    public Proveedor(String nombre, String RUC, String direccion, String telefono) {
        this.nombre = nombre;
        this.RUC = RUC;
        this.direccion = direccion;
        this.telefono = telefono;
        this.cantProductos = 0;
    }
    
    
    public Proveedor() {
        this.cantProductos = 0;
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
        this.productosXProveedor = productos;
    }


}

package pe.edu.pucp.arsacsoft.sedes.model;

import pe.edu.pucp.arsacsoft.producto.model.Producto;

/**
 * Represents the relationship between a Sede and a Producto, including the stock.
 * 
 * @author Gino
 */
public class SedeXProducto {
    private Producto producto;
    private int stock;

    public Producto getProducto() {
        return producto;
    }

    public void setProducto(Producto producto) {
        this.producto = producto;
    }

    public int getStock() {
        return stock;
    }

    public void setStock(int stock) {
        this.stock = stock;
    }
}

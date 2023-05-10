
package pe.edu.pucp.arsacsoft.compras.model;

import java.util.Date;
import pe.edu.pucp.arsacsoft.productos.model.Producto;


public class Lote {
    private int idLote;
    private Date fechaObtencion;
    private Date fechaVenc;
    private int cantProduct;
    private String descripcion;
    private int stockDisponible;
    private Producto producto;
    
    public Lote() {

    }
    public Lote(int idLote, Date fechaObtencion, Date fechaVenc, int cantProduct, String descripcion, int stockDisponible, Producto producto) {
        this.idLote = idLote;
        this.fechaObtencion = fechaObtencion;
        this.fechaVenc = fechaVenc;
        this.cantProduct = cantProduct;
        this.descripcion = descripcion;
        this.stockDisponible = stockDisponible;
        this.producto = producto;
    }

    public int getIdLote() {
        return idLote;
    }

    public void setIdLote(int idLote) {
        this.idLote = idLote;
    }

    public Date getFechaObtencion() {
        return fechaObtencion;
    }

    public void setFechaObtencion(Date fechaObtencion) {
        this.fechaObtencion = fechaObtencion;
    }

    public Date getFechaVenc() {
        return fechaVenc;
    }

    public void setFechaVenc(Date fechaVenc) {
        this.fechaVenc = fechaVenc;
    }

    public int getCantProduct() {
        return cantProduct;
    }

    public void setCantProduct(int cantProduct) {
        this.cantProduct = cantProduct;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getStockDisponible() {
        return stockDisponible;
    }

    public void setStockDisponible(int stockDisponible) {
        this.stockDisponible = stockDisponible;
    }

    public Producto getProducto() {
        return producto;
    }

    public void setProducto(Producto producto) {
        this.producto = producto;
    }
    
    
}

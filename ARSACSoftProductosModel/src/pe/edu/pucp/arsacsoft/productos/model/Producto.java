
package pe.edu.pucp.arsacsoft.productos.model;


public class Producto {
    private int idProducto;
    private String marca;
    private String nombreProducto;
    private String descripcion;
    private double precioUnit;
    private double precioPorMayor;
    private int stockBase;
    private int stock;
    private boolean agotado;
    private TipoProducto tipoProducto;
    
    public Producto(){}
    public Producto(int idProducto,String marca, String nombreProducto, String descripcion, double precioUnit, double precioPorMayor, int stockBase, int stock, boolean agotado, TipoProducto tipoProducto) {
        this.idProducto=idProducto;
        this.marca = marca;
        this.nombreProducto = nombreProducto;
        this.descripcion = descripcion;
        this.precioUnit = precioUnit;
        this.precioPorMayor = precioPorMayor;
        this.stockBase = stockBase;
        this.stock = stock;
        this.agotado = agotado;
        this.tipoProducto = tipoProducto;
    }

    public int getIdProducto() {
        return idProducto;
    }

    public void setIdProducto(int idProducto) {
        this.idProducto = idProducto;
    }

    public String getMarca() {
        return marca;
    }

    public void setMarca(String marca) {
        this.marca = marca;
    }

    public String getNombreProducto() {
        return nombreProducto;
    }

    public void setNombreProducto(String nombreProducto) {
        this.nombreProducto = nombreProducto;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public double getPrecioUnit() {
        return precioUnit;
    }

    public void setPrecioUnit(double precioUnit) {
        this.precioUnit = precioUnit;
    }

    public double getPrecioPorMayor() {
        return precioPorMayor;
    }

    public void setPrecioPorMayor(double precioPorMayor) {
        this.precioPorMayor = precioPorMayor;
    }

    public int getStockBase() {
        return stockBase;
    }

    public void setStockBase(int stockBase) {
        this.stockBase = stockBase;
    }

    public int getStock() {
        return stock;
    }

    public void setStock(int stock) {
        this.stock = stock;
    }

    public boolean isAgotado() {
        return agotado;
    }

    public void setAgotado(boolean agotado) {
        this.agotado = agotado;
    }

    public TipoProducto getTipoProducto() {
        return tipoProducto;
    }

    public void setTipoProducto(TipoProducto tipoProducto) {
        this.tipoProducto = tipoProducto;
    }
    
    
}

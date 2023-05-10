
package pe.edu.pucp.arsacsoft.compras.model;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;


public class OrdenDeCompra {
    private int idOrden;
    private Date fechaDeOrden;
    private double preciotTotalCompra;
    private boolean estado;
    private ArrayList<Lote> lotes;
    private Proveedor proveedor;
    public OrdenDeCompra(){}
    public OrdenDeCompra(int idOrden, Date fechaDeOrden, double preciotTotalCompra, boolean estado, Proveedor proveedor) {
        this.idOrden = idOrden;
        this.fechaDeOrden = fechaDeOrden;
        this.preciotTotalCompra = preciotTotalCompra;
        this.estado = estado;
        this.proveedor = proveedor;
    }

    public int getIdOrden() {
        return idOrden;
    }

    public void setIdOrden(int idOrden) {
        this.idOrden = idOrden;
    }

    public Date getFechaDeOrden() {
        return fechaDeOrden;
    }

    public void setFechaDeOrden(Date fechaDeOrden) {
        this.fechaDeOrden = fechaDeOrden;
    }

    public double getPreciotTotalCompra() {
        return preciotTotalCompra;
    }

    public void setPreciotTotalCompra(double preciotTotalCompra) {
        this.preciotTotalCompra = preciotTotalCompra;
    }

    public boolean isEstado() {
        return estado;
    }

    public void setEstado(boolean estado) {
        this.estado = estado;
    }

    public ArrayList<Lote> getLotes() {
        return lotes;
    }

    public void setLotes(ArrayList<Lote> lotes) {
        this.lotes = lotes;
    }

    public Proveedor getProveedor() {
        return proveedor;
    }

    public void setProveedor(Proveedor proveedor) {
        this.proveedor = proveedor;
    }
    
    
}

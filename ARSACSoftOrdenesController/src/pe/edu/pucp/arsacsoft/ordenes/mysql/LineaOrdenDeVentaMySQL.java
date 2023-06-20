/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.ordenes.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import pe.edu.pucp.arsacsoft.config.DBManager;

import pe.edu.pucp.arcacsoft.ordenes.dao.LineaDeOrdenDeVentaDAO;
import pe.edu.pucp.arsacsoft.ordenes.model.LineaDeOrdenDeVenta;

/**
 *
 * @author El~Nicolays
 */
public class LineaOrdenDeVentaMySQL implements LineaDeOrdenDeVentaDAO {

    private Connection con;
    private CallableStatement cs;
    @Override
    public int insertar(LineaDeOrdenDeVenta lineaOrden, int idOrdenVenta) {
        
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_LINEA_ORDEN_VENTA_MAYORISTA(?,?,?,?,?)}");
            cs.setInt("_fid_orden_de_venta",idOrdenVenta);
            cs.setInt("_fid_producto",lineaOrden.getProducto().getIdProducto());
            cs.setInt("_cantidad",lineaOrden.getCantidad());
            cs.setDouble("_descuento",lineaOrden.getDescuento());
            cs.setDouble("_subtotal",lineaOrden.getPrecio());
            cs.executeUpdate();
            resultado = 1; 
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{
                if (cs != null) {
                    cs.close();
                }
                if (con != null) {
                    con.close();
                }
            } catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    @Override
    public int modificar(LineaDeOrdenDeVenta lineaOrden,int idOrdenVenta,int idProducto) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_LINEA_ORDEN_DE_VENTA(?,?,?,?,?,?)}");
            cs.setInt("_fid_orden_de_venta",idOrdenVenta );
            cs.setInt("_fid_producto", idProducto);
            cs.setInt("_cantidad", lineaOrden.getCantidad());
            cs.setDouble("_descuento", lineaOrden.getDescuento());
            cs.setDouble("_subtotal", lineaOrden.getDescuento());
            cs.setBoolean("_activo", lineaOrden.isActivo());
            cs.executeUpdate();
            resultado = 1;
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                if (cs != null) {
                    cs.close();
                }
                if (con != null) {
                    con.close();
                }
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return resultado;
    }
    
    @Override
    public int eliminar(int idOrdenVenta,int idProducto) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
}

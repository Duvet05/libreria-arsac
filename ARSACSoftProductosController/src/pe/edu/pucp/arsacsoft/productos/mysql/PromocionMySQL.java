/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.productos.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.productos.dao.PromocionDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.producto.model.Promocion;

/**
 *
 * @author User
 */
public class PromocionMySQL implements PromocionDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    @Override
    public ArrayList<Promocion> listarTodas() {
        ArrayList<Promocion> promociones = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            rs = cs.executeQuery();
            while(rs.next()){
                Promocion promocion = new Promocion();
                promocion.setCantidadminima(rs.getInt(""));
                promocion.setFechaFin(rs.getDate(""));
                promocion.setFechaInicio(rs.getDate(""));
                promocion.setIdPromocion(rs.getInt(""));
                promocion.setPorcentaje(rs.getDouble(""));
                promocion.setProducto(new Producto());
                promocion.getProducto().setIdProducto(rs.getInt(""));
                promocion.getProducto().setNombre(rs.getString(""));
                promociones.add(promocion);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return promociones;           
    }

    @Override
    public int insertar(Promocion promocion) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.registerOutParameter("", java.sql.Types.INTEGER);
            cs.setInt("", promocion.getCantidadminima());
            cs.setDate("", new java.sql.Date(promocion.getFechaFin().getTime()));
            cs.setDate("", new java.sql.Date(promocion.getFechaInicio().getTime()));
            cs.setDouble("", promocion.getPorcentaje());
            cs.setInt("", promocion.getProducto().getIdProducto());
            cs.executeUpdate();
            promocion.setIdPromocion(cs.getInt(""));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;          
    }

    @Override
    public int modificar(Promocion promocion) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("", promocion.getIdPromocion());
            cs.setInt("", promocion.getCantidadminima());
            cs.setDate("", new java.sql.Date(promocion.getFechaFin().getTime()));
            cs.setDate("", new java.sql.Date(promocion.getFechaInicio().getTime()));
            cs.setDouble("", promocion.getPorcentaje());
            cs.setInt("", promocion.getProducto().getIdProducto());
            cs.executeUpdate();                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;          
    }

    @Override
    public int eliminar(int idPromocion) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("",idPromocion);
            cs.executeUpdate();
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;         
    }
    
}

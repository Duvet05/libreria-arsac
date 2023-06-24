/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Categoria;
import pe.edu.pucp.arsacsoft.producto.model.Marca;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.sedes.dao.SedeXProductoDAO;
import pe.edu.pucp.arsacsoft.sedes.model.SedeXProducto;

/**
 *
 * @author Gino
 */
public class SedeXProductoMySQL implements SedeXProductoDAO {
    
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
    @Override
    public ArrayList<SedeXProducto> listarProductos(int idSede, String nombre) {
        ArrayList<SedeXProducto> productos = new ArrayList<SedeXProducto>();
        
        try
        {
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call LISTAR_PRODUCTOS_DE_SEDE(?,?)}");
            cs.setInt(1, idSede);
            cs.setString(2, nombre);
            
            rs = cs.executeQuery();
            
            while (rs.next())
            {
                SedeXProducto sxp = new SedeXProducto();
                
                // p.id_producto, p.nombre, c.descripcion as categoria,
                // m.descripcion as marca, sxp.stock
                
                sxp.setProducto(new Producto());
                sxp.getProducto().setIdProducto(rs.getInt("id_producto"));
                sxp.getProducto().setNombre(rs.getString("nombre"));
                
                sxp.getProducto().setMarca(new Marca());
                sxp.getProducto().getMarca().setDescripcion(rs.getString("marca"));
                
                sxp.getProducto().setCategoria(new Categoria());
                sxp.getProducto().getCategoria().setDescripcion(rs.getString("categoria"));
                
                sxp.setStock(rs.getInt("stock"));
                
                productos.add(sxp);
                
            }
            
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        return productos;
    }

    @Override
    public int eliminarProductos(int idSede) {
        int resultado = 0;
                
        try
        {
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call ELIMINAR_PRODUCTOS_DE_SEDE(?)}");
            cs.setInt(1, idSede);
            cs.executeUpdate();
            resultado = 1;
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        return resultado;
    }
}

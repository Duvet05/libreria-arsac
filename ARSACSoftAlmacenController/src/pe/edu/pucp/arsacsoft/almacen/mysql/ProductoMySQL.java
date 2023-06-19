/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.dao.ProductoDAO;
import pe.edu.pucp.arsacsoft.almacen.model.Categoria;
import pe.edu.pucp.arsacsoft.almacen.model.Producto;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User 
 */

public class ProductoMySQL implements ProductoDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    
    @Override
    public ArrayList<Producto> listarxnombre(String nombre) {
        ArrayList<Producto> productos = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_PRODUCTO_POR_NOMBRE(?)}");
            cs.setString("_nombre", nombre);
            rs = cs.executeQuery();
            while(rs.next()){
                Producto producto = new Producto();
                producto.setIdProducto(rs.getInt("id_producto"));
                producto.setCategoria(new Categoria());
                producto.getCategoria().setIdCategoria(rs.getInt("id_categoria"));
                producto.getCategoria().setDescripcion(rs.getString("nombre_categoria"));
                producto.setNombre(rs.getString("nombre"));
                producto.setPrecioPorMayor(rs.getDouble("precio_por_mayor"));
                producto.setPrecioPorMenor(rs.getDouble("precio"));
                productos.add(producto);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return productos;               
    }

    @Override
    public int insertar(Producto producto) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_PRODUCTO(?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_producto", java.sql.Types.INTEGER);
            cs.setInt("_fid_categoria", producto.getCategoria().getIdCategoria());
            cs.setInt("_fid_marca", producto.getMarca().getIdMarca());
            cs.setString("_nombre", producto.getNombre());
            cs.setDouble("_precio_por_mayor", producto.getPrecioPorMayor());
            cs.setDouble("_precio", producto.getPrecioPorMenor());
            cs.setBytes("_foto", producto.getFoto());
            cs.executeUpdate();
            producto.setIdProducto(cs.getInt("_id_producto"));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;           
    }

    @Override
    public int modificar(Producto producto) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_PRODUCTO(?,?,?,?,?,?,?)}");
            cs.setInt("_id_producto",producto.getIdProducto());
            cs.setInt("_fid_categoria", producto.getCategoria().getIdCategoria());
            cs.setInt("_fid_marca", producto.getMarca().getIdMarca());
            cs.setString("_nombre", producto.getNombre());
            cs.setDouble("_precio_por_mayor", producto.getPrecioPorMayor());
            cs.setDouble("_precio", producto.getPrecioPorMenor());
            cs.setBytes("_foto", producto.getFoto());
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
    public int eliminar(int idproducto) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ELIMINAR_PRODUCTO(?)}");
            cs.setInt("_id_producto",idproducto);
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
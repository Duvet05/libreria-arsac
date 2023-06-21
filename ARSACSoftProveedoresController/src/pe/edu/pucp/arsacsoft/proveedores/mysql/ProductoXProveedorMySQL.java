/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.proveedores.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Categoria;
import pe.edu.pucp.arsacsoft.producto.model.Marca;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.proveedores.dao.ProductoXProveedorDAO;
import pe.edu.pucp.arsacsoft.proveedores.model.ProductoXProveedor;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

/**
 *
 * @author User
 */
public class ProductoXProveedorMySQL implements ProductoXProveedorDAO{

    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    @Override
    public ArrayList<ProductoXProveedor> listarProductosXProveedor(String nombre, int _fid_categoria, int _fid_marca, int _fid_proveedor) {
        ArrayList<ProductoXProveedor> productos = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_PRODUCTO_PROVEEDOR(?, ?, ?, ?)}");
            cs.setString("_nombre", nombre);
            cs.setInt("_fid_categoria", _fid_categoria);
            cs.setInt("_fid_marca", _fid_marca);
            cs.setInt("_fid_proveedor", _fid_proveedor);
            rs = cs.executeQuery();
            while(rs.next()){
                ProductoXProveedor productoProveedor = new ProductoXProveedor();
                productoProveedor.setProducto(new Producto());
                
                productoProveedor.getProducto().setIdProducto(rs.getInt("id_producto"));

                productoProveedor.getProducto().setCategoria(new Categoria());
                productoProveedor.getProducto().getCategoria().setIdCategoria(rs.getInt("id_categoria"));
                productoProveedor.getProducto().getCategoria().setDescripcion(rs.getString("nombre_categoria"));
                productoProveedor.getProducto().setMarca(new Marca());
                productoProveedor.getProducto().getMarca().setIdMarca(rs.getInt("id_marca"));
                productoProveedor.getProducto().getMarca().setDescripcion(rs.getString("nombre_marca"));
                productoProveedor.getProducto().setNombre(rs.getString("nombre"));
                productoProveedor.getProducto().setPrecioPorMayor(rs.getDouble("precio_por_mayor"));
                productoProveedor.getProducto().setPrecioPorMenor(rs.getDouble("precio"));
                productoProveedor.setCosto(rs.getDouble("costo"));
                //productoProveedor.getProducto().setFoto(rs.getBytes("foto"));
                
                productos.add(productoProveedor);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return productos;     
    }
   
}

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
import pe.edu.pucp.arsacsoft.proveedores.dao.ProveedorDAO;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

/**
 *
 * @author User
 */
public class ProveedorMySQL implements ProveedorDAO {
private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
    @Override
    public int insertar(Proveedor proveedor) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_PROVEEDOR(?,?,?,?,?)}");
            cs.registerOutParameter("_id_proveedor", java.sql.Types.INTEGER);
            cs.setString("_nombre", proveedor.getNombre());
            cs.setString("_direccion", proveedor.getDireccion());
            cs.setString("_telefono", proveedor.getTelefono());
            cs.setString("_RUC", proveedor.getRUC());
            cs.executeUpdate();
            proveedor.setIdProveedor(cs.getInt("_id_orden_de_compra"));
            for(Producto prodXProveedor : proveedor.getProductos()){
                cs = con.prepareCall("{INSERTAR_PRODUCTO_DE_PROVEEDOR call (?,?,?)}");
                cs.setInt("_fid_producto", prodXProveedor.getIdProducto());
                cs.setInt("_fid_proveedor", proveedor.getIdProveedor());
                cs.setDouble("_costo", prodXProveedor.getPrecioPorMayor());
                cs.executeUpdate();
            }
            resultado = proveedor.getIdProveedor();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;
    }

    @Override
    public int modificar(Proveedor proveedor) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_PROVEEDOR(?,?,?,?,?)}");
            cs.setInt("_id_proveedor", proveedor.getIdProveedor());
            cs.setString("_nombre", proveedor.getNombre());
            cs.setString("_direccion", proveedor.getDireccion());
            cs.setString("_telefono", proveedor.getTelefono());
            cs.setString("_RUC", proveedor.getRUC());
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
    public int eliminar(int idProveedor) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ELIMINAR_PROVEEDOR(?)}");
            cs.setInt("_id_orden_de_compra", idProveedor);
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
    public ArrayList<Proveedor> listarAlfabeticamente() {
        ArrayList<Proveedor> proveedores = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ORDENAR_PROVEEDOR_ALFABETICAMENTE()}");
            rs = cs.executeQuery();
            while(rs.next()){
                Proveedor proveedorA = new Proveedor();
                proveedorA.setIdProveedor(rs.getInt("id_proveedor"));
                proveedorA.setActivo(rs.getBoolean("activo"));
                proveedorA.setNombre(rs.getString("nombre"));
                proveedorA.setRUC(rs.getString("RUC"));
                proveedorA.setDireccion(rs.getString("direccion"));
                proveedorA.setTelefono(rs.getString("telefono"));
                proveedores.add(proveedorA);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return proveedores; 
    }

    @Override
    public ArrayList<Proveedor> listarPorCategoriaDeProducto(int idCategoria) {
        ArrayList<Proveedor> proveedores = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ORDENAR_PROVEEDOR_CATEGORIA_PRODUCTO(?)}");
            cs.setInt("_id_categoria", idCategoria);
            rs = cs.executeQuery();
            while(rs.next()){
                Proveedor proveedorA = new Proveedor();
                proveedorA.setIdProveedor(rs.getInt("id_proveedor"));
                proveedorA.setActivo(rs.getBoolean("activo"));
                proveedorA.setNombre(rs.getString("nombre"));
                proveedorA.setRUC(rs.getString("RUC"));
                proveedorA.setDireccion(rs.getString("direccion"));
                proveedorA.setTelefono(rs.getString("telefono"));
                proveedores.add(proveedorA);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return proveedores; 
    }

    
}

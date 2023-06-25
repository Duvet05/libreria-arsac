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
import pe.edu.pucp.arsacsoft.sedes.dao.OrdenDeAbastecimientoDAO;
import pe.edu.pucp.arsacsoft.sedes.model.LineaOrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.sedes.model.OrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;

/**
 *
 * @author Gino
 */
public class OrdenDeAbastecimientoMySQL implements OrdenDeAbastecimientoDAO {

    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
    @Override
    public int insertar(OrdenDeAbastecimiento orden) {
        int resultado = 0;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            
            /*
            OUT _id_orden_de_abastecimiento INT,
            IN _fid_empleado INT,
            IN _fid_sede INT
            */
            
            cs = con.prepareCall("{call INSERTAR_ORDEN_DE_ABASTECIMIENTO(?,?,?)}");
            cs.registerOutParameter(1, java.sql.Types.INTEGER);
            cs.setInt(2, orden.getIdEmpleado());
            cs.setInt(3, orden.getSede().getIdSede());
            
            cs.executeUpdate();
            resultado = cs.getInt("_id_orden_de_abastecimiento");
            orden.setIdOrdenDeAbastecimiento(resultado);
            
            for (LineaOrdenDeAbastecimiento linea : orden.getLineas())
            {
                /*
                OUT _id_linea_orden_abastecimiento INT,
                IN _fid_orden_de_abastecimiento INT,
                IN _fid_producto INT,
                IN _cantidad INT
                */
                cs = con.prepareCall("{call INSERTAR_LINEA_DE_ORDEN_DE_ABASTECIMIENTO(?,?,?,?)}");
                cs.registerOutParameter(1, java.sql.Types.INTEGER);
                cs.setInt(2, orden.getIdOrdenDeAbastecimiento());
                cs.setInt(3, linea.getProducto().getIdProducto());
                cs.setInt(4, orden.getSede().getIdSede());
                cs.executeUpdate();
            }
            
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        
        return resultado;
    }

    @Override
    public int verificarEntrega(OrdenDeAbastecimiento orden) {
        int resultado = 1;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            
            for (LineaOrdenDeAbastecimiento linea : orden.getLineas())
            {
                cs = con.prepareCall("{call OBTENER_STOCK_DE_PRODUCTO_EN_SEDE_PRINCIPAL(?)}");
                cs.setInt(1, linea.getProducto().getIdProducto());
                rs = cs.executeQuery();
                rs.next();
                int stock = rs.getInt("stock");
                if (stock < linea.getCantidad())
                {
                    resultado = 0;
                    break;
                }
            }
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        
        return resultado;
    }

    @Override
    public int entregar(OrdenDeAbastecimiento orden) {
        int resultado = 0;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ENTREGAR_ORDEN_DE_ABASTECIMIENTO(?)}");
            cs.setInt(1, orden.getIdOrdenDeAbastecimiento());
            cs.executeUpdate();
            
            for (LineaOrdenDeAbastecimiento linea : orden.getLineas())
            {
                cs = con.prepareCall("{call ACTUALIZAR_STOCK_DE_PRODUCTO(?,?,?)}");
                /*
                IN _id_producto INT,
                IN _id_sede INT,
                IN _cantidad INT
                */
                cs.setInt(1, linea.getProducto().getIdProducto());
                cs.setInt(2, orden.getSede().getIdSede());
                cs.setInt(3, linea.getCantidad());
                cs.executeUpdate();
            
            }
            resultado = 1;
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        
        
        return resultado;
    }

    @Override
    public int cancelar(int idOrdenDeAbastecimiento) {
        int resultado = 0;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ENTREGAR_ORDEN_DE_ABASTECIMIENTO(?)}");
            cs.setInt(1, idOrdenDeAbastecimiento);
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

    @Override
    public ArrayList<OrdenDeAbastecimiento> listarPorIdEmpleadoEstado(int idEmpleado, String estado) {
        ArrayList<OrdenDeAbastecimiento> ordenes = new ArrayList<OrdenDeAbastecimiento>();
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ORDENES_DE_ABASTECIMIENTO_DE_EMPLEADO(?,?)}");
            cs.setInt(1, idEmpleado);
            cs.setString(2, estado);
            rs = cs.executeQuery();
            while (rs.next())
            {
                OrdenDeAbastecimiento orden = new OrdenDeAbastecimiento();
                
                /*
                oa.id_orden_de_abastecimiento,
                oa.fid_empleado,
                s.id_sede,
                s.direccion,
		oa.fecha_registro,
                oa.fecha_entrega,
                oa.fecha_cancelacion,
                oa.estado
                */
                
                orden.setIdOrdenDeAbastecimiento(rs.getInt("id_orden_de_abastecimiento"));
                orden.setIdEmpleado(rs.getInt("fid_empleado"));
                
                orden.setSede(new Sede());
                orden.getSede().setIdSede(rs.getInt("id_sede"));
                orden.getSede().setDireccion(rs.getString("direccion"));
                
                orden.setFechaRegistro(rs.getDate("fecha_registro"));
                orden.setFechaEntrega(rs.getDate("fecha_entrega"));
                orden.setFechaCancelacion(rs.getDate("fecha_cancelacion"));

                orden.setEstado(rs.getString(""));
                
                ordenes.add(orden);
            }
                
            
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        
        return ordenes;
    }

    @Override
    public ArrayList<LineaOrdenDeAbastecimiento> listarLineasDeOrdenDeAbastecimiento(int idOrdenDeAbastecimiento) {
        ArrayList<LineaOrdenDeAbastecimiento> lineas = new ArrayList<LineaOrdenDeAbastecimiento>();
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_LINEAS_DE_ORDEN_DE_ABASTECIMIENTO(?)}");
            cs.setInt(1, idOrdenDeAbastecimiento);
            rs = cs.executeQuery();
            while (rs.next())
            {
                LineaOrdenDeAbastecimiento linea = new LineaOrdenDeAbastecimiento();
                
                /*
                p.id_producto,
                p.nombre,
		c.descripcion as categoria,
                m.descripcion as marca,
                loa.cantidad 
                */
                
                linea.setProducto(new Producto());
                linea.getProducto().setIdProducto(rs.getInt("id_producto"));
                linea.getProducto().setNombre(rs.getString("nombre"));
                
                linea.getProducto().setMarca(new Marca());
                linea.getProducto().getMarca().setDescripcion(rs.getString("categoria"));
                
                linea.getProducto().setCategoria(new Categoria());
                linea.getProducto().getCategoria().setDescripcion(rs.getString("marca"));
                
                linea.setCantidad(rs.getInt("cantidad"));
                
                lineas.add(linea);
            }
            
            
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        
        
        return lineas;
    }

    @Override
    public int obtenerStockDeProductoEnSedePrincipal(int idProducto) {
        int stock = 0;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call OBTENER_STOCK_DE_PRODUCTO_EN_SEDE_PRINCIPAL(?)}");
            cs.setInt(1, idProducto);
            rs = cs.executeQuery();
            rs.next();
            stock = rs.getInt("stock");
            
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return stock;
    }

    @Override
    public int obtenerStockDeProductoEnSede(int idProducto, int idSede) {
        int stock = 0;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call OBTENER_STOCK_DE_PRODUCTO_EN_SEDE(?,?)}");
            cs.setInt(1, idProducto);
            cs.setInt(2, idSede);

            rs = cs.executeQuery();
            rs.next();
            stock = rs.getInt("stock");
            
        }
        catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return stock;
    }
    
}

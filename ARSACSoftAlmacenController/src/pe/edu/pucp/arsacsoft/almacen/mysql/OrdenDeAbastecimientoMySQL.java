/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.almacen.dao.OrdenDeAbastecimientoDAO;
import pe.edu.pucp.arsacsoft.almacen.model.LineaDeOrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User
 */
public class OrdenDeAbastecimientoMySQL implements OrdenDeAbastecimientoDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    @Override
    public int insertar(OrdenDeAbastecimiento ordenAbastecimiento) {
                int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_ORDEN_ABASTECIMIENTO(?,?,?,?)}");
            cs.registerOutParameter("_id_orden_de_abastecimiento", java.sql.Types.INTEGER);
            cs.setInt("_fid_empleado", ordenAbastecimiento.getEmpleado().getIdPersona());
            cs.setInt("_fid_sede", ordenAbastecimiento.getSede().getIdSede());
            cs.setDate("_fecha_orden", new java.sql.Date(ordenAbastecimiento.getFechaOrden().getTime()));
            cs.executeUpdate();
            ordenAbastecimiento.setIdOrdenDeAbastecimiento(cs.getInt("_id_orden_de_abastecimiento"));
            for(LineaDeOrdenDeAbastecimiento lineaOrdenAbastecimiento : ordenAbastecimiento.getLineas()){
                cs = con.prepareCall("{INSERTAR_LINEA_ORDEN_ABASTECIMIENTO call (?,?,?,?)}");
                cs.registerOutParameter("_id_linea_abastecimiento", java.sql.Types.INTEGER);
                cs.setInt("_fid_orden_de_abastecimiento", ordenAbastecimiento.getIdOrdenDeAbastecimiento());
                cs.setInt("_fid_producto", lineaOrdenAbastecimiento.getProducto().getIdProducto());
                cs.setInt("_cantidad", lineaOrdenAbastecimiento.getCantidad());
                cs.executeUpdate();
            }
            resultado = ordenAbastecimiento.getIdOrdenDeAbastecimiento();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;        
    }

    @Override
    public int modificar(OrdenDeAbastecimiento ordenAbastecimiento) {
                int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_ORDEN_ABASTECIMIENTO(?,?,?,?)}");
            cs.setInt("_id_orden_de_abastecimiento", ordenAbastecimiento.getIdOrdenDeAbastecimiento());
            cs.setInt("_fid_empleado", ordenAbastecimiento.getEmpleado().getIdPersona());
            cs.setInt("_fid_sede", ordenAbastecimiento.getSede().getIdSede());
            cs.setDate("_fecha_orden", new java.sql.Date(ordenAbastecimiento.getFechaOrden().getTime()));
            cs.executeUpdate();
            ordenAbastecimiento.setIdOrdenDeAbastecimiento(cs.getInt("_id_orden_de_abastecimiento"));
            for(LineaDeOrdenDeAbastecimiento lineaOrdenAbastecimiento : ordenAbastecimiento.getLineas()){
                cs = con.prepareCall("{INSERTAR_LINEA_ORDEN_ABASTECIMIENTO call (?,?,?,?)}");
                cs.registerOutParameter("_id_linea_abastecimiento", java.sql.Types.INTEGER);
                cs.setInt("_fid_orden_de_abastecimiento", ordenAbastecimiento.getIdOrdenDeAbastecimiento());
                cs.setInt("_fid_producto", lineaOrdenAbastecimiento.getProducto().getIdProducto());
                cs.setInt("_cantidad", lineaOrdenAbastecimiento.getCantidad());
                cs.executeUpdate();
            }
            resultado = ordenAbastecimiento.getIdOrdenDeAbastecimiento();
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;         
    }
    @Override
    public int eliminar(int idOrdenAbastecimiento) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ELIMINAR_ORDEN_ABASTECIMIENTO(?)}");
            cs.setInt("_id_orden_de_abastecimiento", idOrdenAbastecimiento);
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
    public ArrayList<OrdenDeAbastecimiento> listarPorIdDNINombreEmpleado(String idDNINombreEmpleado) {
        ArrayList<OrdenDeAbastecimiento> ordenesAbastecimiento = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_ABASTECIMIENTO_COMPRA_X_ID_NOMBRE_DNI_EMPLEADO(?)}");
            cs.setString("_id_nombre_dni_empleado", idDNINombreEmpleado);
            rs = cs.executeQuery();
            while(rs.next()){
                OrdenDeAbastecimiento ordenAbastecimiento = new OrdenDeAbastecimiento();
                ordenAbastecimiento.setIdOrdenDeAbastecimiento(rs.getInt("id_orden_de_abastecimiento"));
                ordenAbastecimiento.setEmpleado(new Empleado());
                ordenAbastecimiento.getEmpleado().setIdPersona(rs.getInt("fid_empleado"));
                ordenAbastecimiento.getEmpleado().setNombre(rs.getString("nombre"));
                ordenAbastecimiento.getEmpleado().setApellidos(rs.getString("apellidos"));
                ordenAbastecimiento.getEmpleado().setDNI(rs.getString("DNI"));
                ordenAbastecimiento.setFechaOrden(rs.getDate("fecha_orden"));
                ordenesAbastecimiento.add(ordenAbastecimiento);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return ordenesAbastecimiento;             
    }
    
}

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.RRHH.dao.EmpleadoDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.RRHH.model.TipoDeEmpleado;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User
 */
public class EmpleadoMySQL implements EmpleadoDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    @Override    
    public int insertar(Empleado empleado) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_EMPLEADO(?,?,?,?,?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_empleado", java.sql.Types.INTEGER);
            cs.setInt("_fid_tipo_empleado", empleado.getTipo().getIdTipoDeEmpleado());
            cs.setDate("_fecha_contratacion",new java.sql.Date(empleado.getFechaContratacion().getTime()));
            cs.setDouble("_salario",empleado.getSalario());
            cs.setString("_direccion",empleado.getDireccion());
            cs.setString("_usuario",empleado.getUsuario());
            cs.setString("_contrasenha",empleado.getContrasenha());
            cs.setString("_nombre",empleado.getNombre());
            cs.setString("_apellidos",empleado.getApellidos());
            cs.setString("_DNI",empleado.getDNI());
            cs.setString("_correo",empleado.getCorreo());
            cs.setString("_telefono",empleado.getTelefono());
            cs.executeUpdate();
            empleado.setIdPersona(cs.getInt("_id_empleado"));
            resultado = empleado.getIdPersona();   
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        return resultado;             
    }

    @Override
    public int modificar(Empleado empleado) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call MODIFICAR_EMPLEADO(?,?,?,?,?,?,?,?,?,?,?,?)}");
            cs.setInt("_id_empleado", empleado.getIdPersona());
            cs.setInt("_fid_tipo_empleado", empleado.getTipo().getIdTipoDeEmpleado());
            cs.setDate("_fecha_contratacion",new java.sql.Date(empleado.getFechaContratacion().getTime()));
            cs.setDouble("_salario",empleado.getSalario());
            cs.setString("_direccion",empleado.getDireccion());
            cs.setString("_usuario",empleado.getUsuario());
            cs.setString("_contrasenha",empleado.getContrasenha());
            cs.setString("_nombre",empleado.getNombre());
            cs.setString("_apellidos",empleado.getApellidos());
            cs.setString("_DNI",empleado.getDNI());
            cs.setString("_correo",empleado.getCorreo());
            cs.setString("_telefono",empleado.getTelefono());
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
    public int eliminar(int idEmpleado) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ELIMINAR_EMPLEADO(?)}");
            cs.setInt("_id_empleado", idEmpleado);
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
    public ArrayList<Empleado> listarporNombreDNI(String DNINombre) {
        ArrayList<Empleado> empleados = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_EMPLEADO_POR_NOMBRE_DNI(?)}");
            cs.setString("_NOMBRE_DNI", DNINombre);
            rs = cs.executeQuery();
            while(rs.next()){
                Empleado emp = new Empleado();
                emp.setIdPersona(rs.getInt("id_persona"));
                emp.setTipo(new TipoDeEmpleado());
                emp.getTipo().setIdTipoDeEmpleado(rs.getInt("id_tipo_empleado"));
                emp.getTipo().setDescripcion(rs.getString("descripcion"));
                emp.setFechaContratacion(rs.getDate("fecha_contratacion"));
                emp.setSalario(rs.getDouble("salario"));
                emp.setDireccion(rs.getString("direccion"));
                emp.setUsuario(rs.getString("usuario"));
                emp.setContrasenha(rs.getString("contrasenha"));
                emp.setNombre(rs.getString("nombre"));
                emp.setApellidos(rs.getString("apellidos"));
                emp.setDNI(rs.getString("DNI"));
                emp.setCorreo(rs.getString("correo"));
                emp.setTelefono(rs.getString("telefono"));
                emp.setActivo(true);
                empleados.add(emp);               
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return empleados;        
    }
    
}

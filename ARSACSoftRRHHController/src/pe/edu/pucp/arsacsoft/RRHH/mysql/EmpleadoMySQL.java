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
import pe.edu.pucp.arsacsoft.RRHH.model.Persona;
import pe.edu.pucp.arsacsoft.RRHH.model.TipoDeEmpleado;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;

/**
 *
 * @author User
 */
public class EmpleadoMySQL implements EmpleadoDAO {

    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;

    @Override
    public int insertar(Empleado empleado) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL INSERTAR_EMPLEADO(?,?,?,?,?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter(1, java.sql.Types.INTEGER);
            cs.setString(2, empleado.getDNI());
            cs.setString(3, empleado.getNombre());
            cs.setString(4, empleado.getApellidos());
            cs.setString(5, empleado.getCorreo());
            cs.setString(6, empleado.getTelefono());
            cs.setInt(7, empleado.getSede().getIdSede());
            cs.setInt(8, empleado.getTipo().getIdTipoDeEmpleado());
            cs.setDate(9, new java.sql.Date(empleado.getFechaContratacion().getTime()));
            cs.setDouble(10, empleado.getSalario());
            cs.setString(11, empleado.getDireccion());
            cs.setBytes("_foto",empleado.getFoto());
            cs.executeUpdate();
            empleado.setIdPersona(cs.getInt(1));
            resultado = empleado.getIdPersona();
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
    public int modificar(Empleado empleado) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call MODIFICAR_EMPLEADO(?,?,?,?,?,?,?,?,?,?,?)}");
            cs.setInt(1, empleado.getIdPersona());
            cs.setString(2, empleado.getDNI());
            cs.setString(3, empleado.getNombre());
            cs.setString(4, empleado.getApellidos());
            cs.setString(5, empleado.getCorreo());
            cs.setString(6, empleado.getTelefono());

            cs.setInt(7, empleado.getSede().getIdSede());
            cs.setInt(8, empleado.getTipo().getIdTipoDeEmpleado());
            cs.setDate(9, new java.sql.Date(empleado.getFechaContratacion().getTime()));
            cs.setDouble(10, empleado.getSalario());
            cs.setString(11, empleado.getDireccion());

            cs.executeUpdate();
            resultado = 1;
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return resultado;
    }

    @Override
    public int eliminar(int idEmpleado) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ELIMINAR_EMPLEADO(?)}");
            cs.setInt("_id_empleado", idEmpleado);
            cs.executeUpdate();
            resultado = 1;
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return resultado;
    }

    @Override
    public ArrayList<Empleado> listarPorSedeNombreDNI(int idSede, String DNINombre) {
        ArrayList<Empleado> empleados = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_EMPLEADOS_POR_SEDE_NOMBRE_DNI(?,?)}");
            cs.setInt(1, idSede);
            cs.setString(2, DNINombre);
            rs = cs.executeQuery();
            while (rs.next()) {
                Empleado emp = new Empleado();

                emp.setIdPersona(rs.getInt("fid_empleado"));
                emp.setNombre(rs.getString("nombre"));
                emp.setApellidos(rs.getString("apellidos"));
                emp.setDNI(rs.getString("DNI"));
                emp.setCorreo(rs.getString("correo"));
                emp.setTelefono(rs.getString("telefono"));

                emp.setSede(new Sede());
                emp.getSede().setIdSede(rs.getInt("id_sede"));
                emp.getSede().setDireccion(rs.getString("direccion_de_sede"));

                emp.setFechaContratacion(rs.getDate("fecha_contratacion"));
                emp.setSalario(rs.getDouble("salario"));
                emp.setDireccion(rs.getString("direccion"));

                emp.setTipo(new TipoDeEmpleado());
                emp.getTipo().setIdTipoDeEmpleado(rs.getInt("id_tipo_empleado"));
                emp.getTipo().setDescripcion(rs.getString("tipo_empleado"));

                emp.setActivo(true);
                empleados.add(emp);
            }
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return empleados;
    }

    @Override
    public ArrayList<Empleado> listarPorNombreDNI(String DNINombre) {
        ArrayList<Empleado> empleados = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_EMPLEADOS_POR_NOMBRE_DNI(?)}");
            cs.setString(1, DNINombre);
            rs = cs.executeQuery();
            while (rs.next()) {
                Empleado emp = new Empleado();

                emp.setIdPersona(rs.getInt("fid_empleado"));
                emp.setNombre(rs.getString("nombre"));
                emp.setApellidos(rs.getString("apellidos"));
                emp.setDNI(rs.getString("DNI"));
                emp.setCorreo(rs.getString("correo"));
                emp.setTelefono(rs.getString("telefono"));

                emp.setSede(new Sede());
                emp.getSede().setIdSede(rs.getInt("id_sede"));
                emp.getSede().setDireccion(rs.getString("direccion_de_sede"));

                emp.setFechaContratacion(rs.getDate("fecha_contratacion"));
                emp.setSalario(rs.getDouble("salario"));
                emp.setDireccion(rs.getString("direccion"));

                emp.setTipo(new TipoDeEmpleado());
                emp.getTipo().setIdTipoDeEmpleado(rs.getInt("id_tipo_empleado"));
                emp.getTipo().setDescripcion(rs.getString("tipo_empleado"));

                emp.setActivo(true);
                empleados.add(emp);
            }
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return empleados;
    }

    @Override
    public Empleado buscarPorID(int idEmpleado) {
        Empleado emp = new Empleado();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call BUSCAR_EMPLEADO_ID(?)}");
            cs.setInt("_idEmpleado", idEmpleado);
            rs = cs.executeQuery();
            if (rs.next()) {
                emp.setIdPersona(rs.getInt("fid_empleado"));
                emp.setNombre(rs.getString("nombre"));
                emp.setApellidos(rs.getString("apellidos"));
                emp.setDNI(rs.getString("DNI"));
                emp.setCorreo(rs.getString("correo"));
                emp.setTelefono(rs.getString("telefono"));

                emp.setSede(new Sede());
                emp.getSede().setIdSede(rs.getInt("id_sede"));
                emp.getSede().setDireccion(rs.getString("direccion_de_sede"));

                emp.setFechaContratacion(rs.getDate("fecha_contratacion"));
                emp.setSalario(rs.getDouble("salario"));
                emp.setDireccion(rs.getString("direccion"));

                emp.setTipo(new TipoDeEmpleado());
                emp.getTipo().setIdTipoDeEmpleado(rs.getInt("id_tipo_empleado"));
                emp.getTipo().setDescripcion(rs.getString("tipo_empleado"));

                emp.setActivo(true);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        return emp;
    }
}

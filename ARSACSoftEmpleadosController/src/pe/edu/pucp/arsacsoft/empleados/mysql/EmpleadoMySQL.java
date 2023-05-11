package pe.edu.pucp.arsacsoft.empleados.mysql;

import pe.edu.pucp.arsacsoft.empleados.model.Empleado;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.empleados.dao.EmpleadoDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User
 */
public class EmpleadoMySQL implements EmpleadoDAO {

    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;

    @Override
    public ArrayList<Empleado> listarTodas() {
        ArrayList<Empleado> empleados = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL LISTAR_EMPLEADOS()}");
            rs = cs.executeQuery();
            while (rs.next()) {
                Empleado empleado = new Empleado();
                empleado.setIdUsuario(rs.getInt("idEmpleado"));
                empleado.setDNI(rs.getString("DNI"));
                empleado.setNombre(rs.getString("nombre"));
                empleado.setApellidos(rs.getString("apellidos"));
                empleados.add(empleado);
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
    public int insertar(Empleado empleado) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL INSERTAR_EMPLEADO(?,?,?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_cliente", java.sql.Types.INTEGER);
            cs.setString("_DNI",empleado.getDNI());
            cs.setString("_nombre",empleado.getNombre());
            cs.setString("_apellidos",empleado.getApellidos());
            cs.setString("_correo",empleado.getCorreo());
            cs.setString("_telefono",String.valueOf(empleado.getTelefono()));
            cs.setString("_cargo", empleado.getCargo().toString());
            cs.setDate("_fechaContratacion", new java.sql.Date(empleado.getFechaContratacion().getTime()));
            cs.setDouble("_salario", empleado.getSalario());
            cs.setString("_direccion", empleado.getDireccion());
            cs.setString("_contrasena", empleado.getContrasena());
            cs.executeUpdate();
            empleado.setIdUsuario(cs.getInt("_id_empleado"));
            resultado = empleado.getIdUsuario();
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
    public int modificar(Empleado empleado) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");

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
    public int eliminar(int idempleado) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL ELIMINAR_EMPLEADO(?)}");
            cs.setInt(1, idempleado);
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
    public boolean verificarCredenciales(String correo, String contrasena) {
        boolean resultado = false;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{CALL VERIFICAR_EMPLEADO(?,?,?)}");
            cs.setString(1, correo);
            cs.setString(2, contrasena);
            cs.registerOutParameter(3, java.sql.Types.BOOLEAN);
            cs.executeUpdate();
            resultado = cs.getBoolean(3);
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
}

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.sedes.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.sedes.dao.SedeDAO;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.producto.model.Categoria;
import pe.edu.pucp.arsacsoft.producto.model.Marca;
import pe.edu.pucp.arsacsoft.producto.model.Producto;
import pe.edu.pucp.arsacsoft.sedes.model.SedeXProducto;

/**
 *
 * @author User
 */
public class SedeMySQL implements SedeDAO {

    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;

    @Override
    public int insertar(Sede sede) {
        int resultado = 0;
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_SEDE(?,?,?,?,?)}");
            cs.registerOutParameter(1, java.sql.Types.INTEGER);
            cs.setString(2, sede.getDireccion());
            cs.setString(3, sede.getTelefono());
            cs.setString(4, sede.getCorreo());

            cs.executeUpdate();
            sede.setIdSede(cs.getInt("_id_sede"));
            resultado = sede.getIdSede();

            for (Producto producto : sede.getProductos()) {
                cs = con.prepareCall("{call INSERTAR_PRODUCTO_EN_SEDE(?,?)}");
                cs.clearParameters();
                cs.setInt(1, sede.getIdSede());
                cs.setInt(2, producto.getIdProducto());
                cs.executeUpdate();
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
        return resultado;

    }

    @Override
    public ArrayList<Sede> listarTodas() {
        ArrayList<Sede> sedes = new ArrayList<>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_SEDES()}");
            rs = cs.executeQuery();

            while (rs.next()) {
                Sede sede = new Sede();

                sede.setIdSede(rs.getInt("id_sede"));
                sede.setEsPrincipal(rs.getBoolean("es_principal"));
                sede.setCorreo(rs.getString("correo"));
                sede.setDireccion(rs.getString("direccion"));
                sede.setTelefono(rs.getString("telefono"));

                sedes.add(sede);
            }

        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                rs.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }

        return sedes;
    }

    @Override
    public int modificar(Sede sede) {
        int resultado = 0;

        try {
            con = DBManager.getInstance().getConnection();

            cs = con.prepareCall("{call ACTUALIZAR_SEDE(?,?,?,?,?)}");
            cs.setInt(1, sede.getIdSede());
            cs.setBoolean(2, sede.isEsPrincipal());
            cs.setString(3, sede.getDireccion());
            cs.setString(4, sede.getTelefono());
            cs.setString(5, sede.getCorreo());

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
    public int eliminar(int idSede) {
        int resultado = 0;

        try {
            con = DBManager.getInstance().getConnection();

            cs = con.prepareCall("{call ELIMINAR_SEDE(?)}");
            cs.setInt(1, idSede);

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
    public ArrayList<SedeXProducto> listarProductos(int idSede, String nombre) {
        ArrayList<SedeXProducto> productos = new ArrayList<SedeXProducto>();
        try {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_PRODUCTOS_DE_SEDE(?,?)}");
            cs.setInt(1, idSede);
            cs.setString(2, nombre);
            cs.executeUpdate();
            while (rs.next()) {
                SedeXProducto sxp = new SedeXProducto();
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
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        } finally {
            try {
                con.close();
            } catch (Exception ex) {
                System.out.println(ex.getMessage());
            }
        }
        return productos;
    }

    @Override
    public int eliminarProducto(int idProducto) {
        return 0;

    }

}

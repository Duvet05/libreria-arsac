/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.RRHH.dao.ClienteMayoristaDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.ClienteMayorista;
import pe.edu.pucp.arsacsoft.RRHH.model.Persona;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User
 */
public class ClienteMayoristaMySQL implements ClienteMayoristaDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    @Override
    public int insertar(ClienteMayorista cliente) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call INSERTAR_CLIENTE_MAYORISTA(?,?,?,?,?,?,?,?,?)}");
            cs.registerOutParameter("_id_cliente_mayorista", java.sql.Types.INTEGER);
            cs.setString("_RUC",cliente.getRUC());
            cs.setString("_razon_social",cliente.getRazonSocial());
            cs.setString("_direccion",cliente.getDireccion());
            cs.setString("_nombre",cliente.getNombre());
            cs.setString("_apellidos",cliente.getApellidos());
            cs.setString("_DNI",cliente.getDNI());
            cs.setString("_correo",cliente.getCorreo());
            cs.setString("_telefono",cliente.getTelefono());
            cs.executeUpdate();
            cliente.setIdPersona(cs.getInt("_id_cliente_mayorista"));
            resultado = cliente.getIdPersona();   
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        return resultado;         
    }

    @Override
    public int modificar(ClienteMayorista cliente) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ACTUALIZAR_CLIENTE_MAYORISTA(?,?,?,?,?,?,?,?,?)}");
            cs.setInt("_id_cliente_mayorista", cliente.getIdPersona());
            cs.setString("_RUC", cliente.getRUC());
            cs.setString("_razon_social",cliente.getRazonSocial());
            cs.setString("_direccion",cliente.getDireccion());
            cs.setString("_nombre",cliente.getNombre());
            cs.setString("_apellidos",cliente.getApellidos());
            cs.setString("_DNI",cliente.getDNI());
            cs.setString("_correo",cliente.getCorreo());
            cs.setString("_telefono",cliente.getTelefono());
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
    public int eliminar(int idclientemayorista) {
        int resultado = 0;
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call ELIMINAR_CLIENTE_MAYORISTA(?)}");
            cs.setInt("_id_cliente_mayorista", idclientemayorista);
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
    public ArrayList<Persona> listarPorNombreDNI(String DNINombre) {
        ArrayList<Persona> clientes = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_CLIENTES_MAYORISTAS_POR_NOMBRE_DNI(?)}");
            cs.setString("_nombre_DNI", DNINombre);
            rs = cs.executeQuery();
            while(rs.next()){
                ClienteMayorista cli = new ClienteMayorista();
                cli.setIdPersona(rs.getInt("fid_cliente_mayorista"));
                cli.setNombre(rs.getString("nombre"));
                cli.setApellidos(rs.getString("apellidos"));
                cli.setDNI(rs.getString("DNI"));
                cli.setCorreo(rs.getString("correo"));
                cli.setTelefono(rs.getString("telefono"));
                cli.setRUC(rs.getString("RUC"));
                cli.setRazonSocial(rs.getString("razon_social"));
                cli.setDireccion(rs.getString("direccion"));
                cli.setActivo(true);
                clientes.add(cli);               
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return clientes;              
    }
    
}

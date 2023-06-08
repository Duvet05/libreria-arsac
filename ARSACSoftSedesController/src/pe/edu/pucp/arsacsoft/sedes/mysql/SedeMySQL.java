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
        
        try
        {
            con = DBManager.getInstance().getConnection();
            
            /*
            OUT _idSede INT,
            IN _esAlmacen BOOLEAN,
            IN _direccion VARCHAR(50),
            IN _telefono VARCHAR(50),
            IN _correo VARCHAR(50)
            */
            
            cs = con.prepareCall("{call INSERTAR_SEDE(?,?,?,?,?)}");
            cs.registerOutParameter("_idSede", java.sql.Types.INTEGER);
            cs.setBoolean("_esAlmacen", sede.isEsAlmacen());
            cs.setString("_direccion", sede.getDireccion());
            cs.setString("_telefono", sede.getTelefono());
            cs.setString("_correo", sede.getCorreo());
            
            cs.executeUpdate();
            sede.setIdSede(cs.getInt("_idSede"));
            resultado = sede.getIdSede();
            
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();} catch(Exception ex) {System.out.println(ex.getMessage());}
        }
        return resultado;
        
    }

    @Override
    public ArrayList<Sede> listarTodas() {
        ArrayList<Sede> sedes = new ArrayList<Sede>();
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_SEDES()}");
            rs = cs.executeQuery();
            
            while (rs.next())
            {
                Sede sede = new Sede();
                
                sede.setIdSede(rs.getInt("idSede"));
                sede.setEsAlmacen(rs.getBoolean("esAlmacen"));
                sede.setCorreo(rs.getString("correo"));
                sede.setDireccion(rs.getString("direccion"));
                sede.setTelefono(rs.getString("telefono"));
                
                System.out.println(sede.getIdSede());
                
                sedes.add(sede);
            }
                
            
        }
        catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        
        
        return sedes;
    }

    @Override
    public int actualizar(Sede sede) {
        int resultado = 0;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call ACTUALIZAR_SEDE(?,?,?,?,?)}");
            cs.setInt("_idSede", sede.getIdSede());
            cs.setBoolean("_esAlmacen", sede.isEsAlmacen());
            cs.setString("_direccion", sede.getDireccion());
            cs.setString("_telefono", sede.getTelefono());
            cs.setString("_correo", sede.getCorreo());
            
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
    public int eliminar(int idSede) {
        int resultado = 0;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            
            cs = con.prepareCall("{call ELIMINAR_SEDE(?)}");
            cs.setInt("_idSede", idSede);
            
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
    
    
    
}

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
import pe.edu.pucp.arsacsoft.config;
/**
 *
 * @author User
 */
public class SedeMySQL implements SedeDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;

    @Override
    public ArrayList<Sede> listarTodas() {
        ArrayList<Sede> sedes = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            rs = cs.executeQuery();
            while(rs.next()){
                Sede sede = new Sede();

                sedes.add(sede);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return sedes;          
    }

    @Override
    public int insertar(Sede sede) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.registerOutParameter("", java.sql.Types.INTEGER);

            cs.executeUpdate();
            sede.setIdSede(cs.getInt(""));                
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;          
    }

    @Override
    public int modificar(Sede sede) {
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");

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
    public int eliminar(int idsede){
        int resultado = 0;
        try{
            con =DBManager.getInstance().getConnection();
            cs = con.prepareCall("");
            cs.setInt("",idsede);
            cs.executeUpdate();
            resultado = 1;
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return resultado;           
    }

}
/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.RRHH.dao.TipoDeEmpleadoDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.TipoDeEmpleado;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User
 */
public class TipoDeEmpleadoMySQL implements TipoDeEmpleadoDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;    
    @Override
    public ArrayList<TipoDeEmpleado> listartodos() {        
        ArrayList<TipoDeEmpleado> tipos = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_TIPOS_DE_EMPLEADOS()}");
            rs = cs.executeQuery();
            while(rs.next()){
                TipoDeEmpleado tipo = new TipoDeEmpleado();
                tipo.setIdTipoDeEmpleado(rs.getInt("idTipoEmpleado"));
                tipo.setDescripcion(rs.getString("descripcion"));
                tipo.setActivo(true);
                tipos.add(tipo);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return tipos;        
    }
    
}

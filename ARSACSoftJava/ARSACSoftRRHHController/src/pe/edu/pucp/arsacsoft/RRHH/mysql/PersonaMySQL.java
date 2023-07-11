/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import pe.edu.pucp.arsacsoft.RRHH.dao.PersonaDAO;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author Gino
 */
public class PersonaMySQL implements PersonaDAO {

    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    
    @Override
    public int contarRepeticionesDeCorreo(String correo) {
        int repeticiones = 0;
        try
        {
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call CONTAR_REPETICIONES_DE_CORREO(?)}");
            cs.setString(1, correo);
            rs = cs.executeQuery();
            rs.next();
            repeticiones = rs.getInt("repeticiones"); 
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
        return repeticiones;
    }
    
}

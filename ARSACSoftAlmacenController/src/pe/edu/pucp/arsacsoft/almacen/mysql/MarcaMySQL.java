/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.dao.MarcaDAO;
import pe.edu.pucp.arsacsoft.almacen.model.Marca;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author User
 */
public class MarcaMySQL implements MarcaDAO{
    private Connection con;
    private CallableStatement cs;
    private ResultSet rs;
    @Override
    public ArrayList<Marca> listarTodas() {
            ArrayList<Marca> marcas = new ArrayList<>();
            try
            {
                con = DBManager.getInstance().getConnection();
                cs = con.prepareCall("{call LISTAR_MARCA_TODAS()}");
                rs = cs.executeQuery();
                while (rs.next())
                {
                    Marca marca = new Marca();
                    marca.setIdMarca(rs.getInt("id_marca"));
                    marca.setDescripcion(rs.getString("descripcion"));
                    marcas.add(marca);
                }
            }catch (Exception ex){
                System.out.println(ex.getMessage());
            }
            finally{
                try{rs.close();}catch(Exception ex){System.out.println(ex.getMessage());}
                try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
            }
            return marcas;            
    }
    
}

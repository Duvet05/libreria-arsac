/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.edu.pucp.arsacsoft.proveedores.mysql;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.config.DBManager;
import pe.edu.pucp.arsacsoft.proveedores.dao.ProveedorDAO;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;

/**
 *
 * @author User
 */
public class ProveedorMySQL implements ProveedorDAO{
    private Connection con;
    private ResultSet rs;
    private CallableStatement cs;
    @Override
    public ArrayList<Proveedor> listarProveedoresXNombreRUC(String nombre) {
        ArrayList<Proveedor> proveedores = new ArrayList<>();
        try{
            con = DBManager.getInstance().getConnection();
            cs = con.prepareCall("{call LISTAR_PROVEEDORES_POR_NOMBRE_RUC(?)}");
            cs.setString("_nombre", nombre);
            rs = cs.executeQuery();
            while(rs.next()){
                Proveedor provee = new Proveedor();
                provee.setIdProveedor(rs.getInt("id_proveedor"));
                provee.setDescripcion(rs.getString("nombre"));
                provee.setDireccion(rs.getString("direccion"));
                provee.setRUC(rs.getString("RUC"));
                provee.setTelefono(rs.getString("telefono"));
                
                proveedores.add(provee);
            }
        }catch(Exception ex){
            System.out.println(ex.getMessage());
        }finally{
            try{con.close();}catch(Exception ex){System.out.println(ex.getMessage());}
        }
        return proveedores;
    }
    
}

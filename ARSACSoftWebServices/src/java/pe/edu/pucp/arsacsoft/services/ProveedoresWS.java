/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import pe.edu.pucp.arsacsoft.proveedores.dao.ProveedorDAO;
import pe.edu.pucp.arsacsoft.proveedores.model.Proveedor;
import pe.edu.pucp.arsacsoft.proveedores.mysql.ProveedorMySQL;
/**
 *
 * @author Gonzalo
 */
@WebService(serviceName = "ProveedoresWS")
public class ProveedoresWS {

    ProveedorDAO daoProveedor = new ProveedorMySQL();
    @WebMethod
    public ArrayList<Proveedor> listarProveedoresXNombreRUC(String nombre) {
        ArrayList<Proveedor> proveedores = null;
        try {
            proveedores = daoProveedor.listarProveedoresXNombreRUC(nombre);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return proveedores;
    }
}

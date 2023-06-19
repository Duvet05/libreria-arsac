/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.sedes.dao.SedeDAO;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;
import pe.edu.pucp.arsacsoft.sedes.mysql.SedeMySQL;

/**
 *
 * @author Gino
 */
@WebService(serviceName = "SedesWS")
public class SedesWS {
    private SedeDAO daoSede = new SedeMySQL();
    
    @WebMethod(operationName = "insertarSede")
    public int insertarSede(Sede sede)
    {
        return daoSede.insertar(sede);
    }
    
    @WebMethod(operationName = "listarSedes")
    public ArrayList<Sede> listarSedes()
    {
        return daoSede.listarTodas();
    }
    
    @WebMethod(operationName = "modificarSede")
    public int modificarSede(Sede sede)
    {
        return daoSede.modificar(sede);
    }

    @WebMethod(operationName = "eliminarSede")
    public int eliminarSede(int idSede)
    {
        return daoSede.eliminar(idSede);
    }
}

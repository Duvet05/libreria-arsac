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
 * @author Gonzalo
 */
@WebService(serviceName = "SedesWS")
public class SedesWebService {

    /**
     * This is a sample web service operation
     */
    private SedeDAO daoEmpleado = new SedeMySQL();

    @WebMethod(operationName = "listarporNombreDNI")
    public ArrayList<Sede> listarporNombreDNI() {
        ArrayList<Sede> sedes = new ArrayList<Sede>();
        try {
            sedes = daoEmpleado.listarTodas();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return sedes;
    }
}

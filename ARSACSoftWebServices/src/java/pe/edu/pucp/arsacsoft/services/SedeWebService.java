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
@WebService(serviceName = "SedeWS")
public class SedeWebService {

    private SedeDAO daoSede = new SedeMySQL();

    @WebMethod(operationName = "insertarSede")
    public int insertarSede(Sede sede) {
        int resultado = 0;
        try {
            resultado = daoSede.insertar(sede);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "listarSedes")
    public ArrayList<Sede> listarSedes() {
        ArrayList<Sede> sedes = null;
        try {
            sedes = daoSede.listarTodas();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return sedes;
    }

    @WebMethod(operationName = "actualizarSede")
    public int actualizarSede(Sede sede) {
        int resultado = 0;
        try {
            resultado = daoSede.actualizar(sede);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "eliminarSede")
    public int eliminarSede(int idSede) {
        int resultado = 0;
        try {
            resultado = daoSede.eliminar(idSede);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }
}

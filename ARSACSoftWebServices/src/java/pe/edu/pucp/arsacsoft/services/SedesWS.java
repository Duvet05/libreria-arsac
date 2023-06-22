package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import pe.edu.pucp.arsacsoft.sedes.dao.SedeDAO;
import pe.edu.pucp.arsacsoft.sedes.model.Sede;
import pe.edu.pucp.arsacsoft.sedes.model.SedeXProducto;
import pe.edu.pucp.arsacsoft.sedes.mysql.SedeMySQL;

/**
 * Web service para operaciones relacionadas a las Sedes.
 * 
 * @author Gino
 */
@WebService(serviceName = "SedesWS")
public class SedesWS {
    private SedeDAO daoSede = new SedeMySQL();
    
    @WebMethod(operationName = "insertarSede")
    public int insertarSede(Sede sede) {
        try {
            return daoSede.insertar(sede);
        } catch (Exception e) {
            // Manejo de excepciones
            e.printStackTrace();
            return -1; // Código de error personalizado
        }
    }
    
    @WebMethod(operationName = "listarSedes")
    public ArrayList<Sede> listarSedes() {
        try {
            return daoSede.listarTodas();
        } catch (Exception e) {
            // Manejo de excepciones
            e.printStackTrace();
            return new ArrayList<>(); // Retorna una lista vacía en caso de error
        }
    }
    
    @WebMethod(operationName = "modificarSede")
    public int modificarSede(Sede sede) {
        try {
            return daoSede.modificar(sede);
        } catch (Exception e) {
            // Manejo de excepciones
            e.printStackTrace();
            return -1; // Código de error personalizado
        }
    }

    @WebMethod(operationName = "eliminarSede")
    public int eliminarSede(int idSede) {
        try {
            return daoSede.eliminar(idSede);
        } catch (Exception e) {
            // Manejo de excepciones
            e.printStackTrace();
            return -1; // Código de error personalizado
        }
    }
    
    @WebMethod(operationName = "listarProductosDeSede")
    public ArrayList<SedeXProducto> listarProductoDeSede(int idSede, String nombre) {
        try {
            return daoSede.listarProductos(idSede, nombre);
        } catch (Exception e) {
            // Manejo de excepciones
            e.printStackTrace();
            return new ArrayList<>(); // Retorna una lista vacía en caso de error
        }
    }
}

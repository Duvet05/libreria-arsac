package pe.edu.pucp.arsacsoft.services;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.xml.ws.WebServiceException;
import pe.edu.pucp.arsacsoft.RRHH.dao.ClienteMayoristaDAO;
import pe.edu.pucp.arsacsoft.RRHH.dao.CuentaUsuarioDAO;
import pe.edu.pucp.arsacsoft.RRHH.dao.EmpleadoDAO;
import pe.edu.pucp.arsacsoft.RRHH.dao.PersonaDAO;
import pe.edu.pucp.arsacsoft.RRHH.dao.TipoDeEmpleadoDAO;
import pe.edu.pucp.arsacsoft.RRHH.model.ClienteMayorista;
import pe.edu.pucp.arsacsoft.RRHH.model.CuentaUsuario;
import pe.edu.pucp.arsacsoft.RRHH.model.Empleado;
import pe.edu.pucp.arsacsoft.RRHH.model.Persona;
import pe.edu.pucp.arsacsoft.RRHH.model.TipoDeEmpleado;
import pe.edu.pucp.arsacsoft.RRHH.mysql.ClienteMayoristaMySQL;
import pe.edu.pucp.arsacsoft.RRHH.mysql.CuentaUsuarioMySQL;
import pe.edu.pucp.arsacsoft.RRHH.mysql.EmpleadoMySQL;
import pe.edu.pucp.arsacsoft.RRHH.mysql.PersonaMySQL;
import pe.edu.pucp.arsacsoft.RRHH.mysql.TipoDeEmpleadoMySQL;

@WebService(serviceName = "RRHHWS")
public class RRHHWS {

    private TipoDeEmpleadoDAO daoTipoEmpleado = new TipoDeEmpleadoMySQL();
    private EmpleadoDAO daoEmpleado = new EmpleadoMySQL();
    private ClienteMayoristaDAO daoCliente = new ClienteMayoristaMySQL();
    private CuentaUsuarioDAO daoCuentaUsuario = new CuentaUsuarioMySQL();
    private PersonaDAO daoPersona = new PersonaMySQL();
    
    @WebMethod(operationName = "obtenerRepeticionesDeCorreo")
    public int obtenerRepeticionesDeCorreo(String correo)
    {
        return daoPersona.contarRepeticionesDeCorreo(correo);
    }

    @WebMethod(operationName = "listarTiposDeEmpleados")
    public ArrayList<TipoDeEmpleado> listarTiposDeEmpleados() {
        return daoTipoEmpleado.listartodos();
    }

    @WebMethod(operationName = "listarEmpleadosPorSedeNombreDNI")
    public ArrayList<Empleado> listarEmpleadosPorSedeNombreDNI(int idSede, String nombreDNI) {
        return daoEmpleado.listarPorSedeNombreDNI(idSede, nombreDNI);
    }

    @WebMethod(operationName = "listarEmpleadosPorNombreDNI")
    public ArrayList<Empleado> listarEmpleadosPorNombreDNI(String nombreDNI) {
        return daoEmpleado.listarPorNombreDNI(nombreDNI);
    }

    @WebMethod(operationName = "insertarEmpleado")
    public int insertarEmpleado(Empleado empleado) {
        int resultado = 0;
        try {
            resultado = daoEmpleado.insertar(empleado);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "modificarEmpleado")
    public int modificarEmpleado(Empleado empleado) {
        return daoEmpleado.modificar(empleado);
    }

    @WebMethod(operationName = "eliminarEmpleado")
    public int eliminarEmpleado(int idEmpleado) {
        return daoEmpleado.eliminar(idEmpleado);
    }

    @WebMethod(operationName = "obtenerEmpleadoPorID")
    public Empleado obtenerEmpleadoPorID(int idEmpleado) {
        Empleado empleado = new Empleado();
        try {
            empleado = daoEmpleado.buscarPorID(idEmpleado);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return empleado;
    }

    @WebMethod(operationName = "listarClientesMayoristasPorNombreDNI")
    public ArrayList<Persona> listarClientesMayoristasPorNombreDNI(String nombreDNI) {
        return daoCliente.listarPorNombreDNI(nombreDNI);
    }

    @WebMethod(operationName = "insertarClienteMayorista")
    public int insertarClienteMayorista(ClienteMayorista cliente) {
        return daoCliente.insertar(cliente);
    }

    @WebMethod(operationName = "modificarClienteMayorista")
    public int modificarClienteMayorista(ClienteMayorista cliente) {
        return daoCliente.modificar(cliente);
    }

    @WebMethod(operationName = "eliminarClienteMayorista")
    public int eliminarClienteMayorista(int idClienteMayorista) {
        return daoCliente.eliminar(idClienteMayorista);
    }

    @WebMethod(operationName = "verificarCuenta")
    public int verificarCuenta(CuentaUsuario cuentaUsuario) {
        int resultado = 0;
        try {
            resultado = daoCuentaUsuario.verificar(cuentaUsuario);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "insertarCuentaUsuario")
    public int insertarCuentaUsuario(CuentaUsuario cuentaUsuario) {
        int resultado = 0;
        try {
            resultado = daoCuentaUsuario.insertarCuenta(cuentaUsuario);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "buscarEmpleado")
    public Empleado buscarEmpleado(int idEmpleado) {
        Empleado resultado = new Empleado();
        try {
            resultado = daoEmpleado.buscarPorID(idEmpleado);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
        }
        return resultado;
    }

    @WebMethod(operationName = "actualizarCuenta")
    public int actualizarCuenta(CuentaUsuario cuentaUsuario) {
        try {
            return daoCuentaUsuario.actualizar(cuentaUsuario);
        } catch (Exception ex) {
            System.out.println("Error al actualizar la cuenta de usuario: " + ex.getMessage());
            throw new WebServiceException("Error al actualizar la cuenta de usuario", ex);
        }
    }

    @WebMethod(operationName = "buscarCuenta")
    public CuentaUsuario buscarCuenta(int idEmpleado) {
        try {
            return daoCuentaUsuario.buscar(idEmpleado);
        } catch (Exception ex) {
            System.out.println("Error al buscar la cuenta de usuario: " + ex.getMessage());
            throw new WebServiceException("Error al buscar la cuenta de usuario", ex);
        }
    }
    @WebMethod(operationName = "verificarRepeticionDeCuenta")
    public int verificarRepeticionDeCuenta(String username)
    {
        return daoCuentaUsuario.verificarRepeticion(username);
    }
    
    @WebMethod(operationName = "obtenerDireccionDeSedeDeEmpleado")
    public String obtenerDireccionDeSedeDeEmpleado(int idEmpleado)
    {
        return daoEmpleado.obtenerDireccionDeSede(idEmpleado);
    }
    
    @WebMethod(operationName = "buscarClienteMayoristaPorID")
    public ClienteMayorista buscarClienteMayoristaPorID(int idCliente)
    {
        return daoCliente.buscarPorID(idCliente);
    }
}

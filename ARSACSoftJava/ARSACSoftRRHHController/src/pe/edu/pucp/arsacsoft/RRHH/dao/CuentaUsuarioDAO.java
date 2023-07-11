package pe.edu.pucp.arsacsoft.RRHH.dao;

import pe.edu.pucp.arsacsoft.RRHH.model.CuentaUsuario;


public interface CuentaUsuarioDAO {
    int verificar(CuentaUsuario cuenta);
    int insertarCuenta(CuentaUsuario cuenta);
    CuentaUsuario buscar(int idEmpleado);
    int actualizar(CuentaUsuario cuenta);
    int verificarRepeticion(String username);
}

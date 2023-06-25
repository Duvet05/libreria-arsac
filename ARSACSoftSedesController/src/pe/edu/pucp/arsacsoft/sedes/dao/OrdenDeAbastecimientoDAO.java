package pe.edu.pucp.arsacsoft.sedes.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.sedes.model.LineaOrdenDeAbastecimiento;
import pe.edu.pucp.arsacsoft.sedes.model.OrdenDeAbastecimiento;

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */

/**
 *
 * @author Gino
 */
public interface OrdenDeAbastecimientoDAO {
    int insertar(OrdenDeAbastecimiento orden);
    int verificarEntrega(OrdenDeAbastecimiento orden);
    int entregar(OrdenDeAbastecimiento orden);
    int cancelar(int idOrdenDeAbastecimiento);
    ArrayList<OrdenDeAbastecimiento> listarPorIdEmpleadoEstado(int idEmpleado, String estado);
    ArrayList<LineaOrdenDeAbastecimiento> listarLineasDeOrdenDeAbastecimiento(int idOrdenDeAbastecimiento);
    
    int obtenerStockDeProductoEnSedePrincipal(int idProducto);
    int obtenerStockDeProductoEnSede(int idProducto, int idSede);
    
}

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.dao;

import java.util.ArrayList;
import java.util.Date;
import pe.edu.pucp.arsacsoft.almacen.model.LineaOrdenDeCompra;
import pe.edu.pucp.arsacsoft.almacen.model.OrdenDeCompra;

/**
 *
 * @author User
 */
public interface OrdenDeCompraDAO {
    int insertar(OrdenDeCompra ordenCompra);
    int modificar(OrdenDeCompra ordenCompra);
//    int eliminar(int idOrdenCompra);
    ArrayList<OrdenDeCompra> listarPorProveedor(int idProveedor, Date fechaInicio, Date fechaFin, String estado);   
    ArrayList<LineaOrdenDeCompra> listarLineasOrdenDeCompra(int idOrdenCompra);
    int cancelar(int IdOrdenCompra);
    int registrarIngresoDeMercaderia(OrdenDeCompra ordenCompra);
    //ArrayList<OrdenDeCompra> listarPorIdDNINombreEmpleado(String idDNINombreEmpleado);    
}

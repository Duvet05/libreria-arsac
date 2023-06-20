/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arcacsoft.ordenes.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.ordenes.model.LineaDeOrdenDeVenta;
import pe.edu.pucp.arsacsoft.ordenes.model.OrdenDeVenta;

public interface OrdenDeVentaDAO {
    int insertar(OrdenDeVenta ordenV);
    int modificar(OrdenDeVenta ordenV);
    int eliminar(int idOrdenDeVenta);
    ArrayList<OrdenDeVenta> listarPorFecha();    
    ArrayList<OrdenDeVenta> listarPorClienteMayorista();
    ArrayList<OrdenDeVenta> listarPorVendedor( int idPersona);
    //ArrayList<OrdenDeVenta> listarPorSedes( int idClienteMayorista);
    OrdenDeVenta buscarPorID(int idOrdenDeVenta);
    public int CancelarVenta(int idOrdenDeVenta);
    public ArrayList<LineaDeOrdenDeVenta> ListarProductos(int idOrdenDeVenta);
}



/**
 *
 * @author User
 */

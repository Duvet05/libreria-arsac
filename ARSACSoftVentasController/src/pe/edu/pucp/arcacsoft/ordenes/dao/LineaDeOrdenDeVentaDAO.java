/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arcacsoft.ordenes.dao;


import pe.edu.pucp.arsacsoft.ordenes.model.LineaDeOrdenDeVenta;

/**
 *
 * @author El~Nicolays
 */
public interface LineaDeOrdenDeVentaDAO {
    int insertar(LineaDeOrdenDeVenta lineaOrden,int idOrdenVenta);
    int modificar(LineaDeOrdenDeVenta lineaOrden,int idOrdenVenta,int idProducto);
    int eliminar(int idOrdenVenta,int idProducto);
    int verificarStockSuficiente(int idSede, int idProducto, int cantidad);
}

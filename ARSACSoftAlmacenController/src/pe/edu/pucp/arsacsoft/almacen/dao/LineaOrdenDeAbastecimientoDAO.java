/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.model.LineaDeOrdenDeAbastecimiento;

/**
 *
 * @author User
 */
public interface LineaOrdenDeAbastecimientoDAO {
    ArrayList<LineaDeOrdenDeAbastecimiento> listarPorIdOrdenAbastecimiento(int idOrdenAbastecimiento);
}

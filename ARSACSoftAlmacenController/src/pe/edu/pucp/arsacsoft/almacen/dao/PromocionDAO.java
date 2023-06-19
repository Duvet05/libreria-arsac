/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.almacen.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.almacen.model.Promocion;

/**
 *
 * @author User
 */
public interface PromocionDAO {
    ArrayList<Promocion> listarTodas();
    int insertar(Promocion promocion);
    int modificar(Promocion promocion);
    int eliminar(int idPromocion);        
}

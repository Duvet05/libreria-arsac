/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package pe.edu.pucp.arsacsoft.RRHH.dao;

import java.util.ArrayList;
import pe.edu.pucp.arsacsoft.RRHH.model.ClienteMayorista;
import pe.edu.pucp.arsacsoft.RRHH.model.Persona;

/**
 *
 * @author User
 */
public interface ClienteMayoristaDAO {
    int insertar(ClienteMayorista cliente);
    int modificar(ClienteMayorista cliente);
    int eliminar(int idclientemayorista);
    ArrayList<Persona> listarPorNombreDNI(String DNINombre);     
}

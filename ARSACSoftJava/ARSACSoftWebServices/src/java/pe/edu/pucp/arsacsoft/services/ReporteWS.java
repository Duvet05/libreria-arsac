/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/WebServices/WebService.java to edit this template
 */
package pe.edu.pucp.arsacsoft.services;

import java.awt.Image;
import java.sql.Connection;
import java.util.HashMap;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.swing.ImageIcon;
import net.sf.jasperreports.engine.JasperExportManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;
import net.sf.jasperreports.engine.util.JRLoader;
import pe.edu.pucp.arsacsoft.config.DBManager;

/**
 *
 * @author Gino
 */
@WebService(serviceName = "ReporteWS")
public class ReporteWS {

    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "generarBoletaDeVenta")
    public byte[] generarBoletaDeVenta(int idOrdenDeVenta, String direccionDeSede) {
        
        byte[] reporteBytes = null;
        Connection con = null;
        
        try
        {
            con = DBManager.getInstance().getConnection();
            
            JasperReport reporte = (JasperReport)
                JRLoader.loadObject(
                    ReporteWS.class.getResource("/pe/edu/pucp/arsacsoft/reports/BoletaDeVenta.jasper")
                );
            
            //String rutaImagen =
            //BoletaDeVenta.class.getResource("/pe/edu/pucp/arsacsoft/img/logoARSAC_2.png").getPath();
            //Image imagen = (new ImageIcon(rutaImagen)).getImage();
            
            // Conjunto de parametros
            HashMap parametros = new HashMap();
            parametros.put("id_orden_de_venta", idOrdenDeVenta);
            parametros.put("direccion_de_sede", direccionDeSede);
            //parametros.put("Imagen", imagen);

            JasperPrint jp = JasperFillManager.fillReport
            (reporte, parametros, con);
            
            reporteBytes = JasperExportManager.exportReportToPdf(jp);
            
        }catch(Exception ex)
        {
            System.out.println(ex.getMessage());
        }
        finally
        {
            try
            {
                con.close();
            }
            catch(Exception ex)
            {
                System.out.println(ex.getMessage());
            }
        }
        return reporteBytes;
    }
}

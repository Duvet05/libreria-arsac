using ARSACSoft.ReporteWS;
using ARSACSoft.RRHHWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBoletaDeVenta : Form
    {
        private ReporteWSClient _daoReporte;
        private RRHHWSClient _daoRRHH;

        public frmBoletaDeVenta(int idOrdenDeventa, int idEmpleado)
        {
            InitializeComponent();

            _daoReporte = new ReporteWSClient();
            _daoRRHH = new RRHHWSClient();

            string direccionDeSede = _daoRRHH.obtenerDireccionDeSedeDeEmpleado(idEmpleado);
            byte[] arreglo = _daoReporte.generarBoletaDeVenta(idOrdenDeventa, direccionDeSede);
            File.WriteAllBytes("BoletaDeVenta" + idOrdenDeventa + ".pdf", arreglo);
            axBoletaDeVenta.LoadFile("BoletaDeVenta" + idOrdenDeventa + ".pdf");


        }
    }
}

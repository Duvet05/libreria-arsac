using ARSACSoft.ReporteWS;
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

        public frmBoletaDeVenta(int idOrdenDeventa, int idEmpleado)
        {
            InitializeComponent();

            _daoReporte = new ReporteWSClient();

            byte[] arreglo = _daoReporte.generarBoletaDeVenta(idOrdenDeventa, idEmpleado);
            File.WriteAllBytes("BoletaDeVenta" + idOrdenDeventa + ".pdf", arreglo);
            axBoletaDeVenta.LoadFile("BoletaDeVenta" + idOrdenDeventa + ".pdf");


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARSACSoft.RRHHWebService;

namespace ARSACSoft
{
    public partial class frmGestionRRHH : Form
    {
        private RRHHWebServiceClient daoEmpleados = new RRHHWebServiceClient();
        public frmGestionRRHH()
        {
            InitializeComponent();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            empleado empleadito = new empleado();
            empleadito.nombre = textNombre1.Text;
            empleadito.apellidos = textApellido1.Text;
            empleadito.correo = textCorreo1.Text;
            daoEmpleados.insertarEmpleado(empleadito);
        }
    }
}

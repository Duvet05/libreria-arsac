using ARSACSoft.RRHHWS;
using ARSACSoft.SedeWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionRRHH : Form
    {

        private Estado estado;
        private RRHHWebServiceClient daoRRHH;

        public frmGestionRRHH()
        {
            InitializeComponent();
        }

        private void gbDatosEmpleado_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            daoRRHH = new RRHHWebServiceClient();

            empleado empleadito = new empleado();
            empleadito.nombre = textNombre1.Text;
            empleadito.apellidos = textApellido1.Text;
            empleadito.DNI = textDNI1.Text;
            empleadito.correo = textCorreo1.Text;
            empleadito.contrasenha = textContrasenha.Text;
            empleadito.tipo = new tipoDeEmpleado();
            empleadito.tipo.idTipoDeEmpleado = 1;
            int resultado = daoRRHH.insertarEmpleado(empleadito);

            if (resultado != 0)
            {
                MessageBox.Show("Se ha registrado con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDPersona1.Text = resultado.ToString();
                estado = Estado.Inicial;
                //establecerEstadoFormulario();
            }
            else
                MessageBox.Show("Ha ocurrido un error con el registro", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnBuscarSede_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleado formBuscarEmpleado = new frmBuscarEmpleado();
            if (formBuscarEmpleado.ShowDialog() == DialogResult.OK)
            {
                empleado empleadito = formBuscarEmpleado.EmpleadoSeleccionado;
                textNombre1.Text = empleadito.nombre;
                textApellido1.Text = empleadito.apellidos;
                textDNI1.Text = empleadito.DNI;
                textCorreo1.Text = empleadito.correo;
                textContrasenha.Text = empleadito.contrasenha;
                estado = Estado.Buscar;
                //establecerEstadoTabSedes();
            }
        }
    }
}

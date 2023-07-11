using ARSACSoft.RRHHWS;
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
    public partial class frmActualizarCredenciales : Form
    {
        private cuentaUsuario _cuenta;
        private RRHHWSClient _daoRRHH;
        private empleado _empleadoLogeado;

        public frmActualizarCredenciales(empleado empleadoLogeado)
        {
            InitializeComponent();
            _daoRRHH = new RRHHWSClient();
            _empleadoLogeado = empleadoLogeado;

            _cuenta = _daoRRHH.buscarCuenta(empleadoLogeado.idPersona);
            _cuenta.idEmpleado = _empleadoLogeado.idPersona;

            txtContrasena.Text = _cuenta.password;
            txtUsuario.Text = _cuenta.username;
        }

        private void btnGuardarSede_Click(object sender, EventArgs e)
        {

            if (_cuenta.username == txtUsuario.Text || (
                _cuenta.username != txtUsuario.Text && _daoRRHH.verificarRepeticionDeCuenta(txtUsuario.Text) == 0))
            {
                _cuenta.username = txtUsuario.Text;
                _cuenta.password = txtContrasena.Text;
                _daoRRHH.actualizarCuenta(_cuenta);
                MessageBox.Show($"Se actualizaron las credenciales", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Error al actualizar las credenciales", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !cbMostrarContrasena.Checked;
        }
    }
}

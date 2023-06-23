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
        private string _username;

        public frmActualizarCredenciales(empleado empleadoLogeado)
        {
            InitializeComponent();
            _daoRRHH = new RRHHWSClient();
            _empleadoLogeado = empleadoLogeado;

            _cuenta = _daoRRHH.buscarCuenta(empleadoLogeado.idPersona);

            txtContrasena.Text = _cuenta.password;
            txtUsuario.Text = _cuenta.username;
            _username = _cuenta.username;
        }

        private void btnGuardarSede_Click(object sender, EventArgs e)
        {

            if (_username == txtUsuario.Text)
            {
                _cuenta.username = txtUsuario.Text;
                _cuenta.password = txtContrasena.Text;
                _daoRRHH.actualizarCuenta(_cuenta);
            }
            else if (_daoRRHH.verificarRepeticionDeCuenta(txtUsuario.Text) == 0)
            {
                _cuenta.username = txtUsuario.Text;
                _cuenta.password = txtContrasena.Text;
                _daoRRHH.actualizarCuenta(_cuenta);
            }
            else
                MessageBox.Show($"Error al registrar el usuario", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

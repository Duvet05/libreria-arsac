using ARSACSoft.RRHHWS;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmIniciarSesion : Form
    {
        private readonly RRHHWSClient _daoRRHWSClient;
        private cuentaUsuario _cuenta;

        public frmIniciarSesion()
        {
            InitializeComponent();
            _daoRRHWSClient = new RRHHWSClient();
        }

        // Importar funciones externas para arrastrar la ventana sin bordes
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void frmIniciarSesion_MouseDown(object sender, MouseEventArgs e)
        {
            // Permitir arrastrar la ventana sin bordes
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }

        private void txtContrasenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Ingresar();
            }
        }

        private void Ingresar()
        {
            // Obtener las credenciales del usuario
            _cuenta = new cuentaUsuario
            {
                username = txtUsuario.Text.Trim(),
                password = txtContrasenha.Text
            };

            // algo


            // Verificar las credenciales y obtener el ID del empleado
            int idEmpleado = _daoRRHWSClient.verificarCuenta(_cuenta);

            if (idEmpleado == 0)
            {
                MessageBox.Show("Las credenciales no son correctas", "Ups",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AbrirFormPrincipal(idEmpleado);
            }
        }

        private void AbrirFormPrincipal(int idEmpleado)
        {
            // Abrir el formulario principal y ocultar el formulario actual
            frmPrincipal formPrincipal = new frmPrincipal(idEmpleado);
            Hide();
            formPrincipal.ShowDialog();
            ResetearCampos();
            Visible = true;
        }

        private void ResetearCampos()
        {
            // Limpiar los campos de usuario y contraseña
            txtUsuario.Text = "";
            txtContrasenha.Text = "";
        }
    }
}

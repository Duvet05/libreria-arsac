using ARSACSoft.RRHHWS;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmIniciarSesion : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int IParam);

        private readonly RRHHWSClient _daoRRHWSClient;
        private cuentaUsuario _cuenta;

        public frmIniciarSesion()
        {
            InitializeComponent();
            _daoRRHWSClient = new RRHHWSClient();
        }

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
            _cuenta = new cuentaUsuario
            {
                username = txtUsuario.Text.Trim(),
                password = txtContrasenha.Text
            };

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
            frmPrincipal formPrincipal = new frmPrincipal(idEmpleado);
            Hide();
            formPrincipal.ShowDialog();
            ResetearCampos();
            Visible = true;
        }

        private void ResetearCampos()
        {
            txtUsuario.Text = "";
            txtContrasenha.Text = "";
        }
    }
}

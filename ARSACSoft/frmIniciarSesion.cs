using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmIniciarSesion : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmIniciarSesion()
        {
            InitializeComponent();
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            /*
            int verificar = daoEmpleado.verificarUsuarioEmpleado(txtUsername.Text,
                txtPassword.Text);
            if (verificar == 0)
            {
                MessageBox.Show("Las credenciales no son correctas", "Ups",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                frmPrincipal formPrincipal = new frmPrincipal();
                this.Hide();
                //Verificamos roles
                //formPrincipal.BtnGestionarEmpleados.Visible = false;

                formPrincipal.ShowDialog();
                txtPassword.Text = "";
                txtUsername.Text = "";
                this.Visible = true;
            }
            */
            frmPrincipal formPrinc = new frmPrincipal();
            this.Hide();
            //Verificamos roles
            //formPrincipal.BtnGestionarEmpleados.Visible = false;

            //Código para desactivar páginas dados sus privilegios
            //TabPage page2 = formPrinc.TcPrincipal.TabPages[0];
            //formPrinc.TcPrincipal.TabPages.Remove(page2);

            formPrinc.ShowDialog();
            txtPassword.Text = "";
            txtUsername.Text = "";
            this.Visible = true;
        }

        private void frmIniciarSesion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }
    }
}

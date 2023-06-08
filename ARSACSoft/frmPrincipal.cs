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
    public partial class frmPrincipal : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);
        public frmPrincipal()
        {
            InitializeComponent();
            frmBienvenida formularioBienvenida = new frmBienvenida();
            mostrarFormulario(formularioBienvenida);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Realiza cualquier limpieza o reinicio necesario para cerrar la sesión
                // Por ejemplo, puedes reiniciar los valores de las variables o limpiar el estado de la aplicación

                // Muestra el formulario de inicio de sesión y oculta el formulario principal
                this.Close();
            }
        }

        private void frmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Realiza cualquier limpieza o reinicio necesario para cerrar la sesión
                // Por ejemplo, puedes reiniciar los valores de las variables o limpiar el estado de la aplicación

                // Muestra el formulario de inicio de sesión y oculta el formulario principal
                this.Close();
            }
        }

        private void pbCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Realiza cualquier limpieza o reinicio necesario para cerrar la sesión
                // Por ejemplo, puedes reiniciar los valores de las variables o limpiar el estado de la aplicación

                // Muestra el formulario de inicio de sesión y oculta el formulario principal
                this.Close();
            }
        }

        private void panelBarraVentana_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        public void mostrarFormulario(Form form)
        {
            panelContenedor.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panelContenedor.Controls.Add(form);
            form.Visible = true;
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            frmGestionAlmacen frmGestAlmac = new frmGestionAlmacen();
            mostrarFormulario(frmGestAlmac);
        }

        private void pbAlmacen_Click(object sender, EventArgs e)
        {
            frmGestionAlmacen frmGestAlmac = new frmGestionAlmacen();
            mostrarFormulario(frmGestAlmac);
        }

        private void lblTituloARSAC_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void pbLogoARSAC_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmGestionPedidos frmGestPed = new frmGestionPedidos();
            mostrarFormulario(frmGestPed);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmGestionProveedores frmGestProveedores = new frmGestionProveedores();
            mostrarFormulario(frmGestProveedores);
        }

        private void btnSede_Click(object sender, EventArgs e)
        {
            frmGestionSedes frmGestSedes = new frmGestionSedes();
            mostrarFormulario(frmGestSedes);
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            frmContabilidad frmContab = new frmContabilidad();
            mostrarFormulario(frmContab);
        }

        private void btnRRHH_Click(object sender, EventArgs e)
        {
            frmGestionRRHH frmGestRRHH = new frmGestionRRHH();
            mostrarFormulario(frmGestRRHH);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReportes frmReports = new frmReportes();
            mostrarFormulario(frmReports);
        }
    }
}

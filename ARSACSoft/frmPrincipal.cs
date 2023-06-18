using ARSACSoft.RRHHWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        
        private RRHHWSClient daoRRHH;
        empleado _empleado;
        private empleado empleadoLogeado;

        public GroupBox BtnPedidos
        {
            get => grupoPedidos;
            set => grupoPedidos = value;
        }

        public GroupBox BtnAlmacen
        {
            get => grupoAlmacen;
            set => grupoAlmacen = value;
        }

        public GroupBox BtnProveedores
        {
            get => grupoProveedores;
            set => grupoProveedores = value;
        }

        public GroupBox BtnSede
        {
            get => grupoSede;
            set => grupoSede = value;
        }

        public GroupBox BtnContabilidad
        {
            get => grupoContabilidad;
            set => grupoContabilidad = value;
        }

        public GroupBox BtnRRHH
        {
            get => grupoRRHH;
            set => grupoRRHH = value;
        }

        public GroupBox BtnReportes
        {
            get => grupoReportes;
            set => grupoReportes = value;
        }
        public frmPrincipal(empleado empleadoLogeado)
        {
            
            InitializeComponent();
            frmBienvenida formularioBienvenida = new frmBienvenida();
            mostrarFormulario(formularioBienvenida);

            this.empleadoLogeado = empleadoLogeado;
            lblNombreApellidoUsuario.Text = empleadoLogeado.nombre + " " + empleadoLogeado.apellidos;
            lblCargoUsuario.Text = empleadoLogeado.tipo.descripcion;
            lblSedeUsuario.Text = empleadoLogeado.sede.direccion;

            MemoryStream ms = new MemoryStream(empleadoLogeado.foto);
            pbFotoUsuario.Image = new Bitmap(ms);


            daoRRHH = new RRHHWSClient();
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

            btnPedidos.ForeColor = System.Drawing.Color.Gray;
            btnAlmacen.ForeColor = System.Drawing.Color.Black;
            btnProveedores.ForeColor = System.Drawing.Color.Gray;
            btnSede.ForeColor = System.Drawing.Color.Gray;
            btnContabilidad.ForeColor = System.Drawing.Color.Gray;
            btnRRHH.ForeColor = System.Drawing.Color.Gray;
            btnReportes.ForeColor = System.Drawing.Color.Gray;
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

        public void SetButtonColor(Button selectedButton)
        {
            // Establecer todos los botones en gris
            btnPedidos.ForeColor = Color.Gray;
            btnAlmacen.ForeColor = Color.Gray;
            btnProveedores.ForeColor = Color.Gray;
            btnSede.ForeColor = Color.Gray;
            btnContabilidad.ForeColor = Color.Gray;
            btnRRHH.ForeColor = Color.Gray;
            btnReportes.ForeColor = Color.Gray;

            // Establecer el botón seleccionado en negro
            selectedButton.ForeColor = Color.Black;
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmGestionsPedidos frmGestPed = new frmGestionsPedidos();
            mostrarFormulario(frmGestPed);

            SetButtonColor(btnPedidos);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmGestionProveedores frmGestProveedores = new frmGestionProveedores();
            mostrarFormulario(frmGestProveedores);

            SetButtonColor(btnProveedores);
        }

        private void btnSede_Click(object sender, EventArgs e)
        {
            frmGestionSedes frmGestSedes = new frmGestionSedes();
            mostrarFormulario(frmGestSedes);

            btnPedidos.ForeColor = System.Drawing.Color.Gray;
            btnAlmacen.ForeColor = System.Drawing.Color.Gray;
            btnProveedores.ForeColor = System.Drawing.Color.Gray;
            btnSede.ForeColor = System.Drawing.Color.Black;
            btnContabilidad.ForeColor = System.Drawing.Color.Gray;
            btnRRHH.ForeColor = System.Drawing.Color.Gray;
            btnReportes.ForeColor = System.Drawing.Color.Gray;
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            frmContabilidad frmContab = new frmContabilidad();
            mostrarFormulario(frmContab);

            btnPedidos.ForeColor = System.Drawing.Color.Gray;
            btnAlmacen.ForeColor = System.Drawing.Color.Gray;
            btnProveedores.ForeColor = System.Drawing.Color.Gray;
            btnSede.ForeColor = System.Drawing.Color.Gray;
            btnContabilidad.ForeColor = System.Drawing.Color.Black;
            btnRRHH.ForeColor = System.Drawing.Color.Gray;
            btnReportes.ForeColor = System.Drawing.Color.Gray;
        }

        private void btnRRHH_Click(object sender, EventArgs e)
        {
            frmGestionRRHH frmGestRRHH = new frmGestionRRHH();
            mostrarFormulario(frmGestRRHH);

            btnPedidos.ForeColor = System.Drawing.Color.Gray;
            btnAlmacen.ForeColor = System.Drawing.Color.Gray;
            btnProveedores.ForeColor = System.Drawing.Color.Gray;
            btnSede.ForeColor = System.Drawing.Color.Gray;
            btnContabilidad.ForeColor = System.Drawing.Color.Gray;
            btnRRHH.ForeColor = System.Drawing.Color.Black;
            btnReportes.ForeColor = System.Drawing.Color.Gray;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            frmReportes frmReports = new frmReportes();
            mostrarFormulario(frmReports);

            btnPedidos.ForeColor = System.Drawing.Color.Gray;
            btnAlmacen.ForeColor = System.Drawing.Color.Gray;
            btnProveedores.ForeColor = System.Drawing.Color.Gray;
            btnSede.ForeColor = System.Drawing.Color.Gray;
            btnContabilidad.ForeColor = System.Drawing.Color.Gray;
            btnRRHH.ForeColor = System.Drawing.Color.Gray;
            btnReportes.ForeColor = System.Drawing.Color.Black;
        }

        private void panelMenuPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

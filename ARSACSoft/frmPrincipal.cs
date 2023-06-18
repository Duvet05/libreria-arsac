using ARSACSoft.RRHHWS;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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
        private empleado _empleadoLogeado;
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
        public frmPrincipal(int idEmpleado)
        {
            InitializeComponent();
            DisplayForm(new frmBienvenida());

            daoRRHH = new RRHHWSClient();
            _empleadoLogeado = daoRRHH.obtenerEmpleadoPorID(idEmpleado);
            UpdateEmployeeInfo();

            switch (_empleadoLogeado.tipo.idTipoDeEmpleado)
            {
                case 1:
                    OcultarBotones(this.BtnPedidos, this.BtnAlmacen, this.BtnProveedores, this.BtnContabilidad);
                    break;
                case 2:
                    OcultarBotones(this.BtnAlmacen, this.BtnProveedores, this.BtnSede, this.BtnContabilidad, this.BtnRRHH);
                    break;
                case 3:
                    OcultarBotones(this.BtnPedidos, this.BtnContabilidad, this.BtnRRHH, this.BtnReportes);
                    break;
                case 4:
                    OcultarBotones(this.BtnPedidos, this.BtnAlmacen, this.BtnContabilidad);
                    break;
                case 5:
                    OcultarBotones(this.BtnPedidos, this.BtnAlmacen, this.BtnProveedores, this.BtnSede, this.BtnContabilidad);
                    break;
                case 6:
                    //Gerencia
                    break;
            }
        }

        private void OcultarBotones(params GroupBox[] botones)
        {
            foreach (var boton in botones)
            {
                boton.Visible = false;
            }
        }


        private void UpdateEmployeeInfo()
        {
            lblNombreApellidoUsuario.Text = $"{_empleadoLogeado.nombre} {_empleadoLogeado.apellidos}";
            lblCargoUsuario.Text = _empleadoLogeado.tipo.descripcion;
            lblSedeUsuario.Text = _empleadoLogeado.sede.direccion;
            if (this._empleadoLogeado.foto != null)
            {
                MemoryStream ms = new MemoryStream(_empleadoLogeado.foto);
                pbFotoUsuario.Image = new Bitmap(ms);
            }
        }

        private void DisplayForm(Form form)
        {
            panelContenedor.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            panelContenedor.Controls.Add(form);
            form.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void frmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void pbCerrarSesion_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void LogOut()
        {
            if (MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void panelBarraVentana_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }


        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            frmGestionAlmacen frmGestAlmac = new frmGestionAlmacen();
            DisplayForm(frmGestAlmac);

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
            DisplayForm(frmGestAlmac);
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
            frmGestionPedidos frmGestPed = new frmGestionPedidos();
            DisplayForm(frmGestPed);

            SetButtonColor(btnPedidos);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmGestionProveedores frmGestProveedores = new frmGestionProveedores();
            DisplayForm(frmGestProveedores);

            SetButtonColor(btnProveedores);
        }

        private void btnSede_Click(object sender, EventArgs e)
        {
            frmGestionSedes frmGestSedes = new frmGestionSedes();
            DisplayForm(frmGestSedes);

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
            DisplayForm(frmContab);

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
            DisplayForm(frmGestRRHH);

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
            DisplayForm(frmReports);

            btnPedidos.ForeColor = System.Drawing.Color.Gray;
            btnAlmacen.ForeColor = System.Drawing.Color.Gray;
            btnProveedores.ForeColor = System.Drawing.Color.Gray;
            btnSede.ForeColor = System.Drawing.Color.Gray;
            btnContabilidad.ForeColor = System.Drawing.Color.Gray;
            btnRRHH.ForeColor = System.Drawing.Color.Gray;
            btnReportes.ForeColor = System.Drawing.Color.Black;
        }

    }
}

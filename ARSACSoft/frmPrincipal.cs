using ARSACSoft.RRHHWS;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmPrincipal : Form
    {
        private readonly RRHHWSClient daoRRHH;
        private readonly empleado _empleadoLogeado;

        private frmGestionAlmacen frmAlmacen;
        private frmGestionPedidos frmPedidos;
        private frmGestionProveedores frmProveedores;
        private frmGestionSedes frmSedes;
        private frmContabilidad frmContab;
        private frmGestionRRHH frmGestRRHH;
        private frmReportes frmReports;
        
        public frmPrincipal(int idEmpleado)
        {
            InitializeComponent();
            DisplayForm(new frmBienvenida());

            daoRRHH = new RRHHWSClient();
            _empleadoLogeado = daoRRHH.obtenerEmpleadoPorID(idEmpleado);
            UpdateEmployeeInfo();

            InitializeForms();

            switch (_empleadoLogeado.tipo.idTipoDeEmpleado)
            {
                case 1:
                    OcultarBotones(grupoPedidos, grupoAlmacen, grupoProveedores, grupoContabilidad);
                    break;
                case 2:
                    OcultarBotones(grupoAlmacen, grupoProveedores, grupoSede, grupoContabilidad, grupoRRHH);
                    break;
                case 3:
                    OcultarBotones(grupoPedidos, grupoContabilidad, grupoRRHH, grupoReportes);
                    break;
                case 4:
                    OcultarBotones(grupoPedidos, grupoAlmacen, grupoContabilidad);
                    break;
                case 5:
                    OcultarBotones(grupoPedidos, grupoAlmacen, grupoProveedores, grupoSede, grupoContabilidad);
                    break;
                case 6:
                    //Gerencia
                    break;
            }
        }

        private void InitializeForms()
        {
            frmAlmacen = new frmGestionAlmacen();
            frmPedidos = new frmGestionPedidos();
            frmProveedores = new frmGestionProveedores();
            frmSedes = new frmGestionSedes();
            frmContab = new frmContabilidad();
            frmGestRRHH = new frmGestionRRHH();
            frmReports = new frmReportes();
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
            if (_empleadoLogeado.foto != null)
            {
                using (MemoryStream ms = new MemoryStream(_empleadoLogeado.foto))
                {
                    pbFotoUsuario.Image = new Bitmap(ms);
                }
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void frmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            LogOut();
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

        private void SetButtonColor(Button selectedButton)
        {
            foreach (Control control in panelContenedor.Controls)
            {
                if (control is Button button)
                {
                    button.ForeColor = (button == selectedButton) ? Color.Black : Color.Gray;
                }
            }
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            DisplayForm(frmAlmacen);
            SetButtonColor(btnAlmacen);
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            DisplayForm(frmPedidos);
            SetButtonColor(btnPedidos);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            DisplayForm(frmProveedores);
            SetButtonColor(btnProveedores);
        }

        private void btnSede_Click(object sender, EventArgs e)
        {
            DisplayForm(frmSedes);
            SetButtonColor(btnSede);
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            DisplayForm(frmContab);
            SetButtonColor(btnContabilidad);
        }

        private void btnRRHH_Click(object sender, EventArgs e)
        {
            DisplayForm(frmGestRRHH);
            SetButtonColor(btnRRHH);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            DisplayForm(frmReports);
            SetButtonColor(btnReportes);
        }

    }
}

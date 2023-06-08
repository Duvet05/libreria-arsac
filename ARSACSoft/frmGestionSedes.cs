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
    public partial class frmGestionSedes : Form
    {
        private Estado estado;
        public frmGestionSedes()
        {
            InitializeComponent();
            estado = Estado.Inicial;
            establecerEstadoFormulario();
            limpiarComponentes();


            //Para sedes
            establecerEstadoTabSedes();
            limpiarComponentesSedes();
        }

        public void establecerEstadoFormulario()
        {
            switch (estado)
            {
                case Estado.Inicial:
                    btnNuevo.Enabled = true;
                    btnModificar.Enabled = false;
                    btnCancelar.Enabled = false;
                    cboSedeEmitidora.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    txtNombreProducto.Enabled = false;
                    txtStockActual.Enabled = false;
                    txtStockBase.Enabled = false;   
                    btnBuscarProducto.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnGenerarOrden.Enabled = false;
                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnCancelar.Enabled = true;
                    cboSedeEmitidora.Enabled = true;
                    txtCantidad.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnQuitar.Enabled = true;
                    txtNombreProducto.Enabled = true;
                    txtStockActual.Enabled = true;
                    txtStockBase.Enabled = true;
                    btnBuscarProducto.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnGenerarOrden.Enabled = true;
                    break;
                case Estado.Buscar:
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = true;
                    btnCancelar.Enabled = true;
                    cboSedeEmitidora.Enabled = false;
                    txtCantidad.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnQuitar.Enabled = false;
                    txtNombreProducto.Enabled = false;
                    txtStockActual.Enabled = false;
                    txtStockBase.Enabled = false;
                    btnBuscarProducto.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnGenerarOrden.Enabled = false;
                    break;
            }
        }

        public void establecerEstadoTabSedes()
        {
            switch (estado)
            {
                case Estado.Inicial:
                    btnNuevoSede.Enabled = true;
                    btnModificarSede.Enabled = false;
                    btnCancelarSede.Enabled = false;
                    btnBuscarSede.Enabled = true;
                    btnGuardarSede.Enabled = false;

                    txtIDSede.Enabled = false;
                    txtDireccionSede.Enabled=false;
                    txtTelefonoSede.Enabled=false;
                    txtCorreoSede.Enabled=false;
                    dtpHoraFinAtencion.Enabled=false;
                    dtpHoraInicioAtencion.Enabled=false;
                    rbNoSedePrincipal.Enabled=false;
                    rbSiSedePrincipal.Enabled=false;
                    txtDescripcionSede.Enabled=false;
        
                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoSede.Enabled = false;
                    btnModificarSede.Enabled = false;
                    btnCancelarSede.Enabled = true;
                    btnBuscarSede.Enabled = false;
                    btnGuardarSede.Enabled = true;

                    txtIDSede.Enabled = true;
                    txtDireccionSede.Enabled = true;
                    txtTelefonoSede.Enabled = true;
                    txtCorreoSede.Enabled = true;
                    dtpHoraFinAtencion.Enabled = true;
                    dtpHoraInicioAtencion.Enabled = true;
                    rbNoSedePrincipal.Enabled = true;
                    rbSiSedePrincipal.Enabled = true;
                    txtDescripcionSede.Enabled = true;

                    break;
                case Estado.Buscar:
                    btnNuevoSede.Enabled = false;
                    btnModificarSede.Enabled = true;
                    btnCancelarSede.Enabled = true;
                    btnBuscarSede.Enabled = false;
                    btnGuardarSede.Enabled = false;

                    txtIDSede.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    txtTelefonoSede.Enabled = false;
                    txtCorreoSede.Enabled = false;
                    dtpHoraFinAtencion.Enabled = false;
                    dtpHoraInicioAtencion.Enabled = false;
                    rbNoSedePrincipal.Enabled = false;
                    rbSiSedePrincipal.Enabled = false;
                    txtDescripcionSede.Enabled = false;

                    break;
            }
        }

        public void limpiarComponentes()
        {
            cboSedeEmitidora.SelectedIndex = -1;
            txtNombreProducto.Text = "";
            txtStockActual.Text = "";
            txtStockBase.Text = "";
            txtCantidad.Text = "";
        }

        public void limpiarComponentesSedes()
        {
            txtIDSede.Text = string.Empty;
            txtDireccionSede.Text = string.Empty;
            txtTelefonoSede.Text = string.Empty;
            txtCorreoSede.Text = string.Empty;
            dtpHoraFinAtencion.Value = DateTime.Now;
            dtpHoraInicioAtencion.Value = DateTime.Now;
            rbNoSedePrincipal.Checked = false;
            rbSiSedePrincipal.Checked = false;
            txtDescripcionSede.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estado = Estado.Inicial;
            limpiarComponentes();
            establecerEstadoFormulario();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estado = Estado.Nuevo;
            limpiarComponentes();
            establecerEstadoFormulario();
            //empleado = new OrdenSede();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            estado = Estado.Buscar;
            establecerEstadoFormulario();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            estado = Estado.Modificar;
            establecerEstadoFormulario();
        }

        private void btnBuscarSede_Click(object sender, EventArgs e)
        {
            frmBuscarSede formBuscarSede = new frmBuscarSede();
            if (formBuscarSede.ShowDialog() == DialogResult.OK)
            {
                /*
                this.empleado = formBusqEmp.EmpleadoSeleccionado;
                txtIDEmpleado.Text = empleado.IdPersona.ToString();
                txtNombre.Text = empleado.Nombre;
                txtApellidoPaterno.Text = empleado.ApellidoPaterno;
                txtDNI.Text = empleado.DNI;
                dtpFechaNacimiento.Value = empleado.FechaNacimiento;
                if (empleado.Genero == 'M') rbMasculino.Checked = true;
                else rbFemenino.Checked = true;
                cboArea.SelectedValue = empleado.Area.IdArea;
                txtCargo.Text = empleado.Cargo;
                txtSueldo.Text = empleado.Sueldo.ToString("N2");
                */

                //estado = Estado.Buscar;
                //establecerEstadoFormulario();
                estado = Estado.Buscar;
                establecerEstadoTabSedes();
            }
        }

        private void btnNuevoSede_Click(object sender, EventArgs e)
        {
            estado = Estado.Nuevo;
            limpiarComponentesSedes();
            establecerEstadoTabSedes();
        }

        private void btnCancelarSede_Click(object sender, EventArgs e)
        {
            estado = Estado.Inicial;
            limpiarComponentesSedes();
            establecerEstadoTabSedes();
        }

        private void btnModificarSede_Click(object sender, EventArgs e)
        {
            estado = Estado.Modificar;
            establecerEstadoTabSedes();
        }

        private void btnGuardarSede_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto formBusqProd = new frmBuscarProducto();
            if (formBusqProd.ShowDialog() == DialogResult.OK)
            {
                /*
                _producto = formBusqProd.ProductoSeleccionado;
                txtNombreProducto.Text = _producto.Nombre + " " + _producto.UnidadMedida;
                txtCodigoProducto.Text = _producto.IdProducto.ToString();
                txtPrecioUnitario.Text = _producto.Precio.ToString("N2");
                */
            }
        }
    }
}

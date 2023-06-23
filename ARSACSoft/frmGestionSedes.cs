using ARSACSoft.AlmacenWS;
using ARSACSoft.ProductosWS;
using ARSACSoft.SedeWS;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionSedes : Form
    {
        private Estado estado;
        private SedesWSClient daoSede;
        private SedeWS.sede sede;
        private ProductosWS.producto _producto;
        private BindingList<SedeWS.sedeXProducto> _productos;
        public frmGestionSedes()
        {
            InitializeComponent();
            estado = Estado.Inicial;
            establecerEstadoFormulario();
            limpiarComponentes();


            daoSede = new SedesWSClient();
            establecerEstadoTabSedes();
            limpiarComponentesSedes();
            dgvProductos.AutoGenerateColumns = false;
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
                    //txtStockBase.Enabled = false;
                    btnBuscarProducto.Enabled = true;
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
                    //txtStockBase.Enabled = true;
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
                    //txtStockBase.Enabled = false;
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

                    txtStockProductoSede.Enabled = false;
                    txtIDSede.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    txtTelefonoSede.Enabled = false;
                    txtCorreoSede.Enabled = false;
                    //rbNoSedePrincipal.Enabled = false;
                    //rbSiSedePrincipal.Enabled = false;
                    //txtDescripcionSede.Enabled = false;

                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoSede.Enabled = false;
                    btnModificarSede.Enabled = false;
                    btnCancelarSede.Enabled = true;
                    btnBuscarSede.Enabled = false;
                    btnGuardarSede.Enabled = true;

                    txtStockProductoSede.Enabled = true;
                    txtIDSede.Enabled = true;
                    txtDireccionSede.Enabled = true;
                    txtTelefonoSede.Enabled = true;
                    txtCorreoSede.Enabled = true;
                    //rbNoSedePrincipal.Enabled = true;
                    //rbSiSedePrincipal.Enabled = true;
                    //txtDescripcionSede.Enabled = true;

                    break;
                case Estado.Buscar:
                    btnNuevoSede.Enabled = false;
                    btnModificarSede.Enabled = true;
                    btnCancelarSede.Enabled = true;
                    btnBuscarSede.Enabled = false;
                    btnGuardarSede.Enabled = false;

                    txtStockProductoSede.Enabled = false;
                    txtIDSede.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    txtTelefonoSede.Enabled = false;
                    txtCorreoSede.Enabled = false;
                    //rbNoSedePrincipal.Enabled = false;
                    //rbSiSedePrincipal.Enabled = false;
                    //txtDescripcionSede.Enabled = false;

                    break;
            }
        }

        public void limpiarComponentes()
        {
            cboSedeEmitidora.SelectedIndex = -1;
            txtNombreProducto.Text = "";
            txtStockActual.Text = "";
            txtCantidad.Text = "";
        }

        public void limpiarComponentesSedes()
        {
            txtIDSede.Text = string.Empty;
            txtDireccionSede.Text = string.Empty;
            txtTelefonoSede.Text = string.Empty;
            txtCorreoSede.Text = string.Empty;
            dgvProductos.DataSource = null;
            txtNombreProducto.Text = string.Empty;
            txtCodigoProducto.Text= string.Empty;
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
            sede = new SedeWS.sede();
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
                sede = formBuscarSede.SedeSeleccionada;
                txtIDSede.Text = sede.idSede.ToString();
                txtCorreoSede.Text = sede.correo;
                txtDireccionSede.Text = sede.direccion;
                txtTelefonoSede.Text = sede.telefono;

                _productos = new BindingList<SedeWS.sedeXProducto>(daoSede.listarProductosDeSede(sede.idSede, ""));
                dgvProductos.DataSource = _productos;

                estado = Estado.Buscar;
                establecerEstadoTabSedes();
            }
        }

        private void btnNuevoSede_Click(object sender, EventArgs e)
        {
            estado = Estado.Nuevo;
            limpiarComponentesSedes();
            establecerEstadoTabSedes();
            sede = new SedeWS.sede();
            _productos = new BindingList<SedeWS.sedeXProducto>();
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
            sede.direccion = txtDireccionSede.Text;
            sede.telefono = txtTelefonoSede.Text;
            sede.correo = txtCorreoSede.Text;
            sede.productos = _productos.ToArray();

            int resultado = 0;

            if (estado == Estado.Nuevo)
            {
                resultado = daoSede.insertarSede(sede);
            }
            else if (estado == Estado.Modificar)
            {
                resultado = daoSede.modificarSede(sede);
            }
            

            if (resultado != 0)
            {
                MessageBox.Show("Se ha realizado la operación con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDSede.Text = resultado.ToString();
                estado = Estado.Inicial;
                establecerEstadoFormulario();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _producto = frm.ProductoSeleccionado;
                txtCodigoProducto.Text = _producto.idProducto.ToString();
                textNombreProducto.Text = _producto.nombre.ToString();
            }
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            SedeWS.sedeXProducto sxp = new SedeWS.sedeXProducto();
            sxp.producto = new SedeWS.producto();
            sxp.producto.idProducto = _producto.idProducto;
            sxp.producto.nombre = _producto.nombre;
            sxp.stock = 0;

            _productos.Add(sxp);

            dgvProductos.DataSource = _productos;

            txtCodigoProducto.Text = "";
            textNombreProducto.Text = "";

        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgvProductos.Rows[e.RowIndex].DataBoundItem is SedeWS.sedeXProducto sxp)
                {
                    dgvProductos.Rows[e.RowIndex].Cells[0].Value = sxp.producto.idProducto;
                    dgvProductos.Rows[e.RowIndex].Cells[1].Value = sxp.producto.nombre;
                    dgvProductos.Rows[e.RowIndex].Cells[2].Value = sxp.stock;
                }
                else
                {
                    // Maneja la situación en la que el elemento enlazado no es una 'sede'
                }
            }
            catch { }
        }

        private void btnQuitarProducto_Click(object sender, EventArgs e)
        {

            _productos.Remove((SedeWS.sedeXProducto)dgvProductos.CurrentRow.DataBoundItem);

            dgvProductos.DataSource = _productos;
        }


    }
}

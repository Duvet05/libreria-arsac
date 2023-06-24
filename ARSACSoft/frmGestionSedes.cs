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
        private Estado estadoTabSedes;
        private SedesWSClient daoSede;
        private SedeWS.sede sede;
        private ProductosWS.producto _producto;
        private BindingList<SedeWS.sedeXProducto> _productos;
        public frmGestionSedes()
        {
            InitializeComponent();
            estadoTabSedes = Estado.Inicial;
            limpiarComponentesTabSedes();


            daoSede = new SedesWSClient();
            establecerEstadoTabSedes();
            limpiarComponentesTabSedes();
            dgvProductosTabSede.AutoGenerateColumns = false;
        }
        /*
        public void establecerEstadoFormulario()
        {
            switch (estadoTabSedes)
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
                    btnBuscarProducto.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnGenerarOrden.Enabled = false;
                    break;
            }
        }
        */
        public void establecerEstadoTabSedes()
        {
            switch (estadoTabSedes)
            {
                case Estado.Inicial:
                    btnNuevoSede.Enabled = true;
                    btnModificarSede.Enabled = false;
                    btnCancelarSede.Enabled = false;
                    btnEliminarSede.Enabled = true;
                    btnGuardarSede.Enabled = false;
                    btnEliminarSede.Enabled = false;

                    txtIDSede.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    txtTelefonoSede.Enabled = false;
                    txtCorreoSede.Enabled = false;

                    btnAgregarProductoTabSede.Enabled = false;
                    btnQuitarProductoTabSede.Enabled=false;
                    btnBuscarProductoTabSede.Enabled = false;

                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoSede.Enabled = false;
                    btnModificarSede.Enabled = false;
                    btnCancelarSede.Enabled = true;
                    btnEliminarSede.Enabled = false;
                    btnGuardarSede.Enabled = true;
                    btnEliminarSede.Enabled = false;

                    txtIDSede.Enabled = true;
                    txtDireccionSede.Enabled = true;
                    txtTelefonoSede.Enabled = true;
                    txtCorreoSede.Enabled = true;


                    btnAgregarProductoTabSede.Enabled = true;
                    btnQuitarProductoTabSede.Enabled = true;
                    btnBuscarProductoTabSede.Enabled = true;

                    break;
                case Estado.Buscar:
                    btnNuevoSede.Enabled = false;
                    btnModificarSede.Enabled = true;
                    btnCancelarSede.Enabled = true;
                    btnEliminarSede.Enabled = false;
                    btnGuardarSede.Enabled = false;
                    btnEliminarSede.Enabled = true;

                    txtIDSede.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    txtTelefonoSede.Enabled = false;
                    txtCorreoSede.Enabled = false;

                    btnAgregarProductoTabSede.Enabled = false;
                    btnQuitarProductoTabSede.Enabled = false;
                    btnBuscarProductoTabSede.Enabled = false;


                    break;
            }
        }
        /*
        public void limpiarComponentes()
        {
            cboSedeEmitidora.SelectedIndex = -1;
            txtNombreProducto.Text = "";
            txtStockActual.Text = "";
            txtCantidad.Text = "";
        }
        */
        public void limpiarComponentesTabSedes()
        {
            txtIDSede.Text = string.Empty;
            txtDireccionSede.Text = string.Empty;
            txtTelefonoSede.Text = string.Empty;
            txtCorreoSede.Text = string.Empty;
            dgvProductosTabSede.DataSource = null;
            txtNombreProducto.Text = string.Empty;
            txtIdProductoTabSede.Text= string.Empty;
        }
        /*
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Inicial;
            limpiarComponentes();
            establecerEstadoFormulario();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Nuevo;
            limpiarComponentes();
            establecerEstadoFormulario();
            sede = new SedeWS.sede();
        }


        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Buscar;
            establecerEstadoFormulario();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Modificar;
            establecerEstadoFormulario();
        }
        */
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

                
                SedeWS.sedeXProducto[] p = daoSede.listarProductosDeSede(sede.idSede, "");
                if (p != null)
                    _productos = new BindingList<SedeWS.sedeXProducto>(p.ToList());
                else
                    _productos = new BindingList<SedeWS.sedeXProducto>();

                

                dgvProductosTabSede.DataSource = _productos;
                estadoTabSedes = Estado.Buscar;
                establecerEstadoTabSedes();
            }
        }

        private void btnNuevoSede_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Nuevo;
            limpiarComponentesTabSedes();
            establecerEstadoTabSedes();
            sede = new SedeWS.sede();
            _productos = new BindingList<SedeWS.sedeXProducto>();
        }

        private void btnCancelarSede_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Inicial;
            limpiarComponentesTabSedes();
            establecerEstadoTabSedes();
        }

        private void btnModificarSede_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Modificar;
            establecerEstadoTabSedes();
        }

        private void btnGuardarSede_Click(object sender, EventArgs e)
        {
            sede.direccion = txtDireccionSede.Text;
            sede.telefono = txtTelefonoSede.Text;
            sede.correo = txtCorreoSede.Text;
            sede.productos = _productos.ToArray();

            int resultado = 0;

            if (estadoTabSedes == Estado.Nuevo)
            {
                resultado = daoSede.insertarSede(sede);
            }
            else if (estadoTabSedes == Estado.Modificar)
            {
                daoSede.eliminarProductosDeSede(sede.idSede);
                resultado = daoSede.modificarSede(sede);
            }
            

            if (resultado != 0)
            {
                MessageBox.Show("Se ha realizado la operación con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDSede.Text = resultado.ToString();
                estadoTabSedes = Estado.Inicial;
                establecerEstadoTabSedes();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProductoTabSede_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _producto = frm.ProductoSeleccionado;
                txtIdProductoTabSede.Text = _producto.idProducto.ToString();
                txtNombreProductoTabSede.Text = _producto.nombre;
            }
        }

        private void btnAgregarProductoTabSede_Click(object sender, EventArgs e)
        {
            if (_producto == null)
                return;

            foreach (SedeWS.sedeXProducto p in _productos)
            {
                if (p.producto.idProducto == _producto.idProducto)
                    return;
            }
                

            SedeWS.sedeXProducto sxp = new SedeWS.sedeXProducto();

            sxp.producto = new SedeWS.producto();
            sxp.producto.idProducto = _producto.idProducto;
            sxp.producto.nombre = _producto.nombre;

            sxp.producto.categoria = new SedeWS.categoria();
            sxp.producto.categoria.descripcion = _producto.categoria.descripcion;

            sxp.producto.marca = new SedeWS.marca();
            sxp.producto.marca.descripcion = _producto.marca.descripcion;

            sxp.stock = 0;

            _productos.Add(sxp);

            dgvProductosTabSede.DataSource = _productos;

            txtIdProductoTabSede.Text = "";
            txtNombreProductoTabSede.Text = "";

            _producto = null;
        }

        private void btnQuitarProductoTabSede_Click(object sender, EventArgs e)
        {
            if (dgvProductosTabSede.CurrentRow.DataBoundItem == null)
                return;

            _productos.Remove((SedeWS.sedeXProducto)dgvProductosTabSede.CurrentRow.DataBoundItem);

            dgvProductosTabSede.DataSource = _productos;
        }

        private void dgvProductosTabSede_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                SedeWS.sedeXProducto sxp = (SedeWS.sedeXProducto)dgvProductosTabSede.Rows[e.RowIndex].DataBoundItem;

                dgvProductosTabSede.Rows[e.RowIndex].Cells[0].Value = sxp.producto.idProducto;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[1].Value = sxp.producto.nombre;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[2].Value = sxp.producto.categoria.descripcion;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[3].Value = sxp.producto.marca.descripcion;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[4].Value = sxp.stock;
            }
            catch { }
        }

        private void btnEliminarSede_Click(object sender, EventArgs e)
        {
            DialogResult resultadoInteraccion = MessageBox.Show("¿Está seguro de que desea eliminar a este cliente mayorista?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultadoInteraccion == DialogResult.Yes)
            {
                int resultado = daoSede.eliminarSede(sede.idSede);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoTabSedes = Estado.Inicial;
                    establecerEstadoTabSedes();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

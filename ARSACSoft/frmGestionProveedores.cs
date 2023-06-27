using ARSACSoft.AlmacenWS;
using ARSACSoft.ProductosWS;
using ARSACSoft.Properties;
using ARSACSoft.ProveedoresWS;
using ARSACSoft.RRHHWS;
using ARSACSoft.SedeWS;
using ARSACSoft.VentasWS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ARSACSoft
{
    public partial class frmGestionProveedores : Form
    {
        private Estado _estadoPagProveedor;
        private int productosIndex;
        private ProveedoresWSClient daoProveedorWS;
        private ProveedoresWS.proveedor _proveedorSeleccionado;
        private ProductosWS.producto _producto;
        private BindingList<ProveedoresWS.productoXProveedor> _productos;
        //private BindingList<productoXProveedor> _lineasOrdenDeVenta;
        private RRHHWS.empleado _empleadoLogeado;
        private ProveedoresWS.proveedor _prov;
        AlmacenWSClient daoAlmacenWS;
        public frmGestionProveedores(RRHHWS.empleado _empleadoLogeado)
        {
            InitializeComponent();

            _estadoPagProveedor = Estado.Inicial;
            establecerEstadoFormularioProveedor();

            daoProveedorWS = new ProveedoresWSClient();
            daoAlmacenWS = new AlmacenWSClient();

            this._empleadoLogeado = _empleadoLogeado;
            dgvProductos.AutoGenerateColumns = false;

            dgvOrdenesCompra.AutoGenerateColumns = false;
            rbTodos.Checked = true;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtRUC.Text == "")
            {
                MessageBox.Show("Falta el campo RUC para su registro",
                    "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNombreProveedor.Text == "")
            {
                MessageBox.Show("Falta la Razón social del proveedor para su registro",
                    "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Falta el teléfono para su registro",
                    "Mensaje de Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _prov.direccion = txtDireccion.Text;
            _prov.RUC = txtRUC.Text;
            _prov.nombre = txtNombreProveedor.Text;
            _prov.telefono = txtTelefono.Text;
            _prov.activo = true;


            int resultado = 0;

            if (_estadoPagProveedor == Estado.Nuevo)
            {
                _prov.productosXProveedor = _productos.ToArray();
                _prov.cantProductos = _prov.productosXProveedor.Length;
                resultado = daoProveedorWS.insertarProveedor(_prov);
            }
            else if (_estadoPagProveedor == Estado.Modificar)
            {
                BindingList<ProveedoresWS.productoXProveedor> productosNuevos = new BindingList<ProveedoresWS.productoXProveedor>();

                for (int i = productosIndex; i < _productos.Count; i++)
                {
                    productosNuevos.Add(_productos[i]);
                }
                _prov.productosXProveedor = productosNuevos.ToArray();
                _prov.cantProductos = _prov.productosXProveedor.Length;
                resultado = daoProveedorWS.modificarProveedor(_prov);
            }


            if (resultado != 0)
            {
                MessageBox.Show("Se ha realizado la operación con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDProveedor.Text = resultado.ToString();
                _estadoPagProveedor = Estado.Inicial;
                establecerEstadoFormularioProveedor();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            _estadoPagProveedor = Estado.Nuevo;
            LimpiarComponentes();
            establecerEstadoFormularioProveedor();
            // dgvProductos.DataSource = _productosVendedor;
            _productos = new BindingList<ProveedoresWS.productoXProveedor>();
            _prov = new ProveedoresWS.proveedor();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarProveedores frmBuscarProvee = new frmBuscarProveedores();
            if (frmBuscarProvee.ShowDialog() == DialogResult.OK)
            {
                _prov = frmBuscarProvee.ProveedorSeleccionado;
                txtIDProveedor.Text = _prov.idProveedor.ToString();
                txtDireccion.Text = _prov.direccion;
                txtNombreProveedor.Text = _prov.nombre;
                txtRUC.Text = _prov.RUC;
                txtTelefono.Text = _prov.telefono;

                ProveedoresWS.productoXProveedor[] p = daoProveedorWS.listarProductosXProveedor(string.Empty,
                -1, -1, _prov.idProveedor);
                if (p != null)
                {
                    _productos = new BindingList<ProveedoresWS.productoXProveedor>(p.ToList());
                }
                else
                    _productos = new BindingList<ProveedoresWS.productoXProveedor>();

                productosIndex = _productos.Count;

                dgvProductos.DataSource = _productos;
                _estadoPagProveedor = Estado.Buscar;
                establecerEstadoFormularioProveedor();
            }
        }
                
            

        public void establecerEstadoFormularioProveedor()
        {
            switch (_estadoPagProveedor)
            {
                case Estado.Inicial:
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnBuscar.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnModificar.Enabled = false;

                    txtDireccion.Enabled = false;
                    txtNombreProveedor.Enabled = false;
                    txtRUC.Enabled = false;
                    txtTelefono.Enabled = false;
                    txtCosto.Enabled = false;
                    //txtEstado.Enabled = false;
                    btnBuscarDirrecion.Enabled = false;
                    btnBuscarProductoTabSede.Enabled = false;
                    btnAgregarProductoTabSede.Enabled= false;
                    btnQuitarProductoTabSede.Enabled = false;
                    break;
                case Estado.Modificar:
                case Estado.Nuevo:
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnModificar.Enabled = false;

                    txtDireccion.Enabled = true;
                    txtDireccion.ReadOnly = false;
                    txtNombreProveedor.Enabled = true;
                    txtNombreProveedor.ReadOnly = false;
                    txtCosto.Enabled = true;
                    txtRUC.Enabled = true;
                    txtRUC.ReadOnly = false;
                    txtTelefono.Enabled = true;
                    txtTelefono.ReadOnly = false;
                    //txtEstado.Enabled = false;
                    //txtEstado.ReadOnly = true;
                    //dgvProductos.Rows.Clear();
                    btnBuscarDirrecion.Enabled = true;
                    btnBuscarProductoTabSede.Enabled = true;
                    btnAgregarProductoTabSede.Enabled = true;
                    btnQuitarProductoTabSede.Enabled = true;
                    break;
                case Estado.Buscar:
                    btnNuevo.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnModificar.Enabled = true;

                    txtDireccion.Enabled = false;
                    txtNombreProveedor.Enabled = false;
                    txtRUC.Enabled = false;
                    txtCosto.Enabled = false;
                    //dgvProductos.Rows.Clear();
                    txtTelefono.Enabled = false;
                    //txtEstado.Enabled = false;
                    btnBuscarDirrecion.Enabled = false;
                    btnBuscarProductoTabSede.Enabled = false;
                    btnAgregarProductoTabSede.Enabled = false;
                    btnQuitarProductoTabSede.Enabled = false;
                    break;
            }
        }

    
        public void LimpiarComponentes()
        {
            txtDireccion.Text = "";
            txtRUC.Text = "";
            txtNombreProveedor.Text = "";
            txtTelefono.Text = "";
            dgvProductos.DataSource = null;
            //txtEstado.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _estadoPagProveedor = Estado.Inicial;
            LimpiarComponentes();
            establecerEstadoFormularioProveedor();
        }

        private void btnBuscarDirrecion_Click(object sender, EventArgs e)
        {
            frmBursarDireccion frm = new frmBursarDireccion();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDireccion.Text = frm.direccionSeleccionada;
            }
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                ProveedoresWS.productoXProveedor prod = (ProveedoresWS.productoXProveedor)dgvProductos.Rows[e.RowIndex].DataBoundItem;
                dgvProductos.Rows[e.RowIndex].Cells[0].Value = prod.producto.idProducto;
                dgvProductos.Rows[e.RowIndex].Cells[1].Value = prod.producto.nombre;
                dgvProductos.Rows[e.RowIndex].Cells[2].Value = prod.producto.marca.descripcion;
                dgvProductos.Rows[e.RowIndex].Cells[3].Value = prod.producto.categoria.descripcion;

                dgvProductos.Rows[e.RowIndex].Cells[4].Value = prod.costo.ToString("N2");
                dgvProductos.Rows[e.RowIndex].Cells[4].Style.Alignment =
                    DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error en el formato de celda: " + ex.Message);
            }
        }

        private void btnBuscarProductoTabSede_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _producto = frm.ProductoSeleccionado;
                txtIdProductoTabSede.Text = _producto.idProducto.ToString();
                txtNombreProductoTabSede.Text = _producto.nombre + " " + _producto.marca.descripcion;

                btnAgregarProductoTabSede.Enabled = true;
            }
        }

        private void btnAgregarProductoTabSede_Click(object sender, EventArgs e)
        {
            if (_producto == null)
                return;

            foreach (ProveedoresWS.productoXProveedor  p in _productos)
            {
                if (p.producto.idProducto == _producto.idProducto)
                    return;
            }


            ProveedoresWS.productoXProveedor pxp = new ProveedoresWS.productoXProveedor();
            if(txtCosto.Text == "")
            {
                pxp.costo = 0;
            }
            else
            {
                pxp.costo = Double.Parse(txtCosto.Text);
            }
            pxp.producto = new ProveedoresWS.producto();
            pxp.producto.idProducto = _producto.idProducto;
            pxp.producto.nombre = _producto.nombre;

            pxp.producto.categoria = new ProveedoresWS.categoria();
            pxp.producto.categoria.descripcion = _producto.categoria.descripcion;

            pxp.producto.marca = new ProveedoresWS.marca();
            pxp.producto.marca.descripcion = _producto.marca.descripcion;

            _productos.Add(pxp);

            dgvProductos.DataSource = _productos;

            txtIdProductoTabSede.Text = "";
            txtNombreProductoTabSede.Text = "";
            txtCosto.Text = "";
            _producto = null;
        }

        private void btnQuitarProductoTabSede_Click(object sender, EventArgs e)
        {
            if (_productos.Count == 0)
                return;

            if (dgvProductos.CurrentRow.DataBoundItem == null)
                return;

            _productos.Remove((ProveedoresWS.productoXProveedor)dgvProductos.CurrentRow.DataBoundItem);

            dgvProductos.DataSource = _productos;


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _estadoPagProveedor = Estado.Modificar;
            establecerEstadoFormularioProveedor();

            btnQuitarProductoTabSede.Enabled = false;


            btnBuscar.Enabled = false;
            btnAgregarProductoTabSede.Enabled = false;
        }

        private void btnBuscarProveedorOC_Click(object sender, EventArgs e)
        {
            frmBuscarProveedores frmBuscProvee = new frmBuscarProveedores();

            if (frmBuscProvee.ShowDialog() == DialogResult.OK)
            {
                this._proveedorSeleccionado = frmBuscProvee.ProveedorSeleccionado;
                txtRUCProveedorOC.Text = _proveedorSeleccionado.RUC;
                txtRazonSocialProveedorOC.Text = _proveedorSeleccionado.nombre;
            }
        }

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            _proveedorSeleccionado = null;
            txtRUCProveedorOC.Text = "";
            txtRazonSocialProveedorOC.Text = "";
        }

        private void btnBuscarHistorialCompras_Click(object sender, EventArgs e)
        {
            //dgvOrdenesCompra.Rows.Clear();
            if (_proveedorSeleccionado == null)
            {
                string estado = rbEnProceso.Checked ? "EN PROCESO" : (rbCancelado.Checked ? "CANCELADO" : (rbRecibido.Checked ? "RECIBIDO" : "TODOS"));

                dgvOrdenesCompra.DataSource = daoAlmacenWS.listarOrdenesDeCompraXProveedor(
                    -1, dtpInicio.Value, dtpfin.Value, estado);
            }
            else
            {
                string estado = rbEnProceso.Checked ? "EN PROCESO" : (rbCancelado.Checked ? "CANCELADO" : (rbRecibido.Checked ? "RECIBIDO" : "TODOS"));

                dgvOrdenesCompra.DataSource = daoAlmacenWS.listarOrdenesDeCompraXProveedor(
                    _proveedorSeleccionado.idProveedor, dtpInicio.Value, dtpfin.Value, estado);
            }
        }

        private void dgvOrdenesCompra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            AlmacenWS.ordenDeCompra ordenCompra = (AlmacenWS.ordenDeCompra)
                dgvOrdenesCompra.Rows[e.RowIndex].DataBoundItem;
            dgvOrdenesCompra.Rows[e.RowIndex].
                Cells[0].Value = ordenCompra.idOrdenDeCompra;
            dgvOrdenesCompra.Rows[e.RowIndex].
                Cells[1].Value = ordenCompra.proveedor.nombre;
            dgvOrdenesCompra.Rows[e.RowIndex].
                Cells[2].Value = ordenCompra.fechaOrden.ToString("dd-MM-yyyy");

            dgvOrdenesCompra.Rows[e.RowIndex].
                Cells[3].Value = ordenCompra.costototal.ToString("N2");

            dgvOrdenesCompra.Rows[e.RowIndex].
                Cells[4].Value = ordenCompra.estado;
        }

        private void btnQuitarProveedor_MouseHover(object sender, EventArgs e)
        {
            lblMensajeQuitar.Text = "No filtrar por un proveedor en específico. Se mostrarán las órdenes de compra" +
                " de todos los proveedores.";
        }

        private void btnQuitarProveedor_MouseLeave(object sender, EventArgs e)
        {
            lblMensajeQuitar.Text = "";
        }
    }
    }

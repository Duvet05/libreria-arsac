using ARSACSoft.AlmacenWS;
using ARSACSoft.VentasWS;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarOrdenDeCompra : Form
    {
        ProveedoresWS.proveedor _proveedorSeleccionado = null;
        AlmacenWS.ordenDeCompra _ordenCompraSeleccionada;
        AlmacenWSClient daoAlmacenWS;

        public AlmacenWS.ordenDeCompra  OrdenCompraSeleccionada { get => _ordenCompraSeleccionada; set => _ordenCompraSeleccionada = value; }
        public ProveedoresWS.proveedor ProveedorSeleccionado { get => _proveedorSeleccionado; set => _proveedorSeleccionado = value; }
        public frmBuscarOrdenDeCompra()
        {
            InitializeComponent();
            daoAlmacenWS = new AlmacenWSClient();

            dgvOrdenesCompra.AutoGenerateColumns = false;
            rbTodos.Checked = true;
        }

        private void frmBuscarOrdenDeCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesCompra.CurrentRow != null)
            {
                _ordenCompraSeleccionada = (AlmacenWS.ordenDeCompra)
                dgvOrdenesCompra.CurrentRow.DataBoundItem;
                _ordenCompraSeleccionada.lineas
                    = daoAlmacenWS.listarLineasDeOrdenDeCompra(_ordenCompraSeleccionada.idOrdenDeCompra);
                /*Para el caso donde no seleccione un proveedor*/
                if(_proveedorSeleccionado == null)
                {
                    _proveedorSeleccionado = new ProveedoresWS.proveedor();
                    _proveedorSeleccionado.idProveedor = _ordenCompraSeleccionada.proveedor.idProveedor;
                    _proveedorSeleccionado.nombre = _ordenCompraSeleccionada.proveedor.nombre;
                }

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una orden de la tabla", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //dgvOrdenesCompra.Rows.Clear();
            if(_proveedorSeleccionado == null)
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

        private void dgvOrdenesCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOrdenesCompra_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ordenDeCompra ordenCompra = (ordenDeCompra)
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

            dgvOrdenesCompra.Rows[e.RowIndex].Cells[0].Style.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvOrdenesCompra.Rows[e.RowIndex].Cells[1].Style.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvOrdenesCompra.Rows[e.RowIndex].Cells[2].Style.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvOrdenesCompra.Rows[e.RowIndex].Cells[3].Style.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvOrdenesCompra.Rows[e.RowIndex].Cells[4].Style.Alignment =
                DataGridViewContentAlignment.MiddleRight;

        }

        private void btnBorrarProveedor_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitarProveedor_Click(object sender, EventArgs e)
        {
            _proveedorSeleccionado = null;
            txtRUCProveedorOC.Text = "";
            txtRazonSocialProveedorOC.Text = "";
        }
    }
}

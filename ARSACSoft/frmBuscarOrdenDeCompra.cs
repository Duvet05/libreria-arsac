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

        public ProveedoresWS.proveedor ProveedorSeleccionado { get => _proveedorSeleccionado; set => _proveedorSeleccionado = value; }
        public frmBuscarOrdenDeCompra()
        {
            InitializeComponent();
            daoAlmacenWS = new AlmacenWSClient();

            //dgvOrdenesCompra.AutoGenerateColumns = false;
        }

        private void frmBuscarOrdenDeCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            _ordenCompraSeleccionada = (AlmacenWS.ordenDeCompra)
                dgvOrdenesCompra.CurrentRow.DataBoundItem;
            _ordenCompraSeleccionada.lineas
                = daoAlmacenWS.listarLineasDeOrdenDeCompra(_ordenCompraSeleccionada.idOrdenDeCompra);
            this.DialogResult = DialogResult.OK;
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
            string estado = rbEnProceso.Checked ? "EN PROCESO" : (rbCancelado.Checked ? "CANCELADO" : "RECIBIDO");
            dgvOrdenesCompra.DataSource = daoAlmacenWS.listarOrdenesDeCompraXProveedor(
                
                _proveedorSeleccionado.idProveedor, dtpInicio.Value, dtpfin.Value, estado);
        }

        private void dgvOrdenesCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

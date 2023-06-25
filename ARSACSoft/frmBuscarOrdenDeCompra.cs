using ARSACSoft.VentasWS;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarOrdenDeCompra : Form
    {
        ProveedoresWS.proveedor _proveedorSeleccionado = null;

        public ProveedoresWS.proveedor ProveedorSeleccionado { get => _proveedorSeleccionado; set => _proveedorSeleccionado = value; }
        public frmBuscarOrdenDeCompra()
        {
            InitializeComponent();
        }

        private void frmBuscarOrdenDeCompra_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //_ordenVentaSeleccionada = (ordenVenta)
            //    dgvOrdenesVenta.CurrentRow.DataBoundItem;
            //_ordenVentaSeleccionada.lineasOrdenVenta
            //    = _daoLogistica.listarLineasOrdenVentaPorIdOrdenVenta
            //    (_ordenVentaSeleccionada.idOrdenVenta);
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
            //dgvOrdenesCompra.DataSource = _daoLogistica.listarOrdenesVentaPorIDNombreDNICliente(txtBusqueda.Text);
        }
    }
}

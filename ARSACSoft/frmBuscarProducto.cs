using ARSACSoft.ProductosWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProducto : Form
    {
        private ProductosWS.producto _productoSeleccionado;
        private ProductosWSClient daoProductosWS;

        public ProductosWS.producto ProductoSeleccionado { get => _productoSeleccionado; set => _productoSeleccionado = value; }
        public frmBuscarProducto()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;

            daoProductosWS = new ProductosWSClient();
            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = daoProductosWS.listarCategoriasTodas();

            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = daoProductosWS.listarMarcaTodas();

            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ProductoSeleccionado = (ProductosWS.producto)dgvProductos.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvProductos.DataSource = daoProductosWS.listarProductosXNombre(txtNombreProd.Text);
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ProductosWS.producto prod= (ProductosWS.producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
            dgvProductos.Rows[e.RowIndex].Cells[0].Value =
                prod.nombre;
            dgvProductos.Rows[e.RowIndex].Cells[1].Value =
                prod.marca.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[2].Value =
                prod.categoria.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[3].Value =
                prod.precioPorMenor;
            dgvProductos.Rows[e.RowIndex].Cells[4].Value =
                prod.precioPorMayor;
        }
    }
}

using ARSACSoft.ProductosWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProducto : Form
    {
        private ProductosWS.producto _productoSeleccionado;
        private ProductosWSClient daoProductosWS;

        public ProductosWS.producto ProductoSeleccionado
        {
            get => _productoSeleccionado;
            set => _productoSeleccionado = value;
        }

        public frmBuscarProducto()
        {
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;

            daoProductosWS = new ProductosWSClient();
            CargarCategorias();
            CargarMarcas();

            txtNombreProd.Text = string.Empty;
            dgvProductos.DataSource = daoProductosWS.listarProductosXNombreXCategoriaXMarca(txtNombreProd.Text, -1, -1);
        }

        private void CargarCategorias()
        {
            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = daoProductosWS.listarCategoriasTodas();
            cboCategoria.SelectedIndex = -1;
        }

        private void CargarMarcas()
        {
            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = daoProductosWS.listarMarcaTodas();
            cboMarca.SelectedIndex = -1;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                ProductoSeleccionado = (ProductosWS.producto)dgvProductos.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int categoriaSeleccionada = cboCategoria.SelectedValue != null ? (int)cboCategoria.SelectedValue : -1;
            int marcaSeleccionada = cboMarca.SelectedValue != null ? (int)cboMarca.SelectedValue : -1;

            dgvProductos.DataSource = daoProductosWS.listarProductosXNombreXCategoriaXMarca(txtNombreProd.Text, categoriaSeleccionada, marcaSeleccionada);
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvProductos.Rows.Count)
                return;

            ProductosWS.producto prod = (ProductosWS.producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
            dgvProductos.Rows[e.RowIndex].Cells[0].Value = prod.nombre;
            dgvProductos.Rows[e.RowIndex].Cells[1].Value = prod.marca.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[2].Value = prod.categoria.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[3].Value = prod.precioPorMenor;
            dgvProductos.Rows[e.RowIndex].Cells[4].Value = prod.precioPorMayor;
        }
    }
}

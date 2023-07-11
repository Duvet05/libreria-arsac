using ARSACSoft.ProductosWS;
using ARSACSoft.SedeWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProductoXSedeVenta : Form
    {
        private ProductosWS.producto _productoSede;
        private ProductosWSClient daoProductosWS;
        private int _sede;
        public ProductosWS.producto ProductoSeleccionado
        {
            get => _productoSede;
            set => _productoSede = value;
        }

        public frmBuscarProductoXSedeVenta(int idSede)
        {
            _sede = idSede;
            InitializeComponent();
            dgvProductos.AutoGenerateColumns = false;
            daoProductosWS = new ProductosWSClient();
            CargarCategorias();
            CargarMarcas();
            txtIdSede.Text = idSede.ToString();
            txtNombreProd.Text = string.Empty;
            dgvProductos.DataSource = daoProductosWS.listarProductosXSede(txtNombreProd.Text, _sede, -1, -1);

            dgvProductos.SelectionChanged -= dgvProductos_SelectionChanged; // Remover el evento dgvProductos_SelectionChanged
            dgvProductos.ClearSelection();
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        }

        private void CargarCategorias()
        {
            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = daoProductosWS.listarCategoriasTodas();
            cboCategoria.SelectedIndex = 0;
        }

        private void CargarMarcas()
        {
            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = daoProductosWS.listarMarcaTodas();
            cboMarca.SelectedIndex = 0;
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

            dgvProductos.DataSource = daoProductosWS.listarProductosXSede(txtNombreProd.Text, _sede, categoriaSeleccionada, marcaSeleccionada);
            dgvProductos.ClearSelection();
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
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
            dgvProductos.Rows[e.RowIndex].Cells[5].Value = prod.stockTmp;  
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                ProductoSeleccionado = (ProductosWS.producto)dgvProductos.CurrentRow.DataBoundItem;
                //txtNombreProd.Text = ProductoSeleccionado.nombre;
                cboMarca.SelectedValue = ProductoSeleccionado.marca.idMarca;
                cboCategoria.SelectedValue = ProductoSeleccionado.categoria.idCategoria;
            }
        }

    }
}
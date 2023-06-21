using ARSACSoft.ProductosWS;
using ARSACSoft.ProveedoresWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProductoXProveedor : Form
    {
        ProductosWSClient daoProductosWS;
        proveedor _proveedorSeleccionado;
        public frmBuscarProductoXProveedor(proveedor _proveedorSeleccionado)
        {
            InitializeComponent();
            this._proveedorSeleccionado = _proveedorSeleccionado;

            txtProveedor.Text = _proveedorSeleccionado.nombre;

            daoProductosWS = new ProductosWSClient();
            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = daoProductosWS.listarCategoriasTodas();

            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = daoProductosWS.listarMarcaTodas();

            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtNombreProd.Text = string.Empty;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            ProductosWS.producto prod = (ProductosWS.producto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
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
            //dgvProductos.Rows[e.RowIndex].Cells[5].Value = "costo";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int categoriaSeleccionada = cboCategoria.SelectedValue != null ? (int)cboCategoria.SelectedValue : -1;
            int marcaSeleccionada = cboMarca.SelectedValue != null ? (int)cboMarca.SelectedValue : -1;

            dgvProductos.DataSource = daoProductosWS.listarProductosXNombreXCategoriaXMarca(txtNombreProd.Text, categoriaSeleccionada, marcaSeleccionada);

        }
    }
}

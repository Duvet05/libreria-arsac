using ARSACSoft.ProductosWS;
using ARSACSoft.ProveedoresWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProductoXProveedor : Form
    {
        ProductosWSClient daoProductosWS;
        ProveedoresWSClient daoProveedoresWS;
        proveedor _proveedorSeleccionado;
        productoXProveedor _productoDeProveedorSeleccionado;
        public ProveedoresWS.productoXProveedor ProductoDeProveedorSeleccionado { get => _productoDeProveedorSeleccionado; set => _productoDeProveedorSeleccionado = value; }
        public frmBuscarProductoXProveedor(proveedor _proveedorSeleccionado)
        {
            InitializeComponent();
            this._proveedorSeleccionado = _proveedorSeleccionado;

            txtProveedor.Text = _proveedorSeleccionado.nombre;

            daoProductosWS = new ProductosWSClient();
            daoProveedoresWS = new ProveedoresWSClient();
            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = daoProductosWS.listarCategoriasTodas();

            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = daoProductosWS.listarMarcaTodas();

            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtNombreProd.Text = string.Empty;
            dgvProductos.AutoGenerateColumns = false;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            ProveedoresWS.productoXProveedor prod = (ProveedoresWS.productoXProveedor)dgvProductos.Rows[e.RowIndex].DataBoundItem;
            dgvProductos.Rows[e.RowIndex].Cells[0].Value =
                prod.producto.idProducto;
            dgvProductos.Rows[e.RowIndex].Cells[1].Value =
                prod.producto.nombre;
            dgvProductos.Rows[e.RowIndex].Cells[2].Value =
                prod.producto.marca.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[3].Value =
                prod.producto.categoria.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[4].Value =
                prod.producto.precioPorMenor;
            dgvProductos.Rows[e.RowIndex].Cells[5].Value =
                prod.producto.precioPorMayor;
            dgvProductos.Rows[e.RowIndex].Cells[6].Value =
                prod.costo;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int categoriaSeleccionada = cboCategoria.SelectedValue != null ? (int)cboCategoria.SelectedValue : -1;
            int marcaSeleccionada = cboMarca.SelectedValue != null ? (int)cboMarca.SelectedValue : -1;

            dgvProductos.DataSource = daoProveedoresWS.listarProductosXProveedor(txtNombreProd.Text, 
                categoriaSeleccionada, marcaSeleccionada, _proveedorSeleccionado.idProveedor);
            //MessageBox.Show("Producto seleccionado: Marca = " + cboMarca.SelectedValue + ", Categoria: " + cboCategoria.SelectedValue, "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            ProductoDeProveedorSeleccionado = (ProveedoresWS.productoXProveedor)dgvProductos.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }
    }
}

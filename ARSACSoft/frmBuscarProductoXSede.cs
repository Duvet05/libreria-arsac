using ARSACSoft.ProductosWS;
using ARSACSoft.SedeWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProductoXSede : Form
    {
        private SedesWSClient _daoSede;
        private ProductosWSClient _daoProducto;
        private sede _sedeSeleccionada;
        private sedeXProducto _productoDeSedeSeleccionada;

        public sedeXProducto ProductoDeSedeSeleccionada { get => _productoDeSedeSeleccionada; set => _productoDeSedeSeleccionada = value; }

        public frmBuscarProductoXSede(sede sedeSeleccionada)
        {
            InitializeComponent();

            this._sedeSeleccionada = sedeSeleccionada;
            txtDireccionDeSede.Text = _sedeSeleccionada.direccion;

            _daoProducto = new ProductosWSClient();
            _daoSede = new SedesWSClient();

            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = _daoProducto.listarCategoriasTodas();

            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = _daoProducto.listarMarcaTodas();

            cboCategoria.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtNombreProducto.Text = string.Empty;
            dgvProductos.AutoGenerateColumns = false;
        }

        private void dgvProductos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            sedeXProducto prod = (sedeXProducto)dgvProductos.Rows[e.RowIndex].DataBoundItem;
            dgvProductos.Rows[e.RowIndex].Cells[0].Value =
                prod.producto.idProducto;
            dgvProductos.Rows[e.RowIndex].Cells[1].Value =
                prod.producto.nombre;
            dgvProductos.Rows[e.RowIndex].Cells[2].Value =
                prod.producto.marca.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[3].Value =
                prod.producto.categoria.descripcion;
            dgvProductos.Rows[e.RowIndex].Cells[4].Value =
                prod.stock;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int categoriaSeleccionada = cboCategoria.SelectedValue != null ? (int)cboCategoria.SelectedValue : -1;
            int marcaSeleccionada = cboMarca.SelectedValue != null ? (int)cboMarca.SelectedValue : -1;

            dgvProductos.DataSource = _daoSede.listarProductosDeSedePorNombreMarcaCategoria(_sedeSeleccionada.idSede,txtNombreProducto.Text,
                                        marcaSeleccionada,categoriaSeleccionada);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem is sedeXProducto)
            {
                _productoDeSedeSeleccionada = (sedeXProducto)dgvProductos.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null)
            {
                ProductoDeSedeSeleccionada = (sedeXProducto)dgvProductos.CurrentRow.DataBoundItem;
                txtNombreProducto.Text = ProductoDeSedeSeleccionada.producto.nombre;
                cboMarca.SelectedValue = ProductoDeSedeSeleccionada.producto.marca.idMarca;
                cboCategoria.SelectedValue = ProductoDeSedeSeleccionada.producto.categoria.idCategoria;
            }
        }
    }
}

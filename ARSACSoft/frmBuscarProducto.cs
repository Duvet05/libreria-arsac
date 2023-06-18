using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmBuscarProducto : Form
    {
        //private ProductoDAO daoProducto;
        //private Producto _productoSeleccionado;
        public frmBuscarProducto()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            //ProductoSeleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
        }
    }
}

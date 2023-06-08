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
    public partial class frmGestionAlmacen : Form
    {
        //private Estado _estado;
        private string _rutaFotoLocal;
        public frmGestionAlmacen()
        {
            InitializeComponent();
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdImagenProducto.ShowDialog() == DialogResult.OK)
                {
                    _rutaFotoLocal = ofdImagenProducto.FileName;
                    pbFoto.Image = Image.FromFile(_rutaFotoLocal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void lblAforo_MouseHover(object sender, EventArgs e)
        {
            lblNotificacion.Text = "Stock mínimo que debería haber del producto en almacén";
        }

        private void lblAforo_MouseLeave(object sender, EventArgs e)
        {
            lblNotificacion.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frmBuscProd = new frmBuscarProducto();

            if (frmBuscProd.ShowDialog() == DialogResult.OK)
            {
                /*
                _producto = formBusqProd.ProductoSeleccionado;
                txtNombreProducto.Text = _producto.Nombre + " " + _producto.UnidadMedida;
                txtCodigoProducto.Text = _producto.IdProducto.ToString();
                txtPrecioUnitario.Text = _producto.Precio.ToString("N2");
                */
            }

        }

        private void tpProductos_Click(object sender, EventArgs e)
        {

        }

        private void dgvListaLotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void tpPromociones_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {

        }
    }
}

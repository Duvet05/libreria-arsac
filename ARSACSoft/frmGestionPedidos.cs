using ARSACSoft.ProductosWS;
using ARSACSoft.RRHHWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionPedidos : Form
    {
        private ProductosWS.producto _producto;
        private RRHHWS.clienteMayorista _clienteMayorista;
        public frmGestionPedidos()
        {
            InitializeComponent();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombreCliente_Click(object sender, EventArgs e)
        {

        }

        private void gbProveedor_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _producto = frm.ProductoSeleccionado;
                textNombreProducto.Text = _producto.nombre.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBuscarClienteMayorista frm = new frmBuscarClienteMayorista();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _clienteMayorista = frm.ClienteMayoristaSeleccionado;
                txtNombreCompleto.Text = _clienteMayorista.nombre + " " + _clienteMayorista.apellidos;
                txtRazonSocial.Text = _clienteMayorista.razonSocial;
                txtRUC.Text = _clienteMayorista.RUC;

            }
        }
    }
}

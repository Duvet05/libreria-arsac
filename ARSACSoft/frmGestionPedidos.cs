using ARSACSoft.ProductosWS;
using ARSACSoft.RRHHWS;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionPedidos : Form
    {
        private ProductosWS.producto _producto;
        private Estado estado;
        private RRHHWS.clienteMayorista _clienteMayorista;
        public frmGestionPedidos()
        {
            InitializeComponent();
            estado = Estado.Inicial;
            establecerEstadoFormulario();
            limpiarComponentes();
        }


        public void establecerEstadoFormulario()
        {
            switch (estado)
            {
                case Estado.Inicial:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnBuscarPedido.Enabled = true;
                    btnGuardar.Enabled = false;
                    textNombreProducto.Enabled = false;
                    btnBuscarProd.Enabled = false;
                    textDescuentoPorcentaje.Enabled = false;
                    textMonto.Enabled = false;
                    txtIGV.Enabled = false;
                    textDescontadoTotal.Enabled = false;
                    textCantProducto.Enabled = false;
                    btPedido.Enabled = false;
                    txtNombreCompleto.Enabled = false;
                    checkBoxFactura.Enabled = false;
                    checkBoxDescuento.Enabled = false;
                    dataGridView2.Enabled = false;
                    textPrecioUni.Enabled = false;
                    textCantidad.Enabled = false;
                    textSubTotal.Enabled = false;
                    btnCliente.Enabled = false;
                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnBuscarPedido.Enabled = false;
                    btnGuardar.Enabled = true;
                    textNombreProducto.Enabled = true;
                    btnBuscarProd.Enabled = true;
                    textDescuentoPorcentaje.Enabled = true;
                    textMonto.Enabled = true;
                    txtIGV.Enabled = true;
                    textDescontadoTotal.Enabled = true;
                    textCantProducto.Enabled = true;
                    btPedido.Enabled = true;
                    txtNombreCompleto.Enabled = true;
                    checkBoxFactura.Enabled = true;
                    checkBoxDescuento.Enabled = true;
                    dataGridView2.Enabled = true;
                    textPrecioUni.Enabled = true;
                    textCantidad.Enabled = true;
                    textSubTotal.Enabled = true;
                    btnCliente.Enabled = true;
                    break;
                case Estado.Buscar:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnBuscarPedido.Enabled = false;
                    btnGuardar.Enabled = false;
                    textNombreProducto.Enabled = false;
                    btnBuscarProd.Enabled = false;
                    textDescuentoPorcentaje.Enabled = false;
                    textMonto.Enabled = false;
                    txtIGV.Enabled = false;
                    textDescontadoTotal.Enabled = false;
                    textCantProducto.Enabled = false;
                    btPedido.Enabled = false;
                    txtNombreCompleto.Enabled = false;
                    checkBoxFactura.Enabled = false;
                    checkBoxDescuento.Enabled = false;
                    dataGridView2.Enabled = false;
                    textPrecioUni.Enabled = false;
                    textCantidad.Enabled = false;
                    textSubTotal.Enabled = false;
                    btnCliente.Enabled = false;
                    break;
            }
        }


        public void limpiarComponentes()
        {
            // Limpiar componentes de gbProveedor
            txtRazonSocial.Text = "";
            txtRUC.Text = "";

            // Limpiar componentes de groupBox1
            textNombreProducto.Text = "";

            // Limpiar componentes de groupBox3
            dateFechaEntrega.Value = DateTime.Now;
            textMonto.Text = "";

            // Limpiar componentes de groupBox2
            txtIGV.Text = "";
            textDescontadoTotal.Text = "";

            // Limpiar componentes generales
            txtNombreCompleto.Text = "";
            checkBoxFactura.Checked = false;
            checkBoxDescuento.Checked = false;

            // Limpiar componentes del DataGridView (dataGridView2)
            dataGridView2.Rows.Clear();

            // Limpiar componentes adicionales
            textPrecioUni.Text = "";
            textCantidad.Text = "";
            textSubTotal.Text = "";
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


        private void checkBoxFactura_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente(object sender, EventArgs e)
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estado = Estado.Inicial;
            limpiarComponentes();
            establecerEstadoFormulario();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estado = Estado.Nuevo;
            limpiarComponentes();
            establecerEstadoFormulario();
        }


        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            estado = Estado.Buscar;
            establecerEstadoFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            estado = Estado.Inicial;
            establecerEstadoFormulario();
        }
    }
}

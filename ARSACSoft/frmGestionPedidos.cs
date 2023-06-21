using ARSACSoft.ProductosWS;
using ARSACSoft.RRHHWS;
using GMap.NET.Internals;
using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionPedidos : Form
    {
        private ProductosWS.producto _producto;
        private Estado estado;
        private clienteMayorista _clienteMayorista;

        public frmGestionPedidos()
        {
            InitializeComponent();
            estado = Estado.Inicial;
            EstablecerEstadoFormulario();
            LimpiarComponentes();
        }

        public void EstablecerEstadoFormulario()
        {
            switch (estado)
            {
                case Estado.Inicial:
                    btnNuevo.Enabled = true;
                    btnCancelar.Enabled = false;
                    btnBuscarPedido.Enabled = true;
                    AgregarCliente.Enabled = false;
                    btnGuardar.Enabled = false;
                    btnAgregar.Enabled = false;
                    BtnQuitar.Enabled = false;
                    textNombreProducto.Enabled = false;
                    btnBuscarProd.Enabled = false;
                    textDescuentoPorcentaje.Enabled = false;
                    textMonto.Enabled = false;
                    txtIGV.Enabled = false;
                    textDescontadoTotal.Enabled = false;
                    textCantProducto.Enabled = false;
                    txtRUC.Enabled = false;
                    btPedido.Enabled = false;
                    txtNombreCompleto.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    checkBoxFactura.Enabled = false;
                    checkBoxDescuento.Enabled = false;
                    dataGridView2.Enabled = false;
                    textPrecioUni.Enabled = false;
                    textCantidad.Enabled = false;
                    textSubTotal.Enabled = false;
                    btnCliente.Enabled = false;
                    break;
                case Estado.Nuevo:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = true;
                    BtnQuitar.Enabled = true;
                    btnBuscarPedido.Enabled = false;
                    btnGuardar.Enabled = true;
                    textNombreProducto.Enabled = true;
                    btnBuscarProd.Enabled = true;
                    textMonto.Enabled = true;
                    txtIGV.Enabled = true;
                    textDescontadoTotal.Enabled = true;
                    textCantProducto.Enabled = true;
                    btPedido.Enabled = true;
                    checkBoxFactura.Enabled = true;
                    checkBoxDescuento.Enabled = true;
                    dataGridView2.Enabled = true;
                    textPrecioUni.Enabled = true;
                    textCantidad.Enabled = true;
                    textSubTotal.Enabled = true;
                    break;
                case Estado.Buscar:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = false;
                    BtnQuitar.Enabled = false;
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
                    txtRazonSocial.Enabled = false;
                    txtRUC.Enabled = false;
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
        private void checkBoxFactura_CheckedChanged(object sender, EventArgs e)
        {
            bool facturaChecked = checkBoxFactura.Checked;
            txtRUC.Enabled = facturaChecked;
            txtRazonSocial.Enabled = facturaChecked;
            txtNombreCompleto.Enabled = facturaChecked;
            btnCliente.Enabled = facturaChecked;
            AgregarCliente.Enabled = facturaChecked;
        }

        private void checkBoxDescuento_CheckedChanged(object sender, EventArgs e)
        {
            bool facturaChecked = checkBoxDescuento.Checked;
            textDescuentoPorcentaje.Enabled = facturaChecked;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
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



        public void LimpiarComponentes()
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

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _producto = frm.ProductoSeleccionado;
                textNombreProducto.Text = _producto.nombre.ToString();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estado = Estado.Inicial;
            LimpiarComponentes();
            EstablecerEstadoFormulario();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            estado = Estado.Nuevo;
            LimpiarComponentes();
            EstablecerEstadoFormulario();
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            estado = Estado.Buscar;
            EstablecerEstadoFormulario();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            estado = Estado.Inicial;
            EstablecerEstadoFormulario();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Evento sin implementación actualmente
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            // Evento sin implementación actualmente
        }

        private void AgregarCliente_Click(object sender, EventArgs e)
        {
            frmCrearCliente frm = new frmCrearCliente();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _clienteMayorista = frm.ClienteMayoristaSeleccionado;
                txtNombreCompleto.Text = _clienteMayorista.nombre + " " + _clienteMayorista.apellidos;
            }
        }
    }
}

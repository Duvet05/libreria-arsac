using ARSACSoft.VentasWS;
using GMap.NET.Internals;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionPedidos : Form
    {
        private ProductosWS.producto _producto;
        private VentasWS.ordenDeVenta _venta;
        private Estado estado;
        private RRHHWS.clienteMayorista _clienteMayorista;
        private BindingList<lineaDeOrdenDeVenta> _lineasOrdenDeVenta;
        private VentasWSClient daoVentas;
        private int _id_sede;
        private int _id_empleado;

        public frmGestionPedidos(RRHHWS.empleado _empleadoLogeado)
        {
            _id_empleado = _empleadoLogeado.idPersona;
            _id_sede = _empleadoLogeado.sede.idSede;
            InitializeComponent();

            estado = Estado.Inicial;
            EstablecerEstadoFormulario();
            LimpiarComponentes();

            _venta = new ordenDeVenta();
            _venta.precioTotal = 0;

            dataGridView2.AutoGenerateColumns = false;
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
                    dateFechaEntrega.Enabled = false;
                    btnAgregar.Enabled = false;
                    BtnQuitar.Enabled = false;
                    textNombreProducto.Enabled = false;
                    btCorreo.Enabled = false;
                    btnBuscarProd.Enabled = false;
                    textDescuentoPorcentaje.Enabled = false;
                    textMonto.Enabled = false;
                    txtIGV.Enabled = false;
                    textDescontadoTotal.Enabled = false;
                    textCantProducto.Enabled = false;
                    txtRUC.Enabled = false;
                    btPedido.Enabled = false;
                    btnBuscarDireccion.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtNombreCompleto.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    checkBoxFactura.Enabled = false;
                    checkBoxDescuento.Enabled = false;
                    dataGridView2.Enabled = false;
                    textPrecioUni.Enabled = false;
                    textCantidad.Enabled = false;
                    textCantProducto.Enabled = false;
                    textSubTotal.Enabled = false;
                    btnCliente.Enabled = false;
                    break;
                case Estado.Nuevo:
                    btnNuevo.Enabled = false;
                    btCorreo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = true;
                    BtnQuitar.Enabled = true;
                    btnBuscarPedido.Enabled = false;
                    textNombreProducto.Enabled = true;
                    textCantProducto.Enabled = true;
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
                    textCantProducto.Enabled = false;
                    BtnQuitar.Enabled = false;
                    btnBuscarPedido.Enabled = false;
                    btnBuscarDireccion.Enabled = false;
                    textNombreProducto.Enabled = false;
                    btnBuscarProd.Enabled = false;
                    textDescuentoPorcentaje.Enabled = false;
                    textMonto.Enabled = false;
                    txtIGV.Enabled = false;
                    textDescontadoTotal.Enabled = false;
                    textCantProducto.Enabled = false;
                    btPedido.Enabled = false;
                    txtDireccion.Enabled = false;
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
            txtDireccion.Enabled = facturaChecked;
            dateFechaEntrega.Enabled = facturaChecked;
            btnBuscarDireccion.Enabled = facturaChecked;
            if (!facturaChecked)
            {
                txtRUC.Text = string.Empty;
                txtDireccion.Text = string.Empty;
                dateFechaEntrega.Value = DateTime.Now;
                txtRazonSocial.Text = string.Empty;
                txtNombreCompleto.Text = string.Empty; // Limpia el contenido del campo de factura
            }
        }

        private void checkBoxDescuento_CheckedChanged(object sender, EventArgs e)
        {
            bool descuentoChecked = checkBoxDescuento.Checked;
            textDescuentoPorcentaje.Enabled = descuentoChecked;
            if (!descuentoChecked)
            {
                textDescuentoPorcentaje.Text = string.Empty; // Limpia el contenido del campo de descuento
            }
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
                txtDireccion.Text = _clienteMayorista.direccion;
            }
        }

        public void LimpiarComponentes()
        {
            txtRazonSocial.Text = "";
            txtRUC.Text = "";
            textNombreProducto.Text = "";
            dateFechaEntrega.Value = DateTime.Now;
            textMonto.Text = "";
            txtIGV.Text = "";
            textDescontadoTotal.Text = "";
            txtNombreCompleto.Text = "";
            checkBoxFactura.Checked = false;
            checkBoxDescuento.Checked = false;
            dataGridView2.Rows.Clear();
            textPrecioUni.Text = "";
            textCantidad.Text = "";
            textSubTotal.Text = "";
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProductoXSedeVenta frm = new frmBuscarProductoXSedeVenta(_id_sede);
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
            daoVentas = new VentasWSClient();
            _lineasOrdenDeVenta = new BindingList<lineaDeOrdenDeVenta>();
            dataGridView2.DataSource = _lineasOrdenDeVenta;
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            estado = Estado.Buscar;
            EstablecerEstadoFormulario();

        }
        //falta agregar funcion para modificar 
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textNombreProducto.Text))
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textCantProducto.Text) || int.Parse(textCantProducto.Text.Trim()) == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            //verificar stock en sede
            foreach (lineaDeOrdenDeVenta linea in this._lineasOrdenDeVenta)
            {
                if (linea.producto.idProducto.Equals(_producto.idProducto))
                {
                    linea.cantidad += Int32.Parse(textCantProducto.Text);
                    linea.descuento = Double.Parse(textDescuentoPorcentaje.Text); // Actualizar subtotal
                    UpdateTextBoxes();
                    return;
                }
            }

            lineaDeOrdenDeVenta lov = new lineaDeOrdenDeVenta();
            lov.producto = new VentasWS.producto();
            lov.producto.idProducto = _producto.idProducto;
            lov.producto.nombre = _producto.nombre;
            lov.cantidad = Int32.Parse(textCantProducto.Text);
            lov.precio = _producto.precioPorMenor;

            if (Double.TryParse(textDescuentoPorcentaje.Text, out double descuento))
            {
                lov.descuento = descuento;
            }
            else
            {
                lov.descuento = 0.0;
            }
            _lineasOrdenDeVenta.Add(lov);
            UpdateTextBoxes();
        }


        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView2.SelectedRows[0].Index;
                textNombreProducto.Text = "";
                textDescuentoPorcentaje.Text = "";
                _lineasOrdenDeVenta.RemoveAt(rowIndex);
                UpdateTextBoxes();
            }
        }

        public void UpdateTextBoxes()
        {
            dataGridView2.Refresh();

            // Actualizar los valores de los TextBox relevantes en función de los cambios en _lineasOrdenDeVenta
            double total = 0;
            double descuentoTotal = 0;
            
            textCantProducto.Text = "";
            foreach (lineaDeOrdenDeVenta linea in _lineasOrdenDeVenta)
            {
                if (linea.producto.idProducto.Equals(_producto.idProducto))
                {
                    textPrecioUni.Text = (linea.precio - linea.precio * (linea.descuento / 100)).ToString("N2");
                    textCantidad.Text = linea.cantidad.ToString();
                    textSubTotal.Text = (linea.precio * linea.cantidad).ToString("N2");
                    descuentoTotal += (linea.precio * linea.cantidad * (linea.descuento / 100));
                    total += (linea.precio * linea.cantidad);
                }
            }

            // Calcular el IGV y el monto total
            double igv = total * 0.18;
            double montoTotal = total + igv - descuentoTotal;

            txtIGV.Text = igv.ToString("N2");
            textDescontadoTotal.Text = descuentoTotal.ToString("N2");
            textMonto.Text = montoTotal.ToString("N2");
        }

        private void AgregarCliente_Click(object sender, EventArgs e)
        {
            frmCrearCliente frm = new frmCrearCliente();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _clienteMayorista = frm.ClienteMayoristaSeleccionado;
                txtNombreCompleto.Text = _clienteMayorista.nombre + " " + _clienteMayorista.apellidos;
                txtRazonSocial.Text = _clienteMayorista.razonSocial;
                txtRUC.Text = _clienteMayorista.RUC;
                txtDireccion.Text = _clienteMayorista.direccion;
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                // Obtener los valores de precio y cantidad de la línea seleccionada
                double precio = Convert.ToDouble(selectedRow.Cells["Column4"].Value);
                int cantidad = Convert.ToInt32(selectedRow.Cells["Column3"].Value);

                // Asignar los valores a los TextBox correspondientes
                textPrecioUni.Text = precio.ToString();
                textCantidad.Text = cantidad.ToString();
                textSubTotal.Text = (cantidad * precio).ToString("N2");
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _lineasOrdenDeVenta.Count)
            {
                lineaDeOrdenDeVenta lov = _lineasOrdenDeVenta[e.RowIndex];

                if (e.ColumnIndex == 0)
                {
                    e.Value = lov.producto.idProducto.ToString();
                }
                else if (e.ColumnIndex == 1)
                {
                    e.Value = lov.producto.nombre;
                }
                else if (e.ColumnIndex == 2)
                {
                    e.Value = lov.cantidad.ToString();
                }
                else if (e.ColumnIndex == 3)
                {
                    e.Value = lov.precio.ToString("N2");
                }
                else if (e.ColumnIndex == 4)
                {
                    e.Value = lov.descuento.ToString("N2");
                }
                else if (e.ColumnIndex == 5)
                {
                    e.Value = (lov.cantidad * lov.precio).ToString("N2");
                }
            }
        }

        private void textCantProducto_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (textCantProducto.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textDescuentoPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
            }

            if (e.KeyChar == decimalSeparator && ((TextBox)sender).Text.Contains(decimalSeparator))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido de "beep" al presionar Enter
                                  //btnCalcularDescuento.Focus(); // Cambia el foco al botón para realizar el cálculo
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false; // Permite borrar el contenido del TextBox
            }

            if (e.KeyChar != (char)Keys.Back && !char.IsControl(e.KeyChar))
            {
                string newText = ((TextBox)sender).Text + e.KeyChar.ToString();

                if (newText.Contains(decimalSeparator))
                {
                    // Verificar si el número decimal tiene más de dos dígitos después del separador
                    int decimalDigits = newText.Substring(newText.IndexOf(decimalSeparator) + 1).Length;
                    if (decimalDigits > 2)
                    {
                        e.Handled = true;
                    }
                }

                if (newText.Length > 3)
                {
                    // Verificar si el número entero es mayor a 100
                    int integerValue = int.Parse(newText.Split(decimalSeparator)[0]);
                    if (integerValue > 100)
                    {
                        e.Handled = true;
                    }
                }
            }
        }


        private void btCorreo_Click(object sender, EventArgs e)
        {
            btCorreo.Enabled = false;
            estado = Estado.Inicial;
            LimpiarComponentes();
            EstablecerEstadoFormulario();
        }

        private void btPedido_Click(object sender, EventArgs e)
        {
            
            if (_lineasOrdenDeVenta.Count == 0)
            {
                MostrarAdvertencia("La línea de orden de venta está vacía.");
                return;
            }

            if (!double.TryParse(textMonto.Text, out double precioTotal))
            {
                MostrarAdvertencia("El monto total no es válido.");
                return;
            }

            VentasWS.ordenDeVenta ordenV = new VentasWS.ordenDeVenta();
            ordenV.lineaDeOrdenDeVenta = _lineasOrdenDeVenta.ToArray();
            ordenV.fechaOrdenSpecified = true;
            ordenV.fechaEnvioSpecified = true;
            ordenV.fechaOrden = DateTime.Now.Date;
            ordenV.fechaEnvio = dateFechaEntrega.Value;
            ordenV.precioTotal = precioTotal;
            ordenV.empleado = new VentasWS.empleado();
            ordenV.empleado.idPersona = _id_empleado;
            //ordenV.d
            if (checkBoxFactura.Checked)
            {
                if (_clienteMayorista == null)
                {
                    MostrarAdvertencia("No se ha seleccionado un cliente mayorista.");
                    return;
                }

                ordenV.clienteMayorista = new VentasWS.clienteMayorista();
                ordenV.clienteMayorista.idPersona = _clienteMayorista.idPersona;
                ordenV.direccion = txtDireccion.Text;
                daoVentas.insertarOrdenDeVentaMayorista(ordenV);
            }
            else
            {
                daoVentas.insertarOrdenDeVentaMinorista(ordenV);
            }
            //descontar productos sedes
            RestaurarEstadoFormulario();
        }

        private void RestaurarEstadoFormulario()
        {
            estado = Estado.Inicial;
            //LimpiarComponentes();
            EstablecerEstadoFormulario();
            btCorreo.Enabled = true;
        }

        private void MostrarAdvertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnBuscarDireccion_Click(object sender, EventArgs e)
        {
              
        }
    }
}

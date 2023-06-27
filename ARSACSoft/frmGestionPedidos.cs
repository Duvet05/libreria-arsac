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
                    textCantProducto.Enabled = false;
                    txtRUC.Enabled = false;
                    btPedido.Enabled = false;
                    txtNombreCompleto.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    checkBoxFactura.Enabled = false;
                    checkBoxDescuento.Enabled = false;
                    dataGridView2.Enabled = false;
                    btnBuscarDireccion.Enabled = false;
                    txtDireccion.Enabled = false;
                    textCantProducto.Enabled = false;
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
                    textCantProducto.Enabled = true;
                    btPedido.Enabled = true;
                    checkBoxFactura.Enabled = true;
                    checkBoxDescuento.Enabled = true;
                    dataGridView2.Enabled = true;
                    break;
                case Estado.Buscar:
                    btnNuevo.Enabled = false;
                    btnCancelar.Enabled = true;
                    btnAgregar.Enabled = false;
                    btnBuscarDireccion.Enabled = false;
                    txtDireccion.Enabled = false;
                    textCantProducto.Enabled = false;
                    BtnQuitar.Enabled = false;
                    btnBuscarPedido.Enabled = false;
                    textNombreProducto.Enabled = false;
                    btnBuscarProd.Enabled = false;
                    textDescuentoPorcentaje.Enabled = false;
                    textMonto.Enabled = false;
                    textCantProducto.Enabled = false;
                    btPedido.Enabled = false;
                    txtNombreCompleto.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    txtRUC.Enabled = false;
                    checkBoxFactura.Enabled = false;
                    checkBoxDescuento.Enabled = false;
                    dataGridView2.Enabled = false;
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
                dateFechaEntrega.Value = DateTime.Now;
                txtDireccion.Text = string.Empty;
                txtRazonSocial.Text = string.Empty;
                txtNombreCompleto.Text = string.Empty; // Limpia el contenido del campo de factura
            }
            UpdateTextBoxes();

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
            txtNombreCompleto.Text = "";
            checkBoxFactura.Checked = false;
            checkBoxDescuento.Checked = false;
            txtDireccion.Text = "";
            dataGridView2.Rows.Clear();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProductoXSedeVenta frm = new frmBuscarProductoXSedeVenta(_id_sede);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _producto = frm.ProductoSeleccionado;
                textNombreProducto.Text = _producto.nombre.ToString();
                textCantProducto.Enabled = true;
                checkBoxDescuento.Checked = false;
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

        private void calcularSubtotal(lineaDeOrdenDeVenta lov)
        {
            if (checkBoxFactura.Checked)
            {
                if (double.TryParse(textDescuentoPorcentaje.Text, out double descuento))
                {
                    lov.descuento = (_producto.precioPorMayor * lov.cantidad) * (descuento / 100);
                }
                else
                    lov.descuento = 0.0;
                lov.precio = (_producto.precioPorMayor * lov.cantidad) - lov.descuento;
            }
            else
            {
                if (double.TryParse(textDescuentoPorcentaje.Text, out double descuento))
                {
                    lov.descuento = (_producto.precioPorMenor * lov.cantidad) * (descuento / 100);
                }
                else
                    lov.descuento = 0.0;
                lov.precio = (_producto.precioPorMenor * lov.cantidad) - lov.descuento;
            }
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

            // Verificar stock en sede
            int idProducto = _producto.idProducto;
            int cantidad = int.Parse(textCantProducto.Text);

            // Obtener el ID de la sede desde algún lugar (por ejemplo, una variable o un control en el formulario)

            // Llamar al método para verificar el stock suficiente en la sede
            int tieneStock = daoVentas.verificarStockSuficiente(_id_sede, idProducto, cantidad);

            if (tieneStock == 1)
            {
                lineaDeOrdenDeVenta lineaExistente = _lineasOrdenDeVenta.FirstOrDefault(linea => linea.producto.nombre == textNombreProducto.Text);

                if (lineaExistente != null)
                {
                    int nuevaCantidad = lineaExistente.cantidad + cantidad;

                    if (daoVentas.verificarStockSuficiente(_id_sede, idProducto, nuevaCantidad) != 1)
                    {
                        MostrarAdvertencia("No hay suficiente stock disponible para agregar este producto a la orden.");
                        return;
                    }

                    lineaExistente.cantidad = nuevaCantidad;
                    calcularSubtotal(lineaExistente);
                }
                else
                {
                    
                    lineaDeOrdenDeVenta lov = new lineaDeOrdenDeVenta
                    {
                        producto = new VentasWS.producto
                        {
                            idProducto = _producto.idProducto,
                            precioPorMayor = _producto.precioPorMayor,
                            precioPorMenor = _producto.precioPorMenor,
                            nombre = _producto.nombre
                        },
                        cantidad = cantidad
                    };

                    calcularSubtotal(lov);
                    _lineasOrdenDeVenta.Add(lov);
                }
                UpdateTextBoxes();
            }
            else
            {
                // No hay suficiente stock, mostrar un mensaje de advertencia
                MessageBox.Show("No hay suficiente stock disponible para agregar este producto a la orden.", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            double montoTotal = 0;

            textCantProducto.Text = "";
            foreach (lineaDeOrdenDeVenta linea in _lineasOrdenDeVenta)
            {
                if (checkBoxFactura.Checked)
                {
                    linea.precio = linea.producto.precioPorMayor;
                }
                else
                {
                    linea.precio = linea.producto.precioPorMenor;
                }

                montoTotal += linea.precio;
            }

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

                if (selectedRow.DataBoundItem is lineaDeOrdenDeVenta linea)
                {
                    textNombreProducto.Text = linea.producto.nombre;
                    textCantProducto.Text = string.Empty;
                    textDescuentoPorcentaje.Text = linea.descuento.ToString();

                    // Habilitar la edición de los valores de cantidad y descuento
                }
            }
            else
            {
                // No hay filas seleccionadas, limpiar los campos de texto y deshabilitar la edición
                textNombreProducto.Text = string.Empty;
                textCantProducto.Text = string.Empty;
                textDescuentoPorcentaje.Text = string.Empty;
                textCantProducto.Enabled = false;
                textDescuentoPorcentaje.Enabled = false;
            }
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _lineasOrdenDeVenta.Count)
            {
                try
                {
                    lineaDeOrdenDeVenta lov = (lineaDeOrdenDeVenta)dataGridView2.Rows[e.RowIndex].DataBoundItem;
                    lov.precio = checkBoxFactura.Checked ? lov.producto.precioPorMayor : lov.producto.precioPorMenor;
                    dataGridView2.Rows[e.RowIndex].Cells[0].Value = lov.producto.idProducto;
                    dataGridView2.Rows[e.RowIndex].Cells[1].Value = lov.producto.nombre;
                    dataGridView2.Rows[e.RowIndex].Cells[2].Value = lov.cantidad;
                    dataGridView2.Rows[e.RowIndex].Cells[3].Value = checkBoxFactura.Checked ? lov.producto.precioPorMayor : lov.producto.precioPorMenor;
                    dataGridView2.Rows[e.RowIndex].Cells[4].Value = lov.descuento.ToString("N2");
                    dataGridView2.Rows[e.RowIndex].Cells[5].Value = lov.precio.ToString("N2");
                }
                catch { }
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

                if (newText.Length > 6)
                {
                    e.Handled = true;
                }
                else if (newText.Length > 3)
                {
                    // Verificar si el número entero es mayor a 99
                    int integerValue = int.Parse(newText.Split(decimalSeparator)[0]);
                    if (integerValue > 99)
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
            if (checkBoxFactura.Checked)
            {
                if (_clienteMayorista == null)
                {
                    MostrarAdvertencia("No se ha seleccionado un cliente mayorista.");
                    return;
                }

                ordenV.clienteMayorista = new VentasWS.clienteMayorista();
                ordenV.clienteMayorista.idPersona = _clienteMayorista.idPersona;
                daoVentas.insertarOrdenDeVentaMayorista(ordenV);
            }
            else
            {
                ordenV.idOrdenDeVenta = daoVentas.insertarOrdenDeVentaMinorista(ordenV);
                
                frmBoletaDeVenta frm = new frmBoletaDeVenta(ordenV.idOrdenDeVenta, _id_empleado);
                frm.ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            frmBursarDireccion frm = new frmBursarDireccion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtDireccion.Text = frm.direccionSeleccionada;
            }
        }
    }
}

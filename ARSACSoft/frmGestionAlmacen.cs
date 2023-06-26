using ARSACSoft.AlmacenWS;
using ARSACSoft.ProductosWS;
using ARSACSoft.Properties;
using ARSACSoft.ProveedoresWS;
using ARSACSoft.RRHHWS;
using ARSACSoft.SedeWS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ARSACSoft
{
    public partial class frmGestionAlmacen : Form
    {
        private Estado _estadoPagProducto;
        private Estado _estadoPagOrdenCompra;

        private string _rutaFotoProducto = "";
        private ProductosWSClient daoProductosWS;
        private AlmacenWSClient daoAlmacenWS;
        private ProductosWS.producto prodSeleccionado;
        private ProveedoresWS.proveedor _proveedorSeleccionado = null;
        private AlmacenWS.ordenDeCompra _ordenCompraSeleccionada = null;

        private ordenDeCompra _ordenCompra;
        private BindingList<lineaOrdenDeCompra> _lineasOrdenDeCompra;

        private RRHHWS.empleado _empleadoLogeado;

        ProveedoresWS.productoXProveedor _productoDeProveedorSeleccionado;
        public frmGestionAlmacen(RRHHWS.empleado _empleadoLogeado)
        {

            InitializeComponent();
            

            daoProductosWS = new ProductosWSClient();
            daoAlmacenWS = new AlmacenWSClient();
            this._empleadoLogeado = _empleadoLogeado;

            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = daoProductosWS.listarCategoriasTodas();

            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = daoProductosWS.listarMarcaTodas();

            dgvListaProductosOC.AutoGenerateColumns = false;
            /*****************************/
            _estadoPagProducto = Estado.Inicial;
            establecerEstadoFormularioProducto();
            limpiarComponentesProducto();

            _estadoPagOrdenCompra = Estado.Inicial;
            establecerEstadoFormularioOrdenDeCompra();
            limpiarComponentesOrdenCompra();
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdImagenProducto.ShowDialog() == DialogResult.OK)
                {
                    _rutaFotoProducto = ofdImagenProducto.FileName;
                    pbFoto.Image =  System.Drawing.Image.FromFile(_rutaFotoProducto);
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
                
                prodSeleccionado = frmBuscProd.ProductoSeleccionado;

                txtNombreProducto.Text = prodSeleccionado.nombre;
                txtIDProducto.Text = prodSeleccionado.idProducto.ToString();

                cboMarca.SelectedValue = prodSeleccionado.marca.idMarca;
                cboCategoria.SelectedValue = prodSeleccionado.categoria.idCategoria;
                txtPrecioXMayor.Text = prodSeleccionado.precioPorMayor.ToString("N2");
                txtPrecioXMenor.Text = prodSeleccionado.precioPorMenor.ToString("N2");

                MemoryStream ms = new MemoryStream(prodSeleccionado.foto);
                pbFoto.Image = new Bitmap(ms);

                _estadoPagProducto = Estado.Buscar;
                establecerEstadoFormularioProducto();

            }

        }


        public void establecerEstadoFormularioProducto()
        {
            switch (_estadoPagProducto)
            {
                case Estado.Inicial:
                    btnNuevoProducto.Enabled = true;
                    btnGuardarProducto.Enabled = false;
                    btnBuscarProducto.Enabled = true;
                    btnModificarProducto.Enabled = false;
                    btnCancelarProducto.Enabled = false;
                    txtIDProducto.Enabled = false;
                    txtNombreProducto.Enabled = false;
                    cboMarca.Enabled = false;
                    cboCategoria.Enabled = false;
                    txtPrecioXMayor.Enabled = false;
                    txtPrecioXMenor.Enabled = false;    
                    btnSubirFoto.Enabled = false;

                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoProducto.Enabled = false;
                    btnGuardarProducto.Enabled = true;
                    btnBuscarProducto.Enabled = false;
                    btnModificarProducto.Enabled = false;
                    btnCancelarProducto.Enabled = true;
                    txtIDProducto.Enabled = true;
                    txtNombreProducto.Enabled = true;
                    cboMarca.Enabled = true;
                    cboCategoria.Enabled = true;
                    txtPrecioXMayor.Enabled = true;
                    txtPrecioXMenor.Enabled = true;
                    btnSubirFoto.Enabled = true;

                    break;
                case Estado.Buscar:
                    btnNuevoProducto.Enabled = false;
                    btnGuardarProducto.Enabled = false;
                    btnBuscarProducto.Enabled = true;
                    btnModificarProducto.Enabled = true;
                    btnCancelarProducto.Enabled = true;
                    txtIDProducto.Enabled = false;
                    txtNombreProducto.Enabled = false;
                    cboMarca.Enabled = false;
                    cboCategoria.Enabled = false;
                    txtPrecioXMayor.Enabled = false;
                    txtPrecioXMenor.Enabled = false;
                    btnSubirFoto.Enabled = false;
                    break;
            }
        }

        public void establecerEstadoFormularioOrdenDeCompra()
        {
            switch (_estadoPagOrdenCompra)
            {
                case Estado.Inicial:
                    btnNuevoOC.Enabled = true;
                    btnGuardarOC.Enabled = false;
                    btnBuscarOC.Enabled = true;
                    btnModificarOC.Enabled = false;
                    //btnEliminarOC.Enabled = false;
                    btnCancelarOC.Enabled = false;
                    //btnMarcarRecibidoOC.Enabled = false;

                    txtIDOrdenCompra.Enabled = false;
                    dtpFechaOrdenCompra.Enabled = false;
                    txtRUCProveedorOC.Enabled = false;
                    txtRazonSocialProveedorOC.Enabled= false;
                    btnBuscarProveedorOC.Enabled = false;
                    
                    txtCodigoProductoOC.Enabled = false;
                    txtNombreProductoOC.Enabled = false;
                    txtPrecioUnitarioProdOC.Enabled = false;
                    txtCantidadProdOC.Enabled= false;
                    btnAgregarProductoOC.Enabled = false;
                    btnQuitarProductoOC.Enabled= false;
                    btnBuscarProductoOC.Enabled= false;
                    /*Botones para cambios de estado del pedido recien activamos aqui*/
                    btnEliminarOC.Visible=false;
                    btnMarcarRecibidoOC.Visible=false;

                    btnEliminarOC.Enabled = false;
                    btnMarcarRecibidoOC.Enabled = false;
                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoOC.Enabled = false;
                    btnGuardarOC.Enabled = true;
                    btnBuscarOC.Enabled = false;
                    btnModificarOC.Enabled = false;
                    //btnEliminarOC.Enabled = true;
                    btnCancelarOC.Enabled = true;
                    //btnMarcarRecibidoOC.Enabled = false;

                    txtIDOrdenCompra.Enabled = false;
                    dtpFechaOrdenCompra.Enabled = true;
                    txtRUCProveedorOC.Enabled = true;
                    txtRazonSocialProveedorOC.Enabled = true;
                    btnBuscarProveedorOC.Enabled = true;

                    txtCodigoProductoOC.Enabled = true;
                    txtNombreProductoOC.Enabled = true;
                    txtPrecioUnitarioProdOC.Enabled = true;
                    txtCantidadProdOC.Enabled = true;
                    btnAgregarProductoOC.Enabled = true;
                    btnQuitarProductoOC.Enabled = true;
                    btnBuscarProductoOC.Enabled = true;
                    /*Botones para cambios de estado del pedido recien activamos aqui*/
                    btnEliminarOC.Visible = false;
                    btnMarcarRecibidoOC.Visible = false;

                    btnEliminarOC.Enabled = false;
                    btnMarcarRecibidoOC.Enabled = false;
                    break;
                case Estado.Buscar:
                    btnNuevoOC.Enabled = true;
                    btnGuardarOC.Enabled = false;
                    btnBuscarOC.Enabled = true;
                    btnModificarOC.Enabled = true;
                    btnCancelarOC.Enabled = false;
                    //btnEliminarOC.Enabled = true;
                    //btnMarcarRecibidoOC.Enabled = true;

                    txtIDOrdenCompra.Enabled = false;
                    dtpFechaOrdenCompra.Enabled = false;
                    txtRUCProveedorOC.Enabled = false;
                    txtRazonSocialProveedorOC.Enabled = false;
                    btnBuscarProveedorOC.Enabled = false;

                    txtCodigoProductoOC.Enabled = false;
                    txtNombreProductoOC.Enabled = false;
                    txtPrecioUnitarioProdOC.Enabled = false;
                    txtCantidadProdOC.Enabled = false;
                    btnAgregarProductoOC.Enabled = false;
                    btnQuitarProductoOC.Enabled = false;
                    btnBuscarProductoOC.Enabled = false;

                    /*Botones para cambios de estado del pedido recien activamos aqui*/
                    btnEliminarOC.Visible = true;
                    btnMarcarRecibidoOC.Visible = true;

                    btnEliminarOC.Enabled=true;
                    btnMarcarRecibidoOC.Enabled = true;
                    break;
            }
        }
        public void limpiarComponentesProducto()
        {
            txtIDProducto.Text = "";
            txtNombreProducto.Text = "";
            cboMarca.SelectedIndex = -1;
            cboCategoria.SelectedIndex = -1;
            txtPrecioXMayor.Text = "";
            txtPrecioXMenor.Text = "";
            pbFoto.Image = null;
        }
        public void limpiarComponentesOrdenCompra()
        {
            txtIDOrdenCompra.Text = "";
            dtpFechaOrdenCompra.Value = DateTime.Today;
            txtRUCProveedorOC.Text= "";
            txtRazonSocialProveedorOC.Text = "";

            txtCodigoProductoOC.Text = "";
            txtNombreProductoOC.Text = "";
            txtPrecioUnitarioProdOC.Text = "";
            txtCantidadProdOC.Text = "";
        }
        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            _estadoPagProducto = Estado.Nuevo;
            establecerEstadoFormularioProducto();
            limpiarComponentesProducto();
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
             _estadoPagProducto= Estado.Inicial;
            establecerEstadoFormularioProducto();
            limpiarComponentesProducto();

        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {

            ProductosWS.producto prod = new ProductosWS.producto();
            prod.nombre = txtNombreProducto.Text;
            prod.marca = new ProductosWS.marca();
            prod.marca.idMarca = (int)cboMarca.SelectedValue;
            prod.categoria  = new ProductosWS.categoria();
            prod.categoria.idCategoria = (int)cboCategoria.SelectedValue;
            prod.precioPorMayor = Double.Parse(txtPrecioXMayor.Text);
            prod.precioPorMenor = Double.Parse(txtPrecioXMenor.Text);

            if (_rutaFotoProducto != "")
            {
                FileStream fs = new FileStream(_rutaFotoProducto, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                prod.foto = br.ReadBytes((int)fs.Length);
                fs.Close();
            }

            if (_estadoPagProducto == Estado.Nuevo)
            {
                int resultado = daoProductosWS.insertarProducto(prod);

                if (resultado != 0)
                {
                    MessageBox.Show("Se ha agregado el producto correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _estadoPagProducto = Estado.Inicial;
                    establecerEstadoFormularioProducto();
                    txtIDProducto.Text = resultado.ToString();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de guardar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_estadoPagProducto == Estado.Modificar)
            {
                prod.idProducto = Int32.Parse(txtIDProducto.Text);
                int resultado = daoProductosWS.modificarProducto(prod);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha modificado con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _estadoPagProducto = Estado.Inicial;
                    establecerEstadoFormularioProducto();
                }
                else
                    MessageBox.Show("Ha ocurrido un error con la modificación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            _estadoPagProducto = Estado.Modificar;
            establecerEstadoFormularioProducto();
        }

        private void btnBuscarProveedorOC_Click(object sender, EventArgs e)
        {
            //En caso quiera cambiar de proveedor cuando ya tiene productos registrados u objeto seleccionado
            if(_lineasOrdenDeCompra.Count > 0 || _productoDeProveedorSeleccionado!=null)
            {
                CultureInfo.CurrentCulture = new CultureInfo("es-ES");
                DialogResult result = MessageBox.Show("No puede cambiar de proveedor porque hay producto(s) seleccionado(s).\n\n                  ¿Borrar productos seleccionados?", "Mensaje de advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _productoDeProveedorSeleccionado = null;
                    txtCodigoProductoOC.Text = "";
                    txtNombreProductoOC.Text = "";
                    txtPrecioUnitarioProdOC.Text = "";
                    txtCantidadProdOC.Text = "";

                    _proveedorSeleccionado = null;
                    txtRUCProveedorOC.Text = "";
                    txtRazonSocialProveedorOC.Text = "";
                    _lineasOrdenDeCompra.Clear();//reseteo productos guardados
                    _ordenCompra.costototal = 0;

                    txtTotal.Text = "";
                    //dgvListaProductosOC.Rows.Clear();

                }
                else if (result == DialogResult.No)
                {
                    return;

                }
            }
            
            frmBuscarProveedores frmBuscProvee = new frmBuscarProveedores();

            if (frmBuscProvee.ShowDialog() == DialogResult.OK)
            {
                this._proveedorSeleccionado= frmBuscProvee.ProveedorSeleccionado;
                txtRUCProveedorOC.Text = _proveedorSeleccionado.RUC;
                txtRazonSocialProveedorOC.Text = _proveedorSeleccionado.nombre;
            }
        }

        private void btnBuscarProductoOC_Click(object sender, EventArgs e)
        {
            if (_proveedorSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un proveedor para la orden de compra", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmBuscarProductoXProveedor formBusqProdProv = new frmBuscarProductoXProveedor(_proveedorSeleccionado);
            if (formBusqProdProv.ShowDialog() == DialogResult.OK)
            {
                _productoDeProveedorSeleccionado = formBusqProdProv.ProductoDeProveedorSeleccionado;
                txtCodigoProductoOC.Text = _productoDeProveedorSeleccionado.producto.idProducto.ToString();
                txtNombreProductoOC.Text = _productoDeProveedorSeleccionado.producto.nombre + " " +
                                            _productoDeProveedorSeleccionado.producto.marca.descripcion;
                txtPrecioUnitarioProdOC.Text = _productoDeProveedorSeleccionado.costo.ToString("N2");

                //txtCodigoProducto.Text = _producto.idProducto.ToString();
                //txtPrecioUnitario.Text = _producto.precio.ToString("N2");
            }
        }

        private void btnAgregarProductoOC_Click(object sender, EventArgs e)
        {
            if (txtCodigoProductoOC.Text == "")
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCantidadProdOC.Text == "" || Int32.Parse(txtCantidadProdOC.Text.Trim()) == 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (lineaOrdenDeCompra linea in this._lineasOrdenDeCompra)
            {
                if (linea.productoProveedor.producto.idProducto.Equals(_productoDeProveedorSeleccionado.producto.idProducto))
                {
                    linea.cantidad = linea.cantidad + Int32.Parse(txtCantidadProdOC.Text);
                    linea.subtotal = linea.cantidad * linea.productoProveedor.costo;//subtotal
                    dgvListaProductosOC.Refresh();
                    calcularTotal();
                    txtTotal.Text = this._ordenCompra.costototal.ToString("N2");
                    _productoDeProveedorSeleccionado = null;
                    txtCodigoProductoOC.Text = "";
                    txtNombreProductoOC.Text = "";
                    txtPrecioUnitarioProdOC.Text = "";
                    txtCantidadProdOC.Text = "";
                    return;
                }
            }

            lineaOrdenDeCompra lov = new lineaOrdenDeCompra();
            lov.productoProveedor = new AlmacenWS.productoXProveedor();
            lov.productoProveedor.costo = _productoDeProveedorSeleccionado.costo;
            lov.productoProveedor.producto = new AlmacenWS.producto();
            lov.productoProveedor.proveedor = new AlmacenWS.proveedor();
            lov.productoProveedor.producto.marca = new AlmacenWS.marca();
            lov.productoProveedor.producto.marca.descripcion = _productoDeProveedorSeleccionado.producto.marca.descripcion;
            lov.productoProveedor.proveedor.idProveedor = _proveedorSeleccionado.idProveedor;
            lov.productoProveedor.producto.idProducto = _productoDeProveedorSeleccionado.producto.idProducto;
            lov.productoProveedor.producto.nombre = _productoDeProveedorSeleccionado.producto.nombre;
            
            lov.cantidad = Int32.Parse(txtCantidadProdOC.Text);
            lov.subtotal = lov.cantidad * lov.productoProveedor.costo;
            _lineasOrdenDeCompra.Add(lov);
            dgvListaProductosOC.Refresh();
            calcularTotal();
            txtTotal.Text = this._ordenCompra.costototal.ToString("N2");
            _productoDeProveedorSeleccionado = null;
            txtCodigoProductoOC.Text = "";
            txtNombreProductoOC.Text = "";
            txtPrecioUnitarioProdOC.Text = "";
            txtCantidadProdOC.Text = "";
        }

        public void calcularTotal()
        {
            this._ordenCompra.costototal = 0;
            foreach (lineaOrdenDeCompra lov in this._lineasOrdenDeCompra)
            {
                _ordenCompra.costototal = _ordenCompra.costototal + lov.subtotal;
            }
        }

        private void btnNuevoOC_Click(object sender, EventArgs e)
        {
            _estadoPagOrdenCompra = Estado.Nuevo;
            establecerEstadoFormularioOrdenDeCompra();
            limpiarComponentesOrdenCompra();

            _proveedorSeleccionado = null;
            _ordenCompra = new ordenDeCompra();
            _lineasOrdenDeCompra = new BindingList<lineaOrdenDeCompra>();
            
            dgvListaProductosOC.DataSource = _lineasOrdenDeCompra;
        }

        private void dgvListaProductosOC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                lineaOrdenDeCompra lov = (lineaOrdenDeCompra)dgvListaProductosOC.Rows[e.RowIndex].DataBoundItem;
                dgvListaProductosOC.Rows[e.RowIndex].Cells[0].Value = lov.productoProveedor.producto.idProducto;
                dgvListaProductosOC.Rows[e.RowIndex].Cells[1].Value = lov.productoProveedor.producto.nombre;
                dgvListaProductosOC.Rows[e.RowIndex].Cells[2].Value = lov.productoProveedor.producto.marca.descripcion;
                dgvListaProductosOC.Rows[e.RowIndex].Cells[3].Value = lov.cantidad;
                dgvListaProductosOC.Rows[e.RowIndex].Cells[4].Value = lov.productoProveedor.costo;
                dgvListaProductosOC.Rows[e.RowIndex].Cells[5].Value = lov.subtotal;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnGuardarOC_Click(object sender, EventArgs e)
        {
            if (txtRUCProveedorOC.Text == "")
            {
                MessageBox.Show("No ha seleccionado un proveedor", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this._lineasOrdenDeCompra.Count == 0)
            {
                MessageBox.Show("No se han agregado productos a esta orden de venta", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ordenCompra.empleado = new AlmacenWS.empleado();
            _ordenCompra.proveedor = new AlmacenWS.proveedor();
            _ordenCompra.proveedor.idProveedor = _proveedorSeleccionado.idProveedor;
            _ordenCompra.empleado.idPersona = _empleadoLogeado.idPersona;
            _ordenCompra.fechaOrden = dtpFechaOrdenCompra.Value;
            _ordenCompra.fechaOrdenSpecified = true; //Clave************
            _ordenCompra.lineas = _lineasOrdenDeCompra.ToArray();
            _ordenCompra.estado = "EN PROCESO";//Si la OC estuvo en proceso o cancelado, ahora estará en proceso.
            if (_estadoPagOrdenCompra == Estado.Nuevo) //_estado == Estado.Nuevo
            {
                int resultado = daoAlmacenWS.insertarOrdenCompra(_ordenCompra);
                if (resultado != 0)
                {
                    txtIDOrdenCompra.Text = resultado.ToString();
                    lblEstadoOrdenCompra.Text = "(En proceso)";
                    MessageBox.Show("Se ha registrado correctamente",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    _estadoPagOrdenCompra = Estado.Inicial;
                    establecerEstadoFormularioOrdenDeCompra();

                    return;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error con el registro",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else if (_estadoPagOrdenCompra == Estado.Modificar)
            {
                int resultado = daoAlmacenWS.modificarOrdenCompra(_ordenCompra);
                if (resultado != 0)
                {
                    //txtIDOrdenVenta.Text = resultado.ToString();
                    lblEstadoOrdenCompra.Text = "(En proceso)";
                    MessageBox.Show("Se ha modificado correctamente",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error con el registro de la modificacion",
                    "Mensaje de éxito", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

                _estadoPagOrdenCompra = Estado.Buscar;
                establecerEstadoFormularioOrdenDeCompra();
            }
            
        }

        private void btnBuscarOC_Click(object sender, EventArgs e)
        {
            frmBuscarOrdenDeCompra formBusqOC = new frmBuscarOrdenDeCompra();
            if (formBusqOC.ShowDialog() == DialogResult.OK)
            {
                _ordenCompra = formBusqOC.OrdenCompraSeleccionada;
                txtIDOrdenCompra.Text = _ordenCompra.idOrdenDeCompra.ToString();
                dtpFechaOrdenCompra.Value = _ordenCompra.fechaOrden;
                txtRUCProveedorOC.Text = _ordenCompra.proveedor.RUC;
                txtRazonSocialProveedorOC.Text = _ordenCompra.proveedor.nombre;

                _proveedorSeleccionado = formBusqOC.ProveedorSeleccionado;
                _lineasOrdenDeCompra= new BindingList<lineaOrdenDeCompra>(_ordenCompra.lineas.ToList());
                //_ordenCompra = new ordenDeCompra();

                dgvListaProductosOC.DataSource = _lineasOrdenDeCompra;
                txtTotal.Text = _ordenCompra.costototal.ToString("N2");
                _estadoPagOrdenCompra = Estado.Buscar;
                establecerEstadoFormularioOrdenDeCompra();

                lblEstadoOrdenCompra.Text = "(" + ConvertirEstado(_ordenCompra.estado) + ")";
                //De acuerdo a su estado, permitiré que acceda a un cambio de estado
                if(_ordenCompra.estado == "RECIBIDO")
                {
                    //No permitiré que pueda cancelarlo o volver a recibirlo
                    btnEliminarOC.Enabled = false;
                    btnMarcarRecibidoOC.Enabled = false;
                    btnModificarOC.Enabled = false;

                }
                if (_ordenCompra.estado == "CANCELADO")
                {
                    //No permitiré que pueda cancelarlo o volver a recibirlo, pero sí modificarlo
                    btnEliminarOC.Enabled = false;
                    btnMarcarRecibidoOC.Enabled = false;
                }
            }
        }

        private void btnCancelarOC_Click(object sender, EventArgs e)
        {
            
            _estadoPagOrdenCompra = Estado.Inicial;
            establecerEstadoFormularioOrdenDeCompra();
            limpiarComponentesOrdenCompra();

            _productoDeProveedorSeleccionado = null;
            _proveedorSeleccionado = null;

            _lineasOrdenDeCompra.Clear();//reseteo productos guardados
            _ordenCompra.costototal = 0;

            txtTotal.Text = "";
        }

        private void btnQuitarProductoOC_Click(object sender, EventArgs e)
        {
            //ProveedoresWS.productoXProveedor productoXProvAux= (ProveedoresWS.productoXProveedor)dgvProductos.CurrentRow.DataBoundItem;
            if (dgvListaProductosOC.CurrentRow != null)
            {
                lineaOrdenDeCompra lov = (lineaOrdenDeCompra)dgvListaProductosOC.CurrentRow.DataBoundItem;
                this._lineasOrdenDeCompra.Remove(lov);
                calcularTotal();
                txtTotal.Text = this._ordenCompra.costototal.ToString("N2");
            }
            else
            {
                MessageBox.Show("Debe seleccionar una linea de orden de compra", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void tpPromociones_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnMarcarRecibidoOC_Click(object sender, EventArgs e)
        {

        }

        private void gbDatosOrdenCompra_Enter(object sender, EventArgs e)
        {

        }

        private void btnModificarOC_Click(object sender, EventArgs e)
        {
            _estadoPagOrdenCompra = Estado.Modificar;
            establecerEstadoFormularioOrdenDeCompra();
        }

 
        public string ConvertirEstado(string estado)
        {
            switch (estado.ToUpper())
            {
                case "EN PROCESO":
                    return "En proceso";
                case "CANCELADO":
                    return "Cancelado";
                case "RECIBIDO":
                    return "Recibido";
                default:
                    return estado;
            }
        }

        private void btnMarcarRecibidoOC_Click_1(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-ES");
            DialogResult result = MessageBox.Show("¿Registrar orden de compra como recibida?", "Mensaje de advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int resultado = daoAlmacenWS.registrarIngresoDeMercaderiaDeOrdenCompra(_ordenCompra);
                if (resultado != 0)
                {
                    MessageBox.Show("Se Registró correctamente nueva mercadería en almacén principal", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEliminarOC.Enabled = false;
                    btnMarcarRecibidoOC.Enabled = false;
                    btnModificarOC.Enabled = false;
                    lblEstadoOrdenCompra.Text = "(Recibido)";
                    return;
                }
                else
                {
                    MessageBox.Show("Error al intentar cancelar la orden de compra", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void btnEliminarOC_Click_1(object sender, EventArgs e)
        {
            CultureInfo.CurrentCulture = new CultureInfo("es-ES");
            DialogResult result = MessageBox.Show("¿Cancelar orden de compra?", "Mensaje de advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int resultado = daoAlmacenWS.cancelarOrdenCompra(_ordenCompra.idOrdenDeCompra);
                if (resultado != 0)
                {
                    MessageBox.Show("Orden de compra cancelada", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEliminarOC.Enabled = false;
                    btnMarcarRecibidoOC.Enabled = false;
                    lblEstadoOrdenCompra.Text = "(Cancelado)";
                    return;
                }
                else
                {
                    MessageBox.Show("Error al intentar cancelar la orden de compra", "Mensaje de advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
    }
}

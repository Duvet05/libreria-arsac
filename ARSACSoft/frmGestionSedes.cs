using ARSACSoft.AlmacenWS;
using ARSACSoft.ProductosWS;
using ARSACSoft.SedeWS;
using System;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionSedes : Form
    {
        private int _idEmpleado;

        private Estado estadoTabSedes;
        private Estado estadoTabOA;

        private SedesWSClient daoSede;
        
        private SedeWS.sede sede;
        private ProductosWS.producto _producto;
        private BindingList<SedeWS.sedeXProducto> _productos;
        private int productosIndex;

        private SedeWS.ordenDeAbastecimiento _orden;
        private SedeWS.sedeXProducto _productoDeSedeSeleccionado;
        private BindingList<SedeWS.lineaOrdenDeAbastecimiento> _lineasOA;


        public frmGestionSedes(int idEmpleado)
        {
            InitializeComponent();
            
            _idEmpleado = idEmpleado;

            estadoTabSedes = Estado.Inicial;
            estadoTabOA = Estado.Inicial;


            daoSede = new SedesWSClient();

            establecerEstadoTabSedes();
            limpiarComponentesTabSedes();
            
            establecerEstadoTabOA();
            limpiarComponentesTabOA();

            dgvProductosTabSede.AutoGenerateColumns = false;
            dgvLineasTabOA.AutoGenerateColumns = false;
        }

        // Tab Sedes

        public void establecerEstadoTabSedes()
        {
            switch (estadoTabSedes)
            {
                case Estado.Inicial:
                    btnNuevoTabSede.Enabled = true;
                    btnModificarTabSede.Enabled = false;
                    btnCancelarTabSede.Enabled = false;
                    btnBuscarTabSede.Enabled = true;
                    btnGuardarTabSede.Enabled = false;

                    txtDireccionTabSede.Enabled = false;
                    txtTelefonoTabSede.Enabled = false;
                    txtCorreoTabSede.Enabled = false;

                    btnAgregarProductoTabSede.Enabled = false;
                    btnQuitarProductoTabSede.Enabled=false;
                    btnBuscarProductoTabSede.Enabled = false;

                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoTabSede.Enabled = false;
                    btnModificarTabSede.Enabled = false;
                    btnCancelarTabSede.Enabled = true;
                    btnBuscarTabSede.Enabled = false;
                    btnGuardarTabSede.Enabled = true;

                    txtDireccionTabSede.Enabled = true;
                    txtTelefonoTabSede.Enabled = true;
                    txtCorreoTabSede.Enabled = true;

                    btnAgregarProductoTabSede.Enabled = false;
                    btnQuitarProductoTabSede.Enabled = true;
                    btnBuscarProductoTabSede.Enabled = true;

                    break;
                case Estado.Buscar:
                    btnNuevoTabSede.Enabled = false;
                    btnModificarTabSede.Enabled = true;
                    btnCancelarTabSede.Enabled = true;
                    btnBuscarTabSede.Enabled = false;
                    btnGuardarTabSede.Enabled = false;

                    txtDireccionTabSede.Enabled = false;
                    txtTelefonoTabSede.Enabled = false;
                    txtCorreoTabSede.Enabled = false;

                    btnAgregarProductoTabSede.Enabled = false;
                    btnQuitarProductoTabSede.Enabled = false;
                    btnBuscarProductoTabSede.Enabled = false;


                    break;
            }
        }

        public void limpiarComponentesTabSedes()
        {
            txtIdSedeTabSede.Text = string.Empty;
            txtDireccionTabSede.Text = string.Empty;
            txtTelefonoTabSede.Text = string.Empty;
            txtCorreoTabSede.Text = string.Empty;
            dgvProductosTabSede.DataSource = null;
            txtNombreProductoTabOA.Text = string.Empty;
            txtIdProductoTabSede.Text= string.Empty;
        }
        
        private void btnBuscarSede_Click(object sender, EventArgs e)
        {
            frmBuscarSede formBuscarSede = new frmBuscarSede();
            if (formBuscarSede.ShowDialog() == DialogResult.OK)
            {
                sede = formBuscarSede.SedeSeleccionada;
                txtIdSedeTabSede.Text = sede.idSede.ToString();
                txtCorreoTabSede.Text = sede.correo;
                txtDireccionTabSede.Text = sede.direccion;
                txtTelefonoTabSede.Text = sede.telefono;

                
                SedeWS.sedeXProducto[] p = daoSede.listarProductosDeSede(sede.idSede);
                if (p != null)
                {
                    _productos = new BindingList<SedeWS.sedeXProducto>(p.ToList());   
                }
                else
                    _productos = new BindingList<SedeWS.sedeXProducto>();

                productosIndex = _productos.Count;

                dgvProductosTabSede.DataSource = _productos;
                estadoTabSedes = Estado.Buscar;
                establecerEstadoTabSedes();
            }
        }

        private void btnNuevoSede_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Nuevo;
            limpiarComponentesTabSedes();
            establecerEstadoTabSedes();
            sede = new SedeWS.sede();
            _productos = new BindingList<SedeWS.sedeXProducto>();
        }

        private void btnCancelarSede_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Inicial;
            limpiarComponentesTabSedes();
            establecerEstadoTabSedes();
        }

        private void btnModificarSede_Click(object sender, EventArgs e)
        {
            estadoTabSedes = Estado.Modificar;
            establecerEstadoTabSedes();
            btnQuitarProductoTabSede.Enabled = false;

            if (sede.esPrincipal)
            {
                btnBuscarProductoTabSede.Enabled = false;
                btnAgregarProductoTabSede.Enabled = false;
            }
        }

        private void btnGuardarSede_Click(object sender, EventArgs e)
        {
            if (txtDireccionTabSede.Text == "" ||
                txtTelefonoTabSede.Text == "" ||
                txtCorreoTabSede.Text == "")
            {
                MessageBox.Show("Todos los campos deben estar llenos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            sede.direccion = txtDireccionTabSede.Text;
            sede.telefono = txtTelefonoTabSede.Text;
            sede.correo = txtCorreoTabSede.Text;
            
            int resultado = 0;

            if (estadoTabSedes == Estado.Nuevo)
            {
                sede.productos = _productos.ToArray();
                resultado = daoSede.insertarSede(sede);
            }
            else if (estadoTabSedes == Estado.Modificar)
            {
                BindingList<SedeWS.sedeXProducto> productosNuevos = new BindingList<SedeWS.sedeXProducto>();
                
                for (int i = productosIndex; i < _productos.Count; i++)
                {
                    productosNuevos.Add(_productos[i]);
                }
                sede.productos = productosNuevos.ToArray();

                resultado = daoSede.modificarSede(sede);
            }
            

            if (resultado != 0)
            {
                MessageBox.Show("Se ha realizado la operación con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdSedeTabSede.Text = resultado.ToString();
                estadoTabSedes = Estado.Inicial;
                establecerEstadoTabSedes();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarProductoTabSede_Click(object sender, EventArgs e)
        {
            frmBuscarProducto frm = new frmBuscarProducto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _producto = frm.ProductoSeleccionado;
                txtIdProductoTabSede.Text = _producto.idProducto.ToString();
                txtNombreProductoTabSede.Text = _producto.nombre;

                btnAgregarProductoTabSede.Enabled = true;
            }
        }

        private void btnAgregarProductoTabSede_Click(object sender, EventArgs e)
        {
            if (_producto == null)
                return;

            foreach (SedeWS.sedeXProducto p in _productos)
            {
                if (p.producto.idProducto == _producto.idProducto)
                    return;
            }
                

            SedeWS.sedeXProducto sxp = new SedeWS.sedeXProducto();

            sxp.producto = new SedeWS.producto();
            sxp.producto.idProducto = _producto.idProducto;
            sxp.producto.nombre = _producto.nombre;

            sxp.producto.categoria = new SedeWS.categoria();
            sxp.producto.categoria.descripcion = _producto.categoria.descripcion;

            sxp.producto.marca = new SedeWS.marca();
            sxp.producto.marca.descripcion = _producto.marca.descripcion;

            sxp.stock = 0;

            _productos.Add(sxp);

            dgvProductosTabSede.DataSource = _productos;

            txtIdProductoTabSede.Text = "";
            txtNombreProductoTabSede.Text = "";

            _producto = null;
        }

        private void btnQuitarProductoTabSede_Click(object sender, EventArgs e)
        {
            if (_productos.Count == 0)
                return;

            if (dgvProductosTabSede.CurrentRow.DataBoundItem == null)
                return;

            _productos.Remove((SedeWS.sedeXProducto)dgvProductosTabSede.CurrentRow.DataBoundItem);

            dgvProductosTabSede.DataSource = _productos;
        }

        private void dgvProductosTabSede_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                SedeWS.sedeXProducto sxp = (SedeWS.sedeXProducto)dgvProductosTabSede.Rows[e.RowIndex].DataBoundItem;

                dgvProductosTabSede.Rows[e.RowIndex].Cells[0].Value = sxp.producto.idProducto;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[1].Value = sxp.producto.nombre;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[2].Value = sxp.producto.marca.descripcion;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[3].Value = sxp.producto.categoria.descripcion;
                dgvProductosTabSede.Rows[e.RowIndex].Cells[4].Value = sxp.stock;
            }
            catch { }
        }

        // Tab Orden de abastecimiento

        public void establecerEstadoTabOA()
        {
            switch (estadoTabOA)
            {
                case Estado.Inicial:
                    btnNuevoTabOA.Enabled = true;
                    btnGuardarTabOA.Enabled = false;
                    btnBuscarTabOA.Enabled = true;
                    btnCancelarTabOA.Enabled = false;

                    btnBuscarSedeTabOA.Enabled = false;
                    btnBuscarProductoTabOA.Enabled = false;
                    txtCantidadTabOA.Enabled = false;
                    btnAgregarTabOA.Enabled = false;
                    btnQuitarTabOA.Enabled = false;
                    btnEntregarOrdenTabOA.Enabled = false;
                    btnCancelarOrdenTabOA.Enabled= false;

                    break;
                case Estado.Nuevo:

                    btnNuevoTabOA.Enabled = false;
                    btnGuardarTabOA.Enabled = true;
                    btnBuscarTabOA.Enabled = false;
                    btnCancelarTabOA.Enabled = true;

                    btnBuscarSedeTabOA.Enabled = true;
                    btnBuscarProductoTabOA.Enabled = false;
                    txtCantidadTabOA.Enabled = false;
                    btnAgregarTabOA.Enabled = false;
                    btnQuitarTabOA.Enabled = false;
                    btnEntregarOrdenTabOA.Enabled = false;
                    btnCancelarOrdenTabOA.Enabled = false;


                    break;
                case Estado.Buscar:

                    btnNuevoTabOA.Enabled = false;
                    btnGuardarTabOA.Enabled = false;
                    btnBuscarTabOA.Enabled = false;
                    btnCancelarTabOA.Enabled = true;

                    btnBuscarSedeTabOA.Enabled = false;
                    btnBuscarProductoTabOA.Enabled = false;
                    txtCantidadTabOA.Enabled = false;
                    btnAgregarTabOA.Enabled = false;
                    btnQuitarTabOA.Enabled = false;
                    btnEntregarOrdenTabOA.Enabled = true;
                    btnCancelarOrdenTabOA.Enabled = true;

                    break;
            }
        }

        public void limpiarComponentesTabOA()
        {
            txtCantidadTabOA.Text = "";
            txtDireccionSedeTabOA.Text = "";
            txtNombreProductoTabOA.Text = "";
            txtStockSedePrincipalTabOA.Text = "";
            txtStockTabOA.Text = "";
        }

        private void btnCancelarTabOA_Click(object sender, EventArgs e)
        {
            estadoTabOA = Estado.Inicial;
            limpiarComponentesTabOA();
            establecerEstadoTabOA();
        }

        private void btnNuevoTabOA_Click(object sender, EventArgs e)
        {
            estadoTabOA = Estado.Nuevo;
            limpiarComponentesTabOA();
            establecerEstadoTabOA();
            _orden = new ordenDeAbastecimiento();
            _lineasOA = new BindingList<lineaOrdenDeAbastecimiento>();

        }

        private void btnGuardarTabOA_Click(object sender, EventArgs e)
        {
            if (_orden.sede == null)
            {
                MessageBox.Show("Tiene que seleccionar una sede secundaria", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _orden.idEmpleado = _idEmpleado;
            _orden.lineas = _lineasOA.ToArray();

            int resultado = daoSede.insertarOrdenDeAbastecimiento(_orden);

            if (resultado != 0)
            { 
                MessageBox.Show("Se ha registrado con éxito", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIdOrdenTabSede.Text = resultado.ToString();
                estadoTabOA = Estado.Inicial;
                establecerEstadoTabOA();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscarTabOA_Click(object sender, EventArgs e)
        {
            frmBuscarOrdenDeAbastecimiento frm = new frmBuscarOrdenDeAbastecimiento(_idEmpleado);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _orden = frm.OrdenSeleccionada;

                txtIdOrdenTabSede.Text = _orden.idOrdenDeAbastecimiento.ToString();
                txtDireccionSedeTabOA.Text = _orden.sede.direccion;

                _orden.lineas = daoSede.listarLineasDeOrdenDeAbastecimiento(_orden.idOrdenDeAbastecimiento);

                dgvLineasTabOA.DataSource = _orden.lineas;
                
                estadoTabOA = Estado.Buscar;
                establecerEstadoTabOA();

                if (_orden.estado != "Pendiente")
                {
                    btnEntregarOrdenTabOA.Enabled = false;
                    btnCancelarOrdenTabOA.Enabled = false;
                }
            }
        }

        private void btnBuscarSedeTabOA_Click(object sender, EventArgs e)
        {
            frmBuscarSede frm = new frmBuscarSede(true);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _orden.sede = frm.SedeSeleccionada;
                txtDireccionSedeTabOA.Text = _orden.sede.direccion;

                btnBuscarSedeTabOA.Enabled = false;
                btnBuscarProductoTabOA.Enabled = true;


            }
        }

        private void btnBuscarProductoTabOA_Click(object sender, EventArgs e)
        {
            frmBuscarProductoXSede frm = new frmBuscarProductoXSede(_orden.sede);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _productoDeSedeSeleccionado = frm.ProductoDeSedeSeleccionada;
                txtNombreProductoTabOA.Text = _productoDeSedeSeleccionado.producto.nombre;

                txtStockTabOA.Text = daoSede.obtenerStockDeProductoEnSede
                    (_productoDeSedeSeleccionado.producto.idProducto, _orden.sede.idSede).ToString();

                txtStockSedePrincipalTabOA.Text = daoSede.obtenerStockDeProductoEnSedePrincipal
                    (_productoDeSedeSeleccionado.producto.idProducto).ToString();

                txtCantidadTabOA.Enabled = true;
                btnAgregarTabOA.Enabled = true;
                btnQuitarTabOA.Enabled = true;
            }
        }

        private void btnAgregarTabOA_Click(object sender, EventArgs e)
        {

            int cantidad = 0;

            try
            {
               cantidad  = int.Parse(txtCantidadTabOA.Text);
            }
            catch
            {
                MessageBox.Show("Debe de ingresar una cantidad", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int i;
            for (i = 0; i<_lineasOA.Count; i++)
            {
                if (_lineasOA[i].producto.idProducto == _productoDeSedeSeleccionado.producto.idProducto)
                {
                    if (int.Parse(txtStockSedePrincipalTabOA.Text) < _lineasOA[i].cantidad + cantidad)
                    {
                        MessageBox.Show("El stock de la sede principal es menor a la cantidad ingresada", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _lineasOA[i].cantidad += cantidad;
                    break;
                }
            }

            if (i == _lineasOA.Count)
                if (int.Parse(txtStockSedePrincipalTabOA.Text) < cantidad)
                {
                    MessageBox.Show("El stock de la sede principal es menor a la cantidad ingresada", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            lineaOrdenDeAbastecimiento linea = new lineaOrdenDeAbastecimiento();
            linea.cantidad = cantidad;
            linea.producto = _productoDeSedeSeleccionado.producto;

            _lineasOA.Add(linea);

            dgvLineasTabOA.DataSource = _lineasOA;

            txtNombreProductoTabOA.Text = "";
            txtStockTabOA.Text = "";
            txtStockSedePrincipalTabOA.Text = "";
            txtCantidadTabOA.Text = "";

            _productoDeSedeSeleccionado = null;

            btnAgregarTabOA.Enabled = false;
        }

        private void btnQuitarTabOA_Click(object sender, EventArgs e)
        {
            if (dgvLineasTabOA.CurrentRow != null && dgvLineasTabOA.CurrentRow.DataBoundItem is lineaOrdenDeAbastecimiento)
            {
                lineaOrdenDeAbastecimiento linea = (lineaOrdenDeAbastecimiento)dgvLineasTabOA.CurrentRow.DataBoundItem;

                _lineasOA.Remove(linea);

                dgvLineasTabOA.DataSource = _lineasOA;
            }
        }

        private void dgvLineasTabOA_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                lineaOrdenDeAbastecimiento linea = (lineaOrdenDeAbastecimiento)dgvLineasTabOA.Rows[e.RowIndex].DataBoundItem;
                dgvLineasTabOA.Rows[e.RowIndex].Cells[0].Value = linea.producto.idProducto;
                dgvLineasTabOA.Rows[e.RowIndex].Cells[1].Value = linea.producto.nombre;
                dgvLineasTabOA.Rows[e.RowIndex].Cells[2].Value = linea.producto.categoria.descripcion;
                dgvLineasTabOA.Rows[e.RowIndex].Cells[3].Value = linea.producto.marca.descripcion;
                dgvLineasTabOA.Rows[e.RowIndex].Cells[4].Value = linea.cantidad;
            }
            catch { }
        }

        private void btnEntregarOrdenTabOA_Click(object sender, EventArgs e)
        {
            // Verificacion de que hay una orden de abastecimiento seleccionada

            int verificacion = daoSede.verificarEntregaDeOrdenDeAbastecimiento(_orden);

            if (verificacion != 0 )
            {
                int resultado = daoSede.entregarOrdenDeAbastecimiento(_orden);

                if (resultado != 0 )
                {
                    MessageBox.Show("Se ha entregado la orden de abastecimiento", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEntregarOrdenTabOA.Enabled = false;
                    btnCancelarOrdenTabOA.Enabled = false;
                }
                else
                    MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("No se puede entregar la orden porque no hay suficiente stock en la sede principal", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnCancelarOrdenTabOA_Click(object sender, EventArgs e)
        {
            // Verificacion de que hay una orden de abastecimiento seleccionada

            int resultado = daoSede.cancelarOrdenDeAbastecimiento(_orden.idOrdenDeAbastecimiento);

            if (resultado != 0)
            {
                MessageBox.Show("Se ha cancelado la orden de abastecimiento", "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEntregarOrdenTabOA.Enabled = false;
                btnCancelarOrdenTabOA.Enabled = false;
            }
            else
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using ARSACSoft.ProductosWS;
using ARSACSoft.Properties;
using ARSACSoft.RRHHWS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmGestionAlmacen : Form
    {
        private Estado _estadoPagProducto;
        private string _rutaFotoProducto = "";
        private ProductosWSClient daoProductosWS;
        private ProductosWS.producto prodSeleccionado;
        public frmGestionAlmacen()
        {
            InitializeComponent();
            _estadoPagProducto = Estado.Inicial;
            establecerEstadoFormularioProducto();
            limpiarComponentesProducto();
            daoProductosWS = new ProductosWSClient();
            

            cboCategoria.DisplayMember = "descripcion";
            cboCategoria.ValueMember = "idCategoria";
            cboCategoria.DataSource = daoProductosWS.listarCategoriasTodas();

            cboMarca.DisplayMember = "descripcion";
            cboMarca.ValueMember = "idMarca";
            cboMarca.DataSource = daoProductosWS.listarMarcaTodas();
        }

        private void btnSubirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdImagenProducto.ShowDialog() == DialogResult.OK)
                {
                    _rutaFotoProducto = ofdImagenProducto.FileName;
                    pbFoto.Image = Image.FromFile(_rutaFotoProducto);
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
    }
}

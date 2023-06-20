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
        private string _rutaFotoLocal;

        public frmGestionAlmacen()
        {
            InitializeComponent();
            _estadoPagProducto = Estado.Inicial;
            establecerEstadoFormularioProducto();
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
                    btnGuardarProducto.Enabled = true;
                    btnBuscarProducto.Enabled = false;
                    btnModificarProducto.Enabled = true;
                    btnCancelarProducto.Enabled = false;
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
        public void limpiarComponentesEmpleado()
        {

        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            _estadoPagProducto = Estado.Nuevo;
            establecerEstadoFormularioProducto();
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
             _estadoPagProducto= Estado.Inicial;
            establecerEstadoFormularioProducto();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {

            //producto = new pelicula();
            //pelicula.actores = new BindingList<actor>().ToArray();
            //pelicula.actores = _actores.ToArray();
            //pelicula.titulo = txtTitulo.Text;
            //pelicula.fechaEstreno = dtpFechaEstreno.Value;
            //pelicula.fechaEstrenoSpecified = true;
            //pelicula.genero = new genero();
            //pelicula.genero.idGenero = (int)cboGenero.SelectedValue;
            //pelicula.duracion = dtpDuracion.Value.ToString("hh:mm");
            //pelicula.disponibleSubtitulada = cbSubtitulada.Checked;
            //pelicula.disponibleDoblada = cbDoblada.Checked;
            //pelicula.sinopsis = txtSinopsis.Text;

            //if (_rutaFotoPortada != "")
            //{
            //    FileStream fs = new FileStream(_rutaFotoPortada, FileMode.Open, FileAccess.Read);
            //    BinaryReader br = new BinaryReader(fs);
            //    pelicula.portada = br.ReadBytes((int)fs.Length);
            //    fs.Close();
            //}

            //int resultado = daoServiceWS.insertarPelicula(pelicula);

            //if (resultado != 0)
            //{
            //    MessageBox.Show("Se ha agregado pelicula correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    _estado = Estado.Inicial;
            //    establecerEstadoComponentes();
            //}
            //else
            //{
            //    MessageBox.Show("Ha ocurrido un error al momento de guardar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}

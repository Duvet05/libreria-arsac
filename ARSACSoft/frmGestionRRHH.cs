using ARSACSoft.RRHHWS;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using ARSACSoft.Properties;
using System.Collections.Generic;
using System.Globalization;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;

namespace ARSACSoft
{
    public partial class frmGestionRRHH : Form
    {
        private Estado _estadoEmpleado;
        private empleado _empleado;

        private Estado _estadoCliente;
        private clienteMayorista _clienteMayorista;

        private RRHHWSClient daoRRHH;
        private string _rutaFotoEmpleado;

        private cuentaUsuario _cuentaUsuario;
        public frmGestionRRHH()
        {
            InitializeComponent();
            ConfigureForm();
            InitializeServiceClient();
            InitializeMaps();
        }

        private void InitializeMaps()
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyBgyKAoWNGBGh8QkqYaxlsiale87i-sstI";
            gMapControl1.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.Position = new GMap.NET.PointLatLng(-12.046374, -77.042793); // Puedes ajustar estas coordenadas a la ubicación que deseas mostrar inicialmente
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
            gMapControl1.ShowCenter = true; // Muestra el control de centrado
        }

        private async Task<string> GetAddressAsync(double lat, double lng)
        {
            string apiKey = "AIzaSyBgyKAoWNGBGh8QkqYaxlsiale87i-sstI";
            string requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={lat},{lng}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject jsonResult = JObject.Parse(content);

                    if (jsonResult.TryGetValue("results", out var results) && results.Any())
                    {
                        string address = results[0]?.Value<string>("formatted_address");
                        return address;
                    }
                }
                else
                {
                    // Manejar el caso de respuesta no exitosa
                    // ...
                }
            }
            return null;
        }

        private async void gMapControl1_OnMapClick(GMap.NET.PointLatLng point, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string address = await GetAddressAsync(point.Lat, point.Lng);
                // Hacer algo con la dirección...
                textDireccion.Text = address;
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            GMap.NET.PointLatLng point = gMapControl1.Position;
            string address = await GetAddressAsync(point.Lat, point.Lng);
            textDireccion.Text = address;
        }

        private void ConfigureForm()
        {
            _estadoEmpleado = Estado.Inicial;
            establecerEstadoFormularioEmpleado();
            _estadoCliente = Estado.Inicial;
            establecerEstadoFormularioCliente();

            cboTipoDeEmpleado.ValueMember = "idTipoDeEmpleado";
            cboTipoDeEmpleado.DisplayMember = "descripcion";

            limpiarComponentesCliente();
            limpiarComponentesEmpleado();
        }
        private void InitializeServiceClient()
        {
            daoRRHH = new RRHHWSClient();
            cboTipoDeEmpleado.DataSource = daoRRHH.listarTiposDeEmpleados();
        }
        public void establecerEstadoFormularioEmpleado()
        {
            switch (_estadoEmpleado)
            {
                case Estado.Inicial:
                    btnNuevoEmpleado.Enabled = true;
                    btnCancelarEmpleado.Enabled = false;
                    btnBuscarEmpleado.Enabled = true;
                    btnModificarEmpleado.Enabled = false;
                    btnEliminarEmpleado.Enabled = false;
                    btnGuardarEmpleado.Enabled = false;
                    btnSubirPortada.Enabled = false;
                    txtIDEmpleado.Enabled = false;
                    txtDNIEmpleado.Enabled = false;
                    txtNombreEmpleado.Enabled = false;
                    txtApellidoEmpleado.Enabled = false;
                    txtTelefonoEmpleado.Enabled = false;
                    dtpFechaContratacion.Enabled = false;
                    cboTipoDeEmpleado.Enabled = false;
                    txtCorreoEmpleado.Enabled = false;
                    txtSalario.Enabled = false;
                    txtDireccion.Enabled = false;
                    txtContrasena.Enabled = false;
                    txtUsuario.Enabled = false;
                    btnBuscarSede.Enabled = false;
                    cbMostrarContrasena.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoEmpleado.Enabled = false;
                    btnGuardarEmpleado.Enabled = true;
                    btnBuscarEmpleado.Enabled = false;
                    btnModificarEmpleado.Enabled = false;
                    btnEliminarEmpleado.Enabled = false;
                    btnCancelarEmpleado.Enabled = true;
                    txtContrasena.Enabled = true;
                    txtIDEmpleado.Enabled = true;
                    txtDNIEmpleado.Enabled = true;
                    txtNombreEmpleado.Enabled = true;
                    txtTelefonoEmpleado.Enabled = true;
                    txtApellidoEmpleado.Enabled = true;
                    dtpFechaContratacion.Enabled = true;
                    cboTipoDeEmpleado.Enabled = true;
                    txtCorreoEmpleado.Enabled = true;
                    txtSalario.Enabled = true;
                    txtDireccion.Enabled = true;
                    btnBuscarSede.Enabled = true;
                    cbMostrarContrasena.Enabled = true;
                    txtUsuario.Enabled = true;
                    txtDireccionSede.Enabled = true;
                    btnSubirPortada.Enabled = true;
                    break;
                case Estado.Buscar:
                    btnNuevoEmpleado.Enabled = false;
                    btnGuardarEmpleado.Enabled = false;
                    btnBuscarEmpleado.Enabled = false;
                    btnModificarEmpleado.Enabled = true;
                    btnEliminarEmpleado.Enabled = true;
                    btnCancelarEmpleado.Enabled = true;

                    txtIDEmpleado.Enabled = false;
                    txtDNIEmpleado.Enabled = false;
                    txtNombreEmpleado.Enabled = false;
                    txtApellidoEmpleado.Enabled = false;
                    txtTelefonoEmpleado.Enabled = false;
                    dtpFechaContratacion.Enabled = false;
                    cboTipoDeEmpleado.Enabled = false;
                    txtCorreoEmpleado.Enabled = false;
                    txtSalario.Enabled = false;
                    txtDireccion.Enabled = false;
                    btnBuscarSede.Enabled = false;

                    txtUsuario.Enabled = false;
                    txtDireccionSede.Enabled = false;
                    txtContrasena.Enabled = false;
                    break;
            }
        }
        public void establecerEstadoFormularioCliente()
        {
            switch (_estadoCliente)
            {
                case Estado.Inicial:
                    btnNuevoCliente.Enabled = true;
                    btnCancelarCliente.Enabled = false;
                    btnBuscarCliente.Enabled = true;
                    btnModificarCliente.Enabled = false;
                    btnEliminarCliente.Enabled = false;
                    btnGuardarCliente.Enabled = false;
                    gMapControl1.Enabled = false;
                    botonUbicacion.Enabled = false;
                    txtIDCliente.Enabled = false;
                    txtDNICliente.Enabled = false;
                    txtNombreCliente.Enabled = false;
                    txtApellidoCliente.Enabled = false;
                    txtTelefonoCliente.Enabled = false;
                    txtCorreoCliente.Enabled = false;
                    txtRUC.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    textDireccion.Enabled = false;

                    break;
                case Estado.Nuevo:
                case Estado.Modificar:
                    btnNuevoCliente.Enabled = false;
                    btnCancelarCliente.Enabled = true;
                    btnBuscarCliente.Enabled = false;
                    btnModificarCliente.Enabled = false;
                    btnEliminarCliente.Enabled = false;
                    btnCancelarCliente.Enabled = true;
                    btnGuardarCliente.Enabled = true;
                    gMapControl1.Enabled = true;
                    botonUbicacion.Enabled = true;
                    txtIDCliente.Enabled = true;
                    txtDNICliente.Enabled = true;
                    txtNombreCliente.Enabled = true;
                    txtApellidoCliente.Enabled = true;
                    txtTelefonoCliente.Enabled = true;
                    txtCorreoCliente.Enabled = true;
                    txtRUC.Enabled = true;
                    txtRazonSocial.Enabled = true;
                    textDireccion.Enabled = true;
                    break;
                case Estado.Buscar:
                    btnNuevoCliente.Enabled = false;
                    btnGuardarCliente.Enabled = false;
                    btnBuscarCliente.Enabled = false;
                    btnModificarCliente.Enabled = true;
                    btnEliminarCliente.Enabled = true;
                    btnCancelarCliente.Enabled = true;

                    txtIDCliente.Enabled = false;
                    txtDNICliente.Enabled = false;
                    txtNombreCliente.Enabled = false;
                    txtApellidoCliente.Enabled = false;
                    txtTelefonoCliente.Enabled = false;
                    txtCorreoCliente.Enabled = false;
                    txtRUC.Enabled = false;
                    txtRazonSocial.Enabled = false;
                    break;
            }
        }
        public void limpiarComponentesEmpleado()
        {
            txtIDEmpleado.Text = "";
            txtDNIEmpleado.Text = "";
            txtNombreEmpleado.Text = "";
            txtApellidoEmpleado.Text = "";
            txtTelefonoEmpleado.Text = "";
            dtpFechaContratacion.Value = DateTime.Now;
            cboTipoDeEmpleado.SelectedIndex = -1;
            txtCorreoEmpleado.Text = "";
            txtSalario.Text = "";
            txtDireccion.Text = "";
            pbFotoEmpleado.Image = Resources.hombre;
            txtUsuario.Text = "";
            txtDireccionSede.Text = "";
            txtContrasena.Text = "";
        }
        public void limpiarComponentesCliente()
        {
            txtIDCliente.Text = "";
            txtDNICliente.Text = "";
            txtNombreCliente.Text = "";
            txtApellidoCliente.Text = "";
            txtTelefonoCliente.Text = "";
            txtCorreoCliente.Text = "";
            txtRazonSocial.Text = "";
            txtNombreCliente.Text = "";
        }

        private void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            _estadoEmpleado = Estado.Nuevo;
            limpiarComponentesEmpleado();
            establecerEstadoFormularioEmpleado();

            _empleado = new empleado();
            _empleado.sede = new sede();
            _cuentaUsuario = new cuentaUsuario();
        }

        private void btnBuscarSede_Click(object sender, EventArgs e)
        {
            frmBuscarSede frm = new frmBuscarSede();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _empleado.sede.idSede = frm.SedeSeleccionada.idSede;
                txtDireccionSede.Text = frm.SedeSeleccionada.direccion;
            }

        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleados frm = new frmBuscarEmpleados();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _empleado = frm.EmpleadoSeleccionado;


                txtIDEmpleado.Text = _empleado.idPersona.ToString();
                txtDNIEmpleado.Text = _empleado.DNI;
                txtNombreEmpleado.Text = _empleado.nombre;
                txtApellidoEmpleado.Text = _empleado.apellidos;
                txtTelefonoEmpleado.Text = _empleado.telefono;
                dtpFechaContratacion.Value = _empleado.fechaContratacion;
                cboTipoDeEmpleado.SelectedValue = _empleado.tipo.idTipoDeEmpleado;
                txtCorreoEmpleado.Text = _empleado.correo;
                txtSalario.Text = _empleado.salario.ToString(CultureInfo.InvariantCulture);
                txtDireccion.Text = _empleado.direccion;

                if (_empleado.foto != null)
                {
                    MemoryStream ms = new MemoryStream(_empleado.foto);
                    pbFotoEmpleado.Image = new Bitmap(ms);
                }
                txtDireccionSede.Text = _empleado.sede.direccion;

                _cuentaUsuario = daoRRHH.buscarCuenta(_empleado.idPersona);
                if (_cuentaUsuario != null)
                {
                    txtUsuario.Text = _cuentaUsuario.username;
                    txtContrasena.Text = _cuentaUsuario.password;
                }

                _estadoEmpleado = Estado.Buscar;
                establecerEstadoFormularioEmpleado();

            }
        }

        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreEmpleado.Text) ||
                string.IsNullOrEmpty(txtApellidoEmpleado.Text) ||
                string.IsNullOrEmpty(txtDNIEmpleado.Text) ||
                string.IsNullOrEmpty(txtCorreoEmpleado.Text) ||
                string.IsNullOrEmpty(txtTelefonoEmpleado.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _empleado.nombre = txtNombreEmpleado.Text;
            _empleado.apellidos = txtApellidoEmpleado.Text;
            _empleado.DNI = txtDNIEmpleado.Text;
            _empleado.correo = txtCorreoEmpleado.Text;
            _empleado.telefono = txtTelefonoEmpleado.Text;

            _empleado.tipo = new tipoDeEmpleado();
            _empleado.tipo.idTipoDeEmpleado = (int)cboTipoDeEmpleado.SelectedValue;

            _empleado.fechaContratacion = dtpFechaContratacion.Value;
            _empleado.fechaContratacionSpecified = true;

            if (!double.TryParse(txtSalario.Text, out double salario))
            {
                MessageBox.Show("El salario debe ser un número válido", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _empleado.salario = salario;
            _empleado.direccion = txtDireccion.Text;

            if (!string.IsNullOrEmpty(_rutaFotoEmpleado))
            {
                try
                {
                    using (FileStream fs = new FileStream(_rutaFotoEmpleado, FileMode.Open, FileAccess.Read))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        _empleado.foto = br.ReadBytes((int)fs.Length);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // VERIFICACION DE NO REPETIR EL USERNAME DE UN EMPLEADO

            if (_estadoEmpleado == Estado.Modificar && _cuentaUsuario.username != txtUsuario.Text && daoRRHH.verificarRepeticionDeCuenta(txtUsuario.Text) > 0)
            {
                MessageBox.Show($"Error al actualizar las credenciales", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_estadoEmpleado == Estado.Nuevo && daoRRHH.verificarRepeticionDeCuenta(txtUsuario.Text) > 0)
            {
                MessageBox.Show($"Error al registrar las credenciales", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int resultado;
            if (_estadoEmpleado == Estado.Nuevo)
                resultado = daoRRHH.insertarEmpleado(_empleado);
            else
                resultado = daoRRHH.modificarEmpleado(_empleado);

            _cuentaUsuario.username = txtUsuario.Text;
            _cuentaUsuario.password = txtContrasena.Text;
            _cuentaUsuario.idEmpleado = resultado;

            if (resultado != 0)
            {
  

                if (_estadoEmpleado == Estado.Nuevo)
                {
                    try
                    {
                        //metodo de busqueda de nombre de usuario
                        /*Guardar cuenta de usuario*/

                        daoRRHH.insertarCuentaUsuario(_cuentaUsuario);
                        /*Fin GuardarCuentaUsuario*/
                        txtIDEmpleado.Text = resultado.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear la cuenta de usuario: {ex.Message}", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (_estadoEmpleado == Estado.Modificar)
                {
                    try
                    {
                        daoRRHH.actualizarCuenta(_cuentaUsuario);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar la contraseña: {ex.Message}", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string mensaje = _estadoEmpleado == Estado.Nuevo ? "Se ha registrado con éxito" : "Se ha modificado con éxito";
                MessageBox.Show(mensaje, "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _estadoEmpleado = Estado.Inicial;
                establecerEstadoFormularioEmpleado();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            _estadoEmpleado = Estado.Modificar;
            establecerEstadoFormularioEmpleado();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult resultadoInteraccion = MessageBox.Show("¿Está seguro de que desea eliminar a este empleado", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultadoInteraccion == DialogResult.Yes)
            {
                int resultado = daoRRHH.eliminarEmpleado(_empleado.idPersona);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _estadoEmpleado = Estado.Inicial;
                    establecerEstadoFormularioEmpleado();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarEmpleado_Click(object sender, EventArgs e)
        {
            _estadoEmpleado = Estado.Inicial;
            establecerEstadoFormularioEmpleado();
            limpiarComponentesEmpleado();
        }

        private void btnSubirPortada_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdFotoEmpleado.ShowDialog() == DialogResult.OK)
                {
                    _rutaFotoEmpleado = ofdFotoEmpleado.FileName;
                    pbFotoEmpleado.Image = Image.FromFile(_rutaFotoEmpleado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            _estadoCliente = Estado.Nuevo;
            limpiarComponentesCliente();
            establecerEstadoFormularioCliente();
            CargarCiudades();

            _clienteMayorista = new clienteMayorista();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombreCliente.Text) ||
                string.IsNullOrEmpty(txtApellidoCliente.Text) ||
                string.IsNullOrEmpty(txtDNICliente.Text) ||
                string.IsNullOrEmpty(txtCorreoCliente.Text) ||
                string.IsNullOrEmpty(txtTelefonoCliente.Text) ||
                string.IsNullOrEmpty(txtRUC.Text) ||
                string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                MessageBox.Show("Todos los campos deben estar llenos", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _clienteMayorista.nombre = txtNombreCliente.Text;
            _clienteMayorista.apellidos = txtApellidoCliente.Text;
            _clienteMayorista.DNI = txtDNICliente.Text;
            _clienteMayorista.correo = txtCorreoCliente.Text;
            _clienteMayorista.telefono = txtTelefonoCliente.Text;
            _clienteMayorista.RUC = txtRUC.Text;
            _clienteMayorista.razonSocial = txtRazonSocial.Text;
            _clienteMayorista.direccion = textDireccion.Text;

            int resultado = _estadoCliente == Estado.Nuevo ? daoRRHH.insertarClienteMayorista(_clienteMayorista) : daoRRHH.modificarClienteMayorista(_clienteMayorista);

            if (resultado != 0)
            {
                string mensaje = _estadoCliente == Estado.Nuevo ? "Se ha registrado con éxito" : "Se ha modificado con éxito";
                MessageBox.Show(mensaje, "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_estadoCliente == Estado.Nuevo)
                {
                    txtIDCliente.Text = resultado.ToString();
                }

                _estadoCliente = Estado.Inicial;
                establecerEstadoFormularioCliente();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmBuscarClienteMayorista frm = new frmBuscarClienteMayorista();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _clienteMayorista = frm.ClienteMayoristaSeleccionado;
                txtIDCliente.Text = _clienteMayorista.idPersona.ToString();
                txtNombreCliente.Text = _clienteMayorista.nombre;
                txtApellidoCliente.Text = _clienteMayorista.apellidos;
                txtDNICliente.Text = _clienteMayorista.DNI;
                txtCorreoCliente.Text = _clienteMayorista.correo;
                txtTelefonoCliente.Text = _clienteMayorista.telefono;
                txtRazonSocial.Text = _clienteMayorista.razonSocial;
                txtRUC.Text = _clienteMayorista.RUC;
                textDireccion.Text = _clienteMayorista.direccion;
                _estadoCliente = Estado.Buscar;
                establecerEstadoFormularioCliente();
            }


        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            _estadoCliente = Estado.Modificar;
            establecerEstadoFormularioCliente();
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            DialogResult resultadoInteraccion = MessageBox.Show("¿Está seguro de que desea eliminar a este cliente mayorista?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultadoInteraccion == DialogResult.Yes)
            {
                int resultado = daoRRHH.eliminarClienteMayorista(_clienteMayorista.idPersona);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _estadoCliente = Estado.Inicial;
                    establecerEstadoFormularioCliente();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al momento de eliminar", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            _estadoCliente = Estado.Inicial;
            establecerEstadoFormularioCliente();
            limpiarComponentesEmpleado();
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void cbMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !cbMostrarContrasena.Checked;
        }

        private void txtDNIEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtDNIEmpleado.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefonoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;
                int selectionStart = textBox.SelectionStart;
                string currentText = textBox.Text;

                // Eliminar espacios en blanco
                string strippedText = currentText.Replace(" ", "");

                // Insertar espacios cada 3 dígitos
                string formattedText = string.Empty;
                for (int i = 0; i < strippedText.Length; i++)
                {
                    formattedText += strippedText[i];
                    if ((i + 1) % 3 == 0 && (i + 1) < strippedText.Length)
                    {
                        formattedText += " ";
                    }
                }

                textBox.Text = formattedText;
                textBox.SelectionStart = selectionStart + 1;
            }
            else if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDNICliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtDNICliente.Text.Length >= 8 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;
                int selectionStart = textBox.SelectionStart;
                string currentText = textBox.Text;

                // Eliminar espacios en blanco
                string strippedText = currentText.Replace(" ", "");

                // Verificar longitud máxima (11 caracteres)
                if (strippedText.Length >= 11)
                {
                    e.Handled = true;
                    return;
                }

                // Insertar espacios cada 3 dígitos
                string formattedText = string.Empty;
                for (int i = 0; i < strippedText.Length; i++)
                {
                    formattedText += strippedText[i];
                    if ((i + 1) % 3 == 0 && (i + 1) < strippedText.Length)
                    {
                        formattedText += " ";
                    }
                }

                textBox.Text = formattedText;
                textBox.SelectionStart = selectionStart + 1;
            }
            else if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (txtRUC.Text.Length >= 20 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private List<City> ciudades;

        private void CargarCiudades()
        {
            ciudades = new List<City>
                {
                new City("Lima", -12.046374, -77.042793),
                new City("Arequipa", -16.409047, -71.537450),
                new City("Trujillo", -8.109052, -79.024452),
                new City("Cusco", -13.531950, -71.967463),
                new City("Piura", -5.194490, -80.632683),
                new City("Huancayo", -12.065194, -75.204873),
                new City("Tacna", -18.014647, -70.253738),
                new City("Chimbote", -9.085518, -78.578083),
                new City("Ica", -14.068023, -75.725402)
                };
            cmbCiudades.DataSource = ciudades;
            cmbCiudades.DisplayMember = "Nombre";
            cmbCiudades.ValueMember = "Coordenadas";
        }

        private void cmbCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            City ciudadSeleccionada = (City)cmbCiudades.SelectedItem;
            ActualizarMapa(ciudadSeleccionada.Coordenadas);
        }

        private void ActualizarMapa(Coordenadas coordenadas)
        {
            gMapControl1.Overlays.Clear();

            PointLatLng ubicacion = new PointLatLng(coordenadas.Latitud, coordenadas.Longitud);
            GMapMarker marker = new GMarkerGoogle(ubicacion, GMarkerGoogleType.red_dot);

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);

            gMapControl1.Position = ubicacion;
            gMapControl1.Zoom = 10;
        }

    }
}

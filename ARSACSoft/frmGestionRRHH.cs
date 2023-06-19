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
using static GMap.NET.Entity.OpenStreetMapGraphHopperGeocodeEntity;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;
using System.Linq;
using ARSACSoft.Properties;
using System.Xml.Linq;

namespace ARSACSoft
{
    public partial class frmGestionRRHH : Form
    {
        private Estado estadoEmpleado;
        private empleado empleado;

        private Estado estadoCliente;
        private clienteMayorista clienteMayorista;

        private RRHHWSClient daoRRHH;
        private string _rutaFotoEmpleado;
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
            gMapControl1.Position = new GMap.NET.PointLatLng(-23.973875, -46.391510); // Puedes ajustar estas coordenadas a la ubicación que deseas mostrar inicialmente
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
                    if (jsonResult["results"].Count() > 0)
                    {
                        string address = jsonResult["results"][0]["formatted_address"].ToString();
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
            estadoEmpleado = Estado.Inicial;
            establecerEstadoFormularioEmpleado();
            estadoCliente = Estado.Inicial;
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
            switch (estadoEmpleado)
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
                    checkBox1.Enabled = false;
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
                    checkBox1.Enabled = true;
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
                    break;
            }
        }
        public void establecerEstadoFormularioCliente()
        {
            switch (estadoCliente)
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
            estadoEmpleado = Estado.Nuevo;
            limpiarComponentesEmpleado();
            establecerEstadoFormularioEmpleado();

            empleado = new empleado();
            empleado.sede = new sede();

        }

        private void btnBuscarSede_Click(object sender, EventArgs e)
        {
            frmBuscarSede frm = new frmBuscarSede();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                empleado.sede.idSede = frm.SedeSeleccionada.idSede;
                txtDireccionSede.Text = frm.SedeSeleccionada.direccion;
            }

        }

        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            frmBuscarEmpleados frm = new frmBuscarEmpleados();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                empleado = frm.EmpleadoSeleccionado;


                txtIDEmpleado.Text = empleado.idPersona.ToString();
                txtDNIEmpleado.Text = empleado.DNI;
                txtNombreEmpleado.Text = empleado.nombre;
                txtApellidoEmpleado.Text = empleado.apellidos;
                txtTelefonoEmpleado.Text = empleado.telefono;
                dtpFechaContratacion.Value = empleado.fechaContratacion;
                cboTipoDeEmpleado.SelectedValue = empleado.tipo.idTipoDeEmpleado;
                txtCorreoEmpleado.Text = empleado.correo;
                txtSalario.Text = empleado.salario.ToString();
                txtDireccion.Text = empleado.direccion;
                
                if (empleado.foto != null)
                {
                    MemoryStream ms = new MemoryStream(empleado.foto);
                    pbFotoEmpleado.Image = new Bitmap(ms);
                }
                txtDireccionSede.Text = empleado.sede.direccion;

                cuentaUsuario cuenta = daoRRHH.buscarCuenta(empleado.idPersona);
                if (cuenta != null)
                {
                    txtUsuario.Text = cuenta.username;
                    txtContrasena.Text = cuenta.password;
                }
                estadoEmpleado = Estado.Buscar;
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

            empleado.nombre = txtNombreEmpleado.Text;
            empleado.apellidos = txtApellidoEmpleado.Text;
            empleado.DNI = txtDNIEmpleado.Text;
            empleado.correo = txtCorreoEmpleado.Text;
            empleado.telefono = txtTelefonoEmpleado.Text;

            empleado.tipo = new tipoDeEmpleado();
            empleado.tipo.idTipoDeEmpleado = (int)cboTipoDeEmpleado.SelectedValue;

            empleado.fechaContratacion = dtpFechaContratacion.Value;
            empleado.fechaContratacionSpecified = true;

            if (!double.TryParse(txtSalario.Text, out double salario))
            {
                MessageBox.Show("El salario debe ser un número válido", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            empleado.salario = salario;
            empleado.direccion = txtDireccion.Text;

            if (!string.IsNullOrEmpty(_rutaFotoEmpleado))
            {
                try
                {
                    using (FileStream fs = new FileStream(_rutaFotoEmpleado, FileMode.Open, FileAccess.Read))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        empleado.foto = br.ReadBytes((int)fs.Length);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo: {ex.Message}", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int resultado = estadoEmpleado == Estado.Nuevo ? daoRRHH.insertarEmpleado(empleado) : daoRRHH.modificarEmpleado(empleado);

            if (resultado != 0)
            {
                cuentaUsuario nuevaCuentaUsuario = new cuentaUsuario();
                nuevaCuentaUsuario.username = txtUsuario.Text;
                nuevaCuentaUsuario.password = txtContrasena.Text;
                nuevaCuentaUsuario.idEmpleado = resultado;

                if (estadoEmpleado == Estado.Nuevo)
                {
                    try
                    {
                        //metodo de busqueda de nombre de usuario
                        /*Guardar cuenta de usuario*/
                        daoRRHH.insertarCuentaUsuario(nuevaCuentaUsuario);
                        /*Fin GuardarCuentaUsuario*/
                        txtIDEmpleado.Text = resultado.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al crear la cuenta de usuario: {ex.Message}", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (estadoEmpleado == Estado.Modificar)
                {
                    try
                    {
                        daoRRHH.actualizarCuenta(nuevaCuentaUsuario);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al modificar la contraseña: {ex.Message}", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string mensaje = estadoEmpleado == Estado.Nuevo ? "Se ha registrado con éxito" : "Se ha modificado con éxito";
                MessageBox.Show(mensaje, "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                estadoEmpleado = Estado.Inicial;
                establecerEstadoFormularioEmpleado();
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            estadoEmpleado = Estado.Modificar;
            establecerEstadoFormularioEmpleado();
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            DialogResult resultadoInteraccion = MessageBox.Show("¿Está seguro de que desea eliminar a este empleado", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultadoInteraccion == DialogResult.Yes)
            {
                int resultado = daoRRHH.eliminarEmpleado(empleado.idPersona);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoEmpleado = Estado.Inicial;
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
            estadoEmpleado = Estado.Inicial;
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
            estadoCliente = Estado.Nuevo;
            limpiarComponentesCliente();
            establecerEstadoFormularioCliente();

            clienteMayorista = new clienteMayorista();
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

            clienteMayorista.nombre = txtNombreCliente.Text;
            clienteMayorista.apellidos = txtApellidoCliente.Text;
            clienteMayorista.DNI = txtDNICliente.Text;
            clienteMayorista.correo = txtCorreoCliente.Text;
            clienteMayorista.telefono = txtTelefonoCliente.Text;
            clienteMayorista.RUC = txtRUC.Text;
            clienteMayorista.razonSocial = txtRazonSocial.Text;

            int resultado = estadoCliente == Estado.Nuevo ? daoRRHH.insertarClienteMayorista(clienteMayorista) : daoRRHH.modificarClienteMayorista(clienteMayorista);

            if (resultado != 0)
            {
                string mensaje = estadoCliente == Estado.Nuevo ? "Se ha registrado con éxito" : "Se ha modificado con éxito";
                MessageBox.Show(mensaje, "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (estadoCliente == Estado.Nuevo)
                {
                    txtIDCliente.Text = resultado.ToString();
                }

                estadoCliente = Estado.Inicial;
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
                clienteMayorista = frm.ClienteMayoristaSeleccionado;
                txtIDCliente.Text = clienteMayorista.idPersona.ToString();
                txtNombreCliente.Text = clienteMayorista.nombre;
                txtApellidoCliente.Text = clienteMayorista.apellidos;
                txtDNICliente.Text = clienteMayorista.DNI;
                txtCorreoCliente.Text = clienteMayorista.correo;
                txtTelefonoCliente.Text = clienteMayorista.telefono;
                txtRazonSocial.Text = clienteMayorista.razonSocial;
                txtRUC.Text = clienteMayorista.RUC;

                estadoCliente = Estado.Buscar;
                establecerEstadoFormularioCliente();
            }


        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            estadoCliente = Estado.Modificar;
            establecerEstadoFormularioCliente();
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            DialogResult resultadoInteraccion = MessageBox.Show("¿Está seguro de que desea eliminar a este cliente mayorista?", "Mensaje de Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultadoInteraccion == DialogResult.Yes)
            {
                int resultado = daoRRHH.eliminarClienteMayorista(clienteMayorista.idPersona);
                if (resultado != 0)
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Mensaje de Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    estadoCliente = Estado.Inicial;
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
            estadoCliente = Estado.Inicial;
            establecerEstadoFormularioCliente();
            limpiarComponentesEmpleado();
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // solo permite un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !checkBox1.Checked;
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
    }
}

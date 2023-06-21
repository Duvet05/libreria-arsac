using ARSACSoft.RRHHWS;
using GMap.NET.MapProviders;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARSACSoft
{
    public partial class frmCrearCliente : Form
    {
        private clienteMayorista _clienteMayorista = new clienteMayorista();

        private clienteMayorista clienteMayoristaSeleccionado;

        private RRHHWSClient daoRRHH;
        public frmCrearCliente()
        {
            InitializeComponent();
            ConfigureForm();
            InitializeMaps();
        }
        public clienteMayorista ClienteMayoristaSeleccionado { get => clienteMayoristaSeleccionado; set => clienteMayoristaSeleccionado = value; }

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
            limpiarComponentesCliente();
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarComponentesCliente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarComponentesCliente();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

            int resultado = daoRRHH.insertarClienteMayorista(_clienteMayorista);
            if (resultado != 0)
            {
                string mensaje = "Se ha registrado con éxito";
                MessageBox.Show(mensaje, "Mensaje de confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clienteMayoristaSeleccionado = _clienteMayorista;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Ha ocurrido un error con la operación", "Mensaje de error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDNICliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Asegurarse de que solo se ingresen números y el formato sea correcto (8 dígitos como máximo)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text + e.KeyChar;

                // Verificar el formato (8 dígitos como máximo)
                if (!Regex.IsMatch(text, @"^\d{0,8}$"))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtTelefonoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            // Asegurarse de que solo se ingresen números y el formato sea correcto (11 dígitos)
            if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode))
            {
                e.SuppressKeyPress = true;
            }
            else if (char.IsDigit((char)e.KeyCode))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text + (char)e.KeyCode;

                // Verificar el formato (11 dígitos)
                if (!Regex.IsMatch(text, @"^\d{0,11}$"))
                {
                    e.SuppressKeyPress = true;
                }
            }
        }

        private void txtRUC_KeyDown(object sender, KeyEventArgs e)
        {
            // Asegurarse de que solo se ingresen números y el formato sea correcto (20 dígitos)
            if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode))
            {
                e.SuppressKeyPress = true;
            }
            else if (char.IsDigit((char)e.KeyCode))
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text + (char)e.KeyCode;

                // Verificar el formato (20 dígitos)
                if (!Regex.IsMatch(text, @"^\d{0,20}$"))
                {
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}

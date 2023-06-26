using ARSACSoft.RRHHWS;
using GMap.NET.MapProviders;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;

namespace ARSACSoft
{
    public partial class frmBursarDireccion : Form
    {
        private string _direccionSeleccionada;
        private RRHHWSClient daoRRHH = new RRHHWSClient();

        public frmBursarDireccion()
        {
            InitializeComponent();
            InitializeMaps();
        }
        public string direccionSeleccionada { get => _direccionSeleccionada; set => _direccionSeleccionada = value; }

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

        private async Task<GMap.NET.PointLatLng> GetCoordinatesAsync(string address)
        {
            string apiKey = "AIzaSyBgyKAoWNGBGh8QkqYaxlsiale87i-sstI"; // Reemplaza "TU_API_KEY" con tu clave de API de Google Maps

            // Codifica la dirección para que sea segura para usar en una URL
            string encodedAddress = Uri.EscapeDataString(address);

            string requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedAddress}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject jsonResult = JObject.Parse(content);

                    if (jsonResult.TryGetValue("results", out var results) && results.Any())
                    {
                        // Obtén las coordenadas de la primera coincidencia de dirección
                        double lat = results[0]?.Value<JObject>("geometry")?.Value<JObject>("location")?.Value<double>("lat") ?? 0;
                        double lng = results[0]?.Value<JObject>("geometry")?.Value<JObject>("location")?.Value<double>("lng") ?? 0;

                        return new GMap.NET.PointLatLng(lat, lng);
                    }
                }
                else
                {
                    // Manejar el caso de respuesta no exitosa
                    // ...
                }
            }

            return new GMap.NET.PointLatLng(-12.046374, -77.042793);
        }

        private async void gMapControl1_OnMapClick(GMap.NET.PointLatLng point, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    string address = await GetAddressAsync(point.Lat, point.Lng);
                    textDireccion.Text = address;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la dirección: " + ex.Message);
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                GMap.NET.PointLatLng point = gMapControl1.Position;
                string address = await GetAddressAsync(point.Lat, point.Lng);
                textDireccion.Text = address;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la dirección: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textDireccion.Text))
            {
                _direccionSeleccionada = textDireccion.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una dirección.");
            }
        }

        private async void btnBuscarSede_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textDireccion.Text))
            {
                string address = textDireccion.Text;
                GMap.NET.PointLatLng coordinates = await GetCoordinatesAsync(address);

                if (coordinates != null)
                {
                    // Hacer algo con las coordenadas (latitud y longitud)
                    double lat = coordinates.Lat;
                    double lng = coordinates.Lng;

                    // Actualizar la posición del mapa
                    gMapControl1.Position = coordinates;
                }
                else
                {
                    // Manejar el caso de dirección no encontrada
                    // ...
                }
            }
            else
            {
                // Manejo de error cuando no hay dirección ingresada
            }
        }
    }
}

using System;
using System.Windows.Forms;

namespace ARSACSoft
{
    public class City
    {
        private string Nombre { get; }
        public Coordenadas Coordenadas { get; }

        public City(string nombre, double latitud, double longitud)
        {
            Nombre = nombre;
            Coordenadas = new Coordenadas(latitud, longitud);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }

    // Clase auxiliar para representar las coordenadas de una ubicación
    public class Coordenadas
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public Coordenadas(double latitud, double longitud)
        {
            Latitud = latitud;
            Longitud = longitud;
        }
    }
}

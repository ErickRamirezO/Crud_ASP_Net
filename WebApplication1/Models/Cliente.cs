using System;

namespace WebApplication1.Models
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string Cedula { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
    }
}

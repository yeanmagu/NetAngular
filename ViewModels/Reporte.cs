using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetPrueba.ViewModels
{
    public class Reporte
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public string Empleado { get; set; }
    }
}

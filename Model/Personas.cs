using System;
using System.Collections.Generic;

namespace NetPrueba.Model
{
    public partial class Personas
    {
        public Personas()
        {
            AutoresLibros = new HashSet<AutoresLibros>();
            VentasCliente = new HashSet<Ventas>();
            VentasEmpleado = new HashSet<Ventas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string AnioNacimiento { get; set; }
        public string AnioMuerte { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int TipoId { get; set; }

        public virtual Tipo Tipo { get; set; }
        public virtual ICollection<AutoresLibros> AutoresLibros { get; set; }
        public virtual ICollection<Ventas> VentasCliente { get; set; }
        public virtual ICollection<Ventas> VentasEmpleado { get; set; }
    }
}

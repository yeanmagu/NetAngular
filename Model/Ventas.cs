using System;
using System.Collections.Generic;

namespace NetPrueba.Model
{
    public partial class Ventas
    {
        public Ventas()
        {
            DetalleVenta = new HashSet<DetalleVenta>();
        }

        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int EmpleadoId { get; set; }

        public virtual Personas Cliente { get; set; }
        public virtual Personas Empleado { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}

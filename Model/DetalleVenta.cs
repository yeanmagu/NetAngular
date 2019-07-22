using System;
using System.Collections.Generic;

namespace NetPrueba.Model
{
    public partial class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int LibroId { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public virtual Libros Libro { get; set; }
        public virtual Ventas Venta { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace NetPrueba.Model
{
    public partial class Inventario
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int CantidadAnterior { get; set; }
        public int CantidadActual { get; set; }
    }
}

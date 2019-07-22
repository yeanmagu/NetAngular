using System;
using System.Collections.Generic;

namespace NetPrueba.Model
{
    public partial class AutoresLibros
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public int AutorId { get; set; }

        public virtual Personas Autor { get; set; }
        public virtual Libros Libro { get; set; }
    }
}

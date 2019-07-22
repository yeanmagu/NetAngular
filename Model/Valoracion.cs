using System;
using System.Collections.Generic;

namespace NetPrueba.Model
{
    public partial class Valoracion
    {
        public Valoracion()
        {
            Libros = new HashSet<Libros>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Libros> Libros { get; set; }
    }
}

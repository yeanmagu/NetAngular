using System;
using System.Collections.Generic;

namespace NetPrueba.Model
{
    public partial class Tipo
    {
        public Tipo()
        {
            Personas = new HashSet<Personas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Personas> Personas { get; set; }
    }
}

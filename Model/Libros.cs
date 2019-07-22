using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetPrueba.Model
{
    public partial class Libros
    {
        public Libros()
        {
            AutoresLibros = new HashSet<AutoresLibros>();
            DetalleVenta = new HashSet<DetalleVenta>();
        }


        public int Id { get; set; }
        [Required]
        [MinLength(4)]

        public string Titulo { get; set; }
        [Required]
        

        public DateTime FechaPublicacion { get; set; }
        [Required]
        

        public string Edicion { get; set; }
        [Required]        
        public decimal Costo { get; set; }
        [Required]
        public decimal PrecioMinorista { get; set; }
        public int ValoracionId { get; set; }
        public string DescripcionValoracion { get; set; }

        public virtual Valoracion Valoracion { get; set; }
        public virtual ICollection<AutoresLibros> AutoresLibros { get; set; }
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPrueba.Model;
using NetPrueba.ViewModels;

namespace NetPrueba.Controllers
{
    [Route("api/[controller]")]
    public class SellController : Controller
    {
        private DataContext _context;
        public SellController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("[action]")]
        public IActionResult Post([FromBody]Filters obj)
        {

            if (obj.FechaInicial != null)
            {
                if (obj.FechaFin!=null)
                {
                    if (string.IsNullOrEmpty(obj.Cliente))
                    {
                        obj.Cliente = "";
                    }
                    //var result =_context.Ventas
                    //    .Include(v=>v.DetalleVenta)
                    //        .ThenInclude(d=>d.Libro)
                    //    .Include(v=>v.Cliente)
                    //    .Include(v => v.Empleado)
                    //    .Where(m => (m.Fecha >= obj.FechaInicial && m.Fecha <= obj.FechaFin) || m.Cliente.Nombre.Contains(obj.Cliente) ).ToList();
                    var List = (from m in _context.DetalleVenta where (m.Venta.Fecha >= obj.FechaInicial && m.Venta.Fecha <= obj.FechaFin)  && (m.Venta.Cliente.Nombre.Contains(obj.Cliente) || obj.Cliente=="")
                                 select new Reporte {
                                     Nombre = m.Venta.Cliente.Nombre,
                                     Apellidos=m.Venta.Cliente.Apellido,
                                     Telefono=m.Venta.Cliente.Telefono,
                                     Correo=m.Venta.Cliente.Direccion,
                                     Titulo=m.Libro.Titulo,
                                     Fecha =m.Venta.Fecha,
                                     Valor=m.Precio,
                                     Empleado=m.Venta.Empleado.Nombre + " " +m.Venta.Empleado.Apellido 
                                 });
                    

                    
                    return Ok(List);
                }
            }


            return BadRequest(obj);

        }



    }
}

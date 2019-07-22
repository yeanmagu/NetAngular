using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetPrueba.Model;

namespace NetPrueba.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private DataContext _context;
        public BooksController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var result = _context.Libros.OrderBy(m=>m.Titulo);

            return Ok(result); 
        }
        [HttpPost("[action]")]

        public IActionResult Post([FromBody]Libros obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Libros.Add(obj);
            _context.SaveChanges();

            return Ok(obj);

        }



        [HttpGet("[action]")]

        public IActionResult Get(int id)
        {

            var Libro = _context.Libros.Find(id);
            return Ok(Libro);

        }

        [HttpPut("[action]")]

        public IActionResult Put(int id, [FromBody] Libros obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (id != obj.Id)
                {
                    return BadRequest();
                }
                _context.Entry(obj).State = EntityState.Modified;
                try
                {
                    _context.SaveChanges();
                    return Ok(obj);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]       
        
        public IActionResult Delete(int id)
        {
            var libro = _context.Libros.Find(id);
            if (libro == null)
            {
                return NotFound();
            }
            _context.Libros.Remove(libro);
            _context.SaveChanges();
            return Ok(libro);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lib = await _context.Libros.FindAsync(id);
            _context.Libros.Remove(lib);
            await _context.SaveChangesAsync();
            return Ok();
        }
        private bool Exists(int id)
        {
            var r = _context.Libros.Find(id);
            if (_context.Libros.Find(id).Id>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

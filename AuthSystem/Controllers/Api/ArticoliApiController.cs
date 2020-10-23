using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticoliApiController : ControllerBase
    {
        private readonly NContext _context;

        public ArticoliApiController(NContext context)
        {
            _context = context;
        }

        // GET: api/<ArticoliApiController>
        [HttpGet]
        public IEnumerable<Articolo> Get()
        {
            return _context.Articoli;
        }

        // GET api/<ArticoliApiController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetArticolo/{id}")]
        public async Task<ActionResult<Articolo>> GetArticolo(int id)
        {
            var articolo = await _context.Articoli.FirstOrDefaultAsync(m => m.IdArticolo == id);

            if (articolo == null)
            {
                return NotFound();
            }
            return articolo;
        }

        // GET api/<ArticoliApiController>/nome
        [HttpGet]
        [Route("GetNomeArticolo/{nome}")]
        public async Task<ActionResult<Articolo>> GetNomeArticolo(string nome)
        {
            var articolo = await _context.Articoli
               .FirstOrDefaultAsync(m => m.NomeArticolo == nome);
            if (articolo == null)
            {
                return NotFound();
            }

            return articolo;
        }


        [HttpPost]
        // POST api/<ArticoliApiController>
        public async Task<IActionResult> Post([FromBody] Articolo articolo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Articoli.Add(articolo);
            await _context.SaveChangesAsync();
            return Ok(articolo);
        }

        // PUT api/<ArticoliApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Articolo articolo)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articolo.IdArticolo)
            {
                return BadRequest();
            }

            _context.Entry(articolo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticoloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<ArticoliApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Articolo>> DeletetArticolo(int? id)
        {
            var articolo = await _context.Articoli
               .FirstOrDefaultAsync(m => m.IdArticolo == id);

            if (id == null)
            {
                return NotFound();
            }


            if (articolo == null)
            {
                return NotFound();
            }
            _context.Articoli.Remove(articolo);
            await _context.SaveChangesAsync();

            return articolo;
        }

        private bool ArticoloExists(int id)
        {
            return _context.Articoli.Any(e => e.IdArticolo == id);
        }
    }
}

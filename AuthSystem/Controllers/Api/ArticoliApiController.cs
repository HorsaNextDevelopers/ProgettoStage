using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.ApiModels;
using AuthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthSystem.Controllers.Api
{
    [Authorize]
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
        public IActionResult Get()
        {
            return this.Ok( _context.Articoli.Select(a => new ArticoloApiModel
            {
                IdArticolo = a.IdArticolo,
                NomeArticolo = a.NomeArticolo,
                Descrizione = a.Descrizione
            }));
        }

        // GET api/<ArticoliApiController>/5
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetArticolo/{id}")]
        public async Task<ActionResult<Articolo>> GetArticolo(int id)
        {
            var articolo = await _context.Articoli.SingleOrDefaultAsync(m => m.IdArticolo == id);

            if (articolo == null)
            {
                return NotFound();
            }
            return this.Ok(new ArticoloApiModel
            {
                IdArticolo = articolo.IdArticolo,
                NomeArticolo = articolo.NomeArticolo,
                Descrizione = articolo.Descrizione
            });
        }

        // GET api/<ArticoliApiController>/nome
        [HttpGet]
        [Route("GetNomeArticolo/{nome}")]
        public IActionResult GetNomeArticolo(string nome)
        {
            var articoli =_context.Articoli
               .Where(m => m.NomeArticolo.ToLower().Contains(nome.ToLower()));
            if (articoli == null)
            {
                return NotFound();
            }

            return this.Ok(articoli.ToList());
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticoloApiModel articolo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
          
            _context.Articoli.Add(new Articolo 
            { 
                Descrizione = articolo.Descrizione,
                NomeArticolo = articolo.NomeArticolo,
            });
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
        public async Task<ActionResult<Articolo>> DeleteArticolo(int id)
        {
            var articolo = await _context.Articoli
               .FirstOrDefaultAsync(m => m.IdArticolo == id);
                       
            if (articolo == null)
            {
                return NotFound();
            }
            _context.Articoli.Remove(articolo);
            await _context.SaveChangesAsync();

            return this.Ok(articolo);
        }

        private bool ArticoloExists(int id)
        {
            return _context.Articoli.Any(e => e.IdArticolo == id);
        }
    }
}

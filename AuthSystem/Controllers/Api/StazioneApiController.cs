using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class StazioneApiController : ControllerBase
    {

        private readonly NContext _context;

        public StazioneApiController(NContext context)
        {
            _context = context;
        }

        // GET: api/<StazioneApiController>
        [HttpGet]
        public IEnumerable<Stazione> Get()
        {
            return _context.Stazioni;
        }

        // GET api/<StazioneApiController>/5
        [HttpGet]
        [Route("GetStazione/{id}")]
        public async Task<ActionResult<Stazione>> GetStazione(int id)
        {
            var stazione = await _context.Stazioni.SingleOrDefaultAsync(m => m.IdNomeStazione == id);

            if (stazione == null)
            {
                return NotFound();
            }
            return this.Ok(stazione);
        }

        [HttpGet]
        [Route("GetNomeStazione/{nome}")]
        public IActionResult GetNomeStazione(string nome)
        {
            var stazioni = _context.Stazioni
               .Where(m => m.NomeStazione.ToLower().Contains(nome.ToLower()));


            if (stazioni.Any())
            {
                return NotFound();
            }

            return this.Ok(stazioni.ToList());
        }

        // POST api/<StazioneApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]  Stazione stazione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            stazione.IdNomeStazione = 0;
            _context.Stazioni.Add(stazione);
            await _context.SaveChangesAsync();
            return Ok(stazione);
        }

        // PUT api/<StazioneApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Stazione stazione)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stazione.IdNomeStazione)
            {
                return BadRequest();
            }

            _context.Entry(stazione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StazioneExists(id))
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

        // DELETE api/<StazioneApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stazione>> DeleteStazione(int id)
        {
            var stazione = await _context.Stazioni
               .FirstOrDefaultAsync(m => m.IdNomeStazione == id);

            if (stazione == null)
            {
                return NotFound();
            } 
            _context.Stazioni.Remove(stazione);
            await _context.SaveChangesAsync();

            return this.Ok(stazione);
        }
        private bool StazioneExists(int id)
        {
            return _context.Stazioni.Any(m => m.IdNomeStazione == id);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;

namespace AuthSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotazioneApiController : ControllerBase
    {
        private readonly NContext _context;

        public PrenotazioneApiController(NContext context)
        {
            _context = context;
        }

        // GET: api/PrenotazioneApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prenotazione>>> GetPrenotazioni()
        {
            return await _context.Prenotazioni.ToListAsync();
        }

        // GET: api/PrenotazioneApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prenotazione>> GetPrenotazione(int id)
        {
            var prenotazione = await _context.Prenotazioni.FindAsync(id);

            if (prenotazione == null)
            {
                return NotFound();
            }

            return prenotazione;
        }

        // PUT: api/PrenotazioneApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrenotazione(int id, Prenotazione prenotazione)
        {
            if (id != prenotazione.IdPrenotazione)
            {
                return BadRequest();
            }

            _context.Entry(prenotazione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrenotazioneExists(id))
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

        // POST: api/PrenotazioneApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Prenotazione>> PostPrenotazione(Prenotazione prenotazione)
        {
            _context.Prenotazioni.Add(prenotazione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrenotazione", new { id = prenotazione.IdPrenotazione }, prenotazione);
        }

        // DELETE: api/PrenotazioneApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prenotazione>> DeletePrenotazione(int id)
        {
            var prenotazione = await _context.Prenotazioni.FindAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            _context.Prenotazioni.Remove(prenotazione);
            await _context.SaveChangesAsync();

            return prenotazione;
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazioni.Any(e => e.IdPrenotazione == id);
        }
    }
}

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
    public class PrenotazioneApiController : ControllerBase
    {
        private readonly NContext _context;

        public PrenotazioneApiController(NContext context)
        {
            _context = context;
        }

        // GET: api/<LineeApiController>
        [HttpGet]
        public IEnumerable<Prenotazione> Get()
        {
            return _context.Prenotazioni;
        }

        // GET api/<LineeApiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prenotazione = await _context.Prenotazioni
                .FirstOrDefaultAsync(m => m.IdPrenotazione == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return this.Ok(prenotazione);
        }

        // POST api/<LineeApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Prenotazione prenotazione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            prenotazione.IdPrenotazione = 0;
            _context.Prenotazioni.Add(prenotazione);
            await _context.SaveChangesAsync();
            return Ok(prenotazione);
        }

        [HttpGet]
        [Route("GetDataPrenotazione/{Data}")]
        public IActionResult GetDataPrenotazione(DateTime data)
        {
            var prenotazione = _context.Prenotazioni.Where(m => m.Data == data).ToList();
            if (prenotazione == null)
            {
                return NotFound();
            }
            return this.Ok(prenotazione.ToList());
        }

        // PUT api/<LineeApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Prenotazione prenotazione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prenotazione.IdPrenotazione)
            {
                return BadRequest();
            }

            _context.Update(prenotazione);
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

            return this.Ok(prenotazione);
        }

        // DELETE api/<LineeApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Prenotazione>> Delete(int id)
        {
            var prenotazione = await _context.Prenotazioni.
                FirstOrDefaultAsync(m => m.IdPrenotazione == id);

            if (prenotazione == null)
            {
                return NotFound();
            }
            _context.Prenotazioni.Remove(prenotazione);
            await _context.SaveChangesAsync();

            return this.Ok(prenotazione);
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazioni.Any(e => e.IdPrenotazione == id);
        }
    }
}

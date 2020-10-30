using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using AuthSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthSystem.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentiApiController : ControllerBase
    {
        private readonly NContext _context;

        public ComponentiApiController(NContext context)
        {
            _context = context;
        }
        // GET: api/<ComponentiApiController>
        [HttpGet]
        public IEnumerable<ComponenteArticolo> Get()
        {
            return _context.ComponentiArticolo;
        }

        // GET api/<ComponentiApiController>/5
        [HttpGet]
        [Route("GetComponente/{id}")]
        public async Task<ActionResult<ComponenteArticolo>> GetComponente(int id)
        {
            var componente = await _context.ComponentiArticolo.SingleOrDefaultAsync(m => m.IdComponente == id);

            if (componente == null)
            {
                return NotFound();
            }
            return this.Ok(componente);
        }

        [HttpGet]
        [Route("GetComponenteByArticolo/{idArticolo}")]
        public IActionResult GetComponenteByArticolo(int idArticolo)
        {
            var componenti = _context.ComponentiArticolo.Where(m => m.IdArticolo == idArticolo);

            return this.Ok(componenti);
        }



        [HttpGet]
        [Route("GetNomeComponente/{nome}")]
        public IActionResult GetNomeComponente(string nome)
        {
            var componente = _context.ComponentiArticolo
               .Where(m => m.NomeComponente.ToLower().Contains(nome.ToLower()));
            if (componente.Any())
            {
                return NotFound();
            }

            return this.Ok(componente.ToList());
        }
      

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ComponenteArticolo componente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            componente.IdComponente = 0;
            _context.ComponentiArticolo.Add(componente);
            await _context.SaveChangesAsync();
            return Ok(componente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ComponenteArticolo componente)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != componente.IdComponente)
            {
                return BadRequest();
            }

            _context.Entry(componente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteExists(id))
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

        // DELETE api/<ComponentiApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComponenteArticolo>> DeleteComponente(int id)
        {
            var componente = await _context.ComponentiArticolo
               .FirstOrDefaultAsync(m => m.IdComponente == id);

            if (componente == null)
            {
                return NotFound();
            }
            _context.ComponentiArticolo.Remove(componente);
            await _context.SaveChangesAsync();

            return this.Ok(componente);
        }

        private bool ComponenteExists(int id)
        {
            return _context.ComponentiArticolo.Any(e => e.IdComponente == id);
        }
    }
}

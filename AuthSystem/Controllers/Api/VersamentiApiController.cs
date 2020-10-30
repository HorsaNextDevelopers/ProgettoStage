using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthSystem.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VersamentiApiController : ControllerBase
    {
        private readonly NContext _context;

        public VersamentiApiController(NContext context)
        {
            _context = context;
        }
        // GET: api/<VersamentiApiController>
        [HttpGet]
        public IEnumerable<Versamento> Get()
        {
            return _context.Versamenti;
        }

        // GET api/<VersamentiApiController>/5
        [HttpGet]
        [Route("GetVersamento/{id}")]
        public async Task<ActionResult<Versamento>> GetVersamento(int id) 
        {
            var versamento = await _context.Versamenti
                .SingleOrDefaultAsync(m => m.IdVersamento == id);

            if (versamento == null)
            {
                return NotFound();
            }
            return this.Ok(versamento);
        }

        // POST api/<VersamentiApiController>

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Versamento versamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            versamento.IdVersamento = 0;
            _context.Versamenti.Add(versamento);
            await _context.SaveChangesAsync();
            return Ok(versamento);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Versamento versamento)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != versamento.IdVersamento)
            {
                return BadRequest();
            }

            _context.Entry(versamento).State = EntityState.Modified;

            try

            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersamentoExists(id))
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

        // DELETE api/<VersamentiApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Versamento>> DeleteVersamento(int id)
        {
            var versamento = await _context.Versamenti
               .FirstOrDefaultAsync(m => m.IdVersamento == id);

            if (versamento == null)
            {
                return NotFound();
            }
            _context.Versamenti.Remove(versamento);
            await _context.SaveChangesAsync();

            return this.Ok(versamento);
        }

        private bool VersamentoExists(int id)
        {
            return _context.Versamenti.Any(e => e.IdVersamento == id);
        }
    }
}

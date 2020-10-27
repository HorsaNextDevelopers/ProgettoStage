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
    public class LineeApiController : ControllerBase
    {
        private readonly NContext _context;

        public LineeApiController(NContext context)
        {
            _context = context;
        }

        // GET: api/<LineeApiController>
        [HttpGet]
        public IEnumerable<Linea> Get()
        {
            return _context.Linee;
        }

        // GET api/<LineeApiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var linea = await _context.Linee
                .FirstOrDefaultAsync(m => m.IdLinea == id);
            if (linea == null)
            {
                return NotFound();
            }

            return this.Ok(linea);
        }

        // POST api/<LineeApiController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Linea linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            linea.IdLinea = 0;
            _context.Linee.Add(linea);
            await _context.SaveChangesAsync();
            return Ok(linea);
        }

        // PUT api/<LineeApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Linea linea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linea.IdLinea)
            {
                return BadRequest();
            }

            _context.Update(linea);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            return this.Ok(linea);
        }

        // DELETE api/<LineeApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Linea>> Delete(int id)
        {
            var linea = await _context.Linee.
                FirstOrDefaultAsync(m => m.IdLinea == id);

            if (linea == null)
            {
                return NotFound();
            }
            _context.Linee.Remove(linea);
            await _context.SaveChangesAsync();

            return this.Ok(linea);
        }

        private bool LineaExists(int id)
        {
            return _context.Linee.Any(e => e.IdLinea == id);
        }
    }
}

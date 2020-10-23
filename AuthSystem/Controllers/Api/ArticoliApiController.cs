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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArticoliApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Produces("application/json")]
        [Consumes("application/json")]
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticoliApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

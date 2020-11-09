using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthSystem.ApiModel;
using AuthSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

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
        public async Task<IActionResult> Post(DateTime data, string nomePostazione)
        {
            var postazioneScelta = _context.Postazioni.SingleOrDefault(p => p.NomePostazione.Equals(nomePostazione));

            if (postazioneScelta == null)
            {
                return Ok(new ApiResult<Prenotazione>()
                {
                    Ok = false,
                    Message = "Postazione inesistente!"
                });
            }

            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var prenotazioneEsistente = _context.Prenotazioni.Any(p => p.Data == data && p.IdPostazione == postazioneScelta.IdPostazione);

            if (prenotazioneEsistente)
            {
                return Ok(new ApiResult<Prenotazione>()
                {
                    Ok = false,
                    Message = "Questo posto è stato già prenotato!"
                });
            }

            var dataes = _context.Prenotazioni.Any(p => p.Data == data && p.IdAspNetUsers == userid);

            if (dataes)
            {
                return Ok(new ApiResult<Prenotazione>()
                {
                    Ok = false,
                    Message = "Hai già effettuato un'altra prenotazione, non puoi effettuare più di una prenotazione nello stesso giorno!"
                });
            }

            var prenotazione = new Prenotazione
            {
                IdAspNetUsers = userid,
                Data = data,
                IdPostazione = postazioneScelta.IdPostazione,
                IdPrenotazione = 0
            };

            _context.Prenotazioni.Add(prenotazione);
            await _context.SaveChangesAsync();
            return Ok(new ApiResult<Prenotazione>()
            {
                Ok = true,
                DataResult = prenotazione
            });
        }

        [HttpGet]
        [Route("GetDataPrenotazione/{data}")]
        public IActionResult GetDataPrenotazione(DateTime data)
        {
            var prenotazioni = _context.Prenotazioni.Where(m => m.Data == data)
                .Include(p => p.Postazioni)
                .Include(p => p.AspNetUsers)
                .ToList();

            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return this.Ok(prenotazioni.Select(p => new
            {
                p.Postazioni.NomePostazione,
                p.Data,
                sonoIo = p.IdAspNetUsers.Equals(userid),
                nomeUtente = p.AspNetUsers.FirstName != null
                    ? $"{p.AspNetUsers.FirstName} {p.AspNetUsers.LastName}"
                    : p.AspNetUsers.Email
            }).ToList());
        }

        // DELETE api/<LineeApiController>/5, 2020-11-09
        [HttpDelete("{nomePostazione}/{data}")]
        public async Task<ActionResult<Prenotazione>> Delete(string nomePostazione, DateTime data)
        {
            var userid = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var prenotazione = await _context.Prenotazioni.
                FirstOrDefaultAsync(m => m.Postazioni.NomePostazione == nomePostazione && m.Data == data && m.IdAspNetUsers == userid);


            if (prenotazione == null)
            {
                return Ok(new ApiResult<Prenotazione>()
                {
                    Ok = false,
                    Message = "Non puoi cancellare la prenotazione di un altro utente!"
                });
            }

            //controllo data
            if (data < DateTime.Today)
            {
                return Ok(new ApiResult<Prenotazione>()
                {
                    Ok = false,
                    Message = "Non puoi cancellare una prenotazione passata!"
                });
            }

            _context.Prenotazioni.Remove(prenotazione);
            await _context.SaveChangesAsync();

            return Ok(new ApiResult<Prenotazione>()
            {
                Ok = true,
                DataResult = prenotazione
            });
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazioni.Any(e => e.IdPrenotazione == id);
        }
    }
}
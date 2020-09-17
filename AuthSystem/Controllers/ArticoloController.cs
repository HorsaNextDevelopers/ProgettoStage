using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;

namespace AuthSystem.Controllers
{
    public class ArticoloController : Controller
    {
        private readonly NContext _context;

        public ArticoloController(NContext context)
        {
            _context = context;
        }

        // GET: Articoloe
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articoli.ToListAsync());
        }

        // GET: Articoloe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articolo = await _context.Articoli
                .FirstOrDefaultAsync(m => m.IdArticolo == id);
            if (articolo == null)
            {
                return NotFound();
            }

            return View(articolo);
        }

        // GET: Articoloe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articoloe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArticolo,NomeArticolo,Descrizione")] Articolo articolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articolo);
        }

        // GET: Articoloe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articolo = await _context.Articoli.FindAsync(id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }

        // POST: Articoloe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArticolo,NomeArticolo,Descrizione")] Articolo articolo)
        {
            if (id != articolo.IdArticolo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticoloExists(articolo.IdArticolo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(articolo);
        }

        // GET: Articoloe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articolo = await _context.Articoli
                .FirstOrDefaultAsync(m => m.IdArticolo == id);
            if (articolo == null)
            {
                return NotFound();
            }

            return View(articolo);
        }

        // POST: Articoloe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articolo = await _context.Articoli.FindAsync(id);
            _context.Articoli.Remove(articolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticoloExists(int id)
        {
            return _context.Articoli.Any(e => e.IdArticolo == id);
        }
    }
}

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
    public class StazioneController : Controller
    {
        private readonly NContext _context;

        public StazioneController(NContext context)
        {
            _context = context;
        }

        // GET: Stazione
        public async Task<IActionResult> Index()
        {
            var nContext = _context.Stazioni.Include(s => s.Linee);
            return View(await nContext.ToListAsync());
        }

        // GET: Stazione/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stazione = await _context.Stazioni
                .Include(s => s.Linee)
                .FirstOrDefaultAsync(m => m.IdNomeStazione == id);
            if (stazione == null)
            {
                return NotFound();
            }

            return View(stazione);
        }

        // GET: Stazione/Create
        public IActionResult Create()
        {
            ViewData["IdLinea"] = new SelectList(_context.Linee, "IdLinea", "NomeLinea");
            return View();
        }

        // POST: Stazione/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNomeStazione,NomeStazione,IdLinea")] Stazione stazione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLinea"] = new SelectList(_context.Linee, "IdLinea", "NomeLinea", stazione.IdLinea);
            return View(stazione);
        }

        // GET: Stazione/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stazione = await _context.Stazioni.FindAsync(id);
            if (stazione == null)
            {
                return NotFound();
            }
            ViewData["IdLinea"] = new SelectList(_context.Linee, "IdLinea", "NomeLinea", stazione.IdLinea);
            return View(stazione);
        }

        // POST: Stazione/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNomeStazione,NomeStazione,IdLinea")] Stazione stazione)
        {
            if (id != stazione.IdNomeStazione)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stazione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StazioneExists(stazione.IdNomeStazione))
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
            ViewData["IdLinea"] = new SelectList(_context.Linee, "IdLinea", "NomeLinea", stazione.IdLinea);
            return View(stazione);
        }

        // GET: Stazione/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stazione = await _context.Stazioni
                .Include(s => s.Linee)
                .FirstOrDefaultAsync(m => m.IdNomeStazione == id);
            if (stazione == null)
            {
                return NotFound();
            }

            return View(stazione);
        }

        // POST: Stazione/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stazione = await _context.Stazioni.FindAsync(id);
            _context.Stazioni.Remove(stazione);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StazioneExists(int id)
        {
            return _context.Stazioni.Any(e => e.IdNomeStazione == id);
        }
    }
}

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
    public class ArticolisController : Controller
    {
        private readonly NContext _context;

        public ArticolisController(NContext context)
        {
            _context = context;
        }

        // GET: Articolis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Articolis.ToListAsync());
        }

        // GET: Articolis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articoli = await _context.Articolis
                .FirstOrDefaultAsync(m => m.Id_articolo == id);
            if (articoli == null)
            {
                return NotFound();
            }

            return View(articoli);
        }

        // GET: Articolis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articolis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_articolo,Nome_Articolo,Descrizione,Tempo_produzione")] Articoli articoli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(articoli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articoli);
        }

        // GET: Articolis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articoli = await _context.Articolis.FindAsync(id);
            if (articoli == null)
            {
                return NotFound();
            }
            return View(articoli);
        }

        // POST: Articolis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_articolo,Nome_Articolo,Descrizione,Tempo_produzione")] Articoli articoli)
        {
            if (id != articoli.Id_articolo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(articoli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticoliExists(articoli.Id_articolo))
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
            return View(articoli);
        }

        // GET: Articolis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articoli = await _context.Articolis
                .FirstOrDefaultAsync(m => m.Id_articolo == id);
            if (articoli == null)
            {
                return NotFound();
            }

            return View(articoli);
        }

        // POST: Articolis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var articoli = await _context.Articolis.FindAsync(id);
            _context.Articolis.Remove(articoli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticoliExists(int id)
        {
            return _context.Articolis.Any(e => e.Id_articolo == id);
        }
    }
}

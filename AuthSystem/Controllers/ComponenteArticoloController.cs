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
    public class ComponenteArticoloController : Controller
    {
        private readonly NContext _context;

        public ComponenteArticoloController(NContext context)
        {
            _context = context;
        }

        // GET: ComponenteArticolo
        public async Task<IActionResult> Index()
        {
            var nContext = _context.ComponentiArticolo.Include(c => c.Articoli);
            return View(await nContext.ToListAsync());
        }

        // GET: ComponenteArticolo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenteArticolo = await _context.ComponentiArticolo
                .Include(c => c.Articoli)
                .FirstOrDefaultAsync(m => m.IdComponente == id);
            if (componenteArticolo == null)
            {
                return NotFound();
            }

            return View(componenteArticolo);
        }

        // GET: ComponenteArticolo/Create
        public IActionResult Create()
        {
            ViewData["IdArticolo"] = new SelectList(_context.Articoli, "IdArticolo", "NomeArticolo");
            return View();
        }

        // POST: ComponenteArticolo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComponente,NomeComponente,TempoProduzione,IdArticolo")] ComponenteArticolo componenteArticolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componenteArticolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArticolo"] = new SelectList(_context.Articoli, "IdArticolo", "NomeArticolo", componenteArticolo.IdArticolo);
            return View(componenteArticolo);
        }

        // GET: ComponenteArticolo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenteArticolo = await _context.ComponentiArticolo.FindAsync(id);
            if (componenteArticolo == null)
            {
                return NotFound();
            }
            ViewData["IdArticolo"] = new SelectList(_context.Articoli, "IdArticolo", "NomeArticolo", componenteArticolo.IdArticolo);
            return View(componenteArticolo);
        }

        // POST: ComponenteArticolo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdComponente,NomeComponente,TempoProduzione,IdArticolo")] ComponenteArticolo componenteArticolo)
        {
            if (id != componenteArticolo.IdComponente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componenteArticolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponenteArticoloExists(componenteArticolo.IdComponente))
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
            ViewData["IdArticolo"] = new SelectList(_context.Articoli, "IdArticolo", "NomeArticolo", componenteArticolo.IdArticolo);
            return View(componenteArticolo);
        }

        // GET: ComponenteArticolo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componenteArticolo = await _context.ComponentiArticolo
                .Include(c => c.Articoli)
                .FirstOrDefaultAsync(m => m.IdComponente == id);
            if (componenteArticolo == null)
            {
                return NotFound();
            }

            return View(componenteArticolo);
        }

        // POST: ComponenteArticolo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componenteArticolo = await _context.ComponentiArticolo.FindAsync(id);
            _context.ComponentiArticolo.Remove(componenteArticolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponenteArticoloExists(int id)
        {
            return _context.ComponentiArticolo.Any(e => e.IdComponente == id);
        }
    }
}

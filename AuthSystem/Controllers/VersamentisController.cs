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
    public class VersamentisController : Controller
    {
        private readonly NContext _context;

        public VersamentisController(NContext context)
        {
            _context = context;
        }

        // GET: Versamentis
        public async Task<IActionResult> Index()
        {
            var nContext = _context.Versamentis.Include(v => v.Articoli);
            return View(await nContext.ToListAsync());
        }

        // GET: Versamentis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versamenti = await _context.Versamentis
                .Include(v => v.Articoli)
                .FirstOrDefaultAsync(m => m.Id_versamento == id);
            if (versamenti == null)
            {
                return NotFound();
            }

            return View(versamenti);
        }

        // GET: Versamentis/Create
        public IActionResult Create()
        {
            ViewData["Id_articolo"] = new SelectList(_context.Articolis, "Id_articolo", "Nome_Articolo");
            return View();
        }

        // POST: Versamentis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_versamento,Numero_pezzi,Data,Tempo_prod,Id_articolo")] Versamenti versamenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versamenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_articolo"] = new SelectList(_context.Articolis, "Id_articolo", "Nome_Articolo", versamenti.Id_articolo);
            return View(versamenti);
        }

        // GET: Versamentis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versamenti = await _context.Versamentis.FindAsync(id);
            if (versamenti == null)
            {
                return NotFound();
            }
            ViewData["Id_articolo"] = new SelectList(_context.Articolis, "Id_articolo", "Nome_Articolo", versamenti.Id_articolo);
            return View(versamenti);
        }

        // POST: Versamentis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_versamento,Numero_pezzi,Data,Tempo_prod,Id_articolo")] Versamenti versamenti)
        {
            if (id != versamenti.Id_versamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versamenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersamentiExists(versamenti.Id_versamento))
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
            ViewData["Id_articolo"] = new SelectList(_context.Articolis, "Id_articolo", "Nome_Articolo", versamenti.Id_articolo);
            return View(versamenti);
        }

        // GET: Versamentis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versamenti = await _context.Versamentis
                .Include(v => v.Articoli)
                .FirstOrDefaultAsync(m => m.Id_versamento == id);
            if (versamenti == null)
            {
                return NotFound();
            }

            return View(versamenti);
        }

        // POST: Versamentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var versamenti = await _context.Versamentis.FindAsync(id);
            _context.Versamentis.Remove(versamenti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersamentiExists(int id)
        {
            return _context.Versamentis.Any(e => e.Id_versamento == id);
        }
    }
}

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
    public class VersamentoController : Controller
    {
        private readonly NContext _context;

        public VersamentoController(NContext context)
        {
            _context = context;
        }

        // GET: Versamento
        public async Task<IActionResult> Index()
        {
            var nContext = _context.Versamenti.Include(v => v.AspNetUsers).Include(v => v.ComponentiArticolo).Include(v => v.Stazioni);
            return View(await nContext.ToListAsync());
        }

        // GET: Versamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versamento = await _context.Versamenti
                .Include(v => v.AspNetUsers)
                .Include(v => v.ComponentiArticolo)
                .Include(v => v.Stazioni)
                .FirstOrDefaultAsync(m => m.IdVersamento == id);
            if (versamento == null)
            {
                return NotFound();
            }

            return View(versamento);
        }

        // GET: Versamento/Create
        public IActionResult Create()
        {
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Email");
            ViewData["IdComponente"] = new SelectList(_context.ComponentiArticolo, "IdComponente", "NomeComponente");
            ViewData["IdNomeStazione"] = new SelectList(_context.Stazioni, "IdNomeStazione", "NomeStazione");
            return View();
        }

        // POST: Versamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVersamento,PezziBuoni,PezziDifettosi,Data,TempoProd,IdComponente,IdNomeStazione,IdAspNetUsers")] Versamento versamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(versamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Email", versamento.IdAspNetUsers);
            ViewData["IdComponente"] = new SelectList(_context.ComponentiArticolo, "IdComponente", "NomeComponente", versamento.IdComponente);
            ViewData["IdNomeStazione"] = new SelectList(_context.Stazioni, "IdNomeStazione", "NomeStazione", versamento.IdNomeStazione);
            return View(versamento);
        }

        // GET: Versamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versamento = await _context.Versamenti.FindAsync(id);
            if (versamento == null)
            {
                return NotFound();
            }
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Email", versamento.IdAspNetUsers);
            ViewData["IdComponente"] = new SelectList(_context.ComponentiArticolo, "IdComponente", "NomeComponente", versamento.IdComponente);
            ViewData["IdNomeStazione"] = new SelectList(_context.Stazioni, "IdNomeStazione", "NomeStazione", versamento.IdNomeStazione);
            return View(versamento);
        }

        // POST: Versamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVersamento,PezziBuoni,PezziDifettosi,Data,TempoProd,IdComponente,IdNomeStazione,IdAspNetUsers")] Versamento versamento)
        {
            if (id != versamento.IdVersamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(versamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VersamentoExists(versamento.IdVersamento))
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
            ViewData["IdAspNetUsers"] = new SelectList(_context.AspNetUsers, "Id", "Email", versamento.IdAspNetUsers);
            ViewData["IdComponente"] = new SelectList(_context.ComponentiArticolo, "IdComponente", "NomeComponente", versamento.IdComponente);
            ViewData["IdNomeStazione"] = new SelectList(_context.Stazioni, "IdNomeStazione", "NomeStazione", versamento.IdNomeStazione);
            return View(versamento);
        }

        // GET: Versamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var versamento = await _context.Versamenti
                .Include(v => v.AspNetUsers)
                .Include(v => v.ComponentiArticolo)
                .Include(v => v.Stazioni)
                .FirstOrDefaultAsync(m => m.IdVersamento == id);
            if (versamento == null)
            {
                return NotFound();
            }

            return View(versamento);
        }

        // POST: Versamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var versamento = await _context.Versamenti.FindAsync(id);
            _context.Versamenti.Remove(versamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VersamentoExists(int id)
        {
            return _context.Versamenti.Any(e => e.IdVersamento == id);
        }
    }
}

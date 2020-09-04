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
    public class UtentisController : Controller
    {
        private readonly NContext _context;

        public UtentisController(NContext context)
        {
            _context = context;
        }

        // GET: Utentis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utenti.ToListAsync());
        }

        // GET: Utentis/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utenti = await _context.Utenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utenti == null)
            {
                return NotFound();
            }

            return View(utenti);
        }

        // GET: Utentis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utentis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email")] Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utenti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utenti);
        }

        // GET: Utentis/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utenti = await _context.Utenti.FindAsync(id);
            if (utenti == null)
            {
                return NotFound();
            }
            return View(utenti);
        }

        // POST: Utentis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Email")] Utenti utenti)
        {
            if (id != utenti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utenti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtentiExists(utenti.Id))
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
            return View(utenti);
        }

        // GET: Utentis/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utenti = await _context.Utenti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utenti == null)
            {
                return NotFound();
            }

            return View(utenti);
        }

        // POST: Utentis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var utenti = await _context.Utenti.FindAsync(id);
            _context.Utenti.Remove(utenti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtentiExists(string id)
        {
            return _context.Utenti.Any(e => e.Id == id);
        }
    }
}

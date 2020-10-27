using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthSystem.Models;

namespace AuthSystem.Controllers
{
    public class LineaController : Controller
    {
        private readonly NContext _context;

        public LineaController(NContext context)
        {
            _context = context;
        }

        // GET: Linea
        public async Task<IActionResult> Index()
        {
            return View(await _context.Linee.ToListAsync());
        }

        // GET: Linea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await _context.Linee
                .FirstOrDefaultAsync(m => m.IdLinea == id);
            if (linea == null)
            {
                return NotFound();
            }

            return View(linea);
        }

        // GET: Linea/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Linea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLinea,NomeLinea")] Linea linea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(linea);
        }

        // GET: Linea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await _context.Linee.FindAsync(id);
            if (linea == null)
            {
                return NotFound();
            }
            return View(linea);
        }

        // POST: Linea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLinea,NomeLinea")] Linea linea)
        {
            if (id != linea.IdLinea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineaExists(linea.IdLinea))
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
            return View(linea);
        }

        // GET: Linea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linea = await _context.Linee
                .FirstOrDefaultAsync(m => m.IdLinea == id);
            if (linea == null)
            {
                return NotFound();
            }

            return View(linea);
        }

        // POST: Linea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linea = await _context.Linee.FindAsync(id);
            _context.Linee.Remove(linea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineaExists(int id)
        {
            return _context.Linee.Any(e => e.IdLinea == id);
        }
    }
}

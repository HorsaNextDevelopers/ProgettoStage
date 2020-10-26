using System;
using System.Linq;
using AuthSystem.Models;
using AuthSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuthSystem.Controllers
{
    [Authorize]
    public class GraficiComponentiController : Controller
    {

        private readonly NContext _context;

        public GraficiComponentiController(NContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var articoli = _context.Articoli.ToList();

            var viewModel = new GraficoComponentiViewModel();

            viewModel.Articoli = new SelectList(articoli, "IdArticolo", "NomeArticolo");

            return View(viewModel);
        }

        public IActionResult GetComponenti(int idArticolo)
        {
            var componenti = _context.ComponentiArticolo.Where(c => c.IdArticolo == idArticolo).ToList();

            return this.Ok(componenti);
        }

        public IActionResult GetDatiGrafico(int idComponente)
        {
            var viewModel = new ChartComponentiModel();

            var versamenti = _context.Versamenti.Where(c => c.IdComponente == idComponente).ToList();

            var componente = _context.ComponentiArticolo.Single(c => c.IdComponente == idComponente);

            viewModel.Labels = versamenti.Select(s => s.Data.ToShortDateString()).ToArray();

            viewModel.Dataset = versamenti.Select(s => s.PezziBuoni == 0 ? 0 : Convert.ToInt32(s.TempoProd / (s.PezziBuoni + s.PezziDifettosi))).ToArray();

            viewModel.TempoIdeale = Convert.ToInt32(componente.TempoProduzione);

            return this.Ok(viewModel);
        }
    }
}

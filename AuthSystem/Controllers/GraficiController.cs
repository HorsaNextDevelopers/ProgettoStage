using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Models;
using AuthSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    public class GraficiController : Controller
    {

        private readonly NContext _context;

        public GraficiController(NContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var viewModel = new GraficoViewModel();

            var versamenti = _context.Versamenti.ToList();

            var stazioni = _context.Stazioni.ToList();

            var labels = stazioni.Select(s => s.NomeStazione).ToArray();

            var dataset1 = new StackedBarDatasetViewModel();

            dataset1.Label = "pezzi buoni";

            dataset1.BackgroundColor = "green";

            List<int> pezziBuoni = new List<int>();

            foreach (var stazione in stazioni)
            {
                pezziBuoni.Add(Convert.ToInt32((versamenti.Where(v => v.Stazioni == stazione).Sum(v => v.PezziBuoni))));
                
            }

            dataset1.Data = pezziBuoni.ToArray();

            var dataset2 = new StackedBarDatasetViewModel();

            dataset2.Label = "pezzi difettosi";

            dataset2.BackgroundColor = "red";

            List<int> pezziDifettosi = new List<int>();

            foreach (var stazione in stazioni)
            {
                pezziDifettosi.Add(Convert.ToInt32((versamenti.Where(v => v.Stazioni == stazione).Sum(v => v.PezziDifettosi))));

            }

            dataset2.Data = pezziDifettosi.ToArray();

            viewModel.Labels = labels;

            viewModel.DataSet = new StackedBarDatasetViewModel[] { dataset1, dataset2 };

            return View(viewModel);
        }
    }
}

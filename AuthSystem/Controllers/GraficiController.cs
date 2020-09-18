using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    public class GraficiController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new GraficoViewModel();

            viewModel.Labels = new string[] { "Articolo1 ok", "Articolo2 ko" };

            viewModel.DataSet = new int[] { 10, 20 };

            return View(viewModel);
        }
    }
}

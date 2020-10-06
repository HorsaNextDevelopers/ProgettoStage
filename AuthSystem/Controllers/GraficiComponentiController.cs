using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthSystem.Controllers
{
    [Authorize]
    public class GraficiComponentiController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}

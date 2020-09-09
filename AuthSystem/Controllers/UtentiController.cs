using AuthSystem.Areas.Identity.Data;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Controllers
{
    public class UtentiController : Controller
    {
        private readonly NContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UtentiController(NContext context, UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var utenti = _context.AspNetUsers.ToList();
           //var utenti2 = _userManager.Users.ToList();
            return View(utenti);
        }

      /*  public async IActionResult Create()
        {
             ApplicationUser user = new ApplicationUser { UserName = utente.Email, Email = utente.Email, FirstName = utente.FirstName, LastName = utente.LastName };
             var result = await _userManager.Users.First().FirstName.CreateAsync(user, "pwd");
            return View();


           // var u = _userManager.Users.First();
          //  u.FirstName = "aaa";
          //  _userManager.UpdateAsync(u);
           // _userManager.ResetAuthenticatorKeyAsync(u);
          //  return null;
        }*/
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser utente)
        {
            ApplicationUser user = new ApplicationUser { UserName = utente.Email, Email = utente.Email, FirstName = utente.FirstName, LastName = utente.LastName };
            if (ModelState.IsValid)
            {
                _context.Add(utente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utente);
        }
    }
}


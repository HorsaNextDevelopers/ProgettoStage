using AuthSystem.Areas.Identity.Data;
using AuthSystem.Areas.Identity.Pages.Account;
using AuthSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Controllers
{
    public class RegisterController : Controller
    {
        private readonly NContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterController(NContext context, UserManager<ApplicationUser> _userManager,
         SignInManager<ApplicationUser> _signInManager, ILogger<RegisterModel> _logger, IEmailSender _emailSender)
        {
            _context = context;
        }



    }
}

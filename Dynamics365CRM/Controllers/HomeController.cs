using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dynamics365CRM.Models;
using Dynamics365CRM.Data;

namespace Dynamics365CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MvcDynamicsContext _context;

        public HomeController(ILogger<HomeController> logger, MvcDynamicsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string name)
        {
            return View();
        }

        public IActionResult Regestrierung(string username, string password)
        {
            return View();
        }

        public IActionResult Anmeldung(string username, string password)
        {
            if (_context.Login.Any(x => x.Benutzername != username))
            {
                _context.Login.Add(

                    new Login
                    {
                        Benutzername = username,
                        Passwort = password
                    }
                ); 
                _context.SaveChanges();
                return View("Angemeldet");
            }
            return View("Index");
        }
        public IActionResult Angemeldet(string username, string password)
        {
          bool  isUser = _context.Login.Any(x => x.Benutzername == username&& x.Passwort == password) ;
           
            if (isUser)
            {
                Console.WriteLine("isuser");
               return View();
            }
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

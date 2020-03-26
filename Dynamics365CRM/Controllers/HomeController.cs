using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dynamics365CRM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            //var blogs = from b in _context.Kontakts
            //            where b.Nachname.StartsWith("name")
            //            select b;
            // var items = _context.Kontakts.Where(x => x.Nachname == name);


            
            // _context.Kontakts.Find
            //   ViewData["Id"] =  name;
            //  ViewData["NumTimes"] = numTimes;

            return View();
        }

        public IActionResult Regestrierung(string username, string password)
        {
            //var blogs = from b in _context.Kontakts
            //            where b.Nachname.StartsWith("name")
            //            select b;
            // Console.WriteLine(username);
            //  Console.WriteLine(password);

            
            // _context.Kontakts.Find
            //   ViewData["Id"] =  name;
            //  ViewData["NumTimes"] = numTimes;

            return View();
        }

        public IActionResult Anmeldung(string username, string password)
        {
            //var blogs = from b in _context.Kontakts
            //            where b.Nachname.StartsWith("name")
            //            select b;
            // Console.WriteLine(username);
            //  Console.WriteLine(password);

            
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
            // _context.Kontakts.Find
            //   ViewData["Id"] =  name;
            //  ViewData["NumTimes"] = numTimes;

            return View("Index");

        
            //bool isUser = _context.Login.Any(x => x.Benutzername == username && x.Passwort == password);

            //if (isUser)
            //{
            //    Console.WriteLine("isuser");
            //    return View();
            //}

            //// _context.Kontakts.Find
            ////   ViewData["Id"] =  name;
            ////  ViewData["NumTimes"] = numTimes;
            //return View("Anmeldung");
        }
        public IActionResult Angemeldet(string username, string password)
        {
            //var blogs = from b in _context.Kontakts
            //            where b.Nachname.StartsWith("name")
            //            select b;
            // Console.WriteLine(username);
            //  Console.WriteLine(password);

          bool  isUser = _context.Login.Any(x => x.Benutzername == username&& x.Passwort == password) ;
           
            if (isUser)
            {
                Console.WriteLine("isuser");
               return View();
            }

            // _context.Kontakts.Find
            //   ViewData["Id"] =  name;
            //  ViewData["NumTimes"] = numTimes;
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

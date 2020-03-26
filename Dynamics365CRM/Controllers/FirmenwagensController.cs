using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dynamics365CRM.Data;
using Dynamics365CRM.Models;

namespace Dynamics365CRM
{
    public class FirmenwagensController : Controller
    {
        private readonly MvcDynamicsContext _context;

        public FirmenwagensController(MvcDynamicsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Kontaktdaten(string Fahrzeugname, string Fahrzeughalter)
        {
          var items = _context.Firmenwagens.Where(x => x.Fahrzeugname == Fahrzeugname && x.Fahrzeughalter == Fahrzeughalter);

            return View(await items.ToListAsync());
        }
        public async Task<IActionResult> NamensListe()
        {
            return View(await _context.Firmenwagens.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fahrzeughalter,Zulassungsende,Kennzeichen,Fahrzeugmarke,Fahrzeugname")] Firmenwagen firmenwagen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firmenwagen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NamensListe));
            }
            return View(firmenwagen);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firmenwagen = await _context.Firmenwagens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (firmenwagen == null)
            {
                return NotFound();
            }

            return View(firmenwagen);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firmenwagen = await _context.Firmenwagens.FindAsync(id);
            _context.Firmenwagens.Remove(firmenwagen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }

        private bool FirmenwagenExists(int id)
        {
            return _context.Firmenwagens.Any(e => e.Id == id);
        }
    }
}

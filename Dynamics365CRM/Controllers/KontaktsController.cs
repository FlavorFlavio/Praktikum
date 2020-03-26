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
    public class KontaktsController : Controller
    {
        private readonly MvcDynamicsContext _context;


        public KontaktsController(MvcDynamicsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> NamensListe(string vorname, string nachname)
        {


            return View(await _context.Kontakts.ToListAsync());
        }
        public async Task<IActionResult> Kontaktdaten(string name,string vorname, string nachname)
        {
            IQueryable<Kontakt> items;
            if (name==null)
            {
                items = _context.Kontakts.Where(x => x.Nachname == nachname && x.Vorname == vorname);

            }
            else
            {
                items = _context.Kontakts.Where(x => x.Vorname + " "+x.Nachname == name);

            }
            return View(await items.ToListAsync());

            return View(await _context.Kontakts.ToListAsync());
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kontakts.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,Geburtsdatum,Telefonnummer")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kontakt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NamensListe));
            }
            return View(kontakt);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kontakt = await _context.Kontakts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kontakt == null)
            {
                return NotFound();
            }

            return View(kontakt);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kontakt = await _context.Kontakts.FindAsync(id);
            _context.Kontakts.Remove(kontakt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }

        private bool KontaktExists(int id)
        {
            return _context.Kontakts.Any(e => e.Id == id);
        }
    }
}

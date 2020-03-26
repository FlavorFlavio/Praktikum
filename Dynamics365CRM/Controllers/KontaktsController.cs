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

     //   public IQueryable<Kontakt> items { get; private set; }

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
           // var items;
            if (name==null)
            {
                items = _context.Kontakts.Where(x => x.Nachname == nachname && x.Vorname == vorname);

            }
            else
            {
                //string _name =;
                items = _context.Kontakts.Where(x => x.Vorname + " "+x.Nachname == name);

            }
            //var blogs = from b in _context.Kontakts
            //            where b.Nachname.StartsWith("name")
            //            select b;
            // _context.Kontakts.Find
            //   ViewData["Id"] =  name;
            //  ViewData["NumTimes"] = numTimes;

            return View(await items.ToListAsync());

            return View(await _context.Kontakts.ToListAsync());
        }
        // GET: Kontakts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kontakts.ToListAsync());
        }

        // GET: Kontakts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var kontakt = await _context.Kontakts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (kontakt == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(kontakt);
        //}

        // GET: Kontakts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kontakts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Kontakts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var kontakt = await _context.Kontakts.FindAsync(id);
        //    if (kontakt == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(kontakt);
        //}
     
        //// POST: Kontakts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Vorname,Nachname,Geburtsdatum,Telefonnummer")] Kontakt kontakt)
        //{
        //    if (id != kontakt.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(kontakt);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!KontaktExists(kontakt.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(NamensListe));
        //    }
        //    return View(kontakt);
        //}

        // GET: Kontakts/Delete/5
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

        // POST: Kontakts/Delete/5
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

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dynamics365CRM.Data;
using Dynamics365CRM.Models;

namespace Dynamics365CRM
{
    public class VerkaufschancesController : Controller
    {
        private readonly MvcDynamicsContext _context;

        public VerkaufschancesController(MvcDynamicsContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> NamensListe(string vorname, string nachname, string Firmenname)
        {
            if (Firmenname != null)
            {
                var items = _context.Verkaufschance.Where(x => x.Kunde == Firmenname);

                return View(await items.ToListAsync());

            }

            return View(await _context.Verkaufschance.ToListAsync());
        }
        public async Task<IActionResult> Kontaktdaten(string Betreff, string vorname, string nachname, string Firmenname)
        {

            IQueryable<Verkaufschance> items;
            if (Firmenname!=null)
            {
                items = _context.Verkaufschance.Where(x => x.Kunde == Firmenname);
                return View(await items.ToListAsync());
            }

            items = _context.Verkaufschance.Where(x => x.Betreff == Betreff);
            return View(await items.ToListAsync());

        }
      
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kontakt,AuftragsvolumenNetto,Umsatzsteuer,Typ,Betreff,Beschreibung,Deadline,isFree,Notiz,Kunde")] Verkaufschance verkaufschance)
        {

            if (ModelState.IsValid)
            {
                IQueryable<Firma> firma = _context.Firmen.Where(x => x.Name == verkaufschance.Kunde);
               

                foreach (Firma row in firma)
                {
                    row.Verkaufschancen += 1;
                }

               // _context.SubmitChanges();
                int netto  = verkaufschance.AuftragsvolumenNetto;
                verkaufschance.AuftragsvolumenBrutto = (int)(verkaufschance.AuftragsvolumenNetto - (float)verkaufschance.AuftragsvolumenNetto * ((float)verkaufschance.Umsatzsteuer*0.01f));
                _context.Add(verkaufschance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NamensListe));
            }
            return View(verkaufschance);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verkaufschance = await _context.Verkaufschance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (verkaufschance == null)
            {
                return NotFound();
            }

            return View(verkaufschance);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var verkaufschance = await _context.Verkaufschance.FindAsync(id);
            IQueryable<Firma> firma = _context.Firmen.Where(x => x.Name == verkaufschance.Kunde);


            foreach (Firma row in firma)
            {
                row.Angebote -= 1;
            }
            _context.Verkaufschance.Remove(verkaufschance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }

        private bool VerkaufschanceExists(int id)
        {
            return _context.Verkaufschance.Any(e => e.Id == id);
        }
    }
}

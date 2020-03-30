using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dynamics365CRM.Data;
using Dynamics365CRM.Models;

namespace Dynamics365CRM
{
    public class AngebotsController : Controller
    {
        private readonly MvcDynamicsContext _context;

        public AngebotsController(MvcDynamicsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Kontaktdaten(string Fahrzeugname, string Fahrzeughalter)
        {
            var items = _context.Angebot.Where(x => x.Verkaufschance == Fahrzeugname && x.Verkaufschance == Fahrzeughalter);

            return View(await items.ToListAsync());
        }
        public async Task<IActionResult> NamensListe(string Id, string Firmenname, string Verkaufschance)
        {
            if (Firmenname!=null)
            {
                var items = _context.Angebot.Where(x => x.Kunde == Firmenname);

                return View(await items.ToListAsync());

            }
            if (Verkaufschance != null)
            {
                var items = _context.Angebot.Where(x => x.Verkaufschance == Verkaufschance);

                return View(await items.ToListAsync());

            }
            return View(await _context.Angebot.ToListAsync());
        }
   
 
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Verkaufschance = await _context.Verkaufschance.FindAsync(id);
                Angebot angebot = new Angebot();
            IQueryable<Firma> firma = _context.Firmen.Where(x => x.Name == Verkaufschance.Kunde);

            foreach (Firma row in firma)
            {
                row.Angebote += 1;
            }
            Verkaufschance.AngeboteCount += 1;
            angebot.isFree = 1;
            angebot.Kunde = Verkaufschance.Kunde;
            angebot.Verkaufschance = Verkaufschance.Betreff;
            angebot.Ansprechpartner = Verkaufschance.Kontakt;


            _context.Angebot.Add(angebot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }

        // GET: Angebots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angebot = await _context.Angebot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (angebot == null)
            {
                return NotFound();
            }

            return View(angebot);
        }

        // POST: Angebots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var angebot = await _context.Angebot.FindAsync(id);
            IQueryable<Firma> firma = _context.Firmen.Where(x => x.Name == angebot.Kunde);


            foreach (Firma row in firma)
            {
                row.Angebote -= 1;
            }
            IQueryable<Verkaufschance> Verkaufschance = _context.Verkaufschance.Where(x => x.Betreff == angebot.Verkaufschance);


            foreach (Verkaufschance row in Verkaufschance)
            {
                row.AngeboteCount -= 1;
            }
            _context.Angebot.Remove(angebot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }

        private bool AngebotExists(int id)
        {
            return _context.Angebot.Any(e => e.Id == id);
        }
    }
}

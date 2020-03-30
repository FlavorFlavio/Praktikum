using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dynamics365CRM.Data;
using Dynamics365CRM.Models;

namespace Dynamics365CRM
{
    public class AuftragsController : Controller
    {
        private readonly MvcDynamicsContext _context;

        public AuftragsController(MvcDynamicsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Angebot = await _context.Angebot.FindAsync(id);
            IQueryable<Firma> firma = _context.Firmen.Where(x => x.Name == Angebot.Kunde);
            IQueryable<Verkaufschance> Verkaufschance = _context.Verkaufschance.Where(x => x.Betreff == Angebot.Verkaufschance);

            foreach (Firma row in firma)
            {
                row.Auftrag += 1;
            }
            foreach (Verkaufschance row in Verkaufschance)
            {
                row.AuftragCount += 1;
            }


            Auftrag auftrag = new Auftrag();
            auftrag.isFree = 1;
            auftrag.Kunde = Angebot.Kunde;
            auftrag.Verkaufschance = Angebot.Verkaufschance;
            auftrag.Ansprechpartner = Angebot.Ansprechpartner;


            _context.Auftrag.Add(auftrag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }
        public async Task<IActionResult> Kontaktdaten(string Fahrzeugname, string Fahrzeughalter)
        {
            var items = _context.Auftrag.Where(x => x.Verkaufschance == Fahrzeugname && x.Verkaufschance == Fahrzeughalter);

            return View(await items.ToListAsync());
        }
        public async Task<IActionResult> NamensListe(string Id, string Firmenname, string Verkaufschance)
        {
            if (Firmenname != null)
            {
                var items = _context.Auftrag.Where(x => x.Kunde == Firmenname);

                return View(await items.ToListAsync());

            }

            if (Verkaufschance != null)
            {
                var items = _context.Auftrag.Where(x => x.Verkaufschance == Verkaufschance);

                return View(await items.ToListAsync());

            }
        
            return View(await _context.Auftrag.ToListAsync());
        }
       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auftrag = await _context.Auftrag
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auftrag == null)
            {
                return NotFound();
            }

            return View(auftrag);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auftrag = await _context.Auftrag.FindAsync(id);
            IQueryable<Firma> firma = _context.Firmen.Where(x => x.Name == auftrag.Kunde);


            foreach (Firma row in firma)
            {
                row.Auftrag -= 1;
            }
            IQueryable<Verkaufschance> Verkaufschance = _context.Verkaufschance.Where(x => x.Betreff == auftrag.Verkaufschance);


            foreach (Verkaufschance row in Verkaufschance)
            {
                row.AuftragCount -= 1;
            }
            _context.Auftrag.Remove(auftrag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }

        private bool AuftragExists(int id)
        {
            return _context.Auftrag.Any(e => e.Id == id);
        }
    }
}

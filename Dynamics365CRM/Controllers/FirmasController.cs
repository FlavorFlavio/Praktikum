using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dynamics365CRM.Data;
using Dynamics365CRM.Models;

namespace Dynamics365CRM
{
    public class FirmasController : Controller
    {
        private readonly MvcDynamicsContext _context;

        public FirmasController(MvcDynamicsContext context)
        {
            _context = context;
        }

    
        public async Task<IActionResult> Kontaktdaten(string Firmenname, string Firmennummer)
        {
            var items = _context.Firmen.Where(x => x.Name == Firmenname);
            
            return View(await items.ToListAsync());
        }
        public async Task<IActionResult> NamensListe()
        {
            return View(await _context.Firmen.ToListAsync());
        }
        // GET: Firmas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Adresse,Telefonnummer")] Firma firma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NamensListe));
            }
            return View(firma);
        }

       

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var firma = await _context.Firmen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (firma == null)
            {
                return NotFound();
            }

            return View(firma);
        }

        // POST: Firmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var firma = await _context.Firmen.FindAsync(id);
            _context.Firmen.Remove(firma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NamensListe));
        }

        private bool FirmaExists(int id)
        {
            return _context.Firmen.Any(e => e.Id == id);
        }
    }
}

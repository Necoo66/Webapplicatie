using System.Linq;
using System.Threading.Tasks;
using HoneymoonShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Models.GebruikerModels;

namespace HoneymoonShop.Controllers
{
    public class GebruikerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GebruikerController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Gebruikers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gebruiker.ToListAsync());
        }

        // GET: Gebruikers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruiker.SingleOrDefaultAsync(m => m.Id == id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        // GET: Gebruikers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gebruikers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emailadres,Naam,Telefoonnummer,Trouwdatum")] Gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(gebruiker);
        }

        // GET: Gebruikers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruiker.SingleOrDefaultAsync(m => m.Id == id);
            if (gebruiker == null)
            {
                return NotFound();
            }
            return View(gebruiker);
        }

        // POST: Gebruikers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emailadres,Naam,Telefoonnummer,Trouwdatum")] Gebruiker gebruiker)
        {
            if (id != gebruiker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebruiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebruikerExists(gebruiker.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(gebruiker);
        }

        // GET: Gebruikers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebruiker = await _context.Gebruiker.SingleOrDefaultAsync(m => m.Id == id);
            if (gebruiker == null)
            {
                return NotFound();
            }

            return View(gebruiker);
        }

        // POST: Gebruikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gebruiker = await _context.Gebruiker.SingleOrDefaultAsync(m => m.Id == id);
            _context.Gebruiker.Remove(gebruiker);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool GebruikerExists(int id)
        {
            return _context.Gebruiker.Any(e => e.Id == id);
        }
    }
}
